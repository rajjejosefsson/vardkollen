using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace CareCheck.DataAccess.Repositories.Interfaces
{
    public interface ITodoListRepository
    {
        ICollection<TodoList> TodoList();
        TodoList FindById(int id);
        void InsertTodo(TodoList todoList);
        void DeleteById(int id);
    }
}
