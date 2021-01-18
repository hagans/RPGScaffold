using System;
using UnityEngine;

/// <summary>
/// <see cref="ISlot"/> implementation which stores an unlimited amount of <see cref="global::Item"/>.
/// </summary>
[Serializable]
public class Slot : ISlot
{
    public Item Item
    {
        get => _item;
        protected set => _item = value;
    }
    [SerializeField] Item _item;


    public uint ItemCount
    {
        get => _amount;
        set
        {
            _amount = value;
            if (_amount == default)
            {
                _item = null;
                return;
            }
        }
    }
    [SerializeField] uint _amount;



    public virtual uint Add(Item item, uint toAdd)
    {
        if (item.Equals(Item) || _amount == default)
        {
            _item = item;
            ItemCount += toAdd;
            return default;
        }

        return toAdd;
    }

    public virtual uint Take(Item item, uint toTake)
    {
        if (item.Equals(Item))
        {
            if (toTake > _amount)
            {
                toTake = _amount;
                ItemCount = default;
            }
            else ItemCount -= toTake;

            return toTake;
        }

        return default;
    }

    public bool Add(Item item) => Add(item, 1) == default;

    public bool Take(Item item) => Take(item, 1) == 1;
}

