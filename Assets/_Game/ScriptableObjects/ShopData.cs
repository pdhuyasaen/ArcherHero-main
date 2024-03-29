using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopData", menuName = "ScriptableObjects/ShopData", order = 1)]
public class ShopData : ScriptableObject
{
    public ShopItemDatas<WeaponTypeP> weapons;
    public ShopItemDatas<HatType> hats;
    public ShopItemDatas<PantType> pants;
    public ShopItemDatas<SkinType> skins;
}

[System.Serializable]
public class ShopItemDatas<T> where T : System.Enum
{
    [SerializeField] List<ShopItemData<T>> ts;
    public List<ShopItemData<T>> Ts => ts;

    public ShopItemData<T> GetHat(T t)
    {
        return ts.Single(q => q.type.Equals(t));
    }

}

[System.Serializable]
public class ShopItemData<T> : ShopItemData where T : System.Enum
{
    public T type;
}

public class ShopItemData
{
    public Sprite icon;
}