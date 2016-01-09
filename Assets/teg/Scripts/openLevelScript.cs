using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class openLevelScript : MonoBehaviour {

	public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
