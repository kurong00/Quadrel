using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class DataManager : Singleton<DataManager> {
    
    public int gameScroe;
    public int coinScroe;
    void Start ()
    {
        gameScroe = 0;
        coinScroe = PlayerPrefs.GetInt("COIN_SCORE", 0);
    }
    

    public void AddGameScore ()
    {
        gameScroe += 1;
    }

    public int GetGameScore()
    {
        return gameScroe;
    }

    public int GetCoinScore()
    {
        return coinScroe;
    }

    public void AddCoinScore()
    {
        coinScroe += 10;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("COIN_SCORE", coinScroe);
        if (SceneTypeManager.Instance().GameMode==Constant.Instance().CHANLLENGE)
        {
            PlayerPrefs.SetInt("LAST_GAME_CHANLLENGE_SCORE", gameScroe);
            if (gameScroe > PlayerPrefs.GetInt("BEST_GAME_CHANLLENGE_SCORE", 0))
            {
                PlayerPrefs.SetInt("BEST_GAME_CHANLLENGE_SCORE", gameScroe);
            }
        }
        else
        {
            PlayerPrefs.SetInt("LAST_GAME_SCORE", gameScroe);
            if (gameScroe > PlayerPrefs.GetInt("BEST_GAME_SCORE", 0))
            {
                PlayerPrefs.SetInt("BEST_GAME_SCORE", gameScroe);
            }
        }
    }
}
