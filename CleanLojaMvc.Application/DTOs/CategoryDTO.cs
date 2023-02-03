using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanLojaMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        public CategoryDTO() { }
        public CategoryDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
