using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    /// <summary>
    /// 单例相关
    /// </summary>
    private Constant UIConstant;
    /// <summary>
    /// UI中的组件相关
    /// </summary>
    GComponent componentMain;
    GComponent componentNormal;

    /// <summary>
    /// UI中的动效相关
    /// </summary>
    //Transition transitionLine;

    /// <summary>
    /// UI中的按钮相关
    /// </summary>
    GButton buttonNormal;
    GButton buttonChanllenge;
    GButton buttonExit;
    void Start () {
        UIConstant = Constant.Instance();
        GRoot.inst.SetContentScaleFactor(UIConstant.HEIGHT, UIConstant.WIDE);
        UIPackage.AddPackage("UI/主界面");
        componentMain = UIPackage.CreateObject("界面UI", "主界面").asCom;
        componentNormal = UIPackage.CreateObject("界面UI", "普通模式").asCom;
        GRoot.inst.AddChild(componentMain);

        GComponent ComponentLine = componentMain.GetChild("line").asCom;
        buttonNormal= componentMain.GetChild("button_normal").asButton;
        buttonChanllenge = componentMain.GetChild("button_chanllenge").asButton;
        buttonExit = componentMain.GetChild("button_exit").asButton;
    }
	
	void Update ()
    {
        buttonNormal.onClick.Add(LoadNormalScene);
        buttonChanllenge.onClick.Add(LoadChanllengeScene);
        buttonExit.onClick.Add(GameExit);
    }

    void LoadNormalScene()
    {
        SceneManager.LoadScene("Main");
        GRoot.inst.AddChild(componentNormal);
        componentMain.alpha = 0;
    }

    void LoadChanllengeScene()
    {
        SceneManager.LoadScene("Main");
    }

    void GameExit()
    {
        Application.Quit();
    }
    
}
