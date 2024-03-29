using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin : GameUnit
{
    [SerializeField] PantData pantData;

    [SerializeField] Transform head;
    [SerializeField] Transform rightHand;
    [SerializeField] Transform leftHand;
    [SerializeField] Renderer pant;

    [SerializeField] bool isCanChange = false;

    Weapon currentWeapon;
    CBWeapon currentCBWeapon;
    Hat currentHat;

    [SerializeField] Animator anim;
    public Animator Anim => anim;

    public Weapon Weapon => currentWeapon;
    public CBWeapon CBWeapon => currentCBWeapon;
    public void ChangeWeaponP(WeaponTypeP weaponTypeP)
    {
        currentWeapon = SimplePool.Spawn<Weapon>((PoolType)weaponTypeP, rightHand);
    }
    public void ChangeWeaponB(WeaponTypeB weaponTypeB)
    {
        currentWeapon = SimplePool.Spawn<Weapon>((PoolType)weaponTypeB, rightHand);
    }

    public void ChangeWeaponCB(WeaponTypeCB weaponTypeCB)
    {
        currentCBWeapon = SimplePool.Spawn<CBWeapon>((PoolType)weaponTypeCB, rightHand);
    }

    public void ChangeHat(HatType hatType)
    {
        if (isCanChange && hatType != HatType.HAT_None)
        {
            currentHat = SimplePool.Spawn<Hat>((PoolType)hatType, head);
        }
    }

    public void ChangePant(PantType pantType)
    {
        pant.material = pantData.GetPant(pantType);
    }

    public void OnDespawn()
    {
        SimplePool.Despawn(currentWeapon);
        if (currentHat) SimplePool.Despawn(currentHat);
    }

    public void DespawnHat()
    {
        if (currentHat) SimplePool.Despawn(currentHat);
    }

    internal void DespawnWeapon()
    {
        if (currentWeapon) SimplePool.Despawn(currentWeapon);
    }
}
