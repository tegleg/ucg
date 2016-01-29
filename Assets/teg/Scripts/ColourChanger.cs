using UnityEngine;
using System.Collections;

public class ColourChanger : MonoBehaviour {

    public bool IsColliding = false;
    public bool bPlaced = false;

    public Texture redtexture;

    // Use this for initialization
    void Start () {

        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            if (g.GetComponentInChildren<Renderer>())
            {
                var bounds1 = g.GetComponentInChildren<Renderer>().bounds;
                var bounds2 = this.gameObject.GetComponentInChildren<Renderer>().bounds;

                if (bounds1.Intersects(bounds2))
                {
                    GoRed();
                }
            }
        }


    }

    void OnCollision(Collision col)
    {
        print("collision");
    }

    void GoRed()
    {
        //if (true) {
        //foreach (Transform child in this.transform) {
        //              if (child.name == "Cylinder") {
        print(" go red !!!");
        IsColliding = true;
        //collided = true;
       // Color c;
     //   MeshRenderer m = this.GetComponent<MeshRenderer>();
      //  c = this.gameObject.GetComponentInChildren<MeshRenderer>().material.SetTexture();
      //  c.g = 0f;
      //  c.b = 1f;
      //  c.r = 0f;
        this.gameObject.GetComponentInChildren<MeshRenderer>().material.SetTexture("RGB", redtexture);
    }

        // Update is called once per frame
        void Update () {
	    if (!IsColliding && !bPlaced)
        {
            object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
            foreach (object o in obj)
            {
                GameObject g = (GameObject)o;

                if (g.GetComponentInChildren<Renderer>())
                {
                var bounds1 = g.GetComponentInChildren<Renderer>().bounds;
                var bounds2 = this.gameObject.GetComponentInChildren<Renderer>().bounds;

                if (bounds1.Intersects(bounds2))
                {
                    GoRed();
                }
                }
                
            }
        }
	}
}
