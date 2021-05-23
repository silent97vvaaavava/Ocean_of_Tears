using UnityEngine;

public class Tile : MonoBehaviour
{
    protected TypeTilesCard typeTile;

    private void Awake()
    {
        typeTile = GetComponent<TypeTilesCard>();
    }

    public virtual void GetCharacteristics() { }
    

}
