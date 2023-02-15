using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersManager : MonoBehaviour , Icollectible
{
    private List<Tower> towersList;
    [SerializeField]
    private int _towersInScene;
    private int totalWasteOnScene;
    public static event HandleWasteCollection OnWasteCollected;
    public delegate void HandleWasteCollection();
    public Waste wasteToHandle;


    private void Awake()
    {
        GameObject[] towersInScene = GameObject.FindGameObjectsWithTag("Tower");
        foreach(var tower in towersInScene )
        {
            _towersInScene++;
            var towerComp = GetComponent<Tower>();
            towersList.Add(towerComp);
        }
    }
    public void AttachWasteToTower(Tower tower)
    {
        foreach (var waste in tower.wasteInRadius)
        {
            waste.AttachToTower(tower);
        }
    }
    public void OnTowerDestroy(Tower tower)
    {
        _towersInScene--;
        towersList.Remove(tower);
    }

    public void Collect()
    {
        OnWasteCollected?.Invoke();
    }

}
