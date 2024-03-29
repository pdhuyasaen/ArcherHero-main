using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataCB", menuName = "ScriptableObjects/WeaponDataCB", order = 1)]
public class WeaponDataCB : ScriptableObject
{
    [SerializeField] List<WeaponItemCB> weaponItemsCB;

    public List<WeaponItemCB> WeaponItemsCB => weaponItemsCB;

    public WeaponItemCB GetWeaponItem(WeaponTypeCB weaponTypeCB)
    {
        return weaponItemsCB.Single(q => q.type == weaponTypeCB);
    }

    public WeaponTypeCB NextType(WeaponTypeCB weaponTypeCB)
    {
        int index = weaponItemsCB.FindIndex(q => q.type == weaponTypeCB);
        index = index + 1 >= weaponItemsCB.Count ? 0 : index + 1;
        return weaponItemsCB[index].type;
    }

    public WeaponTypeCB PrevType(WeaponTypeCB weaponTypeCB)
    {
        int index = weaponItemsCB.FindIndex(q => q.type == weaponTypeCB);
        index = index - 1 < 0 ? weaponItemsCB.Count - 1 : index - 1;
        return weaponItemsCB[index].type;
    }
}

[System.Serializable]
public class WeaponItemCB
{
    public string name;
    public WeaponTypeCB type;
}
