using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Inventorymanager : MonoBehaviour
{
    static Inventorymanager instance;

    public Inventory MyBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    //public GameObject emptySlot;
    public Text itemInformation;

    public List<GameObject> slots = new List<GameObject>();

     void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";

    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }

    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }



    public static void RefreshItem()
    {
        for(int i=0;i<instance.slotGrid.transform.childCount; i++)
        { if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);

                    }
        for(int i = 0; i < instance.MyBag.itemList.Count; i++)
        {
            CreateNewItem(instance.MyBag.itemList[i]);
            //instance.slots.Add(Instantiate(instance.emptySlot));
            //instance.slots[i].transform.SetParent(instance.slotGrid.transform);
        }
    }
}
