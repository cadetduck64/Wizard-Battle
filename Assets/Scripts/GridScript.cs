using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

// all tilemaps, in the eyes of the grid are on Z level 0
//the way Z index is determined is on the tilemap's Transform Z value
public class GridScript : MonoBehaviour
{
    public Tilemap tileMapData;
    public TileBase tileBaseData;
    public Grid gridData;
    public GameObject playerGameObject;
    public TextMeshProUGUI GridCoordinatesText;
    public Tilemap[] gridTilemaps;

    // Update is called once per frame

    void Update()
    {
        Vector3Int playerCellPosition;
        playerCellPosition = gridData.WorldToCell(playerGameObject.transform.position);//track player position in cell coordinates
        TransparentTilemap(playerGameObject);// makes the tilemap/ tilemap walls transparent
        TrackTileMap(playerGameObject).SetColor(playerCellPosition, new Color(0, 0, 0, 0f));


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

    public void TrackElevation(GameObject trackedObject)
    {
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
            if (tilemap.HasTile(currentCoord))
            {
                // Debug.Log("Tilemap Name: " + tilemap.name + " Tile: " + tilemap.GetTile(currentCoord) + "elevation: " + tilemap.transform.position.z);
                if (tilemap.transform.position.z <= trackedObjectCellPosition.z + 1)
                    elevations.Add((int)tilemap.transform.position.z);
            }
        }
        // Debug.Log(elevations.Max());
        // Debug.Log(elevations.Count());
        if (elevations.Count > 0)
        { trackedObject.transform.position = new Vector3(trackedObject.transform.position.x, trackedObject.transform.position.y, elevations.Max()); }
    }


    public Tilemap TrackTileMap(GameObject trackedObject)
    {
        // IF PLAYER ELEVATION IS NOT CHANGING REMEMBER THAT THE TILEMAPS NEEDS TO OVERLAP WHERE THE ELEVATION CHANGE HAPPENS 
        Vector3Int trackedObjectCellPosition;
        trackedObjectCellPosition = gridData.WorldToCell(trackedObject.transform.position);//track player position in cell coordinates
        gridTilemaps = GetComponentsInChildren<Tilemap>(); //all Grid tilemaps
        List<Tilemap> possibileTIlemaps = new List<Tilemap>();

        Vector3Int currentCoord = new Vector3Int(trackedObjectCellPosition.x, trackedObjectCellPosition.y, 0);
        // Debug.Log(trackedObjectCellPosition);

        foreach (var tilemap in gridTilemaps)
        {
            if (tilemap.HasTile(currentCoord) && tilemap.transform.position.z == trackedObjectCellPosition.z)
            {
                return tilemap;
            }
        }
        return gridTilemaps[0];
    }

    public void TransparentTilemap(GameObject trackedObject)
    {
        Tilemap[] gameobjectChildTilemaps = TrackTileMap(trackedObject).gameObject.GetComponentsInChildren<Tilemap>();

        foreach (var item in gridTilemaps)
        {
            item.color = new Color(item.color.r, item.color.g, item.color.b, 1);
        }

        if (gameobjectChildTilemaps.Count() > 0 &&  TrackTileMap(trackedObject).CompareTag("Building"))
        {
            foreach (var item in gameobjectChildTilemaps)
            {
                // Debug.Log(item);
                if (item.CompareTag("Wall"))
                    {item.color = new Color(item.color.r, item.color.g, item.color.b, 0.2f);}
                else if (item.CompareTag("Roof"))
                    {item.color = new Color(item.color.r, item.color.g, item.color.b, 0);}
            }
            return;
        }
        // else
        // {
        //     TrackTileMap(trackedObject).color = new Color(1, 1, 1, 0.5f);
        //     return;
        // }
    }

}

