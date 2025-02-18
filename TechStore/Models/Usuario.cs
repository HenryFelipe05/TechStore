using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TechStore.Models;
public class Usuario : IdentityUser
{
    [Required(ErrorMessage ="Por favor, insira o nome")]
    [StringLength(60, ErrorMessage ="o deve conter no máximo 60 caracteres")]
    public string Nome { get; set; }

    [Display(Name ="Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }
    
    [StringLength(300)]
    public string Foto { get; set; }
}