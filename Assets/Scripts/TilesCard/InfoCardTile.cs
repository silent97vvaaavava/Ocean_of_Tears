using UnityEngine;
using UnityEngine.UI;

public class InfoCardTile : MonoBehaviour
{
    [SerializeField] Image imageCard;
    [SerializeField] Text nameCard;

    public void SetInfo(Sprite sprite, string name)
    {
        imageCard.sprite = sprite;
        nameCard.text = name;
    }

}
