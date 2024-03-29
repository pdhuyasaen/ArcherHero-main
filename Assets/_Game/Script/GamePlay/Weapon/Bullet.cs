
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GameUnit
{
    protected Character character;
    [SerializeField] protected float moveSpeed = 6f;
    protected bool isRunning;

    public virtual void OnInit(Character character, Vector3 target, float size)
    {
        this.character = character;
        TF.forward = (target - TF.position).normalized;
        isRunning = true;
    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    protected virtual void OnStop() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER) || other.CompareTag(Constant.TAG_ENEMY))
        {
            IHit hit = Cache.GetIHit(other);

            if (hit != null && hit != (IHit)character)
            {
                hit.TakeDamage(Random.Range(0.5f,2f));

                hit.OnHit(
                    () =>
                    {
                        ParticlePool.Play(Utilities.RandomInMember(ParticleType.Hit_1, ParticleType.Hit_2, ParticleType.Hit_3), TF.position);
                        SimplePool.Despawn(this);
                    });
            }
        }

        if (other.CompareTag(Constant.TAG_BLOCK))
        {
            OnStop();
        }

    }


}
