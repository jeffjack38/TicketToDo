using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace TicketToDo.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for the ticket.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for the ticket.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please enter a due date.")]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Please enter a sprint number.")]
        [Range(1, 50, ErrorMessage = "Spring number must be a number between 1 and 50.")]
        public int SprintNumber { get; set; }

        [Required(ErrorMessage = "Please enter a point value.")]
        [Range(1, 50, ErrorMessage = "Point Value must be a number between 1 and 50.")]
        public int PointValue { get; set; }

        [Required(ErrorMessage = "Please select a status")]
        public string? StatusId { get; set; }
        public Status? Status { get; set; }

        public bool Overdue => Status?.ToString() == "inprogress" && DueDate < DateTime.Today;

    }
}
