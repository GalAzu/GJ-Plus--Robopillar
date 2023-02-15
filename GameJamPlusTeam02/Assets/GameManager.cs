using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TowersManager _towerManager { get; private set; }

    private void Awake()
    {
        _towerManager = GetComponent<TowersManager>();
        instance = this;
    }
    public void GameOver()
    {
        AudioManager.instance.musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void DissolveFog()
    {
        RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, 0, 10);
    }
}