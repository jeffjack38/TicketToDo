using Microsoft.AspNetCore.Mvc;
using TicketToDo.Models;

namespace TicketToDo.Views.Shared.Components
{
    public class StatusButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Status status)
        {
            return View(status.ToString(), status);
        }
    }

}


