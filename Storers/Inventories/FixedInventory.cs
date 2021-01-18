using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A specific size <see cref="Inventory"/>. Can store a fixed amount of <see cref="IStorer"/>s.
/// </summary>
[Serializable]
public class FixedInventory : Inventory
{
    /// <summary>
    /// Creates a new instance of <see cref="FixedInventory"/>
    /// </summary>
    /// <param name="stockers"></param>
    public FixedInventory(params IStorer[] stockers)
    {
        _stockers = stockers;
    }

    public FixedInventory(int defaultSlots, params IStorer[] specialSlots)
    {
        _stockers = new IStorer[specialSlots.Length + defaultSlots];
        specialSlots.CopyTo(_stockers, 0);
        for (int i = specialSlots.Length; i < _stockers.Length; i++)
            _stockers[i] = new Slot();
    }

    public FixedInventory(int slots)
    {
        _stockers = new IStorer[slots];
        for (int i = 0; i < _stockers.Length; i++)
            _stockers[i] = new Slot();
    }



    [SerializeReference] IStorer[] _stockers;



    protected override IEnumerable<IStorer> Stockers => _stockers;



    public override uint Add(Item item, uint toAdd)
    {
        for (int i = 0; i < _stockers.Length; i++)
        {
            toAdd = _stockers[i].Add(item, toAdd);
            if (toAdd == default)
                return toAdd;
        }

        return toAdd;
    }

    public override uint Take(Item item, uint toTake)
    {
        uint takenAmount = default;
        for (int i = _stockers.Length - 1; i >= 0; i--)
        {
            takenAmount += _stockers[i].Take(item, toTake - takenAmount);

            if (takenAmount == toTake)
                break;
        }
        return takenAmount;
    }
}
