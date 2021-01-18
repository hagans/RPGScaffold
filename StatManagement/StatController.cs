using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages <see cref="IStatModifier"/> and calculates the total value of them.
/// </summary>
[Serializable]
public class StatController : IEnumerable<IStatModifier>
{
    /// <summary>
    /// Creates a new <see cref="StatController"/> with the specified name.
    /// </summary>
    /// <param name="name">Identifier name of the instance.</param>
    public StatController(string name) => _name = name;



    [SerializeField] List<Stat> _stats = new List<Stat>();
    bool _isDirty;



    /// <summary>
    /// Identifier name of the instance.
    /// </summary>
    public string Name => _name;
    [SerializeField] string _name;

    /// <summary>
    /// Current value of the instance.
    /// </summary>
    public float Value
    {
        get
        {
            if (_isDirty)
            {
                _isDirty = false;
                _stats.Sort();

                var newValue = 0f;
                for (int i = 0; i < _stats.Count; i++)
                {
                    switch (_stats[i].Type)
                    {
                        case StatType.Flat:
                            newValue += _stats[i].Value;
                            break;
                        case StatType.Mutiplicative:
                            newValue *= _stats[i].Value;
                            break;
                    }
                }

                if(newValue != _value)
                {
                    OnValueChanged.Invoke(newValue - _value);
                    _value = newValue;
                }
            }            
            return _value;
        }
    }
    [SerializeField] float _value;

    /// <summary>
    /// Called when <see cref="Value"/> is asked and it has been changed.
    /// </summary>
    public UnityEvent<float> OnValueChanged { get; private set; } = new UnityEvent<float>();

    /// <summary>
    /// <see cref="IStatModifier"/>s stored at this instance.
    /// </summary>
    public int Count => _stats.Count;

    /// <summary>
    /// Adds a new <see cref="Stat"/>.
    /// </summary>
    public void Add(Stat item) => Add(item as IStatModifier);

    /// <summary>
    /// Adds a new <see cref="IStatModifier"/>.
    /// </summary>
    /// <param name="item"><see cref="IStatModifier"/> to be added.</param>
    public void Add(IStatModifier item)
    {
        _isDirty = true;
        _stats.Add(Stat.FromIStatValue(item));
    }

    /// <summary>
    /// Removes all the <see cref="IStatModifier"/>s stored at this instance, 
    /// turning the current value to 0.
    /// </summary>
    public void Clear()
    {
        _isDirty = true;
        _stats.Clear();
    }

    /// <summary>
    /// Searchs the specified <see cref="IStatModifier"/>.
    /// </summary>
    /// <param name="item"><see cref="IStatModifier"/> to be searched.</param>
    /// <returns><see langword="true"/> if the <see cref="IStatModifier"/> was found, otherwise <see langword="false"/>.</returns>
    public bool Contains(IStatModifier item)
    {
        for(int i = 0; i < _stats.Count; i++)
        {
            if (_stats[i].Equals(item)) return true;
        }
        return false;
    }
    
    public IEnumerator<IStatModifier> GetEnumerator()
    {
        for (int i = 0; i < _stats.Count; i++) yield return _stats[i];
    }

    /// <summary>
    /// Removes the specified <see cref="Stat"/>, if possible.
    /// </summary>
    /// <param name="item"><see cref="Stat"/> to be removed.</param>
    /// <returns><see langword="true"/> if the <see cref="Stat"/> was removed succesfully, otherwise <see langword="false"/>.</returns>
    public bool Remove(Stat item) => Remove(item as IStatModifier);

    /// <summary>
    /// Removes the specified <see cref="IStatModifier"/>, if possible.
    /// </summary>
    /// <param name="item"><see cref="IStatModifier"/> to be removed.</param>
    /// <returns><see langword="true"/> if the <see cref="IStatModifier"/> was removed succesfully, otherwise <see langword="false"/>.</returns>
    public bool Remove(IStatModifier item)
    {
        for(int i = 0; i < _stats.Count; i++)
        {
            if (_stats[i].Equals(item))
            {
                _isDirty = true;
                _stats.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    IEnumerator IEnumerable.GetEnumerator() => _stats.GetEnumerator();    
}

