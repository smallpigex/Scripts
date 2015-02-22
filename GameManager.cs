using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{

    public GameObject tilePrefab;
    public GameObject playerPrefab;

    public int mapSize = 11;

    List<List<Tile>> map;
    List<Player> players;
    int currentPlayerIndex = 0;
	// Use this for initialization
	void Start () {
        generateMap ();
        generatePlayers ();
	}
	
	// Update is called once per frame
	void Update () {
	
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
    }

    private GameObject instantiateGameObject(GameObject prefab, float posX, float posY, float posZ)
    {
        return (GameObject)Instantiate(prefab, new Vector3(posX - Mathf.Floor(mapSize / 2), posY, -posZ + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()));
    }
}
