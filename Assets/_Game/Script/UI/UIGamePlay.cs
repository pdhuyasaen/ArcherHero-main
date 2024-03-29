using System.Collections;
using System.Collections.Generic;
using TMPro;
using UIExample;
using UnityEngine;

public class UIGameplay : UICanvas
{
    public override void Setup()
    {
        base.Setup();
    }

    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.GamePlay);
    }

    public override void CloseDirectly()
    {
        base.CloseDirectly();
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<UISetting>();
    }
}
