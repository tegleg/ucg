using UnityEngine;
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

        if (bInMenu)
        {
            CurrentCar.GetComponent<CamChanger>().DisableCams();
        }
        // 
        // Camera Cam = CurrentCar.transform.Find("hoodCamera");

        //save
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
