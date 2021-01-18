using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base <see cref="ScriptableObject"/> which any <see cref="IStorer"/> can handle.
/// </summary>
public abstract class Item : ScriptableObject, IEquatable<Item>
{
    [SerializeField] float _size = 1f;
    [SerializeField] string _description = "Item description";
    [SerializeField] NamedStat[] _stats = null;



    /// <summary>
    /// Description of this item <see cref="Instance"/>.
    /// </summary>
    public string Description => _description;

    /// <summary>
    /// Instance unique identifier name.
    /// </summary>
    public string Name => name;

    /// <summary>
    /// Space used by the item when stored at some <see cref="IStorer"/>.
    /// </summary>
    public float Size => _size;



    public bool Equals(Item other) => other != null && other.Name == name;

    /// <summary>
    /// Add this instance <see cref="IStatModifier"/>s to the <see cref="ICharacter"/>.
    /// Usefull to be called from <see cref="UnityEvent"/> instances via Inspector.
    /// </summary>
    /// <param name="character"><see cref="ICharacter"/> where the <see cref="IStatModifier"/>s will be added.</param>
    public void AddStats(ICharacter character)
    {
        for(int i = 0; i < _stats.Length; i++)
        {
            character.Stats.Add(_stats[i]);
        }
    }

    /// <summary>
    /// Removes this instance <see cref="IStatModifier"/>s from the <see cref="ICharacter"/>.
    /// Usefull to be called from <see cref="UnityEvent"/> instances via Inspector.
    /// </summary>
    /// <param name="character"><see cref="ICharacter"/> where the <see cref="IStatModifier"/>s will be removed.</param>
    public void RemoveSetats(ICharacter character)
    {
        for (int i = 0; i < _stats.Length; i++)
        {
            character.Stats.Remove(_stats[i]);
        }
    }
}




