using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Bot : Character
{
    Vector3 destination;
    [SerializeField] protected NavMeshAgent agent;
    protected IState<Bot> currentState;

    private CounterTime counter = new CounterTime();
    public CounterTime Counter => counter;

    private bool IsCanRunning => (GameManager.Ins.IsState(GameState.GamePlay) || GameManager.Ins.IsState(GameState.Setting));

    private void Update()
    {
        if (IsCanRunning && currentState != null && !IsDead)
        {
            currentState.OnExecute(this);
        }
    }

    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = state;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }

    }
    public override void OnInit()
    {
        base.OnInit();
        SetMask(false);
        ResetAnim();
        LevelManager.Ins.OnAddEnemy(this);
    }

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
        CancelInvoke();
        Destroy(healthBar.gameObject);
    }

    public override void OnDeath()
    {
        ChangeState(null);
        OnMoveStop();
        base.OnDeath();
        SetMask(false);
        Invoke(nameof(OnDespawn), 2f);
    }

    public override void OnMoveStop()
    {
        base.OnMoveStop();
        agent.enabled = false;
        ChangeAnim(Constant.ANIM_IDLE);
    }

    public bool IsDestination => Vector3.Distance(TF.position, destination) - Mathf.Abs(TF.position.y - destination.y) < ATT_RANGE;

    public void SetDestination(Vector3 point)
    {
        destination = point;
        agent.enabled = true;
        agent.SetDestination(destination);
        ChangeAnim(Constant.ANIM_RUN);
    }

    //public override void AddTarget(Character target)
    //{
    //    base.AddTarget(target);

    //    if (!IsDead /*&& Utilities.Chance(50, 100) */&& IsCanRunning)
    //    {
    //        ChangeState(new AttackState());  
    //    }
    //}

}
