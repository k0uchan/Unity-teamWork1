using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    // Start is called before the first frame update

    public Item thisItem;
    public Inventory playerInventory;

    public int Score = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            AddNewItem();
            Destroy(gameObject);

            GameControl.Instance.totalScore += Score;
            GameControl.Instance.UpdateTotalScore();

        }

    }
    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add(thisItem);
            Inventorymanager.CreateNewItem(thisItem);
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        Inventorymanager.RefreshItem();
    }
}

