using System.Collections;
using System.Collections.Generic;
using UIExample;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] Level[] levels;
    [SerializeField] private List<Bot> bots = new List<Bot>();
    
    public Player player;
    public Level currentLevel;
    private int levelIndex;

    private void Start()
    {
        levelIndex = 0;
        OnLoadLevel(levelIndex);
        OnInit();
    }

    private void OnInit()
    {
        Vector3 index = currentLevel.startPoint.position;
        
        NavMesh.RemoveAllNavMeshData();
        NavMesh.AddNavMeshData(currentLevel.navMeshData);

        player.TF.position = index;
        player.TF.rotation = Quaternion.identity;

        player.OnInit();


    }

    public void OnReset()
    {
        player.OnDespawn();
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].OnDespawn();
        }

        bots.Clear();
        SimplePool.CollectAll();
    }


    public Vector3 GetPlayerPosition()
    {
        return player.TF.position;
    }

    public void OnSpawnBot()
    {
        currentLevel.OnSpawnBot();
    }

    public void OnAddEnemy(Bot bot)
    {
        bots.Add(bot);
    }


    public void OnLoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }

        if (level < levels.Length)
        {
            currentLevel = Instantiate(levels[level]);
        }
        else
        {
            //TODO: level vuot qua limit
        }
        OnSpawnBot();
    }

    public void OnStartGame()
    {
        GameManager.Ins.ChangeState(GameState.GamePlay);
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].ChangeState(new PatrolState());
        }
    }

    public void CharecterDeath(Character c)
    {
        if (c is Player)
        {
            UIManager.Ins.CloseAll();
            {             
                Fail();
            }
        }
        else
        if (c is Bot)
        {
            bots.Remove(c as Bot);

            if (bots.Count == 0)
            {
                currentLevel.finishBox.SetActive(true);
            }
        }

    }

    private void Victory()
    {
        //UIManager.Ins.CloseAll();
        //UIManager.Ins.OpenUI<UINextLevel>();
        //player.ChangeAnim(Constant.ANIM_WIN);
    }

    public void Fail()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UIFail>();
    }

    public void Home()
    {
        UIManager.Ins.CloseAll();
        OnReset();
        OnLoadLevel(levelIndex);
        OnInit();
        UIManager.Ins.OpenUI<UIMainMenu>();
    }

    public void NextLevel()
    {
        levelIndex++;
        PlayerPrefs.SetInt("Level", levelIndex);
        OnReset();
        OnLoadLevel(levelIndex);
        OnInit();
    }

    public void OnPlay()
    {
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].ChangeState(new PatrolState());
        }
    }

}


