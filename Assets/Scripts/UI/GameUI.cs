using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FairyGUI;
using FrameWork;

public class GameUI : Singleton<GameUI> {

    /// <summary>
    /// 单例相关
    /// </summary>
    private Constant UIConstant;
    private DataManager dataManager;
    private GameControl gameControl;
    /// <summary>
    /// UI中的组件相关
    /// </summary>
    GComponent componentNormal;
    GComponent componentGameOver;
    /// <summary>
    /// 游戏界面UI按钮相关
    /// </summary>
    GButton buttonSound;
    GButton buttonPause;
    GButton buttonPlay;
    GButton buttonLeft;
    GButton buttonRight;
    GButton buttonReplay;
    /// <summary>
    /// 游戏界面分数Text相关
    /// </summary>
    GTextField textScore;
    GTextField textCoin;
    GTextField textEndScore;
    void Start () {
        UIConfig.defaultFont = "Blackentina 4F";
        UIConstant = Constant.Instance();
        dataManager = DataManager.Instance();
        gameControl = GameControl.Instance();
        GRoot.inst.SetContentScaleFactor(UIConstant.HEIGHT, UIConstant.WIDE);
        UIPackage.AddPackage("UI/主界面");
        componentNormal = UIPackage.CreateObject("界面UI", "普通模式").asCom;
        GRoot.inst.AddChild(componentNormal);
        componentGameOver = UIPackage.CreateObject("界面UI", "游戏结束").asCom;
        GRoot.inst.AddChild(componentGameOver);
        componentGameOver.visible = false;
        buttonSound = componentNormal.GetChild("button_sound").asButton;
        buttonPause = componentNormal.GetChild("button_pause").asButton;
        buttonPlay = componentNormal.GetChild("button_play").asButton;
        buttonLeft = componentNormal.GetChild("button_left").asButton;
        buttonRight = componentNormal.GetChild("button_right").asButton;
        textScore = componentNormal.GetChild("text_score").asTextField;
        textCoin = componentNormal.GetChild("text_coin").asTextField;
        textEndScore = componentGameOver.GetChild("text_end_score").asTextField;
        buttonReplay = componentGameOver.GetChild("button_replay").asButton;
    }
	
	void Update ()
    {
        buttonPlay.onClick.Add(ButtonPlayClick);
        buttonPause.onClick.Add(ButtonPauseClick);
        buttonSound.onClick.Add(ButtonSoundClick);
        buttonLeft.onClick.Add(ButtonLeftClick);
        buttonRight.onClick.Add(ButtonRightClick);
        buttonReplay.onClick.Add(ButtonRePlayClick);
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
        gameControl.isPlaying = false;
        buttonPause.visible = false;
        buttonPlay.visible = true;
    }
    void ButtonPlayClick()
    {
        gameControl.isPlaying = true;
        buttonPause.visible = true;
        buttonPlay.visible = false;
        PlayerControl.Instance().StartGame();
        buttonLeft.visible = true;
        buttonRight.visible = true;
    }

    void ButtonLeftClick()
    {
        PlayerControl.Instance().GoLeft();
        buttonLeft.alpha = 0;
    }

    void ButtonRightClick()
    {
        PlayerControl.Instance().GoRight();
        buttonRight.alpha = 0;
    }

    void ButtonRePlayClick()
    {
        componentGameOver.visible = false;
        gameControl.ReStartGame();
    }

    public void GameOverScene()
    {
        componentNormal.visible = false;
        componentGameOver.visible = true;
        textEndScore.text = dataManager.gameScroe.ToString();
    }
}
