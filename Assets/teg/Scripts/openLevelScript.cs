using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class openLevelScript : MonoBehaviour {

    private GUIStyle guiStyle = new GUIStyle();
    private bool loading = false;

    public void OpenScene(string sceneName)
    {
        loading = true;
       
        SceneManager.LoadScene(sceneName);
    }
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (loading)
        {
            GUI.contentColor = Color.black;
            guiStyle.fontSize = 40; //change the font size
            GUI.Label(new Rect(200, 200, 100, 20), ("Loading..."), guiStyle);
        }
    }
    }
