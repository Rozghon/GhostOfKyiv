using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : ScriptableObject
{
    public Sprite _icon;
    public string _name;
    public string _targetTag;
    [TextArea(5, 20)]
    public string _description;

    public abstract void BuffEffect();
}