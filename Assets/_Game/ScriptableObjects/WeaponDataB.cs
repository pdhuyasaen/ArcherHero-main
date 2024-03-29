using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataB", menuName = "ScriptableObjects/WeaponDataB", order = 1)]
public class WeaponDataB : ScriptableObject
{
    [SerializeField] List<WeaponItemB> weaponItemsB;

    public List<WeaponItemB> WeaponItemsB => weaponItemsB;

    public WeaponItemB GetWeaponItem(WeaponTypeB weaponTypeB)
    {
        return weaponItemsB.Single(q => q.type == weaponTypeB);
    }

    public WeaponTypeB NextType(WeaponTypeB weaponTypeB)
    {
        int index = weaponItemsB.FindIndex(q => q.type == weaponTypeB);
        index = index + 1 >= weaponItemsB.Count ? 0 : index + 1;
        return weaponItemsB[index].type;
    }

    public WeaponTypeB PrevType(WeaponTypeB weaponTypeB)
    {
        int index = weaponItemsB.FindIndex(q => q.type == weaponTypeB);
        index = index - 1 < 0 ? weaponItemsB.Count - 1 : index - 1;
        return weaponItemsB[index].type;
    }
}

[System.Serializable]
public class WeaponItemB
{
    public string name;
    public WeaponTypeB type;
}
