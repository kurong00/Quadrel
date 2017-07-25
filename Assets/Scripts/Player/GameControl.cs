using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;
using UnityEngine.SceneManagement;

public class GameControl : Singleton<GameControl> {

    public bool isDead = false;
    public bool isPlaying = false;
    private GameUI gameUI;
    private PlayerControl playerControl;
    private CameraManager cameraManager;
    private MapManager mapManager;

    private void Start()
    {
        gameUI = GameUI.Instance();
        playerControl = PlayerControl.Instance();
        cameraManager = CameraManager.Instance();
        mapManager = MapManager.Instance();
    }
    public IEnumerator GameOver(bool isFall)
    {
        if (isFall)
            yield return new WaitForSeconds(1.5f);
        if (!isDead)
        {
            yield return new WaitForSeconds(0.5f);
            Time.timeScale = 0;
            gameUI.GameOverScene();
            isDead = true;
            DataManager.instance.SaveScore();
        }
    }

    public void ReStartGame()
    {
        
    }

    private void ResetPlayer()
    {
        
    }

    private void ResetMap()
    {

    }

    private void ResetCamera()
    {

    }

}
