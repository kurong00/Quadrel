using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class ProbabilityManager : Singleton<ProbabilityManager> {

    /// <summary>
    /// 坑洞陷阱概率，地面陷阱概率，天空陷阱概率，金币概率
    /// </summary>
    private static int pb_hole = 0;
    private static int pb_spikes = 0;
    private static int pb_sky_spikes = 0;
    private static int pb_coin = 2;

    /// <summary>
    /// 计算概率
    /// 0.瓷砖Tile
    /// 1.坑洞Hole
    /// 2.地面陷阱Spikes
    /// 3.天空陷阱Sky_Spikes
    /// </summary>
    /// <returns></returns>
    public int CalculatePb()
    {
        int pb = Random.Range(1, 1000);
        if (pb <= pb_hole)
        {
            return 1;
        }
        else if (301 < pb && pb < pb_spikes + 300)
        {
            return 2;
        }
        else if (601 < pb && pb < pb_sky_spikes + 600)
        {
            return 3;
        }

        return 0;
    }

    /// <summary>
    /// 计算奖励物品的概率
    /// </summary>
    /// <returns></returns>
    public bool CalculateCoin()
    {
        int pr = Random.Range(1, 100);
        if (pr == pb_coin)
            return true;
        return false;
    }
    
    /// <summary>
    /// 增加概率
    /// </summary>
    public void AddPb()
    {
        pb_hole += 2;
        pb_spikes += 1;
        pb_sky_spikes += 1;
    }
}
