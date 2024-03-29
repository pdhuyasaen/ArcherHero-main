using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed = 5f;

    private bool isMoving = false;

    private CounterTime counter = new CounterTime();

    private bool IsCanUpdate => GameManager.Ins.IsState(GameState.GamePlay) || GameManager.Ins.IsState(GameState.Setting);

    SkinType skinType = SkinType.SKIN_Normal;
    WeaponTypeP weaponTypeP = WeaponTypeP.PW_Hammer_1;
    HatType hatType = HatType.HAT_Cap;
    PantType pantType = PantType.Pant_1;

    // Update is called once per frame
    void Update()
    {
        if (IsCanUpdate && !IsDead)
        {

            if (Input.GetMouseButtonDown(0))
            {
                counter.Cancel();
            }

            if (Input.GetMouseButton(0) && JoystickControl.direct != Vector3.zero)
            {
                //rb.velocity = JoystickControl.direct * moveSpeed;
                //rb.MovePosition(rb.position + JoystickControl.direct * moveSpeed * Time.deltaTime);
                TF.position = TF.position + JoystickControl.direct * moveSpeed * Time.deltaTime;
                TF.forward = JoystickControl.direct;

                ChangeAnim(Constant.ANIM_RUN);
                isMoving = true;
            }
            else
            {
                counter.Execute();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isMoving = false;
                OnMoveStop();
                OnAttack();
            }
        }
    }

    public override void OnInit()
    {
        OnTakeClothsData();

        base.OnInit();
        SetSize(MIN_SIZE);
        TF.rotation = Quaternion.Euler(Vector3.up * 180);
    }

    public override void WearClothes()
    {
        base.WearClothes();

        ChangeSkin(skinType);
        ChangeWeaponP(weaponTypeP);
        ChangeHat(hatType);
        ChangePant(pantType);
    }

    public override void AddTarget(Character target)
    {
        base.AddTarget(target);

        if (!target.IsDead && !IsDead)
        {
            target.SetMask(true);
            if (!counter.IsRunning && !isMoving)
            {
                OnAttack();
            }
        }
    }

    public override void RemoveTarget(Character target)
    {
        base.RemoveTarget(target);
        target.SetMask(false);
    }

    public override void OnAttack()
    {
        base.OnAttack();
        if (target != null && !IsDead && currentSkin.Weapon.IsCanAttack)
        {
            counter.Start(Throw, TIME_DELAY_THROW);
            ResetAnim();
        }
    }

    public override void OnMoveStop()
    {
        base.OnMoveStop();
        rb.velocity = Vector3.zero;
        ChangeAnim(Constant.ANIM_IDLE);
    }

    public override void OnDeath()
    {
        base.OnDeath();
        counter.Cancel();
    }

    public void TryCloth(UIShop.ShopType shopType, Enum type)
    {
        switch (shopType)
        {
            case UIShop.ShopType.Hat:
                currentSkin.DespawnHat();
                ChangeHat((HatType)type);
                break;

            case UIShop.ShopType.Pant:
                ChangePant((PantType)type);
                break;

            case UIShop.ShopType.Skin:
                TakeOffClothes();
                skinType = (SkinType)type;
                WearClothes();
                break;
            //case UIShop.ShopType.Weapon:
            //    currentSkin.DespawnWeapon();
            //    ChangeWeaponP((WeaponTypeP)type);
            //    break;
            default:
                break;
        }

    }

    internal void OnTakeClothsData()
    {
        //take old cloth data
        skinType = UserData.Ins.playerSkin;
        weaponTypeP = UserData.Ins.playerWeapon;
        hatType = UserData.Ins.playerHat;
        pantType = UserData.Ins.playerPant;
    }
}

