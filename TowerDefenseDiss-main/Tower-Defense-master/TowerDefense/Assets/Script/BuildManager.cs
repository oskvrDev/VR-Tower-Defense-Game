using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    //using a singleton pattern to make sure that there isn't more than one buildmanaager in the scene

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one buildmanger in scene");
            return;
        }
        instance = this;
    }

    public GameObject standardturret;
    public GameObject doublecannonturret;
    public GameObject missileturret;

    

    private TurretBlueprint turretToBuild;
    private Nodes SelectedNode;

    public NodeUI nodeUI;

    //E 11
    public bool CanBuild {get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (Nodes node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("not enough money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Build! Money left: " + PlayerStats.Money);

    }
    public void selectNode (Nodes node)
    {
        if (SelectedNode == node)
        {
            DeselectNode();
            return;
        }

        SelectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        SelectedNode = null;
        nodeUI.Hide();
    }    
    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }


}
