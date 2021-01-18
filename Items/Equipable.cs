using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Plain <see cref="EquipableBase"/> in order to be setted via inspector.
/// Use <see cref="EquipableBase"/> to create your custom implementations.
/// </summary>
[CreateAssetMenu(fileName = "New Equipable Item", menuName = "Items/Equipable")]
public sealed class Equipable : EquipableBase
{
    /// <summary>
    /// Triggered when <see cref="Equipable"/> instance is equiped.
    /// </summary>
    [SerializeField] UnityEvent<ICharacter> _onEquip = null;

    /// <summary>
    /// Triggered when <see cref="Equipable"/> instance is unequiped.
    /// </summary>
    [SerializeField] UnityEvent<ICharacter> _onUnequip = null;


    public override void OnEquip(ICharacter character) => _onEquip.Invoke(character);

    public override void OnUnequip(ICharacter character) => _onUnequip.Invoke(character);
}

public abstract class EquipableBase : Item
{
    /// <summary>
    /// Called when an <see cref="ICharacter"/> equips this <see cref="EquipableBase"/>.
    /// </summary>
    /// <param name="character"><see cref="ICharacter"/> instance that will equip this <see cref="EquipableBase"/>.</param>
    public abstract void OnEquip(ICharacter character);

    /// <summary>
    /// Called when an <see cref="ICharacter"/> unequips this <see cref="EquipableBase"/>.
    /// </summary>
    /// <param name="character"><see cref="ICharacter"/> instance that will unequip this <see cref="EquipableBase"/>.</param>
    public abstract void OnUnequip(ICharacter character);
}