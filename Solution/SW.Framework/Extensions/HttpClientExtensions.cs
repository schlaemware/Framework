namespace SW.Framework.Extensions {
  public static class HttpClientExtensions {
    /// <summary>
    /// Download from internet asynchronously.
    /// </summary>
    /// <remarks>
    /// https://stackoverflow.com/questions/20661652/progress-bar-with-httpclient
    /// </remarks>
    /// <param name="client"></param>
    /// <param name="requestUri"></param>
    /// <param name="destination"></param>
    /// <param name="progress"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task DownloadAsync(this HttpClient client, string requestUri, Stream destination, IProgress<float> progress = null, CancellationToken cancellationToken = default) {
      // Get the http headers first to examine the content length
      using (HttpResponseMessage response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead)) {
        long? contentLength = response.Content.Headers.ContentLength;

        using (var download = await response.Content.ReadAsStreamAsync()) {
          // Ignore progress reporting when no progress reporter was
          // passed or when the content length is unknown
          if (progress == null || !contentLength.HasValue) {
            await download.CopyToAsync(destination, cancellationToken);
            return;
          }

          // Convert absolute progress (bytes downloaded) into relative progress
          Progress<long> relativeProgress = new Progress<long>(totalBytes => progress.Report((float)totalBytes / contentLength.Value));
          // Use extension method to report progress while downloading
          await download.CopyToAsync(destination, 81920, relativeProgress, cancellationToken);
          progress.Report(1);
        }
      }
    }

    /// <summary>
    /// Download a file asynchronously from internet.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="uri"></param>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static async Task DownloadFileAsync(this HttpClient client, Uri uri, string filePath) {
      using (Stream stream = await client.GetStreamAsync(uri)) {
        using (FileStream fs = new(filePath, FileMode.Create)) {
          await stream.CopyToAsync(fs);
        }
      }
    }
  }
}
