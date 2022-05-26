using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/HealthBuff")]
public class HealthBuff : Buff
{
    public int _healthValue;

    public override void BuffEffect()
    {
        HealthController _healthController = GameObject.FindGameObjectWithTag(_targetTag).GetComponent<HealthController>();
        _healthController.UpHealth(_healthValue);
    }
}
