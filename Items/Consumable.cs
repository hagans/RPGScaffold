using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Plain <see cref="ConsumableBase"/> in order to be setted via inspector.
/// Use <see cref="ConsumableBase"/> to create your custom implementations.
/// </summary>
[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Items/Consumable")]
public sealed class Consumable : ConsumableBase
{
    /// <summary>
    /// Triggered when <see cref="Consumable"/> instance is consumed.
    /// </summary>
    [SerializeField] UnityEvent<ICharacter> _onConsume = null;

    public override void OnConsume(ICharacter character) => _onConsume.Invoke(character);
}



/// <summary>
/// Base <see cref="ScriptableObject"/> for an <see cref="IConsumable"/> <see cref="Item"/>s.
/// </summary>
public abstract class ConsumableBase : Item, IConsumable
{
    /// <summary>
    /// Called when an <see cref="ICharacter"/> consumes this <see cref="ConsumableBase"/>.
    /// </summary>
    /// <param name="character"><see cref="ICharacter"/> instance that will consume this <see cref="ConsumableBase"/>.</param>
    public abstract void OnConsume(ICharacter character);
}

public interface IConsumable
{
    void OnConsume(ICharacter character);
}

public interface IEquipable
{
    void OnEquip(ICharacter character);

    void OnUnequip(ICharacter character);
}