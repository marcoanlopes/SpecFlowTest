using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ToDoWeb.Data;
using ToDoWeb.Models;
using ToDoWeb.Controllers;
using ToDoWeb.Interface;
using ToDoWeb.HttpTest;
using RestSharp;
using NUnit.Framework;
using FluentAssertions;

namespace SpecFlowToDoWeb.Steps
{
    [Binding]
    public sealed class ToDoControllerStepDefinition
    {


        private ToDo _ToDo = new ToDo();
        //private IToDoRepository toDoRepository;
        private IRestResponse _restResponse;
        private HttpStatusCode _statusCode;
        ToDo contextToDo = new ToDo();
        string codigoDeResposta = "";


        //private ToDoController _toDoController;
        //private DataContext _DataContext;
        //private readonly DataContext _DataContext;
        //private readonly ToDoController toDoController;


        //[Given("ToDo object to the context")]
        //public void GivenTheToDoObject(Table ToDoTable)
        //{
        //    _ToDo = ToDoTable.CreateInstance<ToDo>();
        //    _DataContext.ToDos.Add(_ToDo);
        //}

        //[When("the controller should send the object to the repository")]
        //public void WhenControllerSendObject()
        //{           
        //}

        [Given(@"a user has entered information about ToDo (.*)")]
        public void GivenAUserHasEnteredInformationAboutAToDo(string name)
        {
            _ToDo.ToDoName = name;
        }
        [Given(@"it gives more information about ToDo (.*)")]
        public void GivenMoreInformation(string description)
        {
            _ToDo.Description = description;
        }

        [Then(@"that ToDo should be stored in the system")]
        public void ThenThatToDoShouldBeStoredInTheSystem()
        {
            contextToDo.Description = _ToDo.Description;
            contextToDo.ToDoName = _ToDo.ToDoName;
            contextToDo.Id = 5;
            contextToDo.CreationDate = "2021/09/20";


            var request = new HttpRequestWrapper()
                          .SetMethod(Method.POST)
                          .SetResourse("https://localhost:5001/api/todo/create")
                          .AddJsonContent(contextToDo);
            
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            _statusCode = _restResponse.StatusCode;
            codigoDeResposta = _restResponse.StatusDescription;

        }

        [Then(@"the response should be (.*)")]
        public void GivenModelStateIsCorrect(string response)
        {
            codigoDeResposta.Should().Be(response);






            var _request = new HttpRequestWrapper()
              .SetMethod(Method.DELETE)
              .SetResourse("https://localhost:5001/api/todo/delete/" + contextToDo.Id);
            _request.Execute();
        }



    }
}
