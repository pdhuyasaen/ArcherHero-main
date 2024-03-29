using System.Collections;
using System.Collections.Generic;
using TMPro;
using UIExample;
using UnityEngine;

public class UIMainMenu : UICanvas
{
    private const string ANIM_OPEN = "Open";
    private const string ANIM_CLOSE = "Close";
    [SerializeField] Animation anim;

    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.MainMenu);
        CameraFollower.Ins.ChangeState(CameraFollower.State.MainMenu);
        anim.Play(ANIM_OPEN);
    }


    public void SettingButton()
    {

    }

    public void PlayButton()
    {
        LevelManager.Ins.OnPlay();
        UIManager.Ins.OpenUI<UIGameplay>();
        CameraFollower.Ins.ChangeState(CameraFollower.State.Gameplay);

        Close(0.5f);
        anim.Play(ANIM_CLOSE);
    }

    public void ShopButton()
    {
        UIManager.Ins.OpenUI<UIShop>();
        Close(0.5f);
        anim.Play(ANIM_CLOSE);
    }
}

