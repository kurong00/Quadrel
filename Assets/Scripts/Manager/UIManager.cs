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
    /// UI中的控制器相关
    /// </summary>
    //Controller controllerLine;
    /// <summary>
    /// UI中的动效相关
    /// </summary>
    Transition transitionLine;
    Transition transitionButtonNormal;
    Transition transitionButtonChanllenge;
    Transition transitionButtonExit;
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
        GComponent componentMain = UIPackage.CreateObject("主界面", "主界面").asCom;
        GRoot.inst.AddChild(componentMain);
        GComponent ComponentLine = componentMain.GetChild("line").asCom;
        transitionLine = ComponentLine.GetTransition("line_t");
        buttonNormal= componentMain.GetChild("button_normal").asButton;
        buttonChanllenge = componentMain.GetChild("button_chanllenge").asButton;
        buttonExit = componentMain.GetChild("button_exit").asButton;
        transitionButtonNormal = componentMain.GetTransition("button_t");
        transitionButtonChanllenge = componentMain.GetTransition("button_t");
        transitionButtonExit = componentMain.GetTransition("button_t");
    }
	
	void Update ()
    {
        buttonNormal.onClick.Add(LoadNormalScene);
        buttonExit.onClick.Add(GameExit);
    }

    void LoadNormalScene()
    {
        SceneManager.LoadScene("Main");
    }

    void GameExit()
    {
        Application.Quit();
    }
    
}
