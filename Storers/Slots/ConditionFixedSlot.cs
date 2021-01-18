using System;

/// <summary>
/// A <see cref="FixedSlot"/> where the <see cref="Item"/> must complete a <see cref="StorerCondition"/> to be accepted.
/// </summary>
[Serializable]
public class ConditionFixedSlot : FixedSlot
{
    public ConditionFixedSlot(float maxSize, StorerCondition condition, IStorer character) : base(maxSize)
    {
        _condition = condition;
        _character = character;
    }

    StorerCondition _condition;
    IStorer _character;

    public override uint Add(Item item, uint toAdd)
    {
        if (_condition(_character, item))
            return base.Add(item, toAdd);

        return toAdd;
    }
}

