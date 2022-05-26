using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/SpeedBuff")]
public class SpeedBuff : Buff
{
    public float _speedValue;

    public override void BuffEffect()
    {
        PlayerMovement _playerMovement = GameObject.FindGameObjectWithTag(_targetTag).GetComponent<PlayerMovement>();
        _playerMovement.UpSpeed(_speedValue);
    }
}