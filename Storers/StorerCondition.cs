
/// <summary>
/// /// A <see cref="Slot"/> where the <see cref="Item"/> must complete a <see cref="StorerCondition"/> to be accepted.
/// </summary>

/// <summary>
/// Condition to be completed in order to be accepted for some <see cref="ISlot"/> implementations.
/// </summary>
/// <param name="character"><see cref="IStorer"/> root where the item will be saved.</param>
/// <param name="item"><see cref="Item"/> to be added.</param>
/// <returns></returns>
public delegate bool StorerCondition(IStorer character, Item item);

/// <summary>
/// Common <see cref="StorerCondition"/>s for a faster implementation.
/// </summary>
public static class StockerConditions
{
    /// <summary>
    /// Probes if the <see cref="Item"/> is an <see cref="Equipable"/>.
    /// </summary>
    public static StorerCondition IsEquipable = new StorerCondition((stocker, item) => item is Equipable);

    /// <summary>
    /// Probes if the <see cref="Item"/> is an <see cref="Consumable"/>.
    /// </summary>
    public static StorerCondition IsConsumable = new StorerCondition((stocker, item) => item is Consumable);
}

