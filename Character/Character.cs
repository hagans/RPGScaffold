using UnityEngine;

/// <summary>
/// Base <see cref="MonoBehaviour"/> which implements <see cref="ICharacter"/>.
/// </summary>
public abstract class Character : MonoBehaviour, ICharacter
{
    [SerializeReference] IStorer _backpack;
    [SerializeReference] IStorer _equipement;
    [SerializeField] Stats _stats = null;



    public IStorer Backpack => _backpack;

    public IStorer Equipement => _equipement;

    /// <summary>
    /// Storage for unused <see cref="Item"/>s.    
    /// This <see cref="IStorer"/> is only used for initialize purposes and will be always empty.
    /// Use <see cref="Backpack"/> in order to modify actual values.
    /// </summary>
    protected abstract IStorer BackpackInitializer { get; }

    /// <summary>
    /// Model storage for <see cref="Item"/>s being used. 
    /// This <see cref="IStorer"/> is only used for initialize purposes and will be always empty.
    /// Use <see cref="Equipement"/> in order to modify actual values.
    /// </summary>
    protected abstract IStorer EquipementInitializer { get; }

    public Stats Stats => _stats;



    public uint ItemCount => _backpack.ItemCount + _equipement.ItemCount;    

    public bool Equip<T>(T equipable) where T : Item, IEquipable
    {
        if (_backpack.Take(equipable))
        {
            if (_equipement.Add(equipable))
            {
                equipable.OnEquip(this);
                return true;
            }

            _backpack.Add(equipable);
        }
        return false;
    }

    public bool Unequip<T>(T equipable) where T : Item, IEquipable
    {
        if (_equipement.Take(equipable))
        {
            if (_backpack.Add(equipable))
            {
                equipable.OnUnequip(this);
                return true;
            }

            _equipement.Add(equipable);
        }
        return false;
    }

    public bool Consume<T>(T consumable) where T : Item, IConsumable
    {
        if (_backpack.Take(consumable))
        {
            consumable.OnConsume(this);
            return true;            
        }

        return false;
    }

    public uint Add(Item item, uint toAdd = 1) => _backpack.Add(item, toAdd);

    public uint Take(Item item, uint toTake = 1) => _backpack.Take(item, toTake);

    public bool Add(Item item) => _backpack.Add(item);

    public bool Take(Item item) => _backpack.Take(item);



    protected virtual void Awake()
    {
        _backpack = BackpackInitializer;
        _equipement = EquipementInitializer;
    }



//#if UNITY_EDITOR
//    protected void OnValidate()
//    {
//        if(_backpack == null) _backpack = BackpackInitializer;
//        if (_equipement == null) _equipement = EquipementInitializer;
//    }
//#endif
}

