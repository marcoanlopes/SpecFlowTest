using System;

namespace ToDoWeb.Models
{
    public class ToDo
    {
        public ToDo() => CreationDate = DateTime.Now.ToString("yyyy/MM/dd");
        public int Id { get; set; }
        public string ToDoName { get; set; }

        public string Description { get; set; }

        public string CreationDate { get; set; }

        //public override string ToString()
        //{
        //    return $"Nome do ToDo: {ToDoName} | Descrição do ToDo {Description} | Criado em do ToDo {CreationDate} ";
        //}

    }
}