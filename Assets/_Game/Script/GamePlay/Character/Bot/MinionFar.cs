using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionFar : Bot
{
    public override void OnAttack()
    {
        base.OnAttack();
        ActiveAttack();
        Invoke(nameof(DeActiveAttack), 0.5f);
    }

    private void ActiveAttack()
    {
        mask.SetActive(true);
    }

    private void DeActiveAttack()
    {
        mask.SetActive(false);
    }
    public override void WearClothes()
    {
        base.WearClothes();

        ChangeSkin(SkinType.SKIN_Normal);
        ChangeWeaponB(Utilities.RandomEnumValue<WeaponTypeB>());
        ChangeHat(Utilities.RandomEnumValue<HatType>());
        ChangePant(Utilities.RandomEnumValue<PantType>());
    }

    public override void OnInit()
    {
        base.OnInit();
        SetSize(MIN_SIZE);
    }


}
