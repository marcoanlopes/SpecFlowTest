﻿using Microsoft.EntityFrameworkCore;
using ToDoWeb.Models;

namespace ToDoWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ToDo> ToDos { get; set; }
    }
}