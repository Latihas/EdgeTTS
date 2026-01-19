namespace EdgeTTS;

public sealed partial class EdgeTTSEngine : IDisposable
{
    public bool IsDisposed { get; private set; }

    public required string         CacheFolder { get; init; }
    public required string         VoiceFolder { get; init; }
    public required Action<string> LogHandler  { get; init; }
    
    public void Dispose()
    {
        if (IsDisposed) return;

        IsDisposed = true;

        currentPlayer?.Stop();
        cancelSource.Cancel();
        cancelSource.Dispose();
    }
}
