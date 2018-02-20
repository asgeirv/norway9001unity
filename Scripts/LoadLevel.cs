using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {


    public void Level1()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
    }
}
