using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] AudioSource audioSource;
    
    Grid playerGrid;
    Rigidbody rb;
   
    bool upDirection = false;
    bool downDirection = false;
    bool leftDirection = false;
    bool rightDirection = false;

    bool canMove = true;

    private void Start()
    {
        playerGrid = GameObject.FindObjectOfType<Grid>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            MovePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            audioSource.Play();
            Destroy(other.gameObject); // Dots are eaten
            playerGrid.dotCount--;
            Debug.Log(playerGrid.dotCount);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 10)
        {
            canMove = false;
            Debug.Log("Lose");
            rb.isKinematic = true;
            SceneManager.LoadSceneAsync(2); // Lose Scene
        }
    }
    private void MovePlayer()
    {
        if (upDirection)
        {
            rb.velocity = new Vector3(0, 0, playerGrid.NodeArray[15, 29].vPosition.z) * speed;
        }

        if (downDirection)
        {
            rb.velocity = new Vector3(0, 0, playerGrid.NodeArray[15, 0].vPosition.z) * speed;
        }

        if (leftDirection)
        {
            rb.velocity = new Vector3(playerGrid.NodeArray[0, 15].vPosition.x, 0, 0) * speed;
        }

        if (rightDirection)
        {
            rb.velocity = new Vector3(playerGrid.NodeArray[29, 15].vPosition.x, 0, 0) * speed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            downDirection = true;
            upDirection = false;
            leftDirection = false;
            rightDirection = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            upDirection = true;
            downDirection = false;
            leftDirection = false;
            rightDirection = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            leftDirection = true;
            upDirection = false;
            downDirection = false;
            rightDirection = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            rightDirection = true;
            upDirection = false;
            downDirection = false;
            leftDirection = false;
        }
    }
}

