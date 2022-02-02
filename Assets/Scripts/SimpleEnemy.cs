using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] Transform PlayerPosition;
    [SerializeField] Transform EnemyPosition;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.position = Vector3.MoveTowards(transform.position, PlayerPosition.position, speed);
    }
}
