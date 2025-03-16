
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
            if (_repository.CreateTodo(request))
            {
                return Ok();
            }
            return NotFound();    
        }

        [HttpGet]
        [Route("/all-todo")]
        public async Task<IActionResult> GetAllTodo()
        {
            return Ok(_repository.GetAllTodo());
        }

        [HttpGet]
        [Route("/get-todo-{id}")]
        public async Task<IActionResult> GetTodoId(int id)
        {
            return Ok(_repository.GetTodoId(id));
        }
        
        [HttpDelete]
        [Route("/delete-todo-{id}")]
        public async Task<IActionResult> DeleteTodoId(int id)
        {
            _repository.DeleteTodoId(id);
            return Ok();
        }
        
        [HttpPut]
        [Route("/Update-todo-{id}")]
        public async Task<IActionResult> UpdateTodoId(int id, UpdateTodoReqest reqest)
        {
            if (_repository.UpdateTodoId(id, reqest))
            {
                return Ok();
            }
            return Ok();
        }
        
    }
}