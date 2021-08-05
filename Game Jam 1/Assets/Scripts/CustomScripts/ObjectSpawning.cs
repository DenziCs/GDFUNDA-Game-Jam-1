using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    [SerializeField] private GameObject[] itemReferenceList;
    [SerializeField] private GameObject[] drawerList;
    [SerializeField] private List<GameObject> itemList;

    private float timer = 0.0f;
    private float SPAWN_INTERVAL = 5.0f;
    private int TOTAL_MAX = 35;
    private int DRAWER_MAX = 10;

    private bool HasSpace(int drawerIndex)
    {
        if (this.drawerList.Length < DRAWER_MAX) return true;
        else return false;
    }

    private void SpawnItemInDrawer()
    {
        int itemIndex = Random.Range(0, itemReferenceList.Length);
        while (itemReferenceList[itemIndex].activeSelf)
        {
            itemIndex = (itemIndex + 1) % (this.itemReferenceList.Length);
        }
        itemReferenceList[itemIndex].SetActive(true);

        int drawerIndex = Random.Range(0, drawerList.Length);
        while (!this.HasSpace(drawerIndex))
        {
            drawerIndex = (drawerIndex + 1) % (this.drawerList.Length);
        }

        Vector2 spawnPosition = drawerList[drawerIndex].transform.position;
        spawnPosition.x += Random.Range(-0.1f, 0.1f);
        spawnPosition.y += 0.3f; 

        this.itemReferenceList[itemIndex].transform.position = spawnPosition;
        this.itemList.Add(this.itemReferenceList[itemIndex]);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < this.itemReferenceList.Length; i++)
        {
            this.itemReferenceList[i].SetActive(false);
        }

        for(int i = 0; i < 1; i++)
        {
            this.SpawnItemInDrawer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;

        if (this.timer >= this.SPAWN_INTERVAL)
        {
            this.timer = 0.0f;
            if(this.itemList.Count < this.TOTAL_MAX) this.SpawnItemInDrawer();
        }
    }
}