using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    public Vector2 gridPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter ()
    {
        //Debug.Log("My position is " + gridPosition + " and color is blue");
        transform.renderer.material.color = Color.blue;
    }

    void OnMouseExit ()
    {
        transform.renderer.material.color = Color.white;
    }
}
