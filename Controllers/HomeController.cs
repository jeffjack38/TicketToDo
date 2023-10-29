using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TicketToDo.Models;

namespace TicketToDo.Controllers
{
    public class HomeController : Controller
    {

        //private variable for the database context, the constructor, and the first three action method
        private TicketContext context;
        public HomeController(TicketContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            //create new Fitlers object, passing id paramter to its constructor
            var filters = new Filters(id);

            ViewBag.Filters = filters;
            ViewBag.Statuses = context.Statuses.ToList();
            ViewBag.DueFilters = Filters.DueFilterValues;

            //build query for ToDo ojbects and related Category and Status objects
            IQueryable<Ticket> query = context.Tickets
                .Include(t => t.Status);
            //use has properties of the Filters object to add WHERE clauses to the query if the user has selected filter critieria
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }
            if (filters.HasDue)
            {
                var today = DateTime.Today;
                if (filters.IsPast)
                    query = query.Where(t => t.DueDate < today);
                else if (filters.IsFuture)
                    query = query.Where(t => t.DueDate > today);
                else if (filters.IsToday)
                    query = query.Where(t => t.DueDate == today);
            }
            //sort the results by due date and colling the ToList() method
            var tasks = query.OrderBy(t => t.DueDate).ToList();
            //pass the collection of tasks to the view
            return View(tasks);
        }

        //add action method handles GET requests
        [HttpGet]
        public IActionResult Add()
        {
            //get list of category and status objects from the database and assigns these collections to the ViewBag
            ViewBag.Statuses = context.Statuses.ToList();
            return View();
        }

        //handle POST requests
        [HttpPost]
        public IActionResult Add(Ticket task)
        {
            string key = nameof(Ticket.Name);
            var val = ModelState.GetValidationState(key);
            if (val == ModelValidationState.Valid)
            {
                if (task.Name == "Jack")
                {
                    ModelState.AddModelError(key, "Don't use the name Jack as a name!");
                }
            }
            if (ModelState.IsValid)
            {
                //add the new ToDo object to the ToDos context collection and call the SaveChanges() method to update the databse
                context.Tickets.Add(task);
                context.SaveChanges();
                //redirectthe user back to the Home page, where the new taks now displays in the list of tasks
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Statuses = context.Statuses.ToList();
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        //[FromRoute]  tells MVC to look for its value in a route paramter, 
        public IActionResult Edit([FromRoute] string id, Ticket selected)
        {
            if (selected.StatusId == null)
            {
                context.Tickets.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = context.Tickets.Find(selected.Id);
                selected.StatusId = newStatusId;
                context.Tickets.Update(selected);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });
        }


    }
}
