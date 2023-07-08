using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class A1Manager : MonoBehaviour
{
    [SerializeField] private Transform pool;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int objToSpawn = 2000;

    List<GameObject> objectsPool = new List<GameObject>();
    List<GameObject> createdObjectsHolder = new List<GameObject>();

    private void Start() { CreateObjects(pool); }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            CreateObjects(transform);

        if (Input.GetKeyDown(KeyCode.Keypad2))
            RemoveObjectsInList(createdObjectsHolder, true);

        if (Input.GetKeyDown(KeyCode.Keypad4))
            foreach (GameObject obj in objectsPool)
                obj.transform.position = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Keypad5))
            RemoveObjectsInList(objectsPool, false);
    }

    private void CreateObjects(Transform parent)
    {
        for (int i = 0; i < objToSpawn; i++)
        {
            if (prefab)
            {
                if (parent != transform)
                {
                    GameObject newParentedOBJ = Instantiate(prefab, parent);
                    objectsPool.Add(newParentedOBJ);
                    Debug.Log("object created in pool");
                }
                else
                {
                    GameObject newOBJ = Instantiate(prefab, parent);
                    createdObjectsHolder.Add(newOBJ);
                    Debug.Log("created an object");
                }
            }
        }
    }

    private void RemoveObjectsInList(List<GameObject> list, bool delete)
    {
        if (list.Count <= 0) { return; }

        if (delete)
        {
            foreach (GameObject obj in list)
            {
                Destroy(obj);
                Debug.Log("destoryed object");
            }

            list.Clear();
        }
        else
        {
            foreach (GameObject obj in list)
            {
                obj.transform.localPosition = Vector3.zero;
                Debug.Log("reset pooler");
            }
        }
    }

}