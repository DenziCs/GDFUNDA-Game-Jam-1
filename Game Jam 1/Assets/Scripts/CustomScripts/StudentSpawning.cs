using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentSpawning : MonoBehaviour
{
    [SerializeField] private GameObject studentSprite;
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject[] descriptors;

    private float maxPatience = 20.0f;
    private float patience = 20.0f;
    private float timer;

    private const float IN_POS_X = -100.0f;
    private const float OUT_POS_X = 320.0f;
    private const float SPEED = 200.0f;

    private bool isEntering = false;
    private bool isExiting = false;
    private bool isOccupied = false;

    public GameObject currentObject = null;

    private void StudentEnter()
    {
        this.isEntering = true;
    }

    private void StudentExit()
    {
        this.speechBubble.SetActive(false);
        this.currentObject = null;
        this.isOccupied = false;
        this.isExiting = true;
    }

    public void ReceiveItem(GameObject item)
    {
        if (item.GetComponent<ItemClass>() != null)
        {
            if (item.GetComponent<ItemClass>().ID == currentObject.GetComponent<ItemClass>().ID)
            {
                this.GetComponentInParent<ObjectSpawning>().RemoveItemFromDrawer(item, item.GetComponent<ItemClass>().drawerNumber);
                int bonusPoints = (int)((this.patience / this.maxPatience) * 100);
                this.GetComponentInParent<UpdateUI>().UpdateScore(100 + bonusPoints);
                this.patience = this.maxPatience;
                this.StudentExit();
            }

            else this.patience -= 5.0f;
        }

        else this.patience -= 5.0f;
    }

    private void ChooseItem()
    {
        int itemIndex = Random.Range(0, this.GetComponentInParent<ObjectSpawning>().itemList.Count);
        if (this.currentObject == null) this.currentObject = this.GetComponentInParent<ObjectSpawning>().itemList[itemIndex];
        Debug.Log(itemIndex);
    }

    void Start()
    {
        this.timer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.isExiting && !this.isEntering) 
        {
            if (!this.isOccupied) this.timer -= Time.deltaTime;
            else this.patience -= Time.deltaTime;
        }

        if (this.speechBubble.activeSelf)
        {
            this.GetComponentInParent<UpdateUI>().UpdatePatience((int)patience);
        }

        if(this.patience <= 0.0f)
        {
            this.patience = this.maxPatience;
            this.GetComponentInParent<UpdateUI>().UpdateStrikeCount();
            StudentExit();
        }

        if (this.isExiting)
        {
            Vector2 currentPos = this.studentSprite.transform.localPosition;
            currentPos.x += SPEED * Time.deltaTime;
            if (currentPos.x >= OUT_POS_X)
            {
                currentPos.x = -420.0f;
                this.isExiting = false;
            }
            this.studentSprite.transform.localPosition = currentPos;
        }

        if(this.timer <= 0.0f)
        {
            this.timer = Random.Range(0.5f, 5.0f);
            this.StudentEnter();
        }

        if (this.isEntering)
        {
            Vector2 currentPos = this.studentSprite.transform.localPosition;
            currentPos.x += SPEED * Time.deltaTime;
            if (currentPos.x >= IN_POS_X)
            {
                currentPos.x = IN_POS_X;
                this.isOccupied = true;
                this.ChooseItem();
                this.speechBubble.SetActive(true);
                this.descriptors[0].GetComponent<Text>().text = this.currentObject.GetComponent<ItemClass>().GeneralDescriptor;
                this.descriptors[1].GetComponent<Text>().text = this.currentObject.GetComponent<ItemClass>().Specific1;
                this.descriptors[2].GetComponent<Text>().text = this.currentObject.GetComponent<ItemClass>().Specific2;
                this.isEntering = false;
            }
            this.studentSprite.transform.localPosition = currentPos;
        }
    }
}