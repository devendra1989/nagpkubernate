using System.ComponentModel.DataAnnotations;

namespace DevendraNagpDocker2024
{
    public class WeatherForecastEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
