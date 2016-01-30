using UnityEngine;
using System.Collections;

public class AI_Car1 : MonoBehaviour {

    public Transform[] Waypoints;
    int waypoint = 0;
    public float steerLimit = 12;

    public CarController CarCntrl;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!Waypoints[waypoint]) { waypoint = 0; }
        //get the waypoint and head towards it
        //right or left?
        var relativePoint = transform.InverseTransformPoint(Waypoints[waypoint].position);
      /*  if (relativePoint.x < 0.0)
        {
            print("Object is to the left "+ relativePoint.x);
            
        }    
        else if (relativePoint.x > 0.0)
        {
            print("Object is to the right "+ relativePoint.x);
        }
        else
        {
            print("Object is directly ahead");
        }*/
        CarCntrl.steerInput = Mathf.Clamp(relativePoint.x, -1, 1);

        print("relativePoint.x "+ relativePoint.x);

        // float dist = Vector3.Distance(Waypoints[waypoint].position, transform.position);
        if (relativePoint.x > steerLimit || relativePoint.x < -steerLimit)
        {
            CarCntrl.accelKey = false;
            print("notaccel");
        }
        else
        {
            CarCntrl.accelKey = true;
            print("accel");
        }

            
        
        
        //when in distance select next waypoint

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == Waypoints[waypoint]) {
           // print("other.gameObject.tag = "+ other.gameObject.tag);
            waypoint += 1;
        }
       
    }
}
