using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {
    /*
     * Dette scriptet beveger skjoldet i en sirkelbevegelse mot fientlige object rundt aksen av skipet
     * 
     * Author: Niklas
     */

    private float RotateSpeed = 5f;
  

    public float maxAngle;
    public float minAngle;

    public bool debug;

   
    private float _angle = 0;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {


         bool mRight = Input.GetKey(KeyCode.Q);
        bool mLeft = Input.GetKey(KeyCode.E);
        if (mRight)
        {
            _angle--;
            transform.Rotate(new Vector3(-1, 0, 0));
            if (debug){
                Debug.Log("Q was pressed");
            }
            
        }
        else if (mLeft)
        {
            _angle++;
            transform.Rotate(new Vector3(1, 0, 0));
            if (debug)
            {
                Debug.Log("E was pressed");
            }
           
        }

        

    }
}
