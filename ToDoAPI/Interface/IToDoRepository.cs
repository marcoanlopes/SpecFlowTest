using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWeb.Models;

namespace ToDoWeb.Interface
{
    public interface IToDoRepository
    {
        ToDo Create(ToDo toDo);
    }

}
