using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ToDoWeb.Data;
using ToDoWeb.Models;

namespace SpecFlowToDoWeb.Steps
{
    [Binding]
    public sealed class ToDoStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ToDo _ToDo = new ToDo();
        //private ToDo _ToDoResult;

        //private readonly DataContext _DataContext;

        //public ToDoStepDefinition(DataContext DataContext)
        //{
        //    _DataContext = DataContext;
        //}

        [Given("the first name is (.*)")]
        public void GivenTheNameIs(string name)
        {
            _ToDo.ToDoName = name;
        }

        [Given("the description is (.*)")]
        public void GivenTheDescriptionIs(string description)
        {
            _ToDo.Description = description;
        }

        [Given("the unique id: (.*)")]
        public void GivenTheId(int id)
        {
            _ToDo.Id = id;
        }

        [Given("the object creation date (.*)")]
        public void GivenTheDate(string todayDate)
        {
            _ToDo.CreationDate = todayDate;
        }

        [Then("get them all and you have your ToDo object")]
        public void ThenGatherThemAll(Table table)
        {
            var ToDo = table.CreateInstance<ToDo>();
            ToDo.Description.Should().Be(_ToDo.Description);
            ToDo.Id.Should().Be(_ToDo.Id);
            ToDo.ToDoName.Should().Be(_ToDo.ToDoName);
            ToDo.CreationDate.Should().Be(_ToDo.CreationDate);
            //ToDo.Should().Be(_ToDo);
            //ToDo.Id.Equals(_ToDo.Id);

        }

        // [Then(@"get then all and you have your")]
        // public void ThenGetThenAllAndYouHaveYour(Table table)
        //{
        //     Table.
        // }



    }
}
