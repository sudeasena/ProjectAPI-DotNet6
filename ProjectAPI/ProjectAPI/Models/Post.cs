using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI.Models
{
    [Table ("posts")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
    }
}
