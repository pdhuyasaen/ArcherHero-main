using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Bot
{
    public override void OnInit()
    {
        base.OnInit();
        SetSize(MAX_SIZE);
    }

}
