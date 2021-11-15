using Microsoft.EntityFrameworkCore;

namespace Self.Improvement.Data.Context
{
    public class SelfImprovementContext : DbContext
    {
        public SelfImprovementContext(DbContextOptions<SelfImprovementContext> options)
            : base(options)
        {
        }
    }
}
