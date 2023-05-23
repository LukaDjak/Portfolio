using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tiles;
    public float yPos = 0f;
    public float tileLength = 100f;
    public int tilesOnScreen = 4;

    public Transform player;

    void Start()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            SpawnTile(Random.Range(0, tiles.Length));
        }
    }

    void Update()
    {
        if (-player.position.y > yPos - (tilesOnScreen * tileLength))
        {
            SpawnTile(Random.Range(0, tiles.Length));
        }
    }

    public void SpawnTile(int tileIndex)
    {
        Instantiate(tiles[tileIndex], -transform.up * yPos, transform.rotation);
        yPos += tileLength;
    }
}
