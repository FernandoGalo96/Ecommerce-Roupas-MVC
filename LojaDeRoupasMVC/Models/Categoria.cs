using System.ComponentModel.DataAnnotations;

namespace LojaDeRoupasMVC.Models;

public class Categoria
{
    [Key]

    public int CategoriaId { get; set; }
    [Required(ErrorMessage ="Informe o nome da categoria.")]
    [StringLength(100,ErrorMessage ="Tamanho máximo é de 100 caracteres ")]
    [Display(Name = "Nome Categoria")]

    public string CategoriaNome { get; set; }

    [Required(ErrorMessage ="Descrição necessário!")]
    [StringLength(200)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    public List<Camiseta> Camisetas { get; set; }

}
