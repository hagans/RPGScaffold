/// <summary>
/// <see cref="IStorer"/> able to store only one specified <see cref="Item"/>.
/// </summary>
public interface ISlot : IStorer
{
    /// <summary>
    /// Current <see cref="Item"/> stored in this <see cref="ISlot"/> instance.
    /// </summary>
    Item Item { get; }
}

