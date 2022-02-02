using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 1;
    
    Grid enemyGrid;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyGrid = GameObject.FindObjectOfType<Grid>();
    }

    private void Update()
    {
        if (enemyGrid.FinalPath != null)
        {
            rb.position = Vector3.Lerp(transform.position, enemyGrid.FinalPath[0].vPosition, speed);
        }
    }
}
