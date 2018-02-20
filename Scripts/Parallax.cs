using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    private float lowerBounds;
    private float parralaxScale;
    private float startZ;

    private void Start()
    {
        lowerBounds = -10f;
        parralaxScale = 0.01f;
        startZ = 10f;
    }

    //takes in a transform and moves it in the z axis depending on its y position
    public void Update()
    {
        
        float z = transform.localPosition.z;
        float y = transform.localPosition.y;
        float x = transform.localPosition.x;

        //Moves the object down on the screen if it's not under the minimum z value
        if (z > lowerBounds)
        {
            float speed = Mathf.Clamp(0.1f + y * parralaxScale,0f,1f);
            float newZ = z - speed;
            transform.localPosition = new Vector3(x, y, newZ);
        }
        //Moves it to its starting position
        else
        {
            transform.localPosition = new Vector3(x,y,startZ);
        }
    }
}
