using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI.Models
{
    [Table ("users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }

    }
}
