using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    [SerializeField] private GameObject[] itemReferenceList;
    [SerializeField] private GameObject[] junkReferenceList;
    [SerializeField] private GameObject[] drawerList;
    [SerializeField] public List<GameObject> itemList;
    
    private List<int> drawerCounts;
    private float timer = 0.0f;
    private float SPAWN_INTERVAL = 5.0f;
    private int TOTAL_MAX = 16;
    private int DRAWER_MAX = 4;

    private bool HasSpace(int drawerIndex)
    {
        if (this.drawerCounts[drawerIndex] < DRAWER_MAX) return true;
        else return false;
    }

    private GameObject Spawn(GameObject templateObject, Transform parentTransform)
    {
        GameObject obj = GameObject.Instantiate(templateObject, parentTransform);
        obj.SetActive(true);
        return obj;
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

        GameObject newItem = this.Spawn(this.itemReferenceList[itemIndex], drawerList[drawerIndex].transform);
        Vector2 spawnPosition = drawerList[drawerIndex].transform.position;
        spawnPosition.x += Random.Range(-2.0f, 2.0f);
        spawnPosition.y += 0.3f; 

        newItem.transform.position = spawnPosition;
        this.itemList.Add(newItem);
        this.drawerCounts[drawerIndex] += 1;
    }

    public void RemoveItemFromDrawer(GameObject item, int drawerIndex)
    {
        for(int i = 0; i < this.itemList.Count; i++)
        {
            if(this.itemList[i] == item)
            {
                this.drawerCounts[drawerIndex] -= 1;

            }
        }
    }

    private void SpawnJunkInDrawer(GameObject drawer)
    {
        int junkIndex = Random.Range(0, junkReferenceList.Length);
        GameObject newJunk = this.Spawn(this.junkReferenceList[junkIndex], drawer.transform);
        Vector2 spawnPosition = drawer.transform.position;
        spawnPosition.x += Random.Range(-2.0f, 2.0f);
        spawnPosition.y += 0.3f;

        newJunk.transform.position = spawnPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.drawerCounts = new List<int>();

        for (int i = 0; i < this.itemReferenceList.Length; i++)
        {
            this.itemReferenceList[i].SetActive(false);
        }

        for(int i = 0; i < this.drawerList.Length; i++)
        {
            this.drawerCounts.Add(0);
            for (int j = 0; j < 6; j++)
            {
                this.SpawnJunkInDrawer(this.drawerList[i]);
            }
        }

        for(int i = 0; i < 8; i++)
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