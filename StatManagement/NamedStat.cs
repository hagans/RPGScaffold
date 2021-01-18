using System;
using UnityEngine;

/// <summary>
/// Serializable <see cref="IStatModifier"/> <see langword="struct"> with an attached name to it.
/// </summary>
[Serializable]
public struct NamedStat : IStatModifier
{
    public NamedStat(string name, float value = 0, StatType statType = StatType.Flat)
    {
        this.name = name;
        _value = value;
        _type = statType;
    }

    public string name;

    public float Value => _value;
    [SerializeField] float _value;

    public StatType Type => _type;
    [SerializeField] StatType _type;



    public int CompareTo(IStatModifier other) => other.Type - _type;

    public bool Equals(IStatModifier other) => _value == other.Value && _type == other.Type;
}

