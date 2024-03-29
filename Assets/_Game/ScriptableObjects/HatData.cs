using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "HatData", menuName = "ScriptableObjects/HatData", order = 1)]
public class HatData : ScriptableObject
{
    public Hats<HatType> hats;
}

[System.Serializable]
public class Hats<T> where T : System.Enum
{
    [SerializeField] List<HatP<T>> ts;
    public List<HatP<T>> Ts => ts;

    public HatP<T> GetHat(T t)
    {
        return ts.Single(q => q.type.Equals(t));
    }

}

[System.Serializable]
public class HatP<T> : HatP where T : System.Enum
{
    public T type;
}

public class HatP
{
    public Sprite icon;

}