using System.Collections;
using System.Collections.Generic;
using UIExample;
using UnityEngine;

public enum GameState { 
    MainMenu, 
    GamePlay, 
    Finish, 
    Pause, 
    Setting 
}

public class GameManager : Singleton<GameManager>
{
    private GameState gameState;

    public void ChangeState(GameState gameState)
    {
        this.gameState = gameState;
    }

    public bool IsState(GameState gameState) => this.gameState == gameState;

    private void Awake()
    {
        //tranh viec nguoi choi cham da diem vao man hinh
        Input.multiTouchEnabled = false;
        //target frame rate ve 60 fps
        Application.targetFrameRate = 60;
        //tranh viec tat man hinh
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //xu tai tho
        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * (float)maxScreenHeight), maxScreenHeight, true);
        }

        //Init data
        UserData.Ins.OnInitData();
    }

    private void Start()
    {
        UIManager.Ins.OpenUI<UIMainMenu>();
    }
}
