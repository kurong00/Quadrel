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
}
