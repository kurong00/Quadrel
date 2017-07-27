using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using FrameWork;
using UnityEngine.SceneManagement;

public class SelectUI : MonoBehaviour {

    GList roleList;
    /// <summary>
    /// 单例相关
    /// </summary>
    private Constant UIConstant;
    /// <summary>
    /// UI中的组件相关
    /// </summary>
    GComponent componentSelect;
    void Start () {
        UIConstant = Constant.Instance();
        GRoot.inst.SetContentScaleFactor(UIConstant.HEIGHT, UIConstant.WIDE);
        UIPackage.AddPackage("UI/主界面");
        componentSelect = UIPackage.CreateObject("界面UI", "选择角色").asCom;
        GRoot.inst.AddChild(componentSelect);
        roleList = componentSelect.GetChild("list").asList;
        roleList.SetVirtualAndLoop();
        roleList.itemRenderer = RenderListItem;
        roleList.numItems = 2;
        roleList.scrollPane.onScroll.Add(DoSpecialEffect);
        DoSpecialEffect();
    }

    void RenderListItem(int index, GObject obj)
    {
        GButton item = (GButton)obj;
        item.icon = UIPackage.GetItemURL("列表素材", "role" + index );
    }

    void DoSpecialEffect()
    {
        float midX = roleList.scrollPane.posX + roleList.viewWidth / 2;
        int count = roleList.numChildren;
        for (int i = 0; i < count; i++)
        {
            GObject obj = roleList.GetChildAt(i);
            float dist = Mathf.Abs(midX - obj.x - obj.width / 2);
            if (dist > obj.width)
                obj.SetScale(1, 1);
            else
            {
                float scale = 1 + (1 - dist / obj.width) * 0.20f;
                obj.SetScale(scale, scale);
            }
        }
        ShowRoleName();
    }

    int ReturnIndex()
    {
        return ((roleList.GetFirstChildInView() + 1) % roleList.numItems);
    }

    void ShowRoleName()
    {
        switch (ReturnIndex())
        {
            case 0:
                componentSelect.GetChild("text_role_name").text = "MushRoom";
                break;
            case 1:
                componentSelect.GetChild("text_role_name").text = "Cheese";
                break;
            case 2:
                componentSelect.GetChild("text_role_name").text = "Block";
                break;
        }
    }
}
