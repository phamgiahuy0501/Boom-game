using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wallTile;
    public LayerMask explosionMask;

    public GameObject explosionPrefab;
    private bool isCrashed = false;
    public void Explode(Vector2 worldPos, bool isTriggerByAnotherBomb, int length)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);
        ExplodeCell(originCell);
        if (!isTriggerByAnotherBomb){
            GetComponent<AudioSource>().Play();
        }
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

        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        Instantiate(explosionPrefab, pos, Quaternion.identity);
        if (Physics2D.OverlapCircleAll(pos,0.1f,explosionMask,0f,0f).Length != 0){
            isCrashed = true;
        }
        if (isCrashed){
            isCrashed = false;
            return false;
        }
        return true;
    }
}
