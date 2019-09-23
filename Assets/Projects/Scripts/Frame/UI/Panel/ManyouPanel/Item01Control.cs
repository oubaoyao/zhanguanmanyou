using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item01Control : MonoBehaviour
{
    public static Item01Control Instance;

    public List<GameObject> ItemGroup = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

}
