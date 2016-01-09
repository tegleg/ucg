using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveLoad : MonoBehaviour {

    public TrackEditor TrackEdit;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void saveCar(int Index)
    {
        
        PlayerPrefs.SetInt("car", Index);
        PlayerPrefs.Save();
    }

    public int loadCar()
    {
        int Index = PlayerPrefs.GetInt("car");
        return Index;
    }

    public void SaveTrack(List<int> TrackBits, int TrackLength)
    {
        foreach (int i in TrackBits)
        {
            PlayerPrefs.SetInt("track"+i, i);
            print("saving; "+i);
        }

        PlayerPrefs.SetInt("TrackLength", TrackLength);
    }

    public void LoadTrack()
    {
        int Amount = PlayerPrefs.GetInt("TrackLength");
        print("load:.. "+ Amount);
        for (int i = 0;i< Amount;i++)
        {
            int tmp = PlayerPrefs.GetInt("track" + i);
            print("load: "+ tmp);
            TrackEdit.LoadBit(tmp);
           // TrackEdit.PlaceBit();
        }

    }
}
