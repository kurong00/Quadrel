using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class UIManager : MonoBehaviour {

    /// <summary>
    /// 单例相关
    /// </summary>
    private Constant UIConstant;

    /// <summary>
    /// UI中的控制器相关
    /// </summary>
    Controller controllerLine;
    /// <summary>
    /// UI中的动效相关
    /// </summary>
    void Start () {
        UIConstant = Constant.Instance();
        GRoot.inst.SetContentScaleFactor(UIConstant.HEIGHT, UIConstant.WIDE);
        UIPackage.AddPackage("UI/主界面");
        GComponent componentMain = UIPackage.CreateObject("主界面", "主界面").asCom;
        GRoot.inst.AddChild(componentMain);
        GComponent ComponentLine = componentMain.GetChild("n2").asCom;
        controllerLine = ComponentLine.GetController("line_c");
    }
	
	void Update () {
        controllerLine.selectedIndex = 1;
	}
}
