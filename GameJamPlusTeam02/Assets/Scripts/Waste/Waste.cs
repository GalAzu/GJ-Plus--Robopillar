using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waste : MonoBehaviour , Icollectible
{
    public static event HandleWasteCollection OnWasteCollected;
    public delegate void HandleWasteCollection(WasteData wasteData);
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
        towerToBelong.wasteInRadius.Remove(this.gameObject.GetComponent<Collider>());
        towerToBelong.wasteLeftOnTower--;
        inventory.curCapacity += wasteData.quantityToAdd;
        UImanager.instance.towerWaste.text = towerToBelong.wasteLeftOnTower.ToString();
    }
}
