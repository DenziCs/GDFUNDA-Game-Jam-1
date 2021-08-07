using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectionHandling : MonoBehaviour
{
    [SerializeField] private Text selectionLabel;

    public GameObject selectedItem = null;

    public void SelectItem(GameObject item)
    {
        this.selectedItem = item;
        this.selectionLabel.text = item.GetComponent<ItemClass>().itemName;
    }

    public void DeselectItem()
    {
        this.selectedItem = null;
        this.selectionLabel.text = "---";
    }
}