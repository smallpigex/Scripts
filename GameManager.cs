using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    public static GameManager gameManagerInstance = null;
    public GameObject tilePrefab;
    public GameObject playerPrefab;
    public GameObject aiPrefab;

    public int mapSize = 11;

    List<List<Tile>> map;
    List<Player> players;
    int currentPlayerIndex = 0;

    void Awake ()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }
    }

	// Use this for initialization
	void Start () {
        generateMap ();
        generatePlayers ();
	}
	
	// Update is called once per frame
	void Update () 
    {
        players[currentPlayerIndex].turnUpdate();
	}

    void OnGUI ()
    {
        players[currentPlayerIndex].turnOnGUI();
    }

    private void generateMap()
    {
        map = new List<List<Tile>>();
        for (int i = 0; i < mapSize; i++)
        {
            List<Tile> row = new List<Tile>();
            for (int j = 0; j < mapSize; j++)
            {
                GameObject goTile = instantiateGameObject(tilePrefab, i, 0, j);

                Tile tile = goTile.GetComponent<Tile>();
                if (tile != null)
                {
                    tile.gridPosition = new Vector2(i, j);
                    row.Add(tile);
                }
                else
                {
                    //Debug.Log("Tile is null and x = " + i + " j = " + j);
                }         
            }
            map.Add(row);
        }
    }

    private void generatePlayers ()
    {
        players = new List<Player>();
        UserPlayer player;

        player = instantiateGameObject(playerPrefab, 0, 1.5f, 0).GetComponent<UserPlayer>();
        players.Add(player);

        player = instantiateGameObject(playerPrefab, mapSize - 1, 1.5f, mapSize - 1).GetComponent<UserPlayer>();
        players.Add(player);

        //AIPlayer aiPlayer = instantiateGameObject(aiPrefab, 4, 1.5f, 4).GetComponent<AIPlayer>();
       // players.Add(aiPlayer);
    }

    private GameObject instantiateGameObject(GameObject prefab, float posX, float posY, float posZ)
    {
        return (GameObject)Instantiate(prefab, new Vector3(posX - Mathf.Floor(mapSize / 2), posY, -posZ + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()));
    }

    public void nextTurn ()
    {
        if (currentPlayerIndex + 1 < players.Count)
        {
            currentPlayerIndex++;
        }
        else
        {
            currentPlayerIndex = 0;
        }
        Debug.Log("current player index is " + currentPlayerIndex);
    }

    public void moveCurrentPlayer(Tile destinationTile)
    {
        players[currentPlayerIndex].moveDestination = destinationTile.transform.position + 1.5f * Vector3.up;
    }

    public bool playerIsMoving ()
    {
        return players[currentPlayerIndex].moving;
    }

    public bool playerIsAttacking ()
    {
        return players[currentPlayerIndex].attacking;
    }

    public Player getCurrentPlayer ()
    {
        return players[currentPlayerIndex];
    }
}
