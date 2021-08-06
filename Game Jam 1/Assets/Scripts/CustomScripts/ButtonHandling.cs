using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandling : MonoBehaviour
{
    [SerializeField] private GameObject[] drawerButtons;

    private const float OPEN_POS_Y = 1.0f;
    private const float CLOSED_POS_Y = 9.0f;
    private const float SPEED = 20.0f;

    private GameObject activeDrawer = null;
    private bool isOpening = false;
    private bool isClosing = false;

    public void OpenDrawer(GameObject drawer)
    {
        for (int i = 0; i < drawerButtons.Length; i++)
        {
            this.drawerButtons[i].SetActive(false);
        }

        this.activeDrawer = drawer;
        this.isOpening = true;
    }

    public void CloseDrawer(GameObject drawer)
    {
        for(int i = 0; i < drawerButtons.Length; i++)
        {
            this.drawerButtons[i].SetActive(true);
        }

        this.activeDrawer = drawer;
        this.isClosing = true;
    }

    private void Update()
    {
        if (this.isOpening)
        {
            Vector2 currentPos = this.activeDrawer.transform.position;
            currentPos.y -= SPEED * Time.deltaTime;
            if(currentPos.y <= OPEN_POS_Y)
            {
                currentPos.y = OPEN_POS_Y;
                this.isOpening = false;
            }
            this.activeDrawer.transform.position = currentPos;
            if (currentPos.y <= OPEN_POS_Y)
            {
                this.activeDrawer = null;
            }
        }

        if (this.isClosing)
        {
            Vector2 currentPos = this.activeDrawer.transform.position;
            currentPos.y += SPEED * Time.deltaTime;
            if (currentPos.y >= CLOSED_POS_Y)
            {
                currentPos.y = CLOSED_POS_Y;
                this.isClosing = false;
            }
            this.activeDrawer.transform.position = currentPos;
            if (currentPos.y >= CLOSED_POS_Y)
            {
                this.activeDrawer = null;
            }
        }
    }
}