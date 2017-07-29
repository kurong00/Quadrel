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
        Application.targetFrameRate = 60;
        UIConstant = Constant.Instance();
        GRoot.inst.SetContentScaleFactor(UIConstant.HEIGHT, UIConstant.WIDE);
        UIPackage.AddPackage("UI/主界面");
        componentSelect = UIPackage.CreateObject("界面UI", "选择角色").asCom;
        GRoot.inst.AddChild(componentSelect);
        roleList = componentSelect.GetChild("list").asList;
        roleList.SetVirtualAndLoop();
        roleList.itemRenderer = RenderListItem;
        roleList.numItems = 7;
        roleList.scrollPane.onScroll.Add(DoSpecialEffect);
        DoSpecialEffect();
        roleList.GetChildAt(0).onClick.Add(SelectMushRoom);
        roleList.GetChildAt(1).onClick.Add(SelectCheese);
        roleList.GetChildAt(2).onClick.Add(SelectBlock);
        roleList.GetChildAt(3).onClick.Add(SelectSushi);
        roleList.GetChildAt(4).onClick.Add(SelectBrick);
        roleList.GetChildAt(5).onClick.Add(SelectWatermelon);
        roleList.GetChildAt(6).onClick.Add(SelectBread);
    }

    void RenderListItem(int index, GObject obj)
    {
        GButton item = (GButton)obj;
        item.pivot = new Vector2(0.5f, 0.5f);
        item.icon = UIPackage.GetItemURL("界面UI", "role" + index);
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
                float scale = 1 + (1 - dist / obj.width) * 0.25f;
                obj.SetScale(scale, scale);
            }
        }
        ShowRoleName();
    }

    int ReturnIndex()
    {
        return ((roleList.GetFirstChildInView()+2) % roleList.numItems);
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
            case 3:
                componentSelect.GetChild("text_role_name").text = "Sushi";
                break;
            case 4:
                componentSelect.GetChild("text_role_name").text = "Brick";
                break;
            case 5:
                componentSelect.GetChild("text_role_name").text = "Watermelon";
                break;
            case 6:
                componentSelect.GetChild("text_role_name").text = "Bread";
                break;
        }
    }

    void SelectMushRoom()
    {
        SceneTypeManager.Instance().currentType = SceneTypeManager.ScenesType.MONDAY;
        LoadGame();
    }

    void SelectCheese()
    {
        SceneTypeManager.Instance().currentType = SceneTypeManager.ScenesType.TUESDAY;
        LoadGame();
    }

    void SelectBlock()
    {
        SceneTypeManager.Instance().currentType = SceneTypeManager.ScenesType.WENESDAY;
        LoadGame();
    }

    void SelectSushi()
    {
        SceneTypeManager.Instance().currentType = SceneTypeManager.ScenesType.THURSDAY;
        LoadGame();
    }

    void SelectBrick()
    {
        SceneTypeManager.Instance().currentType = SceneTypeManager.ScenesType.FRIDAY;
        LoadGame();
    }

    void SelectWatermelon()
    {
        SceneTypeManager.Instance().currentType = SceneTypeManager.ScenesType.SATERDAY;
        LoadGame();
    }

    void SelectBread()
    {
        SceneTypeManager.Instance().currentType = SceneTypeManager.ScenesType.SUNDAY;
        LoadGame();
    }

    void LoadGame()
    {
        componentSelect.visible = false;
        SceneManager.LoadScene("Main");
    }
}
