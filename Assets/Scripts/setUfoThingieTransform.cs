using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUfoThingieTransform : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(0f, 0.022f, 0.002f);
        transform.eulerAngles = new Vector3(-90,0,45);
    }
}
