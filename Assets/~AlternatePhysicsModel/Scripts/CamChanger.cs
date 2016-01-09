using UnityEngine;
using System.Collections;

public class CamChanger : MonoBehaviour {

	public Camera ChaseCam;
	public Camera HoodCam;

	bool bHood = false;

	public void ChangeCam(){
		bHood = !bHood;

		ChaseCam.gameObject.SetActive (!bHood);
		ChaseCam.enabled = !bHood;
		HoodCam.gameObject.SetActive (bHood); 

	}

    public void DisableCams()
    {
        print("DisableCams");
        ChaseCam.gameObject.SetActive(false);
        ChaseCam.enabled = false;
        HoodCam.gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
		ChaseCam.gameObject.SetActive(true);
		HoodCam.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
