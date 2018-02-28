using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickUp : MonoBehaviour
{
    public GameObject Ammo;
    public float dropValue;

    void Start()
    {




    }

  

   public void DropAmmo()
    {
        if (Random.value <= dropValue)
        {
            //Debug.Log(other.tag + tag);
            Vector3 dropPosition = new Vector3(
                transform.position.x,
                 -1.5f,
                transform.position.z
            );


            if (tag != "Player")
                Instantiate(Ammo, dropPosition, new Quaternion(0f, 0f, 0f, 0f));
        }
    }

}