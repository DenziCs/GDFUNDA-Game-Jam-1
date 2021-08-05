using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawning : MonoBehaviour
{
    [SerializeField] private GameObject[] studentRefList;

    private float maxPatience = 5.0f;
    private float patience = 5.0f;
    private float timer;

    private const float IN_POS_X = -8.5f;
    private const float OUT_POS_X = -0.5f;
    private const float SPEED = 8.0f;

    private GameObject activeStudent = null;
    private bool isEntering = false;
    private bool isExiting = false;

    private GameObject Spawn(GameObject templateObject, Transform parentTransform)
    {
        GameObject obj = GameObject.Instantiate(templateObject, parentTransform);
        obj.SetActive(true);
        return obj;
    }

    private void StudentEnter()
    {
        if (this.activeStudent == null) {
            int studentIndex = Random.Range(0, this.studentRefList.Length);
            GameObject newStudent = this.Spawn(this.studentRefList[studentIndex], null);
            Vector2 spawnPosition = this.studentRefList[studentIndex].transform.position;
            newStudent.transform.position = spawnPosition;
            this.activeStudent = newStudent;
        }
        this.isEntering = true;
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
            if (this.activeStudent == null) this.timer -= Time.deltaTime;
            else this.patience -= Time.deltaTime;
        }

        if(this.patience <= 0.0f)
        {
            this.patience = this.maxPatience;
            if(this.activeStudent != null)
            {
                this.isExiting = true;
            }
        }

        if (this.isExiting)
        {
            Vector2 currentPos = this.activeStudent.transform.position;
            currentPos.x += SPEED * Time.deltaTime;
            if (currentPos.x >= OUT_POS_X)
            {
                GameObject.Destroy(this.activeStudent);
                this.activeStudent = null;
                this.isExiting = false;
            }
            if (this.activeStudent != null) this.activeStudent.transform.position = currentPos;
            if (currentPos.x >= OUT_POS_X)
            {
                this.activeStudent = null;
            }
        }

        if(this.timer <= 0.0f)
        {
            this.timer = Random.Range(0.5f, 5.0f);
            this.StudentEnter();
        }

        if (this.isEntering)
        {
            Vector2 currentPos = this.activeStudent.transform.position;
            currentPos.x += SPEED * Time.deltaTime;
            if (currentPos.x >= IN_POS_X)
            {
                currentPos.x = IN_POS_X;
                this.isEntering = false;
            }
            this.activeStudent.transform.position = currentPos;
        }
    }
}