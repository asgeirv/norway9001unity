using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteByBoundary : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z > 20 || transform.position.z < -20 || transform.position.x%15>15)
        {
            Destroy(gameObject);
        }
	}
}
