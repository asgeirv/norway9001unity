using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour {


    public void Click()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
    }
}
