using System.Collections;
using System.Collections.Generic;
using UIExample;
using UnityEngine;

public class FinishBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Character character = Cache.GetCharacter(other);
        if (character != null)
        {
            if (character is Player)
            {
                LevelManager.Ins.NextLevel();
            }
            character.TF.eulerAngles = Vector3.up * 180;
            //character.OnInit();
        }
    }
}
