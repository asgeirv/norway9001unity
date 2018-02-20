using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public Transform shotSpawn;
    private Rigidbody rb;
    public float fireRate;
    private float nextFire;
    public GameObject shot;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update () {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
            
    }
}
