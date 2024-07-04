using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    private Nodes target;

    public Text sellAmount;

    public void SetTarget(Nodes _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        ui.SetActive(true);

        sellAmount.text = "SELL $" + target.turretBlueprint.SellPrice();
    }

    public void Hide ()
    {
        ui.SetActive(false);
    }

    public void Sell ()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
