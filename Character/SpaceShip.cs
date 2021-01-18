using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceShip : Character
{
    #region Character Implementation
    protected override IStorer BackpackInitializer => new BottomLessInventory(() => new Slot());

    protected override IStorer EquipementInitializer => new ConditionFixedSlot(1f, StockerConditions.IsEquipable, this);
    #endregion

    private void Awake()
    {
        
    }
}