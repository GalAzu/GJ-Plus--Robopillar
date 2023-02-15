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
    private TowersManager _towerManager;
    public int wasteLeftOnTower = 0;
    public int towerWaste;
    private void Awake()
    {
        _towerManager = FindObjectOfType<TowersManager>();  //REFACTOR
    }
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
        if (_towerManager != null)
            _towerManager.AttachWasteToTower(this);

        towerWaste = getWasteInRadiusCastColliders.Length;
        wasteLeftOnTower = getWasteInRadiusCastColliders.Length;
    }
    private void OnDrawGizmos()=> Gizmos.DrawWireSphere(transform.position, towerDetectionRadius);
}
