using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingScreanLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int index = PlayerPrefs.GetInt("SelectedLevel");
        PlayerPrefs.DeleteKey("SelectedLevel");
        SceneManager.LoadSceneAsync(index);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
