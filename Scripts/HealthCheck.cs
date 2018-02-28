using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCheck : MonoBehaviour {
    public int health;
    private GameObject ammo;

    void Start () {
        ammo = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        /**
         * Ødelegger gameobject som har 0 health, og kaller på DropAmmo()
         * */
        if (health <= 0)
        {
            Destroy(this.gameObject);

            if (ammo)
            {
                ammo.GetComponent<PickUp>().DropAmmo();
            }
            
            
        }
	}

    public void DoDamage()
    {
        health = health - 1;
    }

    public int GetHealth()
    {
        return health;
    }

    /**
     * Setter Health til 0
     * */
    public void ZeroHealth()
    {
        health = 0;
    }
    

   
    
}
