using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectionHandling : MonoBehaviour
{
    public GameObject selectedItem = null;

    public void SelectItem(GameObject item)
    {
        this.selectedItem = item;
        if (item.GetComponent<ItemClass>() != null) this.GetComponentInParent<UpdateUI>().UpdateSelectedItem(item.GetComponent<ItemClass>().itemName);
        else this.GetComponentInParent<UpdateUI>().UpdateSelectedItem("PAPER");
    }

    public void DeselectItem()
    {
        this.selectedItem = null;
        this.GetComponentInParent<UpdateUI>().UpdateSelectedItem("---");
    }

    public void GiveItem()
    {
        if (this.selectedItem != null) this.GetComponentInParent<StudentSpawning>().ReceiveItem(this.selectedItem);
    }
}