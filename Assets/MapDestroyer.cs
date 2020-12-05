using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wallTile;
    public Tile destructibleTile;

    public GameObject explosionPrefab;
    public int length = 3;
    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);
        ExplodeCell(originCell);
        bool left = true;
        bool right = true;
        bool up = true;
        bool down = true;
        for (int i=1;i <= length;i++){
            if (right) right = ExplodeCell(originCell + new Vector3Int(i, 0, 0));
            if (left) left = ExplodeCell(originCell + new Vector3Int(-i, 0, 0));
            if (up) up = ExplodeCell(originCell + new Vector3Int(0, i, 0));
            if (down) down = ExplodeCell(originCell + new Vector3Int(0, -i, 0));
            
        }
    }
    
    bool ExplodeCell(Vector3Int cell) 
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        if (tile == wallTile)
        {
            return false;
        }
        
        if (tile == destructibleTile)
        {
            tilemap.SetTile(cell, null);
        }

        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        Instantiate(explosionPrefab,pos, Quaternion.identity);
        return true;
    }
}
