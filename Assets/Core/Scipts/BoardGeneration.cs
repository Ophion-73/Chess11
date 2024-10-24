using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.UIElements;

public class BoardGeneration : MonoBehaviour
{
    [Header("Logica")]
    public GameObject[,] tiles;
    public int tilesX;
    public int tilesY;
    public GameObject singleTile;
    public Player player;

    [Header("Juego")]
    public int p1T;
    public int p2T;
    public string[] Personajes;
    public int[,] player1;
    public int[,] player2;
    private void Awake()
    {
        player1 = new int[tilesX, tilesY];
        player2 = new int[tilesX, tilesY];
        CharacterID(p1T, true);
        CharacterID(p2T, false);
        GenerateAllTiles();
        PositionAllTiles();
        AssignPieces(player1,player2);
    }

    

    public void GenerateAllTiles()
    {
        tiles = new GameObject[tilesX,tilesY];
        for(int i = 0; i < tilesX; i++ )
        {
            for(int j = 0; j < tilesY; j++ ) 
            {
                GenerateSingleTile(i,j);
            }
        }
    }

    public void GenerateSingleTile(int i, int j)
    {
        GameObject tile = Instantiate(singleTile, transform.position, Quaternion.identity);
        tile.transform.parent = transform;
        tiles[i, j] = tile;
    }
    public void PositionAllTiles()
    {
        Debug.Log("1");
        for (int i = 0; i < tilesX; i++)
        {
            for (int j = 0; j < tilesY; j++)
            {
                Vector3 previosPos = tiles[i, j].transform.position;
                Tile tile;
                tiles[i, j].transform.position = previosPos + new Vector3(i, 0, j);
                tile = tiles[i,j].GetComponent<Tile>();
                tile.x = i;
                tile.y = j;
                player.tiles[i, j] = tiles[i, j];
                
            }
        }
    }
    private void AssignPieces(int[,] player1, int[,] player2)
    {
        int[,] finalBoard = new int[tilesX,tilesY];
        for(int i = 0;i < tilesX;i++)
        {
            for(int j = 0; j < tilesY; j++)
            {
                if (player1[i,j] != 0)
                {
                    finalBoard[i, j] = player1[i,j];
                }
                else if(player2[i, j] != 0)
                {
                    finalBoard[i, j] = player2[i, j];
                }
            }
        }
        for (int i = 0; i < tilesX; i++)
        {
            for (int j = 0; j < tilesY; j++)
            {
                Tile tile;
                tile = tiles[i, j].GetComponent<Tile>();
                tile.Piece = finalBoard[i,j];
                tile.SpawnPiece();
            }
        }

    }
    public void CharacterID(int id, bool playerone)
    {
        Debug.Log("0");
        
        switch (id)
        {
           
            case 0:
                
                if(playerone)
                {
                    player1[0, 0] = 1;
                    player1[1, 0] = 1;
                    player1[2, 0] = 1;
                    player1[3, 0] = 1;
                    player1[4, 0] = 1;
                    player1[5, 0] = 1;
                    player1[6, 0] = 1;
                    player1[7, 0] = 1;
                    player1[8, 0] = 1;
                    player1[9, 0] = 1;
                    player1[10, 0] = 1;
                }
                else
                {
                    player2[0, 10] = 1;
                    player2[1, 10] = 1;
                    player2[2, 10] = 1;
                    player2[3, 10] = 1;
                    player2[4, 10] = 1;
                    player2[5, 10] = 1;
                    player2[6, 10] = 1;
                    player2[7, 10] = 1;
                    player2[8, 10] = 1;
                    player2[9, 10] = 1;
                    player2[10, 10] = 1;
                }
                break;
                
        }
        
    }
}
