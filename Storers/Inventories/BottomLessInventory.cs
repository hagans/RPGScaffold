using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Infinite space <see cref="Inventory"/>.
/// </summary>
[Serializable]
public class BottomLessInventory : Inventory
{
    /// <summary>
    /// Creates a new <see cref="BottomLessInventory"/> instance with default <see cref="Slot"/>s.
    /// </summary>
    public BottomLessInventory() => _stockerCreationDelegate = () => new Slot();

    /// <summary>
    /// Creates a new <see cref="BottomLessInventory"/> instance.
    /// </summary>
    /// <param name="stockerCreationDelegate"><see langword="delegate"/> called each time a new <see cref="IStorer"/> must be created.</param>
    public BottomLessInventory(Func<IStorer> stockerCreationDelegate) => _stockerCreationDelegate = stockerCreationDelegate;



    Func<IStorer> _stockerCreationDelegate;
    [SerializeReference] List<IStorer> _stockers = new List<IStorer>();



    protected override IEnumerable<IStorer> Stockers => _stockers;




    public override uint Add(Item item, uint toAdd)
    {
        for (int i = 0; i < _stockers.Count; i++)
        {
            toAdd = _stockers[i].Add(item, toAdd);
            if (toAdd == default)
                return toAdd;
        }

        do
        {
            var newSlot = _stockerCreationDelegate.Invoke();
            toAdd = newSlot.Add(item, toAdd);
            _stockers.Add(newSlot);
        }
        while (toAdd != default);

        return toAdd;
    }

    public override uint Take(Item item, uint toTake)
    {
        uint takenAmount = default;
        for (int i = _stockers.Count - 1; i >= 0; i--)
        {
            takenAmount += _stockers[i].Take(item, toTake - takenAmount);

            if (_stockers[i].ItemCount == default)
                _stockers.RemoveAt(i);

            if (takenAmount == toTake)
                break;
        }
        return takenAmount;
    }    
}
