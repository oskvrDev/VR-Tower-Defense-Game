using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public int SellPrice()
    {
        return cost / 2;
    }
}
