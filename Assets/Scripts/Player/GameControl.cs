using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class GameControl : Singleton<GameControl> {

    public bool isDead = false;
    public bool isPlaying = false;
    private GameUI gameUI;

    private void Start()
    {
        gameUI = GameUI.Instance();
    }
    public void GameOver()
    {
        gameUI.GameOverScene();
        isDead = true;
        Time.timeScale = 0;
        DataManager.instance.SaveScore();
    }
}
