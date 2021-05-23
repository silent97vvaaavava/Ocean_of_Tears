using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Добавляет на поле колладер для определения действия
/// </summary>
public class AddTileEvent : MonoBehaviour
{
    [SerializeField] GameObject gameObjectEvent;
    [SerializeField] TypeTilesCard typeTile;

    private void OnDestroy()
    {
        if (!typeTile.buttonEvent)
        {
            Instantiate(gameObjectEvent, transform.position, Quaternion.identity).name = $"Tile Event {gameObject.name}";
        }
    }

}
