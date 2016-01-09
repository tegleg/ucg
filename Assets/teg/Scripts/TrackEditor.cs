using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this script places the next track bit at the end point of the last track bit
//and swaps between bits (prefabs)

public class TrackEditor : MonoBehaviour {

    public SaveLoad SaveGame;

    public Camera Cam;
    float CamHeight;
    Vector3 CamLoc;
    public float camLerpSpeed = 0.5f;
    
    //set this to start track piece in editor, will be changed in code as track is built
    public GameObject lastBit;
    //the current bit really, the one we decide which one to put next
    private GameObject nextBit;

    //available bits
    public GameObject[] AvailableBits;
    //bits making up current track
    public List<int> TrackBits;

    Transform CurrentTransform;

    int Index = 0;

    // Use this for initialization
    void Start () {

        if (lastBit != null)
        {
            CurrentTransform = lastBit.transform.Find("end").transform;
        }

        if (nextBit == null)
        {
            //Instantiate(Resources.Load("enemy"));
            nextBit = (GameObject)Instantiate(AvailableBits[Index], CurrentTransform.position, CurrentTransform.rotation);
        }

        if (Cam != null)
        {
            CamHeight = Cam.transform.position.y;
            Vector3 newPosition = CurrentTransform.position;
            newPosition.y = CamHeight;
            CamLoc = newPosition;
        }
	}

    public void ChangeBit()
    {
        if (nextBit != null)
        {
            Destroy(nextBit);
            Index++;
            if (Index >= AvailableBits.Length)
            {
                Index = 0;
            }

            nextBit = (GameObject)Instantiate(AvailableBits[Index], CurrentTransform.position, CurrentTransform.rotation);
        }
    }

    public void LoadBit(int Target)
    {
        Index = Target;

        if (nextBit != null)
        {
            Destroy(nextBit);
            Index++;
            if (Index >= AvailableBits.Length)
            {
                Index = 0;
            }

            nextBit = (GameObject)Instantiate(AvailableBits[Index], CurrentTransform.position, CurrentTransform.rotation);
        }

        CurrentTransform = nextBit.transform.Find("end").transform;
        lastBit = nextBit;

        nextBit = (GameObject)Instantiate(AvailableBits[Target], CurrentTransform.position, CurrentTransform.rotation);

        //move the camera
        if (Cam != null)
        {
            Vector3 newPosition = CurrentTransform.position;
            newPosition.y = CamHeight;
            CamLoc = newPosition;
            // lerp cam in update
        }
    }

    public void PlaceBit()
    {
        TrackBits.Add(Index);
        CurrentTransform = nextBit.transform.Find("end").transform;
        lastBit = nextBit;
        
        nextBit = (GameObject)Instantiate(AvailableBits[Index], CurrentTransform.position, CurrentTransform.rotation);

        //move the camera
        if (Cam != null)
        {
            Vector3 newPosition = CurrentTransform.position;
            newPosition.y = CamHeight;
            CamLoc = newPosition;
           // lerp cam in update
        }

    }

    public void SaveTrack()
    {
        //add current bit
        TrackBits.Add(Index);
        //save
        SaveGame.SaveTrack(TrackBits, TrackBits.Count);
    }
	
	// Update is called once per frame
	void Update () {
        //lerp the camera
        if (Cam != null)
        {
            if (Cam.transform.position != CamLoc)
            {
                Cam.transform.position = Vector3.Lerp(Cam.transform.position, CamLoc, camLerpSpeed*Time.deltaTime);
            }  
        }

    }
}
