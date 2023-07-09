using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class A4Manager : MonoBehaviour
{
    [SerializeField] private int araySize = 60000;
    private GameObject[] gOArray;

    private void Start()
    {
        gOArray = new GameObject[araySize];

        for (int i = 0; i < araySize; i++)
        {
            gOArray[i] = new GameObject();
            gOArray[i].transform.SetParent(transform);
            gOArray[i].tag = "Test";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            CompareWay1();

        if (Input.GetKeyDown(KeyCode.Keypad2))
            CompareWay2();
    }

    private void CompareWay1()
    {
        foreach (GameObject o in gOArray)
            if (o.CompareTag("Test"))
                Debug.Log("Tag Match");
            else
                Debug.Log("Tags Missmatch");
    }
    private void CompareWay2()
    {
        foreach (GameObject o in gOArray)
            if (o.tag == ("Test"))
                Debug.Log("Tag Match");
            else
                Debug.Log("Tags Missmatch");
    }

}