using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class Constant :Singleton<Constant>{

    /// <summary>
    /// 地图相关的常量
    /// </summary>
    public float TILE_DOWN_TIME = 0.5f;
    public int TILE_DOWN_DISTANCE = 8;
    public float BOTTOM_LENGTH = Mathf.Sqrt(2) * 0.254f;
}
