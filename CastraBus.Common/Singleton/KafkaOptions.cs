namespace CastraBus.Common.Singleton
{
    public class KafkaOptions
    {
        public string IpKafka { get; set; }
        public bool CommitMessage { get; set; }
        public int CommitInterval { get; set; }
        public int StatisticsInterval { get; set; }
        public int TimeOut { get; set; }
        public string OffsetReset { get; set; }
        public string MessageMaxBytes { get; set; }
    }
}
