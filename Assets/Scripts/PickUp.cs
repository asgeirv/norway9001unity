using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public float radius;
    public float speed;
    public Vector2 playerxz;
    public Transform player;
    public GameObject pickUps;
   

    private Rigidbody2D rb;

void Start () {
       
        rb = GetComponent<Rigidbody2D>();
      
       // player = GameObject.Find("Player");
        pickUps = GameObject.Find("Pickups");

	}
	
	void Fixedupdate () {
        /* Transform playerPosition = player.GetComponent<Transform>();
         playerxz =new Vector2(playerPosition.localPosition.x,playerPosition.localPosition.z);
         pickUps = GetComponentsInChildren<Transform>();
         foreach(Component pickUp in pickUps) {
             Transform trans = (Transform)pickUp;
             Vector2 temp = new Vector2(trans.localPosition.x, trans.localPosition.z);
             float magnitude = Vector2.Distance(playerxz, temp);
             */

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < radius)
        {
            Vector2 direction = player.transform.position - transform.position;
            //  transform.position = Vector3.MoveTowards(transform.position, player.position, step);
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        }
            

    }
	}

