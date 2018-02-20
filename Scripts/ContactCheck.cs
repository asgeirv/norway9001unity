using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactCheck : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject Ammo;

    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("cannot find 'GameController' Script");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((tag == "Enemy" || tag == "Bolt" || tag == "PickUps") && other.tag == "PickUps")
        {
            //Physics.IgnoreCollision(Ammo.GetComponent<Collider>(), GetComponent<Collider>());
            return;
        }
      
        if (other.tag == "Boundary" || other.tag == "BackgroundObject")
        {
            return;
        }

        if (other.tag == "PickUps" && other.tag == "Player")
        {
            Destroy(gameObject);
            return;
        }


        if (other.tag == "Bolt" && tag == "Enemy")
        {

            if (Random.value < 0.8)
            {
                Instantiate(Ammo, other.transform.position, other.transform.rotation);
            }
        }



        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();

        }
        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.AddScore(scoreValue);
    }
}
