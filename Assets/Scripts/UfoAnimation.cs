using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoAnimation : MonoBehaviour {
    public GameObject parent;
    public float rotationSpeed;
	// Use this for initialization
	void Start () {
        rotationSpeed = 100;
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(parent.transform.position,Vector3.up,rotationSpeed*Time.deltaTime);
	}
}
