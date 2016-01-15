using UnityEngine;
using System.Collections;

public class LapTimer : MonoBehaviour {

    private float startTime;
    private float ellapsedTime;
    private float lastLap;
    bool Started = false;

 

    // Use this for initialization
    void Start () {
        startTime = Time.time;
    
    }
	
	// Update is called once per frame
	void Update () {
        if (Started)
        {
            ellapsedTime = Time.time - startTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("trigger = "+ other.tag);
        if (other.gameObject.tag == "Player")
        {
            print("trigger player = true");
            

            if (Started)
            {
                lastLap = ellapsedTime;
                startTime = Time.time;
            }
            Started = true;

        }
        
    }

    void OnGUI()
    {
        GUI.contentColor = Color.grey;
        GUI.Label(new Rect(100, 30, 100, 20), (lastLap.ToString()));
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(100, 50, 100, 20), (ellapsedTime.ToString()));
    }
}
