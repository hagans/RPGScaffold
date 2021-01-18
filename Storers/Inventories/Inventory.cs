using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// <see cref="IStorer"/> able to store another <see cref="IStorer"/> in a tree data structure.
/// It can not contain <see cref="Item"/>s by itself, but the nested <see cref="IStorer"/> will store them.
/// </summary>
[Serializable]
public abstract class Inventory : IStorer, IEnumerable<IStorer>
{
    public abstract uint Add(Item item, uint toAdd);

    public abstract uint Take(Item item, uint toTake);

    /// <summary>
    /// <see cref="IStorer"/>s stored at this <see cref="Inventory"/>.
    /// </summary>
    protected abstract IEnumerable<IStorer> Stockers { get; }

    public uint ItemCount
    {
        get
        {
            uint result = default;
            foreach (var slot in Stockers)
            {
                result += slot.ItemCount;
            }
            return ItemCount;
        }        
    }

    IEnumerator<IStorer> IEnumerable<IStorer>.GetEnumerator() => Stockers.GetEnumerator();    

    IEnumerator IEnumerable.GetEnumerator() => (Stockers as IEnumerable).GetEnumerator();

    public bool Add(Item item) => Add(item, 1) == default;

    public bool Take(Item item) => Take(item, 1) == 1;
}

