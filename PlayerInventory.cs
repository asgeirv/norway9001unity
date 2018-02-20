using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;



public class PlayerInventory  {


    public Text ammoType1;
    public Text ammoType2;
    public Text ammoType3;

    public int ammo;
    private string path;

    private string line;


	// Use this for initialization
	public PlayerInventory () {
        Text[] textFields = Text.FindObjectsOfType<Text>();
        foreach (Text tex in textFields)
        {
            if (tex.tag == "AmmoText")
            {
                ammoType1 = tex;
            }
        }
        
        path = Application.dataPath + "/Ammo.txt";

        System.IO.StreamReader file = new System.IO.StreamReader(path);
        while ((line = file.ReadLine()) != null) 
        {
            ammo = Int32.Parse(line);
            
        }
        file.Close();

    }

    // Update is called once per frame
    void Update () {
		
	}
    public void AddAmmo(int newAmmoValue)
    {
        ammo += newAmmoValue;
        UpdateAmmoCount();
    }

    void UpdateAmmoCount()
    {
        ammoType1.text = "Ammo: " + ammo;
    }

    void PrintAmmo()
    {
        StreamWriter sw = new StreamWriter(path);
        sw.WriteLine(ammo);
    }
}
