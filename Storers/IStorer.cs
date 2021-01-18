/// <summary>
/// <see langword="object"/> able to store one or more <see cref="Item"/>s.
/// </summary>
public interface IStorer
{
    /// <summary>
    /// Amount of <see cref="Item"/>s stored at this instance.
    /// </summary>
    uint ItemCount { get; }

    /// <summary>
    /// Adds the specified amount of the specified <see cref="Item"/> to the instance.
    /// </summary>
    /// <param name="item"><see cref="Item"/> to be added.</param>
    /// <param name="toAdd">Amount desired to be added.</param>
    /// <returns>The amount of items which couldn't be added.</returns>
    uint Add(Item item, uint toAdd);

    /// <summary>
    /// Removes the specified amount of the specified <see cref="Item"/> from the instance.
    /// </summary>
    /// <param name="item"><see cref="Item"/> to be taken.</param>
    /// <param name="toAdd">Amount desired to be taken.</param>
    /// <returns>The amount of items taken.</returns>
    uint Take(Item item, uint toTake);

    /// <summary>
    /// Adds the specified <see cref="Item"/> to the instance.
    /// </summary>
    /// <param name="item"><see cref="Item"/> to be added.</param>
    /// <returns><see langword="true"/> if <see cref="Item"/> was stored. Otherwise <see langword="false"/>.</returns>
    bool Add(Item item);

    /// <summary>
    /// Removes the specified <see cref="Item"/> from the instance.
    /// </summary>
    /// <param name="item"><see cref="Item"/> to be taken.</param>
    /// <returns><see langword="true"/> if <see cref="Item"/> was taken. Otherwise <see langword="false"/>.</returns>
    bool Take(Item item);
}

