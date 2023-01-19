using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutonomoApp.WebApi.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        //[Description("Nome da categoria")]
        public string Nome { get; set; }
        //[Display(Name = "Descricao Categoriaa",Description = "hue teste")]
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

