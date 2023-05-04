using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Books.Models
{
    public class Motorcycle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        public double Price { get; set; }
    }
}
