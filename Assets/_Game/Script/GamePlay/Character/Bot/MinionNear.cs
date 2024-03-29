using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionNear : Bot
{
    [SerializeField] private GameObject attackArea;

    public override void OnCBAttack()
    {
        base.OnCBAttack();
        ActiveAttack();
        Invoke(nameof(DeActiveAttack), 0.5f);
    }

    private void ActiveAttack()
    {
        attackArea.SetActive(true);
    }

    private void DeActiveAttack()
    {
        attackArea.SetActive(false);
    }

    public override void WearClothes()
    {
        base.WearClothes();

        ChangeSkin(SkinType.SKIN_Normal);
        ChangeWeaponCB(Utilities.RandomEnumValue<WeaponTypeCB>());
        ChangeHat(Utilities.RandomEnumValue<HatType>());
        ChangePant(Utilities.RandomEnumValue<PantType>());
    }

    public override void OnInit()
    {
        base.OnInit();
        SetSize(MIN_SIZE);
        DeActiveAttack();
    }
}
