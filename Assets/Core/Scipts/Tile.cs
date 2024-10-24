using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x;
    public int y;
    public int Piece;
    public Material highlitedMat;
    public Material normal;
    public GameObject piece;
    public bool highlited;

    private void Awake()
    {
        highlited = false;
    }
    private void Update()
    {
        ChangeMaterial();
        
    }

    public void ChangeMaterial()
    {
        if (highlited)
        {
            gameObject.GetComponent<Renderer>().material = highlitedMat;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = normal;
        }
    }

    public void SpawnPiece()
    {
        GameObject currentPiece;
        switch (Piece) 
        {
            case 0:
                
                break;

            case 1:
                currentPiece = Instantiate(piece, transform.position, Quaternion.identity);
                currentPiece.transform.parent = transform;
                break;
        }
        
    }



}
