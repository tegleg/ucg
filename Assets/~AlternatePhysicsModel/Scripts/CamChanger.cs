﻿using UnityEngine;
using System.Collections;

public class CamChanger : MonoBehaviour {

	public GameObject ChaseCam;
	public Camera HoodCam;

	bool bHood = false;

	public void ChangeCam(){
		bHood = !bHood;

        if (!ChaseCam)
        {
            ChaseCam = GameObject.FindWithTag("chasecam");
        }

		ChaseCam.gameObject.SetActive (!bHood);
		//ChaseCam.enabled = !bHood;
		HoodCam.gameObject.SetActive (bHood); 

	}

    public void DisableCams()
    {
        print("DisableCams");
        if (ChaseCam)
        {
            ChaseCam.gameObject.SetActive(false);
           // ChaseCam.enabled = false;

        }
        
        HoodCam.gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
        if (ChaseCam)
        {
            ChaseCam.gameObject.SetActive(true);
        }
		
		HoodCam.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
