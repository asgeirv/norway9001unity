using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactCheck : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    private HealthCheck h;



    public int scoreValue;
    private GameController gameController;
    private GameObject playerInventory;
    private GameObject healthCheck;


    bool boolean;

    private void Start()
    {
        h = gameObject.GetComponent<HealthCheck>();
        healthCheck = this.gameObject;
        boolean = false;
        /**
         * Finne gamecontrolleren som blir brukt i unity
         **/
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

    private void Update()
    {
        /**
         * Kaller GameOver() og initialiserer en eksplosjon når player health er 0
         * */
        if (tag == "Player" && h.GetHealth() <= 0)
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver("Asgeir is a noob!");
        }
     }

    /**
     * Sjekker om ting kolliderer og utfører dei riktige handlingane basert på hva som kolliderer
     * */

    private void OnTriggerEnter(Collider other)
    {

        /**
         * Når Enemy blir skutt blir det initialisert en eksplosjon,
         * Enemy tar skade og skuddet blir ødelagt
         * TODO: evt. ved kraftige skudd blir de ikke ødelagt og går igjennom
         * */
        if (other.tag == "Bolt" && tag == "Enemy")
            {

            Instantiate(explosion, transform.position, transform.rotation);
            h.DoDamage();
            Destroy(other.gameObject);
            

            }



            /**
             * Når Player blir skutt blir det initialisert en eksplosjon,
             * player tar skade og skuddet blir ødelagt
             * TODO: evt. ved kraftige skudd blir de ikke ødelagt og går igjennom
             * */
            if (other.tag == "EnemyBolt" && tag == "Player")
            {
                Instantiate(explosion, transform.position, transform.rotation);
                h.DoDamage();
                Destroy(other.gameObject);
            }

            /**
             * Plukker opp ammo når player kolliderer med den og ødelegger den
             * */

            if (tag == "PickUps" )
            {
                gameController.AddAmmo();
                Destroy(gameObject);
                return;
            }

            /**
             * Om player kolliderer med en fiende blir player health satt til 0
             * og enemy skipet blir ødelagt
             * */
            if (tag == "Player" && other.tag == "Enemy")
            {
           
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            p.GetComponent<HealthCheck>().ZeroHealth();
            Destroy(other.gameObject);
            
                
            
            }
            /*
            if(!(other.tag == "Bolt" || other.tag == "EnemyBolt" || other.tag == "PickUps"))
            {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            p.GetComponent<HealthCheck>().ZeroHealth();
            


        }
           
            */
            
            gameController.AddScore(scoreValue);
        
    }

    
}
