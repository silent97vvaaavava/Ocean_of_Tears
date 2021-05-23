using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Item : MonoBehaviour, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerExitHandler
{
    public string info;
    public string nameItem;
    public TYPEITEM type;
    GameObject description;

    private TempInventoryCell thisCell;

    private CurrentInventoryCell targetCell;
    Vector3 targetPosition;
    Image targetSprite;
    private Vector3 positionInGrid;
    bool checkMove = false;

    // показать информацию в окне инфы
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!description.activeSelf)
        {
            description.SetActive(true);
        }
        if (thisCell)
        {
            thisCell.tittleText.text = nameItem;
            thisCell.descriptionText.text = info;
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (targetCell.item)
        {
            targetCell.item.gameObject.SetActive(false);
        }
        positionInGrid = GetComponent<RectTransform>().position; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (thisCell)
        {
            transform.position = eventData.pointerCurrentRaycast.worldPosition;
            targetSprite.color = Color.yellow;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        targetSprite.color = Color.white;

        if (Vector3.Distance(transform.GetComponent<RectTransform>().position, targetPosition) < 0.5f)
        {
            transform.GetComponent<RectTransform>().position = targetPosition;
            if (targetCell.item != null)
            {
                Destroy(targetCell.item.gameObject);
            }
            thisCell.item = null;
            targetCell.item = this;
            thisCell = null;
        }
        else
        {
            transform.GetComponent<RectTransform>().position = positionInGrid;
            if(targetCell.item)
            targetCell.item.gameObject.SetActive(true);
        }
    }

    public void GetPositionCell(CurrentInventoryCell[] cells, TempInventoryCell tempCell)
    {
        foreach (var item in cells)
        {
            if(item.typeCell == this.type)
            {
                targetCell = item;
                targetPosition = targetCell.GetComponent<RectTransform>().position;
                targetSprite = targetCell.GetComponent<Image>();
                description = tempCell.description;
                break;
            }
        }
        thisCell = tempCell;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (description.activeSelf)
        {
            description.SetActive(false);
        }
    }
}
