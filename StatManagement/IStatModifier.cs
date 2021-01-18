using System;
using System.Collections.Generic;

/// <summary>
/// <see langword="object"/> able to be stored at an <see cref="StatController"/>
/// </summary>
public interface IStatModifier : IEquatable<IStatModifier>
{
    /// <summary>
    /// <see cref="float"/> value of this instance.
    /// </summary>
    float Value { get; }

    /// <summary>
    /// Operation used to calculate the Value of the <see cref="StatController"/>.
    /// </summary>
    StatType Type { get; }
}

