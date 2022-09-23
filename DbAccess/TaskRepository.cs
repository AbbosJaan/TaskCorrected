using DbAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess
{
    public class TaskRepository : IGenericRepositroy<TaskEntitiy>
    {
        private readonly AppDbContext _dbContext;
        public TaskRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskEntitiy> Create(TaskEntitiy task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<bool> Delete(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TaskEntitiy>> GetAll()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskEntitiy> GetById(int id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }

        public async Task<TaskEntitiy> Update(int id, TaskEntitiy task)
        {
            var updatedTask = _dbContext.Tasks.Attach(task);
            updatedTask.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return task;
        }
    }
}
