using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class GameOverControl : Singleton<GameOverControl> {

    public bool isDead = false;
	public void GameOver()
    {
        isDead = true;
        Time.timeScale = 0;
    }
}
