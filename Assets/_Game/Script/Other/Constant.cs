using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant 
{
    public const string ANIM_RUN = "run";
    public const string ANIM_IDLE = "idle";
    public const string ANIM_DIE = "die";
    public const string ANIM_ATTACK = "attack";

    public const string TAG_CHARACTER = "Character";
    public const string TAG_ENEMY = "Enemy";
    public const string TAG_BLOCK = "Block";

}

public enum WeaponTypeP
{
    PW_Hammer_1 = PoolType.PW_Hammer_1,
    PW_Hammer_2 = PoolType.PW_Hammer_2,
    PW_Hammer_3 = PoolType.PW_Hammer_3,
}
public enum WeaponTypeB
{
    BW_Hammer_1 = PoolType.BW_Hammer_1,
    BW_Hammer_2 = PoolType.BW_Hammer_2,
    BW_Hammer_3 = PoolType.BW_Hammer_3,
}

public enum WeaponTypeCB
{
    CB_Hammer_1 = PoolType.CB_Hammer_1, 
}

public enum BulletType
{
    B_Hammer_1 = PoolType.B_Hammer_1,
    B_Hammer_2 = PoolType.B_Hammer_2,
    B_Hammer_3 = PoolType.B_Hammer_3,

    P_Hammer_1 = PoolType.P_Hammer_1,
    P_Hammer_2 = PoolType.P_Hammer_2,
    P_Hammer_3 = PoolType.P_Hammer_3,
}

public enum HatType
{
    HAT_None = 0,
    HAT_Arrow = PoolType.HAT_Arrow,
    HAT_Cap = PoolType.HAT_Cap,
    HAT_Cowboy = PoolType.HAT_Cowboy,
    HAT_Crown = PoolType.HAT_Crown,
    HAT_Ear = PoolType.HAT_Ear,
    HAT_StrawHat = PoolType.HAT_StrawHat,
    HAT_Headphone = PoolType.HAT_Headphone,
    HAT_Horn = PoolType.HAT_Horn,
    HAT_Police = PoolType.HAT_Police,
}

public enum SkinType
{
    SKIN_Normal = PoolType.SKIN_Normal,
    SKIN_Devil = PoolType.SKIN_Devil,
    SKIN_Angle = PoolType.SKIN_Angle,
    SKIN_Witch = PoolType.SKIN_Witch,
    SKIN_Deadpool = PoolType.SKIN_Deadpool,
    SKIN_Thor = PoolType.SKIN_Thor,
}

public enum BotType
{
    Archer = PoolType.MinionFar,
    Melee = PoolType.MinionNear,
}

public enum PantType
{
    Pant_1,
    Pant_2,
    Pant_3,
    Pant_4,
    Pant_5,
    Pant_6,
    Pant_7,
    Pant_8,
    Pant_9,
}