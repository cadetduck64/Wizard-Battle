using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridScript : MonoBehaviour
{
    public Tilemap tileMapData;
    public TileBase tileBaseData;
    public Grid gridData;
    public GameObject playerGameObject;
    public TextMeshProUGUI GridCoordinatesText;
    public Tilemap[] gridTilemaps;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {   
        Vector3Int playerCellPosition;
        playerCellPosition = gridData.WorldToCell(playerGameObject.transform.position);//track player position in cell coordinates
        
        
        // grid = GetComponent<Grid>();
        // tileMapData = GetComponent<Tilemap>();
        // tileBaseData = GetComponent<TileBase>();

        //specific tileMAP data (lava itc)
        // Debug.Log("Size " + tileMapData.size);
        // Debug.Log(tileMapData.GetSprite(gridData.WorldToCell(playerGameObject.transform.position)));
        // Debug.Log(tileMapData.(gridData.WorldToCell(playerGameObject.transform.position)));


        //specific tile info (lava itc)
        // TileBaseData

        //grid layout info (thing that holds the tilemaps)
        GridCoordinatesText.text = "Grid Coordinates: " + playerCellPosition;
    }

    public void TrackElevation(GameObject trackedObject) {
        // IF PLAYER ELEVATION IS NOT CHANGING REMEMBER THAT THE TILEMAPS NEEDS TO OVERLAP WHERE THE ELEVATION CHANGE HAPPENS 
        Vector3Int trackedObjectCellPosition;
        // Tilemap currentTilemap;
        // Tile currentTile;
        // currentTile = (Tile)tilemap.GetTile(playerCellPosition);
        trackedObjectCellPosition = gridData.WorldToCell(trackedObject.transform.position);//track player position in cell coordinates
        gridTilemaps = GetComponentsInChildren<Tilemap>(); //all Grid tilemaps
        List<int> elevations = new List<int>(); //list of elevations
        

        Vector3Int currentCoord = new Vector3Int(trackedObjectCellPosition.x, trackedObjectCellPosition.y, 0);
        
        foreach (var tilemap in gridTilemaps)
        {
            if (tilemap.HasTile(currentCoord)) {
                // Debug.Log("Tilemap Name: " + tilemap.name + " Tile: " + tilemap.GetTile(currentCoord) + "elevation: " + tilemap.transform.position.z);
                if (tilemap.transform.position.z <= trackedObjectCellPosition.z + 1)
                elevations.Add((int)tilemap.transform.position.z);
                }
        }
            // Debug.Log(elevations.Max());
            // Debug.Log(elevations.Count());
        trackedObject.transform.position = new Vector3(trackedObject.transform.position.x, trackedObject.transform.position.y, elevations.Max());
    }

    public void TrackTileMap(GameObject trackedObject) {
        // IF PLAYER ELEVATION IS NOT CHANGING REMEMBER THAT THE TILEMAPS NEEDS TO OVERLAP WHERE THE ELEVATION CHANGE HAPPENS 
        Vector3Int trackedObjectCellPosition;
        trackedObjectCellPosition = gridData.WorldToCell(trackedObject.transform.position);//track player position in cell coordinates
        gridTilemaps = GetComponentsInChildren<Tilemap>(); //all Grid tilemaps
        List<Tilemap> possibileTIlemaps = new List<Tilemap>();

        Vector3Int currentCoord = new Vector3Int(trackedObjectCellPosition.x, trackedObjectCellPosition.y, trackedObjectCellPosition.z);
        
        foreach (var tilemap in gridTilemaps)
        {
            if (tilemap.HasTile(trackedObjectCellPosition)) {
                Debug.Log(tilemap);
            }
        }
    }

}

