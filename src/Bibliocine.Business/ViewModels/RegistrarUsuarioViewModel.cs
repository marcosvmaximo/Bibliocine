using System.ComponentModel.DataAnnotations;

namespace Bibliocine.Business.ViewModels;

public class RegistrarUsuarioViewModel
{
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]    
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 6)]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido.")]
    public string Email { get; set; }
    
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 6)]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Senha { get; set; }
    
    [Compare("Senha", ErrorMessage = "Senhas não conferem.")]    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string ConfirmarSenha { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public DateTime DataNascimento { get; set; }
}