using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    public float speed;
    public float tilt;
    public float minSpeed;
    public Boundary boundary;

    public GameObject shot;
    public GameObject shot2;

    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public float fireRate;
    public float fireRate2;

    private float nextFire;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
            Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
        }
        if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate2;
            Instantiate(shot2, shotSpawn3.position, shotSpawn3.rotation);
           
        }
    }

    private void FixedUpdate()
    {
    
        float moveHorizontal = Input.GetAxis("Horizontal");
        if(moveHorizontal < 0)
        {
            Mathf.Lerp(moveHorizontal, -minSpeed, -speed);
        } else if (moveHorizontal > 0)
        {
            Mathf.Lerp(moveHorizontal, minSpeed, speed);
        }

        float moveVertical = Input.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        rb.position = new Vector3
        (
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
        );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
