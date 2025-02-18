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

    [Required(ErrorMessage ="Por favor, informe a categoria do produto")]
    public int CategoriaId { get; set; }
    
    [ForeignKey("CategoriaId")]
    public Categoria Categoria { get; set; }
    
    [Required(ErrorMessage ="Por favor, insira o nome")]
    [StringLength(60, ErrorMessage ="O nome deve conter no máximo 60 caracteres")]
    public string Nome { get; set; }
    
    [Display(Name = "Descrição", Prompt ="Descrição")]
    [StringLength(1000, ErrorMessage ="A descrição deve conter no máximo 1000 caracteres")]
    public string Descricao { get; set; }
    
    [Display(Name ="Quantidade em estoque")]
    [Required(ErrorMessage = "Por favor, indique a quantidade em estoque")]
    [Range(0, int.MaxValue)]
    public int QtdEstoque { get; set; }
    
    [Display(Name ="Valor de Custo")]
    [Range(0, double.MaxValue)]
    [Required(ErrorMessage ="Insira o valor de custo")]
    [Column(TypeName ="decimal(10.2)")]
    public decimal ValorCusto { get; set; }

    [Display(Name ="Valor de Venda")]
    [Range(0, double.MaxValue)]
    [Required(ErrorMessage ="Insira o valor de Venda")]
    [Column(TypeName ="decimal(10.2)")]
    public decimal ValorVenda { get; set; }
}