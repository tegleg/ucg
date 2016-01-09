using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

    public GameObject CurrentCar;
    public CarController CC;

    Vector3 CarPos;

    public void SetCar(GameObject Car)
    {
        print("setcar "+Car);
        CurrentCar = Car;
        CC = Car.GetComponent<CarController>();
        CarPos = Car.transform.position;
    }

    public void SetAccel(bool DoIt)
    {
        //print ("called setaccel");
        CC.SetAccel(DoIt);
    }

    public void SetBrake(bool DoIt)
    {
        CC.SetBrake(DoIt);
    }

    public void SetSteering(float Target)
    {
        CC.SetSteering(Target);
    }

    public void ChangeCam()
    {
        CurrentCar.GetComponent<CamChanger>().ChangeCam();
    }

    public void ResetCar()
    {
        print("resetcar " + CurrentCar);
        CurrentCar.transform.position = CarPos;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
