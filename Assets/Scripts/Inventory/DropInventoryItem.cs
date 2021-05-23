using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// рандомно получаем после боя или ловли рыбы
public class DropInventoryItem : MonoBehaviour
{
    public static DropInventoryItem _instantion;

    [Header("Клетки"), SerializeField] TempInventoryCell[] itemsOnCell;
    [Header("Массив всех предметов"), SerializeField] Item[] items;

    [Header("Массив клеток улучшения корабля"), SerializeField] CurrentInventoryCell[] cells;
    // метод получения случайного предмета

    private void Awake()
    {
        _instantion = this;
    }

    public void GetRandomItem()
    {
        System.Random random = new System.Random();

        int currentItem = random.Next(items.Length-1);

        for (int i = 0; i < itemsOnCell.Length; i++)
        {
            if (itemsOnCell[i].item == null)
            {
                // помещаем поверх нее наш предмет
                var item = Instantiate(items[currentItem].gameObject, transform.GetComponent<RectTransform>());
                itemsOnCell[i].item = item.GetComponent<Item>();
                item.GetComponent<RectTransform>().position = itemsOnCell[i].GetComponent<RectTransform>().position;
                item.GetComponent<Item>().GetPositionCell(cells, itemsOnCell[i]);
                break;
            }
            else 
                if(itemsOnCell[itemsOnCell.Length - 1].item != null)
            {
                var item = Instantiate(items[currentItem].gameObject, transform.GetComponent<RectTransform>());

                Destroy(itemsOnCell[itemsOnCell.Length - 1].item.gameObject);
                item.GetComponent<RectTransform>().position = itemsOnCell[itemsOnCell.Length - 1].GetComponent<RectTransform>().position;
                itemsOnCell[itemsOnCell.Length - 1].item = item.GetComponent<Item>();
                item.GetComponent<Item>().GetPositionCell(cells, itemsOnCell[itemsOnCell.Length - 1]);
            }

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetRandomItem();
        }
    }

}
