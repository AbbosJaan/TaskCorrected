using InterviewTask.Modules;
using InterviewTask.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterviewTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IGenericCRUDService<TaskModel> _taskSvc;
        public TaskController(IGenericCRUDService<TaskModel> taskSvc)
        {
            _taskSvc = taskSvc;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _taskSvc.Get());
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Task with the given id: {id} is not found!");
            else if (id < 1)
                return BadRequest("Wrong data!");
            return Ok(await _taskSvc.GetById(id));
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskModel task)
        {

            var createTask = await _taskSvc.Create(task);
            var routeValues = new { id = createTask.Id };
            return CreatedAtRoute(routeValues, createTask);
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TaskModel task)
        {
            var updatedTask = await _taskSvc.Update(id, task);
            return Ok(updatedTask);
        }


        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deletedTask = await _taskSvc.Delete(id);

            if (deletedTask)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
