using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Protobuf;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mysqlx;

namespace TechStore.Models;

[Table("produto")]
public class Produto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe a categoria!!")]
    public int CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    public Categoria categoria { get; set; }

    [Required(ErrorMessage = "Por favor, informe o Nome")]
    [StringLength(60, ErrorMessage = "O nome deve possuir no maximo 60 caracteres")]
    public string Nome { get; set; }

    [Display(Name = "Descrição")]
    [StringLength(1000, ErrorMessage = "A descrição deve possuir no maximo 1000 caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Por favor, informe a quantidade em estoque")]
    [Range(0, int.MaxValue)]
    [Display(Name = "Quantidade em Estoque")]
    public int QtdeEstoque { get; set; }

    [Required(ErrorMessage = "Defina o valor do custo")]
    [Display(Name = "Valor de Custo")]
    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorCusto { get; set; }

    [Required(ErrorMessage = "Defina o valor de venda")]
    [Display(Name = "Valor de Venda")]
    [Range(0, double.MaxValue)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorVenda { get; set; }

    public bool Destaque { get; set; } = false;

    public List<ProdutoFoto> Fotos { get; set; }
}