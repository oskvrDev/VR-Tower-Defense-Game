using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Nodes : MonoBehaviour { 


    public Color hoverColor;

    public Color notEnoughMoney;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    public TurretBlueprint turretBlueprint;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (turret != null)
        {
            buildManager.selectNode(this);
            return;
        }


        if (!buildManager.CanBuild)
            return;

        buildManager.BuildTurretOn(this);
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.SellPrice();
        Debug.Log(turretBlueprint.SellPrice());
        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }else
        {
            rend.material.color = notEnoughMoney;
        }    
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }



    public void VRDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.selectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        buildManager.BuildTurretOn(this);
    }

    public void VRHover()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoney;
        }
    }

        public void VRHoverExit ()
    {
        rend.material.color = startColor;
    }
}
