using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private List<Tower> towersList;
    [SerializeField]
    private int _towersInScene;
    private int totalWasteOnScene;

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
    public void OnTowerDestroy(Tower tower)
    {
        _towersInScene--;
        towersList.Remove(tower);
    }
}
