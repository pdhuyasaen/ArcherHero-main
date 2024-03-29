using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public class Level : MonoBehaviour
{
    [SerializeField] private List<BotSpawn> botSpawns = new();

    public NavMeshData navMeshData;
    public Transform startPoint;
    public Transform finishPoint;
    public GameObject finishBox;

    public void OnSpawnBot()
    {
        for (int i = 0; i < botSpawns.Count; i++)
            for (int j = 0; j < botSpawns[i].spawnPoints.Count; j++)
                SimplePool.Spawn<Bot>((PoolType)botSpawns[i].botType,
                        botSpawns[i].spawnPoints[j].position, botSpawns[i].spawnPoints[j].rotation)
                    .OnInit();
    }
}
[Serializable]
internal class BotSpawn
{
    public BotType botType;
    public List<Transform> spawnPoints;
}
