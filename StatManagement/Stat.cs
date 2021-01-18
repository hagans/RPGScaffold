using System;
using UnityEngine;

/// <summary>
/// Serializable <see cref="IStatModifier"/> <see langword="struct"/>.
/// </summary>
[Serializable]
public struct Stat : IStatModifier, IComparable<Stat>
{
    /// <summary>
    /// Creates a new <see cref="Stat"/> instance.
    /// </summary>
    /// <param name="value">Value of the instance.</param>
    /// <param name="type"><see cref="StatType"/> of the instance.</param>
    public Stat(float value = 0, StatType type = StatType.Flat)
    {
        _value = value;
        _type = type;
    }

    Stat(IStatModifier stat)
    {
        _value = stat.Value;
        _type = stat.Type;
    }



    /// <summary>
    /// Converts any <see cref="IStatModifier"/> into an <see cref="Stat"/> for serialization purposes.
    /// </summary>
    /// <param name="stat"><see cref="IStatModifier"/> to be converted.</param>
    /// <returns></returns>
    public static Stat FromIStatValue(IStatModifier stat)
    {
        if (stat is Stat) return (Stat)stat;

        else return new Stat(stat);
    }



    [SerializeField] StatType _type;
    [SerializeField] float _value;



    public float Value => _value;

    public StatType Type => _type;



    public bool Equals(IStatModifier other) => _value == other.Value && _type == other.Type;

    public int CompareTo(Stat other) => _type - other.Type;
}

/// <summary>
/// Operation used to calculate the value at the <see cref="StatController"/>.
/// </summary>
public enum StatType { Flat = 0, Mutiplicative = 1 }
