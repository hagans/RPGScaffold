/// <summary>
/// Implemented for each instance which is able to handle <see cref="Stats"/>s and items.
/// </summary>
public interface ICharacter : IStorer
{
    /// <summary>
    /// Storage for unused <see cref="Item"/>s.
    /// </summary>
    IStorer Backpack { get; }

    /// <summary>
    /// Storage for <see cref="Item"/>s being used.
    /// </summary>
    IStorer Equipement { get; }

    /// <summary>
    /// <see cref="ICharacter"/> stats.
    /// </summary>
    Stats Stats { get; }


    /// <summary>
    /// Equips, if possible, an <see cref="Item"/> with <see cref="IConsumable"/> implementation.
    /// </summary>
    /// <param name="equipable"></param>
    /// <returns></returns>
    bool Equip<T>(T equipable) where T : Item, IEquipable;


    /// <summary>
    /// Equips, if possible, an <see cref="Item"/> with <see cref="IConsumable"/> implementation.
    /// </summary>
    /// <param name="equipable"></param>
    /// <returns></returns>
    bool Unequip<T>(T equipable) where T : Item, IEquipable;

    /// <summary>
    /// Consumes, if possible, an <see cref="Item"/> with <see cref="IEquipable"/> implementation.
    /// </summary>
    /// <param name="consumable"></param>
    /// <returns></returns>
    bool Consume<T>(T consumable) where T : Item, IConsumable;
}

