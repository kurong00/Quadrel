using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class Constant :Singleton<Constant>
{
    /// <summary>
    /// 地图相关的常量
    /// </summary>
    public float TILE_DOWN_TIME = 0.5f;
    public int TILE_DOWN_DISTANCE = 8;
    public float BOTTOM_LENGTH = Mathf.Sqrt(2) * 0.254f;
    /// <summary>
    /// 概率相关常量
    /// </summary>
    public int COUNT_COIN_OBJECT_POOL = 20;
    /// <summary>
    /// 障碍物相关常量
    /// </summary>
    public int SPIKES_FALL_TIME = 25;
    public float SPIKES_WAIT_TIME = 2.0f;
    /// <summary>
    /// UI常量相关
    /// </summary>
    public int HEIGHT = 1920;
    public int WIDE = 1080;
    /// <summary>
    /// 游戏得分相关
    /// </summary>
    public int PER_STEP_SCORE = 1;
    public int PER_COIN_SCORE = 10;
    public string KEY_LAST_GAME_SCORE = "LAST_GAME_SCORE";
    public string KEY_BEST_GAME_SCORE = "BEST_GAME_SCORE";
    public string KEY_COIN_SCORE = "COIN_SCORE";
    /// <summary>
    /// 游戏类型
    /// </summary>
    public int NORMAL = 0;
    public int CHANLLENGE = 1;
    /// <summary>
    /// 挑战模式
    /// </summary>
    public float ALLTIME = 30f;

}
