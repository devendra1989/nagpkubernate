using Microsoft.EntityFrameworkCore;

namespace DevendraNagpDocker2024
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<WeatherForecastEntity> WeatherForecast { get; set; }
    }
}
