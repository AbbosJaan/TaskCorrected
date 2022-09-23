using DbAccess;
using DbAccess.Entity;
using InterviewTask.Modules;

namespace InterviewTask.Services
{
    public class TaskCRUDService : IGenericCRUDService<TaskModel>
    {
        private readonly IGenericRepositroy<TaskEntitiy> _taskRepository;
        public TaskCRUDService(IGenericRepositroy<TaskEntitiy> addressRepository)
        {
            _taskRepository = addressRepository;
        }

        public async Task<TaskModel> Create(TaskModel model)
        {
            var testTask = new TaskEntitiy
            {
                Id = model.Id,
                Title = model.Title,
                Quantiy = model.Quantiy,
                Price = model.Price
            };
            var createdTask = await _taskRepository.Create(testTask);
            var result = new TaskModel
            {
                Id = createdTask.Id,
                Title = createdTask.Title,
                Quantiy = createdTask.Quantiy,
                Price = createdTask.Price
            };
            return result;

        }

        public async Task<bool> Delete(int id)
        {
            return await _taskRepository.Delete(id);
        }

        public async Task<IEnumerable<TaskModel>> Get()
        {
            var result = new List<TaskModel>();
            var tasks = await _taskRepository.GetAll();
            foreach (var task in tasks)
            {
                var model = new TaskModel
                {
                    Id = task.Id,
                    Title = task.Title,
                    Quantiy = task.Quantiy,
                    Price = task.Price
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<TaskModel> GetById(int id)
        {
            var model = await _taskRepository.GetById(id);
            var result = new TaskModel
            {
                Id = model.Id,
                Title = model.Title,
                Quantiy = model.Quantiy,
                Price = model.Price
            };
            return result;
        }

        public async Task<TaskModel> Update(int id, TaskModel model)
        {
            var address = new TaskEntitiy
            {
                Id = model.Id,
                Title = model.Title,
                Quantiy = model.Quantiy,
                Price = model.Price
            };
            var updatedAddress = await _taskRepository.Update(id, address);
            var result = new TaskModel
            {
                Id = updatedAddress.Id,
                Title = updatedAddress.Title,
                Quantiy = updatedAddress.Quantiy,
                Price = updatedAddress.Price
            };
            return result;
        }
    }
}
