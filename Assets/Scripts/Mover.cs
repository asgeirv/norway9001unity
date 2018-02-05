using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    private Rigidbody rb;

    public float speed;

    public int debug = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        if (debug == 1)
        {
            Debug.Log("Velosity: " + transform.forward * speed);
        }

    }

    
}
