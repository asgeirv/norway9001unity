using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;
    public GameObject shot;



    void Update () {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
            
    }
}
