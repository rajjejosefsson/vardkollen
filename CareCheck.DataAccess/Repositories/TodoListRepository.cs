using CareCheck.DataAccess.Repositories.Interfaces;
using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.Linq;

namespace CareCheck.DataAccess.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {


        public ICollection<TodoList> TodoList()
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.TodoList.ToList();
            }
        }

        public TodoList FindById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.TodoList.SingleOrDefault(t => t.Id == id);
            }
        }

        public void InsertTodo(TodoList todoItem)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                context.TodoList.Add(todoItem);
                context.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                throw new System.NotImplementedException();
            }
        }
    }
}