    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_api.Dto;
using todo_api.Filters;
using todo_api.Model;
using todo_api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todo_api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly ILogger<TodoController> _logger;
        private readonly TodoContext _context;

        private List<TodoItem> list = new List<TodoItem>();

        private readonly IEmailService _emailService;

        private IValidator<TodoItem> _validator;

        public TodoController(ILogger<TodoController> logger, TodoContext context, IEmailService emailService, IValidator<TodoItem> validator) {
            _logger = logger;
            _context = context;
            _emailService = emailService;
            _validator = validator;

        }


        /// <summary>
        /// Listar todas las tareas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<TodoItem> Get()
        {
            return _context.TodoItem.Include("User").ToList();
        }

        /// <summary>
        /// Obtener tarea por ID
        /// </summary>
        /// <param name="id">Id de Tarea</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            _logger.LogInformation("BEGIN: call TODO get");
            var todoItem = _context.TodoItem.FirstOrDefault(x => x.Id == id);
            if (todoItem == null)
                return NotFound();

            _logger.LogInformation("END: call TODO get");
            return Ok(todoItem);
        }

        // POST api/values
        [HttpPost]
        //[ValidateModel]
        public IActionResult Post([FromBody] TodoItem todoItem)
        {
            //if (!this.ModelState.IsValid)
            //{
            //    throw new ApplicationException("Error de modelo");
            //}

            //ValidationResult validationResult = _validator.Validate(todoItem);

            //if (!validationResult.IsValid)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors);
            //}

            _context.TodoItem.Add(todoItem);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TodoItem todoItem)
        {
            _context.TodoItem.Update(todoItem);
            _context.SaveChanges();

            //_emailService.Send("alfredo.benaute@gmai.com","Tarea actualizada");
        }

        // PUT api/values/5
        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> CompleteTodo(int id, [FromBody] CompleteTodoItemDto todoItem)
        {

            var todoItemSaved = await _context.TodoItem.FirstOrDefaultAsync(x => x.Id == todoItem.Id);
            if (todoItemSaved == null) {
                return Problem($"La tarea {todoItem.Id} no existe", statusCode: 404);

                //throw new Exception($"La tarea {todoItem.Id} no existe");
            }

            todoItemSaved.IsComplete = todoItem.IsComplete;

            await _context.SaveChangesAsync();

            return Ok(todoItemSaved);   
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var item = _context.TodoItem.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

