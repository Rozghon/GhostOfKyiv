using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/DamageBuff")]
public class DamageBuff : Buff
{
    public int _damageValue;

    public override void BuffEffect()
    {
        Shooter _shooter = GameObject.FindGameObjectWithTag(_targetTag).GetComponent<Shooter>();
        _shooter.UpDamage(_damageValue);
    }
}
