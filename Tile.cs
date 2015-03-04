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
        if (GameManager.gameManagerInstance.playerIsMoving())
        {
            //Debug.Log("My position is " + gridPosition + " and color is blue");
            transform.renderer.material.color = Color.blue;
        }
        else if (GameManager.gameManagerInstance.playerIsAttacking())
        {
            transform.renderer.material.color = Color.red;
        }
       
    }

    void OnMouseExit ()
    {
        transform.renderer.material.color = Color.white;
    }

    void OnMouseDown ()
    {
        if (GameManager.gameManagerInstance.playerIsMoving())
        {
            GameManager.gameManagerInstance.moveCurrentPlayer(this);
        }
        else if (GameManager.gameManagerInstance.playerIsAttacking())
        {
            //GameManager.gameManagerInstance.moveCurrentPlayer(this);
        }
        
    }
}
