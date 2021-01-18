
/// <summary>
/// /// A <see cref="Slot"/> where the <see cref="Item"/> must complete a <see cref="StorerCondition"/> to be accepted.
/// </summary>
public class ConditionSlot : Slot
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="character"></param>
    public ConditionSlot(StorerCondition condition, IStorer character)
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

