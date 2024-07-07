using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeClass : MonsterClass
{
    public override void Init(mt type)
    {
        StatusSet(type, 30, 11, 6);
    }
    protected override void LoadSprite(mt t)
    {
        sprite = Resources.Load<Sprite>(t.ToString());
        if (sprite == null)
        {
            Debug.LogError($"{t}‚ÌƒCƒ[ƒW‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ‚Å‚µ‚½");
        }
    }


}