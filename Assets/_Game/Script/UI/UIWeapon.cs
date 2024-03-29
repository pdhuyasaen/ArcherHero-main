using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UIWeapon : UICanvas
{
    [SerializeField] WeaponDataP weaponData;
    private Weapon currentWeapon;
    private WeaponTypeP weaponType;

    public override void Setup()
    {
        base.Setup();
        ChangeWeapon(UserData.Ins.playerWeapon);
    }

    public void EquipButton()
    {
        UserData.Ins.SetEnumData(weaponType.ToString(), ShopItem.State.Equipped);
        UserData.Ins.SetEnumData(UserData.Ins.playerWeapon.ToString(), ShopItem.State.Bought);
        UserData.Ins.SetEnumData(UserData.Key_Player_Weapon, ref UserData.Ins.playerWeapon, weaponType);
        ChangeWeapon(weaponType);
        //LevelManager.Ins.player.TryCloth(UIShop.ShopType.Weapon, weaponType);
    }

    public void ChangeWeapon(WeaponTypeP weaponType)
    {
        this.weaponType = weaponType;

        if (currentWeapon != null)
        {
            SimplePool.Despawn(currentWeapon);
        }
        currentWeapon = SimplePool.Spawn<Weapon>((PoolType)weaponType, Vector3.zero, Quaternion.identity);

        //check data dong
        ButtonState.State state = (ButtonState.State)UserData.Ins.GetDataState(weaponType.ToString(), 0);

        WeaponItemP item = weaponData.GetWeaponItem(weaponType);
    }
}
