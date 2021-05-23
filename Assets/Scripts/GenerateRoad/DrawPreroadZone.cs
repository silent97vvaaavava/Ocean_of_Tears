using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class DrawPreroadZone : MonoBehaviour
{
    [SerializeField] Tilemap mapTrajectory;
    [SerializeField] Tilemap mapPreroad;
    [SerializeField] Tilemap mapSea;
    // тайл который поставим
    [SerializeField] TileBase tileThis;


    private void Update()
    {
        SwapTileForMap();
    }

    void SwapTileForMap()
    {
        var positionTile = mapTrajectory.WorldToCell(transform.position);

        // если под объектом нет тайла из этих двух карт, то добавить на карту предорожного
        if(!mapTrajectory.HasTile(positionTile) && !mapPreroad.HasTile(positionTile))
        {
            mapPreroad.SetTile(positionTile, tileThis);
            if (mapSea.HasTile(positionTile)) mapSea.SetTile(positionTile, null);
        }
    }

}
