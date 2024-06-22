namespace DotXxlJob.Core.Model
{
    public class JobShardingParam
    {
        public JobShardingParam(int broadcastIndex, int broadcastTotal)
        {
            this.BroadcastIndex = broadcastIndex;
            this.BroadcastTotal = broadcastTotal;
        }
        public int BroadcastIndex { get; }
        public int BroadcastTotal { get; }
    }
}