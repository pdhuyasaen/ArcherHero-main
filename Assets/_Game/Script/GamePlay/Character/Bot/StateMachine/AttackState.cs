using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackState : IState<Bot>
{
    //float timer;
    public void OnEnter(Bot t)
    {
        if (t.IsCanAttack)
        {
            t.OnMoveStop();
            t.OnAttack();
            t.Counter.Start(
                () =>
                {
                    t.Throw();
                    t.Counter.Start(
                    () =>
                    {
                        t.ChangeState(Utilities.Chance(50, 100) ? new IdleState() : new PatrolState());

                    }, Character.TIME_DELAY_THROW);
                }, Character.TIME_DELAY_THROW
            );
        }

        //if (t.IsCanCBAttack)
        //{
        //    t.OnMoveStop();
        //    t.OnCBAttack();
        //    t.Counter.Start(
        //        () =>
        //        {
        //            t.Counter.Start(
        //            () =>
        //            {
        //                t.ChangeState(Utilities.Chance(50, 100) ? new IdleState() : new PatrolState());

        //            }, Character.TIME_DELAY_THROW);
        //        }, Character.TIME_DELAY_THROW
        //    );
        //}

    }

    public void OnExecute(Bot t)
    {
        t.Counter.Execute();
    }

    public void OnExit(Bot t)
    {
    }

}
