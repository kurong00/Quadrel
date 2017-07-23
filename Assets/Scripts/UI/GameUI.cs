﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class GameUI : MonoBehaviour {

    /// <summary>
    /// 单例相关
    /// </summary>
    private Constant UIConstant;
    private DataManager dataManager;
    /// <summary>
    /// UI中的组件相关
    /// </summary>
    GComponent componentNormal;
    /// <summary>
    /// 游戏界面UI按钮相关
    /// </summary>
    GButton buttonSound;
    GButton buttonPause;
    GButton buttonPlay;
    /// <summary>
    /// 游戏界面分数Text相关
    /// </summary>
    GTextField textScore;
    GTextField textCoin;
    void Start () {
        UIConstant = Constant.Instance();
        dataManager = DataManager.Instance();
        GRoot.inst.SetContentScaleFactor(UIConstant.HEIGHT, UIConstant.WIDE);
        UIPackage.AddPackage("UI/主界面");
        componentNormal = UIPackage.CreateObject("界面UI", "普通模式").asCom;
        GRoot.inst.AddChild(componentNormal);
        buttonSound = componentNormal.GetChild("button_sound").asButton;
        buttonPause = componentNormal.GetChild("button_pause").asButton;
        buttonPlay = componentNormal.GetChild("button_play").asButton;
        textScore = componentNormal.GetChild("text_score").asTextField;
        textCoin = componentNormal.GetChild("text_coin").asTextField;
    }
	
	void Update ()
    {
        buttonPlay.onClick.Add(ButtonPlayClick);
        buttonPause.onClick.Add(ButtonPauseClick);
        buttonSound.onClick.Add(ButtonSoundClick);
        RefreshScore();
    }

    public void RefreshScore()
    {
        textScore.text = dataManager.gameScroe.ToString();
        textCoin.text = dataManager.coinScroe.ToString();
    }

    public void RefreshGameScore(int score)
    {
        textCoin.text = score.ToString();
    }

    public void RefreshCoinScore(int coin)
    {
        textCoin.text = coin.ToString();
    }

    void ButtonSoundClick()
    {
        Debug.Log("点击了音量键");
    }

    void ButtonPauseClick()
    {
        buttonPause.visible = false;
        buttonPlay.visible = true;
    }
    void ButtonPlayClick()
    {
        buttonPause.visible = true;
        buttonPlay.visible = false;
    }
}