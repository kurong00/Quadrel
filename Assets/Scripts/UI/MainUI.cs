using FrameWork;
using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour {

    /// <summary>
    /// 单例相关
    /// </summary>
    private Constant UIConstant;
    /// <summary>
    /// UI中的组件相关
    /// </summary>
    GComponent componentMain;
    /// <summary>
    /// 主UI界面中的按钮相关
    /// </summary>
    GButton buttonNormal;
    GButton buttonChanllenge;
    GButton buttonExit;
    
    void Start () {
        UIConstant = Constant.Instance();
        GRoot.inst.SetContentScaleFactor(UIConstant.HEIGHT, UIConstant.WIDE);
        UIPackage.AddPackage("UI/主界面");
        componentMain = UIPackage.CreateObject("界面UI", "主界面").asCom;
        GRoot.inst.AddChild(componentMain);
        buttonNormal = componentMain.GetChild("button_normal").asButton;
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
        MainGameInitLoad();
    }

    void LoadChanllengeScene()
    {
        MainGameInitLoad();
    }

    void GameExit()
    {
        Application.Quit();
    }

    void MainGameInitLoad()
    {
        SceneManager.LoadScene("Main");
        componentMain.visible = false;
    }

    

}
