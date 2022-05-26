using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/HealBuff")]
public class HealBuff : Buff
{
    public int _healValue;

    public override void BuffEffect()
    {
        HealthController _healthController = GameObject.FindGameObjectWithTag(_targetTag).GetComponent<HealthController>();
        _healthController.Heal(_healValue);
    }
}
