using System.Data.Entity;
using TTTStatisticsLibrary;

namespace TTTStatisticsServer.Models
{
    public partial class StatisticsContext : DbContext
    {
        public StatisticsContext() : base("name=StatisticsConnectionString") { }
        public DbSet<Statistic> Statistics { get; set; }
    }
}
