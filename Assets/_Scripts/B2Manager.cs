using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class B2Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] UI_ImagePrefabs;
    [SerializeField] private Transform[] canvasParents;
    [SerializeField] private int amountToSpawn = 100;

    private List<GameObject> objects;
    System.Random rand = new System.Random();

    void Start()
    {
        objects = new List<GameObject>(amountToSpawn * 2);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            SpawnThings(false);

        if (Input.GetKeyDown(KeyCode.Keypad2))
            ClearObjects();

        if (Input.GetKeyDown(KeyCode.Keypad3))
            SpawnThings(true);
    }

    private void SpawnThings(bool isStaticUI)
    {
        if (objects.Count > 0)
            ClearObjects();

        Vector3 offset = Vector3.zero;

        if (!isStaticUI)
        {
            for (int i = 0; i < amountToSpawn; i++)
            {
                offset = new Vector2(rand.Next(0, Screen.width), rand.Next(0, Screen.height));
                objects.Add(Instantiate(UI_ImagePrefabs[1], transform.position + offset, Quaternion.identity, canvasParents[0]));
                objects.Add(Instantiate(UI_ImagePrefabs[0], transform.position + offset, UI_ImagePrefabs[0].transform.rotation, canvasParents[0]));
            }
        }
        else
        {
            for (int i = 0; i < amountToSpawn; i++)
            {
                offset = new Vector2(rand.Next(0, Screen.width), rand.Next(0, Screen.height));
                objects.Add(Instantiate(UI_ImagePrefabs[1], transform.position + offset, Quaternion.identity, canvasParents[0]));
                GameObject staticImage = Instantiate(UI_ImagePrefabs[0], transform.position + offset, UI_ImagePrefabs[0].transform.rotation, canvasParents[1]);
                staticImage.isStatic = true;
                objects.Add(staticImage);
            }
        }
    }

    private void ClearObjects()
    {
        foreach (GameObject obj in objects)
            Destroy(obj);
    }

}