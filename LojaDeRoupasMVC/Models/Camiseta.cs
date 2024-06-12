using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaDeRoupasMVC.Models;

public class Camiseta
{
    [Key]

    public int CamisetaId { get; set; }

    [Required]
    [Display(Name= "Nome")]
    [StringLength(100)]

    public string Nome { get; set; }

    [Required]
    [Display(Name = "Tamanho")]
    [StringLength(10)]

    public string Tamanho { get; set; }

    [Required]
    [Display(Name = "Descrição")]
    [StringLength(200)]
    
    public string Descricao { get; set; }

    [Required]
    [Display(Name = "Preço")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(1, 144.99, ErrorMessage = "Preço = de 1 real até 144,99")]

    public decimal Preco { get; set; }

    [Display(Name = "Caminho da imagem normal")]
    
    public string ImagemUrl { get; set; }

    [Display(Name = "Estoque")]
    public bool EmEstoque { get; set; }

    [Column("CategoriaId")]
    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; }    




}
