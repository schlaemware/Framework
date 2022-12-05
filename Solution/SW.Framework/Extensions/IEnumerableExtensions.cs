namespace SW.Framework.Extensions {
  /// <summary>
  /// Extension methods for <see cref="IEnumerable{T}"/>.
  /// </summary>
  public static class IEnumerableExtensions {
    /// <summary>
    /// Implements the <see cref="List{T}.ForEach(Action{T})"/> function for all <see cref="IEnumerable{T}"/> objects.
    /// </summary>
    /// <typeparam name="T">The Type of the collection elements.</typeparam>
    /// <param name="source">The collection of items.</param>
    /// <param name="action">The action to apply for each element.</param>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
      foreach (T item in source) {
        action(item);
      }
    }
  }
}
