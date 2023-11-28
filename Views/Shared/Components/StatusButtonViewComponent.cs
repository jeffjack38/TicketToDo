namespace TicketToDo.Views.Shared.Components
using Microsoft.AspNetCore.Mvc;
using TicketToDo.Models;

public class StatusButtonViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Status status)
    {
        return View(status.ToString(), status);
    }
}