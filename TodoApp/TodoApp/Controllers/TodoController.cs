
using Microsoft.AspNetCore.Mvc;
using TodoApp.Contracts;
using TodoApp.DataAccsess;
using TodoApp.Models;
using TodoApp.Repository;

namespace  TodoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoRepository _repository;

        public TodoController(TodoRepository repository)
        {
            _repository = repository;   
        }
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody]CreateTodoRequest request, CancellationToken ct )
        {
            if (await _repository.CreateTodoAsync(request, ct))
            {
                return Ok();
            }
            return NotFound();    
        }

        [HttpGet]
        [Route("/all-todo")]
        public async Task<IActionResult> GetAllTodoAsync()
        {
            return Ok(await _repository.GetAllTodoAsync());
        }

        [HttpGet]
        [Route("/get-todo-{id}")]
        public async Task<IActionResult> GetTodoIdAsync(int id, CancellationToken ct)
        {
            return Ok( await _repository.GetTodoIdAsync(id, ct));
        }
        
        [HttpDelete]
        [Route("/delete-todo-{id}")]
        public async Task<IActionResult> DeleteTodoIdAsync(int id, CancellationToken ct)
        {
            await _repository.DeleteTodoIdAsync(id, ct);
            return Ok();
        }
        
        [HttpPut]
        [Route("/Update-todo-{id}")]
        public async Task<IActionResult> UpdateTodoIdAsync(int id, UpdateTodoReqest reqest, CancellationToken ct)
        {
            if (await _repository.UpdateTodoIdAsync(id, reqest, ct))
            {
                return Ok();
            }
            return Ok();
        }
        
    }
}