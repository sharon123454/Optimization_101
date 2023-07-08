using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class A3Manager : MonoBehaviour
{
    List<GameObject> list = new List<GameObject>(30000);

    private void Start()
    {
        for (int i = 0; i < 30000; i++)
            list.Add(null);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (NullCheckWay1())
                Debug.Log("all obj are NULL");
            else
                Debug.Log("found a not NULL element");
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (NullCheckWay2())
                Debug.Log("all obj are NULL");
            else
                Debug.Log("found a not NULL element");
        }
    }

    private bool NullCheckWay1()
    {
        foreach (GameObject obj in list)
            if (!System.Object.ReferenceEquals(obj, null))
                return false;

        return true;
    }

    private bool NullCheckWay2()
    {
        foreach (GameObject obj in list)
            if (obj)
                return false;

        return true;
    }

}