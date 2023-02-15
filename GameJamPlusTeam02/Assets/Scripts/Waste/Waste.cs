using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waste : MonoBehaviour , Icollectible
{
    public WasteData wasteData;
    public Tower towerToBelong;
    private Inventory inventory;
    private TowersManager _towerManager;

    private void OnEnable()
    {
        TowersManager.OnWasteCollected += Collect;

    }
    private void OnDisable()
    {
        TowersManager.OnWasteCollected -= Collect;
    }
    private void Awake()
    {
        wasteData.name = wasteData._wasteType.ToString();
        inventory = FindObjectOfType<Inventory>();
    }

    public void Collect()
    {
        towerToBelong.wasteInRadius.Remove(this);
        towerToBelong.wasteLeftOnTower--;
        inventory.curCapacity += wasteData.quantityToAdd;
        UImanager.instance.towerWaste.text = towerToBelong.wasteLeftOnTower.ToString();
        DetachFromTower(towerToBelong);
        inventory.AddToInventory(wasteData);
        Destroy(gameObject);
    }

    public void AttachToTower(Tower tower)
    {
        if(tower != null)
        towerToBelong = tower;
    }
    private void DetachFromTower(Tower tower) => towerToBelong = null;
}
