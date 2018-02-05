using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public Transform[] bgObjs;
    private float[] parallaxScales;             // The proportion of the camera's movement to move the backgrounds by
    public float smoothing = 1.0f;              // How smooth the parallax is going to be. Make sure to set this above 0.
    private float[] prevZPos;
    public float speed;
    public float startZ;
    public float endZ;

    private float[] zPos;                      

    // Is called before Start()
    private void Awake()
    {
        zPos = new float[bgObjs.Length];
        for (int i = 0; i < bgObjs.Length; i++)
        {
            zPos[i] = bgObjs[i].position.z;
        }
    }

    // Use this for initialization
    void Start () {
        prevZPos = new float[bgObjs.Length];

        // Previous frame had the frane's camera position
        for (int i = 0; i < bgObjs.Length; i++)
        {
            prevZPos[i] = zPos[i];
        }

        parallaxScales = new float[bgObjs.Length];

        // Assign corresponding parallax scales
        for (int i = 0; i < bgObjs.Length; i++)
        {
            parallaxScales[i] = (bgObjs[i].position.y + 10) * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < bgObjs.Length; i++)
        {
            zPos[i] = zPos[i] + speed;

            // Parallax is the opposite of the camera movement because the previous frame multiplied by scale
            float parallax = (prevZPos[i] - zPos[i]) * parallaxScales[i];

            // Set a target exposition which is the current position plus the parallax
            float bgTargetPosZ = bgObjs[i].position.z + parallax;

            // Create target position which is the backgroound's current position with its target x position
            Vector3 bgTargetPos = new Vector3(bgObjs[i].position.x, bgObjs[i].position.y, bgTargetPosZ);

            // Fade between current position and the target position using lerp
            bgObjs[i].position = Vector3.Lerp(bgObjs[i].position, bgTargetPos, smoothing * Time.deltaTime);

            prevZPos[i] = zPos[i];

            if (bgObjs[i].position.z < endZ)
            {
                prevZPos[i] = startZ;
                zPos[i] = startZ;
                bgObjs[i].position = new Vector3(bgObjs[i].position.x, bgObjs[i].position.y, startZ);
            }
        }
	}
}
