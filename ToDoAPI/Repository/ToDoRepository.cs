using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWeb.Data;
using ToDoWeb.Interface;
using ToDoWeb.Models;

namespace ToDoWeb.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DataContext dataContext;
        public ToDoRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public ToDo Create(ToDo toDo)
        {
            dataContext.Add(toDo);
            dataContext.SaveChanges();
            return toDo;
        }
    }
}
