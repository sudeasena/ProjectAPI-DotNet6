using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI.Models
{
    [Table ("tags")]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
