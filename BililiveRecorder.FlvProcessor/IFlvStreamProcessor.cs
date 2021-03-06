using System;
using System.Collections.ObjectModel;

#nullable enable
namespace BililiveRecorder.FlvProcessor
{
    public interface IFlvStreamProcessor : IDisposable
    {
        event TagProcessedEvent TagProcessed;
        event EventHandler<long> FileFinalized;
        event StreamFinalizedEvent StreamFinalized;
        event FlvMetadataEvent OnMetaData;

        int TotalMaxTimestamp { get; }
        int CurrentMaxTimestamp { get; }

        IFlvMetadata Metadata { get; set; }
        ObservableCollection<IFlvClipProcessor> Clips { get; }
        uint ClipLengthPast { get; set; }
        uint ClipLengthFuture { get; set; }
        uint CuttingNumber { get; set; }

        IFlvStreamProcessor Initialize(Func<(string fullPath, string relativePath)> getStreamFileName, Func<string> getClipFileName, EnabledFeature enabledFeature, AutoCuttingMode autoCuttingMode);
        IFlvClipProcessor Clip();
        void AddBytes(byte[] data);
        void FinallizeFile();
    }
}
