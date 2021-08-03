using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandling : MonoBehaviour
{
    public void OpenDrawer(GameObject drawer)
    {
        drawer.SetActive(true);
    }

    public void CloseDrawer(GameObject drawer)
    {
        drawer.SetActive(false);
    }
}