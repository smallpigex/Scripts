using UnityEngine;
using System.Collections;

public class AIPlayer : Player 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public override void turnUpdate()
    {
       GameManager.gameManagerInstance.nextTurn();
       base.turnUpdate();
    }

    public override void turnOnGUI()
    {
        base.turnOnGUI();
    }
}
