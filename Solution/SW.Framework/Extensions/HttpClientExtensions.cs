namespace SW.Framework.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task DownloadFileAsync(this HttpClient client, Uri uri, string filePath)
        {
            using (var stream = await client.GetStreamAsync(uri))
            {
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    await stream.CopyToAsync(fs);
                }
            }
        }
    }
}
