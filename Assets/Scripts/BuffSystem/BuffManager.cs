using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField] private List<Buff> _buffs;
    [SerializeField] private List<Buff> _activeBuffs;

    public Buff ChooseRandomBuff()
    {
        return _buffs[Random.Range(0, _buffs.Count)];
    }

    public void AddRandomBuff()
    {
        AddBuff(_buffs[Random.Range(0, _buffs.Count)]);
    }

    public void AddBuff(Buff _buff)
    {
        _activeBuffs.Add(_buff);
        UseBuff(_buff);
    }

    private void UseBuff(Buff _buff)
    {
        _buff.BuffEffect();
    }
}