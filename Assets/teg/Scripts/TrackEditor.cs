using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

//this script places the next track bit at the end point of the last track bit
//and swaps between bits (prefabs)

public class TrackEditor : MonoBehaviour {

    public bool bEditor = true;

    public SaveLoad SaveGame;
    FileInfo f;

    public Camera Cam;
    float CamHeight;
    Vector3 CamLoc;
    public float camLerpSpeed = 0.5f;
    
    //set this to start track piece in editor, will be changed in code as track is built
    public GameObject lastBit;
    //the current bit really, the one we decide which one to put next
    private GameObject currentBit;

    //available bits
    public GameObject[] AvailableBits;
    //bits making up current track
    public List<int> TrackBits;

    List<GameObject> TrackCache = new List<GameObject>();
    int chacheIndex = 0;

    Transform CurrentTransform;

    int Index = 0;

    // Use this for initialization
    void Start () {

        if (lastBit != null)
        {
            CurrentTransform = lastBit.transform.Find("end").transform;
        }

        if (bEditor)
        {
            if (currentBit == null)
            {
                currentBit = (GameObject)Instantiate(AvailableBits[Index], CurrentTransform.position, CurrentTransform.rotation);
                print("currentBit = "+ currentBit);
                TrackCache.Add(currentBit);
                chacheIndex++;
                print("chacheIndex = " + chacheIndex);
            }

            if (Cam != null)
            {
                CamHeight = Cam.transform.position.y;
                Vector3 newPosition = CurrentTransform.position;
                newPosition.y = CamHeight;
                CamLoc = newPosition;
            }
             //TrackCache.Add(currentBit);
        }
        else
        {
            //load from file
            LoadTrack();
        }
   
	}

    public void ChangeBit()
    {
        if (currentBit != null)
        {
            Destroy(currentBit);
            Index++;
            if (Index >= AvailableBits.Length)
            {
                Index = 0;
            }

            currentBit = (GameObject)Instantiate(AvailableBits[Index], CurrentTransform.position, CurrentTransform.rotation);

        }
    }

    public void DeleteBit()
    {
        if (currentBit != null)
        {
            //remove from gameobject array
            print("deletebit = "+ currentBit);

           // TrackCache.Remove(currentBit);
            Destroy(currentBit);
            //remove from int array
            TrackBits.RemoveAt(chacheIndex-2);
           // Index = chacheIndex - 3;

            chacheIndex--;
            print("chacheIndex = "+ chacheIndex);

            //chek em all
            for (int i = 0; i< TrackCache.Count; i++)
            {
                print("TrackCache[i] = " + TrackCache[i]);
            }

            currentBit = TrackCache[chacheIndex];
            print("new currentBit = " + currentBit);
            //need to get the transform of the bit befor
            //
            lastBit = TrackCache[chacheIndex - 1];
            print("new lastbit = "+ lastBit);
             CurrentTransform = lastBit.transform.Find("end").transform;

            Index = 0;

            //move the camera
            if (Cam != null)
            {
                Vector3 newPosition = CurrentTransform.position;
                newPosition.y = CamHeight;
                CamLoc = newPosition;
                // lerp cam in update
            }
        }
    }

    public void LoadBit(int Target)
    {
        Index = Target;

        if (currentBit != null)
        {
            Destroy(currentBit);
        }
            currentBit = (GameObject)Instantiate(AvailableBits[Index], CurrentTransform.position, CurrentTransform.rotation);

            Index++;
            if (Index >= AvailableBits.Length)
            {
                Index = 0;
            }

            
        

        CurrentTransform = currentBit.transform.Find("end").transform;
        lastBit = currentBit;

        currentBit = (GameObject)Instantiate(AvailableBits[Target], CurrentTransform.position, CurrentTransform.rotation);

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
        //int for saving
        TrackBits.Add(Index);
        //gameobject for deleting

        TrackCache.Add(currentBit);
       // TrackCache.IndexOf(currentBit);
        print("TrackCache.Add(currentBit) = "+ currentBit);
       // print("TrackCache.IndexOf(currentBit) = " + TrackCache.IndexOf(currentBit));

        CurrentTransform = currentBit.transform.Find("end").transform;
        lastBit = currentBit;
        
        currentBit = (GameObject)Instantiate(AvailableBits[Index], CurrentTransform.position, CurrentTransform.rotation);
        
        chacheIndex++;
        print("chacheIndex = " + chacheIndex);

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
        StreamWriter w;

        f = new FileInfo(Application.persistentDataPath + "\\" + "myFile.txt");

        //create new file, delete old if it exists
        if (!f.Exists)
        {
            w = f.CreateText();
            print("creating file");
        }
        else
        {
            f.Delete();
            w = f.CreateText();
            print("saving file");
        }
        
        //add current bit
       // TrackBits.Add(Index);

        print("savetrack() length: "+ TrackBits.Count);
        //write trackbits array, 1 element on each line
        for (int i = 0; i < TrackBits.Count; i++)
        {
            string str = TrackBits[i].ToString();
            w.WriteLine(str);
            print("savetrack() value: " + str);
        }
        w.Close();
            
    }

    public void LoadTrack()
    {
        // Handle any problems that might arise when reading the text
        
            string line;

            string DataPath = Application.persistentDataPath + "\\" + "myFile.txt";
            StreamReader theReader = new StreamReader(DataPath, Encoding.Default);

        while ((line = theReader.ReadLine()) != null)
        {
            int value;

            // attempt to parse the value using the TryParse functionality of the integer type
            int.TryParse(line, out value);
            print("loadtrack() line, value: " + line + ", " +(int) value);
            LoadBit(value);
        }


        Destroy(currentBit);

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
