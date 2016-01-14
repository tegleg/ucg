using UnityEngine;
using System.Collections;

public class resetScript : MonoBehaviour {

	public GameObject Car;
	Vector3 startSpot;

	// Use this for initialization
	void Start () {
		startSpot = Car.transform.position;
	}

	public void RestartPlayer(){
		Car.transform.position = startSpot;
		Car.transform.rotation.Set (0,0,0,1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
