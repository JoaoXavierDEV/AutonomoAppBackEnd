using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutonomoApp.WebApi.ViewModels
{
    public class CategoriaViewModel
    {
        //[Key]
        //public Guid Id { get; set; }
        [Description("Nome da categoria")]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        public string Nome { get; set; }
        [Display(Name = "Descricao hue Categoriaa",Description = "hue teste")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }
        //public List<SubCategoriaViewModel> Subcategoria { get; set; }

    }

    public class SubCategoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

