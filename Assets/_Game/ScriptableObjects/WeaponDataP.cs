using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataP", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponDataP : ScriptableObject
{
    [SerializeField] List<WeaponItemP> weaponItems;

    public List<WeaponItemP> WeaponItems => weaponItems;

    public WeaponItemP GetWeaponItem(WeaponTypeP weaponType)
    {
        return weaponItems.Single(q => q.type == weaponType);
    }

    public WeaponTypeP NextType(WeaponTypeP weaponTypeP)
    {
        int index = weaponItems.FindIndex(q => q.type == weaponTypeP);
        index = index + 1 >= weaponItems.Count ? 0 : index + 1;
        return weaponItems[index].type;
    }

    public WeaponTypeP PrevType(WeaponTypeP weaponType)
    {
        int index = weaponItems.FindIndex(q => q.type == weaponType);
        index = index - 1 < 0 ? weaponItems.Count - 1 : index - 1;
        return weaponItems[index].type;
    }
}

[System.Serializable]
public class WeaponItemP
{
    public string name;
    public WeaponTypeP type;
}
