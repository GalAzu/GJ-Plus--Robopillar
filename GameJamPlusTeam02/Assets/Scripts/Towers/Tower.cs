using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tower : MonoBehaviour
{
    [SerializeField] private float towerDetectionRadius;
    [SerializeField] public List<Waste> wasteInRadius = new();
    [SerializeField] private LayerMask wasteMask;
    public int wasteLeftOnTower = 0;
    public int towerWaste;
    private void Start()
    {
        Collider[] getWasteInRadiusCastColliders = Physics.OverlapSphere(transform.position, towerDetectionRadius, wasteMask);
        
        foreach(var collider in getWasteInRadiusCastColliders)
        {
            if(collider != null)
            {
                collider.GetComponent<Waste>().towerToBelong = this;
                wasteInRadius.Add(collider.GetComponent<Waste>());
            }
        }
        towerWaste = getWasteInRadiusCastColliders.Length;
        wasteLeftOnTower = getWasteInRadiusCastColliders.Length;
        AttachWasteToTower();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, towerDetectionRadius);
        
    }
    private void AttachWasteToTower()
    {
        foreach (var waste in wasteInRadius)
        {
            waste.AttachToTower(this);
        }
    }
    public void RemoveWasteFromTower(Waste waste) => wasteInRadius.Remove(waste);
}
