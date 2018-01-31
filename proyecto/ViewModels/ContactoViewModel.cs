namespace proyecto.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class ContactoViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Mensaje { get; set; }

    }
}