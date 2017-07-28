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
    private MusicManager musicManager;
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
    GButton buttonQuit;
    /// <summary>
    /// 游戏界面分数Text相关
    /// </summary>
    GTextField textScore;
    GTextField textCoin;
    GTextField textEndScore;
    GTextField textTime;
    /// <summary>
    /// 倒计时相关
    /// </summary>
    GImage clock;
    Transition clockTransition;
    void Start () {
        UIConfig.defaultFont = "Blackentina 4F";
        UIConstant = Constant.Instance();
        dataManager = DataManager.Instance();
        gameControl = GameControl.Instance();
        musicManager = MusicManager.Instance();
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
        buttonQuit = componentNormal.GetChild("button_quit").asButton;
        textScore = componentNormal.GetChild("text_score").asTextField;
        textCoin = componentNormal.GetChild("text_coin").asTextField;
        textTime = componentNormal.GetChild("text_time").asTextField;
        clock = componentNormal.GetChild("clock").asImage;
        textEndScore = componentGameOver.GetChild("text_end_score").asTextField;
        buttonReplay = componentGameOver.GetChild("button_replay").asButton;
        clockTransition = componentNormal.GetTransition("clock_t");
        if(SceneTypeManager.Instance().GameMode==Constant.Instance().CHANLLENGE)
        {
            textTime.visible = true;
            clock.visible = true;
            StartCoroutine(CountTime());
        }
    }
	
	void Update ()
    {
        buttonPlay.onClick.Add(ButtonPlayClick);
        buttonPause.onClick.Add(ButtonPauseClick);
        buttonSound.onClick.Add(ButtonSoundClick);
        buttonLeft.onClick.Add(ButtonLeftClick);
        buttonRight.onClick.Add(ButtonRightClick);
        buttonReplay.onClick.Add(ButtonRePlayClick);
        buttonQuit.onClick.Add(ButtonQuitClick);
        RefreshUI();
    }

    public void RefreshUI()
    {
        textScore.text = dataManager.gameScroe.ToString();
        textCoin.text = dataManager.coinScroe.ToString();
        if (textTime.visible)
        {
            textTime.text = gameControl.nowTime.ToString();
        }
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
        if(musicManager.isPlayingMusic)
            musicManager.StopMusic();
        else
            musicManager.PlayMusic();
    }

    void ButtonPauseClick()
    {
        musicManager.PlayButtonSound();
        gameControl.isPlaying = false;
        buttonPause.visible = false;
        buttonPlay.visible = true;
        buttonQuit.visible = true;
        Time.timeScale = 0;
    }
    void ButtonPlayClick()
    {
        musicManager.PlayButtonSound();
        gameControl.isPlaying = true;
        buttonPause.visible = true;
        buttonPlay.visible = false;
        buttonQuit.visible = false;
        PlayerControl.Instance().StartGame();
        buttonLeft.visible = true;
        buttonRight.visible = true;
        Time.timeScale = 1;
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
        musicManager.PlayButtonSound();
        componentGameOver.visible = false;
        gameControl.ReStartGame();
        componentNormal.visible = true;
    }

    public void GameOverScene()
    {
        musicManager.PlayLoseSound();
        componentNormal.visible = false;
        componentGameOver.visible = true;
        textEndScore.text = dataManager.gameScroe.ToString();
    }

    public void ButtonStopMove()
    {
        buttonRight.visible = false;
        buttonLeft.visible = false;
    }

    public void ButtonBeginMove()
    {
        buttonRight.visible = true;
        buttonLeft.visible = true;
    }

    public void ButtonQuitClick()
    {
        Application.Quit();
    }
    
    IEnumerator CountTime()
    {
        while (true)
        {
            if (gameControl.nowTime >= 0)
            {
                yield return new WaitForSeconds(1);
                gameControl.nowTime--;
                if(gameControl.nowTime <= 5)
                {
                    clockTransition.Play();
                }
                if (gameControl.nowTime == 0)
                {
                    StartCoroutine(gameControl.GameOver(false));
                }
            }
        }
    }
}
