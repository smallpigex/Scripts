using UnityEngine;
using System.Collections;

public class UserPlayer : Player
{

    // Use this for initialization
    void Start()
    {
        //Debug.Log("Player move distance = " + MoveDistance);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void turnUpdate()
    {
        if (Vector3.Distance(moveDestination, transform.position) > base.moveDistanceOfTarget)
        {
            transform.position += (moveDestination - transform.position).normalized * base.moveSpeed * Time.deltaTime;

            if (Vector3.Distance(moveDestination, transform.position) <= base.moveDistanceOfTarget)
            {
                transform.position = moveDestination;
                GameManager.gameManagerInstance.nextTurn();
            }
        }

        base.turnUpdate();
    }

    public override void turnOnGUI()
    {
        float buttonHeight = 50;
        float buttonWeight = 150;
        Rect buttonRect = new Rect(0, Screen.height - buttonHeight * 3, buttonWeight, buttonHeight);
        //move button
        if (GUI.Button(buttonRect, "Move"))
        {
            if(!moving)
            {
                moving = true;
                attacking = false;
            }
            else
            {
                moving = false;
                attacking = false;
            }
            
        }

        //attack button
        buttonRect = new Rect(0, Screen.height - buttonHeight * 2, buttonWeight, buttonHeight);
        if (GUI.Button(buttonRect, "Attack"))
        {
            if(!attacking)
            {
                moving = false;
                attacking = true;
            }
            else
            {
                moving = false;
                attacking = false;
            }
        }

        //end turn button
        buttonRect = new Rect(0, Screen.height - buttonHeight * 1, buttonWeight, buttonHeight);

        if(GUI.Button(buttonRect, "End Turn"))
        {
            moving = false;
            attacking = false;
            GameManager.gameManagerInstance.nextTurn();
        }
        base.turnOnGUI();
    }
}
