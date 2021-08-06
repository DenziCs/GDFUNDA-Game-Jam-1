using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawning : MonoBehaviour
{
    [SerializeField] private GameObject studentSprite;

    private float maxPatience = 5.0f;
    private float patience = 5.0f;
    private float timer;

    private const float IN_POS_X = -100.0f;
    private const float OUT_POS_X = 320.0f;
    private const float SPEED = 200.0f;

    private bool isEntering = false;
    private bool isExiting = false;
    private bool isOccupied = false;

    private void StudentEnter()
    {
        this.isEntering = true;
    }

    public void StudentExit()
    {
        this.isExiting = true;
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

        if(this.patience <= 0.0f)
        {
            this.patience = this.maxPatience;
            this.isOccupied = false;
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
                this.isEntering = false;
            }
            this.studentSprite.transform.localPosition = currentPos;
        }
    }
}