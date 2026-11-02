using System.ComponentModel.DataAnnotations;

namespace FloristeriaBotero.Models;

public class Pedido
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
    [Display(Name = "Nombre del cliente")]
    public string Cliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Correo inválido")]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Seleccione un producto")]
    public string Producto { get; set; } = string.Empty;

    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [Range(1, 50, ErrorMessage = "La cantidad debe estar entre 1 y 50")]
    public int Cantidad { get; set; }

    public decimal Total { get; set; }
}