using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBWeapon : GameUnit
{
    public const float TIME_WEAPON_RELOAD = 0.5f;

    [SerializeField] GameObject child;

    public bool IsCanCBAttack => child.activeSelf;

    public void SetActive(bool active)
    {
        child.SetActive(active);
    }

    private void OnEnable()
    {
        SetActive(true);
    }
}
