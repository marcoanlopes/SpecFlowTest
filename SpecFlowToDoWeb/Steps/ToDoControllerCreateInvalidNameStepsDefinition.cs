using FluentAssertions;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using ToDoWeb.HttpTest;
using ToDoWeb.Models;

namespace SpecFlowToDoWeb.Features
{
    [Binding]
    public class ToDoControllerCreateInvalidNameStepsDefinition
    {
        private ToDo _ToDo = new ToDo();
        private IRestResponse _restResponse;
        private HttpStatusCode _statusCode;
        ToDo contextToDo = new ToDo();
        string codigoDeResposta = "";


        [Given(@"the prop ToDo Id (.*)")]
        public void GivenThePropToDoId(int id)
        {
            _ToDo.Id = id;
        }
        
        [Then(@"the prop Description ""(.*)""")]
        public void ThenThePropDescription(string description)
        {
            _ToDo.Description = description;
        }
        
        [Then(@"the system try to save the object")]
        public void ThenTheSystemTryToStoredTheObjectInTheSystem()
        {
            contextToDo.Description = _ToDo.Description;
            contextToDo.Id = _ToDo.Id;
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
        
        [Then(@"the error response should be (.*)")]
        public void ThenTheErrorResponseShouldBeBadRequest(string response)
        {
            codigoDeResposta.Should().Be(response);
        }
    }
}
