namespace SW.MUSICBase.Logic.Security {
  public sealed class HashingOptions {
    public int Iterations { get; }

    #region CONSTRUCTORS
    public HashingOptions(int iterations) {
      Iterations = iterations;
    }
    #endregion CONSTRUCTORS
  }
}
