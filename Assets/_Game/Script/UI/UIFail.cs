using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFail : UICanvas
{
    [SerializeField] RectTransform mainMenuPoint;

    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.Finish);
    }

    public void MainMenuButton()
    {
        LevelManager.Ins.Home();
    }
}
