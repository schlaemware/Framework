namespace SW.Framework.Extensions {
  public static class StreamExtensions {
    public static async Task CopyToAsync(this Stream source, Stream destination, int bufferSize, IProgress<long> progress = null, CancellationToken cancellationToken = default) {
      if (source == null) {
        throw new ArgumentNullException(nameof(source));
      } else if (!source.CanRead) {
        throw new ArgumentException("Has to be readable!", nameof(source));
      } else if (destination == null) {
        throw new ArgumentNullException(nameof(destination));
      } else if (!destination.CanWrite) {
        throw new ArgumentException("Has to be writable!", nameof(destination));
      } else if (bufferSize < 0) {
        throw new ArgumentOutOfRangeException(nameof(bufferSize));
      }

      byte[] buffer = new byte[bufferSize];
      long totalBytesRead = 0;
      int bytesRead;
      while ((bytesRead = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) != 0) {
        await destination.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(false);
        totalBytesRead += bytesRead;
        progress?.Report(totalBytesRead);
      }
    }
  }
}
