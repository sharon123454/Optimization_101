using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class B1Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] movingObjPrefabs;
    [SerializeField] private GameObject[] lightPrefabs;
    [SerializeField] private GameObject[] floors;
    [SerializeField] private int lightsToSpawn = 50, movingObjToSpawn = 1000;

    private List<GameObject> objects;
    System.Random rand = new System.Random();

    void Start()
    {
        objects = new List<GameObject>(lightsToSpawn + movingObjToSpawn);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SetLitMat(true);
            SpawnThings(movingObjPrefabs[0], lightPrefabs[0]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SetLitMat(true);
            SpawnThings(movingObjPrefabs[0], lightPrefabs[1]);
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
            foreach (GameObject obj in objects)
                Destroy(obj);

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SetLitMat(false);
            SpawnThings(movingObjPrefabs[1], lightPrefabs[1]);
        }
    }

    private void SpawnThings(GameObject ballPrefab, GameObject lightPrefab)
    {
        Vector3 offset = Vector3.zero;
        for (int i = 0; i < lightsToSpawn; i++)
        {
            offset = new Vector3(rand.Next(-45, 45), 45, rand.Next(-45, 45));
            objects.Add(Instantiate(lightPrefab, transform.position + offset, lightPrefab.transform.rotation, transform));
        }
        for (int i = 0; i < movingObjToSpawn; i++)
        {
            objects.Add(Instantiate(ballPrefab, transform.position, Quaternion.identity, transform));
        }
    }

    private void SetLitMat(bool isActive)
    {
            floors[0].SetActive(isActive);
            floors[1].SetActive(!isActive);
    }

}