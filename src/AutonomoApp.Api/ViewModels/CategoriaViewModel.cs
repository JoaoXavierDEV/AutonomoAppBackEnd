using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutonomoApp.WebApi.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public Guid IdCategoria { get; set; } = Guid.NewGuid();
        [Description("Nome da categoria")]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        public string NomeCategoria { get; set; }
        [Display(Name = "Descricao hue Categoriaa",Description = "hue teste")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string DescricaoCategoria { get; set; }
        public List<SubCategoriaViewModel> Subcategorias { get; set ; }

    }

    public class SubCategoriaViewModel
    {
        [Key]
        public Guid IdSubCategoria { get; set; }
        public string NomeSubcategoria { get; set; }
        public string DescricaoSubcategoria { get; set; }
    }
}

