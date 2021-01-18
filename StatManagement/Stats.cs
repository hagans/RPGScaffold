using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// Stores and manages <see cref="NamedStat"/>s instances inside it.
/// </summary>
[Serializable]
public class Stats : IEnumerable<StatController>
{
    [SerializeField] List<StatController> _controllers = new List<StatController>();

    /// <summary>
    /// Searchs the <see cref="StatController"/> stored at this instance with the specified name. If it doesn't exist, creates it.
    /// </summary>
    /// <param name="name">Name identifier of the <see cref="StatController"/></param>
    /// <returns>The specified <see cref="StatController"/>.</returns>
    public StatController this[string name]
    {
        get
        {
            for(int i = 0; i < _controllers.Count; i++)
            {
                if (_controllers[i].Name == name) return _controllers[i];
            }

            _controllers.Add(new StatController(name));
            return _controllers[_controllers.Count - 1];
        }
    }

    /// <summary>
    /// Adds the specified <see cref="NamedStat"/> to the appropiate <see cref="StatController"/>.
    /// If no one valid <see cref="StatController"/> was found, creates it.
    /// </summary>
    /// <param name="statValue"><see cref="NamedStat"/> to be stored.</param>
    public void Add(NamedStat statValue)
    {
        for(int i = 0; i < _controllers.Count; i++)
        {
            if(_controllers[i].Name == statValue.name)
            {
                _controllers[i].Add(statValue);
                return;
            }
        }

        _controllers.Add(new StatController(statValue.name));
        _controllers[_controllers.Count - 1].Add(statValue);
    }

    public IEnumerator<StatController> GetEnumerator() => _controllers.GetEnumerator();    

    /// <summary>
    /// Removes the specified <see cref="NamedStat"/> from the specified <see cref="StatController"/>, if possible.
    /// </summary>
    /// <param name="statValue"><see cref="NamedStat"/> to be removed.</param>
    /// <returns><see langword="true"/> if the <see cref="NamedStat"/> was succesfully removed. Otherwise <see langword="false"/>.</returns>
    public bool Remove(NamedStat statValue)
    {
        for (int i = 0; i < _controllers.Count; i++)
        {
            if (_controllers[i].Name == statValue.name)
            {
                _controllers[i].Remove(statValue);
                return true;
            }
        }

        return false; 
    }

    IEnumerator IEnumerable.GetEnumerator() => (_controllers as IEnumerable).GetEnumerator();
}

