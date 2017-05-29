namespace TTTStatisticsServer.Models
{
    using System.Data.Entity;
    using TTTStatisticsLibrary;

    public partial class StatisticsContext : DbContext
    {
        public StatisticsContext() : base("name=StatisticsContext") { }
        public DbSet<Statistic> Statistics { get; set; }
    }
}
