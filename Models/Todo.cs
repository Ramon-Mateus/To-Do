using System.ComponentModel.DataAnnotations;
using To_Do.Validators;

namespace To_Do.Models;

public class Todo
{
    public int Id { get; set; }

    // [Display(Name = "Título")] // Define como o nome do campo deve ser exibido
    // [Required(ErrorMessage = "O campo {0} é obrigatório")] // Define que o campo é obrigatório e qual a mensagem de erro deve aparecer caso não seja informado (o {0} é um atributo especial do aspnet para pegar o nome do campo atual)
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The field {0} must be between {2} and {1} characters")]
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    [FutureOrPresent]
    public DateOnly DeadLine { get; set; }
    public DateOnly? FinishedAt { get; set; }

    public void Finish()
    {
        FinishedAt = DateOnly.FromDateTime(DateTime.Now);
    }
}