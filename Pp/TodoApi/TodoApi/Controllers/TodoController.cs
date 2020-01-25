using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _dbContext;

        public TodoController(TodoContext dbContext)
        {
            _dbContext = dbContext;

            if (_dbContext.TodoItems.Count() < 1) {
                AddFirstTodoItem();
            }
        }
        
        public IActionResult Index()
        {
            return Ok("Welcome to the TodoController !");
        }   
        
        [HttpGet("GetTodoItems")]
        [AllowAnonymous]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItems()
        {
            var todoList = await _dbContext.TodoItems.ToListAsync();

            return Ok(todoList);
        }
        
        [HttpGet("{id}")]// GET: api/Todo/5
        [AllowAnonymous]
        public async Task<ActionResult<TodoItem>> GetTodoItemById(long? id)
        {
            TodoItem todoItem = await _dbContext.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound($"Todo item with id {id} was not found !");
            }

            return Ok(todoItem);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<TodoItem>> AddTodoItem([FromBody] TodoItem item)
        {
            await _dbContext.TodoItems.AddAsync(item);

            await _dbContext.SaveChangesAsync();
            var name = nameof(GetTodoItemById);

            return CreatedAtAction(name, new { id = item.Id}, item);  //Status code 201
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<TodoItem>> PutTodoItem(long id, TodoItem item)
        {
            if (id != item.Id) {
                return BadRequest();
            }

            _dbContext.Entry(item).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return NoContent();  //Status code 204
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
            TodoItem item = await _dbContext.TodoItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            _dbContext.TodoItems.Remove(item);
            await _dbContext.SaveChangesAsync();

            return NoContent();  //Status code 204
        }

        private async Task AddFirstTodoItem()
        {
            TodoItem item = new TodoItem() { Id = 1, Name = "Item1", IsComplete = false };
            await _dbContext.TodoItems.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}