using UnityEngine;

/// <summary>
/// <see cref="ISlot"/> implementation which stores a specified amount of <see cref="global::Item"/>.
/// </summary>
public class FixedSlot : Slot
{
    /// <summary>
    /// Creates a new <see cref="FixedSlot"/> instance.
    /// </summary>
    /// <param name="maxSize"></param>
    public FixedSlot(float maxSize) => _maxSize = maxSize;



    [SerializeField] float _maxSize = Mathf.Infinity;



    public override uint Add(Item item, uint toAdd)
    {
        toAdd = base.Add(item, toAdd);

        if(_maxSize < ItemCount * Item.Size)
        {
            toAdd = ItemCount - (uint)Mathf.FloorToInt(_maxSize / Item.Size);
            ItemCount -= toAdd;
            return toAdd;
        }

        return toAdd;
    }
}

