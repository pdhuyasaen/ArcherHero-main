using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackArea : GameUnit
{
    protected Character character;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER) || other.CompareTag(Constant.TAG_ENEMY))
        {
            IHit hit = Cache.GetIHit(other);

            if (hit != null && hit != (IHit)character)
            {
                hit.TakeDamage(Random.Range(0.5f, 2f));

                hit.OnHit(
                    () =>
                    {
                        ParticlePool.Play(Utilities.RandomInMember(ParticleType.Hit_1, ParticleType.Hit_2, ParticleType.Hit_3), TF.position);
                    });
            }
        }
    }
}
