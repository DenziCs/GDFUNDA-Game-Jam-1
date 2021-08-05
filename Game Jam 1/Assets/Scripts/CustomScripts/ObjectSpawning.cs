using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    [SerializeField] private GameObject[] referenceList;
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

    private GameObject Spawn(GameObject templateObject, GameObject parent)
    {
        GameObject obj = GameObject.Instantiate(templateObject, parent.transform);
        obj.SetActive(true);
        return obj;
    }

    private void SpawnItemInDrawer()
    {
        int drawerIndex = Random.Range(0, drawerList.Length);
        while (!this.HasSpace(drawerIndex))
        {
            drawerIndex = (drawerIndex + 1) % (this.drawerList.Length);
        }

        GameObject newItem = this.Spawn(referenceList[Random.Range(0, referenceList.Length)], drawerList[drawerIndex]);
        Vector2 spawnPosition = drawerList[drawerIndex].transform.position;
        newItem.transform.position = spawnPosition;
        this.itemList.Add(newItem);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 12; i++)
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
            this.SpawnItemInDrawer();
        }
    }
}