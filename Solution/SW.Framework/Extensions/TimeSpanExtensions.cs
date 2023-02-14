namespace SW.Framework.Extensions {
  public static class TimeSpanExtensions {
    public static void Sum(this IEnumerable<TimeSpan> timeSpans) {
      TimeSpan sum = TimeSpan.Zero;
      foreach (TimeSpan span in timeSpans) {
        sum += span;
      }

      return sum;
    }
  }
}
