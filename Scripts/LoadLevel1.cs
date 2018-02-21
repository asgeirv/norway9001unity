using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour {

    public void LoadByIndex(int index)
    {
        PlayerPrefs.SetInt("SelectedLevel",index);
        SceneManager.LoadScene(2);


    }
}
