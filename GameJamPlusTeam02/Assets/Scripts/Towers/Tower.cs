using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tower : MonoBehaviour
{
    [SerializeField] private float towerDetectionRadius;
    [SerializeField] public List<Collider> wasteInRadius = new List<Collider>();
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
                wasteInRadius.Add(collider);
            }
        }
        towerWaste = getWasteInRadiusCastColliders.Length;
        wasteLeftOnTower = getWasteInRadiusCastColliders.Length;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, towerDetectionRadius);
        
    }
}
