using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/AttackSpeedBuff")]
public class AttackSpeedBuff : Buff
{
    public float _speedValue;

    public override void BuffEffect()
    {
        Shooter _shooter = GameObject.FindGameObjectWithTag(_targetTag).GetComponent<Shooter>();
        _shooter.UpAttackSpeed(_speedValue);
    }
}