using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class AndroidScoreSavingTest : MonoBehaviour {

    string message;
    string loadMessage = "Yeah working";
    string data;
    FileInfo f;

    void Start()
    {
        f = new FileInfo(Application.persistentDataPath + "\\" + "myFile.txt");
        Screen.SetResolution(800, 600, true);
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, 500, 500));
        GUILayout.Label(message + " " + data);
        if (GUILayout.Button("Save"))
        {

            if (!f.Exists)
            {
                message = "Creating File";
                Save();
            }
            else
            {
                message = "Saving";
                Save();
            }
        }
        if (GUILayout.Button("Load"))
        {
            if (f.Exists)
            {
                Load();
            }
            else
            {
                message = "No File found";
            }
        }
        GUILayout.EndArea();
    }

    void Save()
    {
        StreamWriter w;
        if (!f.Exists)
        {
            w = f.CreateText();
        }
        else
        {
            f.Delete();
            w = f.CreateText();
        }
        //here, for(i.... ){save track index as a line in a text file
        w.WriteLine(loadMessage);
        w.Close();
    }

    void Load()
    {
        StreamReader r = File.OpenText(Application.persistentDataPath + "\\" + "myFile.txt");
        string info = r.ReadToEnd();
        r.Close();
        data = info;
    }

    void ReadFileLines()
    {
        string DataPath = Application.persistentDataPath + "\\" + "myFile.txt";
        
            string[] Readfile = new string[File.ReadAllLines(DataPath).Length];

        for (int i = 0;i< Readfile.Length;i++)
        {
            //value is the index of the track bit, got from a line in a text file
            int value;
            // attempt to parse the value using the TryParse functionality of the integer type
            int.TryParse(Readfile[i], out value);
            //send to track editor to spawn bits
            //.....
//chuk all this int trak editor script...
        }
     
        
    }
}
