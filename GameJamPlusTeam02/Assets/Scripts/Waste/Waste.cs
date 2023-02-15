using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waste : MonoBehaviour , Icollectible
{
    public WasteData wasteData;
    public Tower towerToBelong;
    private Inventory inventory;

    private void Awake()
    {
        wasteData.name = wasteData._wasteType.ToString();
        inventory = FindObjectOfType<Inventory>();
    }

    public void Collect()
    {
        Destroy(gameObject);
        OnWasteCollected?.Invoke(wasteData);
        towerToBelong.wasteInRadius.Remove(this);
        towerToBelong.wasteLeftOnTower--;
        inventory.curCapacity += wasteData.quantityToAdd;
        UImanager.instance.towerWaste.text = towerToBelong.wasteLeftOnTower.ToString();
    }

    public void AttachToTower(Tower tower)
    {
        if(tower != null)
        towerToBelong = tower;
    }
}
