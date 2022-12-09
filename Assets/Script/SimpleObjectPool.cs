using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour
{
    [SerializeField] GameObject objectPrebaf;
    List<GameObject> poolObjects = new List<GameObject>();
    int objectIndex;

    private void Awake()
    {
        for(int i = 0; i <100; i++)
        {
            poolObjects.Add(Instantiate(objectPrebaf));
        }
    }

    public GameObject Get()
    {
        objectIndex %= poolObjects.Count;
        return poolObjects[objectIndex++];
    }
}
