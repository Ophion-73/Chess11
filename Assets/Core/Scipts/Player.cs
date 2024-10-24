using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera camera;
    public BoardGeneration BoardGeneration;
    private GameObject previousTile = null; // Store the previously hovered tile
    public GameObject[,] tiles;
    public LayerMask tileLayer;
    public bool pieceSelected;

    private void Awake()
    {
        tiles = new GameObject[BoardGeneration.tilesX, BoardGeneration.tilesY];
    }
    private void Update()
    {
        Hover();
    }

    public void Hover()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mousePos);

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.cyan);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, tileLayer))
        {
            GameObject currentTile = hit.transform.gameObject;
            Tile hoveredTile = currentTile.GetComponent<Tile>();
            if(Input.GetMouseButtonDown(0) && hoveredTile.Piece !=0)
            {
                 if(!pieceSelected)
                {

                    pieceSelected = true;
                }
                 else
                {

                }
            }
            
            if (currentTile != previousTile)
            {
               
                if (previousTile != null)
                {
                    Tile prevTile = previousTile.GetComponent<Tile>();
                    prevTile.highlited = false; 
                }

                
                hoveredTile.highlited = true;

                
                previousTile = currentTile;
            }
        }
        else
        {
            
            if (previousTile != null)
            {
                Tile prevTile = previousTile.GetComponent<Tile>();
                prevTile.highlited = false;
                previousTile = null; 
            }
        }
    }
}
