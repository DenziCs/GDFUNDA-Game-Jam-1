using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    [SerializeField] private GameObject[] itemReferenceList;
    [SerializeField] private GameObject[] junkReferenceList;
    [SerializeField] private GameObject[] drawerList;
    [SerializeField] public List<GameObject> itemList;
    
    private List<GameObject>[] drawerContents = new List<GameObject>[this.drawerList.Length];
    private float timer = 0.0f;
    private float SPAWN_INTERVAL = 5.0f;
    private int TOTAL_MAX = 16;
    private int DRAWER_MAX = 4;

    private bool HasSpace(int drawerIndex)
    {
        if (this.drawerContents[drawerIndex].Count < DRAWER_MAX) return true;
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

        Vector2 spawnPosition = drawerList[drawerIndex].transform.position;
        spawnPosition.x += Random.Range(-0.1f, 0.1f);
        spawnPosition.y += 0.3f; 

        this.itemReferenceList[itemIndex].transform.position = spawnPosition;
        this.itemList.Add(this.itemReferenceList[itemIndex]);
        this.drawerContents[drawerIndex].Add(this.itemReferenceList[itemIndex]);
    }

    private void SpawnJunkInDrawer(GameObject drawer)
    {
        int junkIndex = Random.Range(0, junkReferenceList.Length);
        GameObject newJunk = this.Spawn(this.junkReferenceList[junkIndex], drawer.transform);
        Vector2 spawnPosition = drawer.transform.position;
        spawnPosition.x += Random.Range(-0.1f, 0.1f);
        spawnPosition.y += 0.3f;

        newJunk.transform.position = spawnPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < this.itemReferenceList.Length; i++)
        {
            this.itemReferenceList[i].SetActive(false);
        }

        for(int i = 0; i < this.drawerList.Length; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                this.SpawnJunkInDrawer(this.drawerList[i]);
            }
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