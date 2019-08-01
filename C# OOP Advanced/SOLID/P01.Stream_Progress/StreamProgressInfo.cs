using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamable streamInfo;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamable streamInfo)
        {
            this.streamInfo = streamInfo;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamInfo.BytesSent * 100) / this.streamInfo.Length;
        }
    }
}
