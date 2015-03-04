using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    protected float moveSpeed = 10.0f;
    protected float moveDistanceOfTarget = 0.1f;
  

    private int playerMoveDistance = 5;
  
    public Vector3 moveDestination { set; get; }
    public int MoveDistance
    {
        set
        {
            if (playerMoveDistance <= 0)
            {
                playerMoveDistance = 5;
            }
        }

        get
        {
            return playerMoveDistance;
        }
    }

    public bool moving = false;
    public bool attacking = false;
    public int hp = 25;
    public float attackChange = 0.75f;
    public float defenseReduction = 0.15f;
    public int demageBase = 0;
    public float demageRollSides = 6; //d6

    void Awake()
    {
        moveDestination = transform.position;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void turnUpdate()
    {
        if(GameManager.gameManagerInstance)
    }

    public virtual void turnOnGUI()
    {

    }
}
