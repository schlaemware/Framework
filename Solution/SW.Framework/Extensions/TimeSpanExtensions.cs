namespace SW.Framework.Extensions {
  /// <summary>
  /// Extension methods for <see cref="TimeSpan"/>.
  /// </summary>
  public static class TimeSpanExtensions {
    /// <summary>
    /// Calculates sum of multiple <see cref="TimeSpan"/> objects.
    /// </summary>
    /// <param name="timeSpans">The <see cref="TimeSpan"/> objects to summarize.</param>
    /// <returns>The summarized <see cref="TimeSpan"/>.</returns>
    public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpans) {
      TimeSpan sum = TimeSpan.Zero;
      foreach (TimeSpan span in timeSpans) {
        sum += span;
      }

      return sum;
    }
  }
}
