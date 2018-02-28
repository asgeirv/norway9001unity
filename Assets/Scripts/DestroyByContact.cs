using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Depricated
 **/
public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
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
        if (other.tag == "Boundary" || other.tag == "BackgroundObject")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver("WHY YOU DO THIS!");
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.AddScore(scoreValue);
    }
}
