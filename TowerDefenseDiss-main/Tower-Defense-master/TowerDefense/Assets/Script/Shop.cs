using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint doublecannonTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectFirstTurret ()
    {
        Debug.Log("standardturret");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectDoubleCannon()
    {
        Debug.Log("doublecannonturret");
        buildManager.SelectTurretToBuild(doublecannonTurret);
    }


 
}
