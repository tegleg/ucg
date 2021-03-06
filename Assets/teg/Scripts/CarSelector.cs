﻿using UnityEngine;
using System.Collections;

public class CarSelector : MonoBehaviour {

    public GameObject CurrentCar;
    public GameObject[] AllCars;

    public SaveLoad SaveGame;

    public InputHandler inputH;

    //disable car cams in menu    
    public bool bInMenu;

    int Index = 0;

    public void ChangeCar()
    {
        Index++;
        if (Index >= AllCars.Length)
        {
            Index = 0;
        }

        GameObject oldCar = CurrentCar;
        oldCar.SetActive(false);
        CurrentCar = (GameObject)Instantiate(AllCars[Index], oldCar.transform.position, oldCar.transform.rotation);
        print("ChangeCar = " + CurrentCar);

        if (bInMenu)
        {
            CamChanger cc =  CurrentCar.GetComponent<CamChanger>();
            if (cc)
            {
                cc.DisableCams();
            }

            SoundController sc = CurrentCar.GetComponent<SoundController>();
            print("soundcontroller = "+sc);
            if (sc)
            {
                sc.enabled = false;
            }
        }
        // 
        // Camera Cam = CurrentCar.transform.Find("hoodCamera");

        //save
        print("saving index = "+Index);
        SaveGame.saveCar(Index);

        Destroy(oldCar);

        //handle inputs
        if (inputH != null)
        {
            inputH.SetCar(CurrentCar);
        }
        
    }   
     
    // Use this for initialization
    void Start () {

        Index = SaveGame.loadCar();
        GameObject oldCar = CurrentCar;
        oldCar.SetActive(false);
        CurrentCar = (GameObject)Instantiate(AllCars[Index], oldCar.transform.position, oldCar.transform.rotation);
        Destroy(oldCar);
        if (bInMenu)
        {
            CurrentCar.GetComponent<CamChanger>().DisableCams();
            SoundController sc = CurrentCar.GetComponent<SoundController>();
            print("soundcontroller = " + sc);
            if (sc)
            {
                sc.enabled = false;
            }
        }

        //handle inputs
        if (inputH != null)
        {
            inputH.SetCar(CurrentCar);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
