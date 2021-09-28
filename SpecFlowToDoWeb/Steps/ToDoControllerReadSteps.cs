using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ToDoWeb.HttpTest;
using ToDoWeb.Models;

namespace SpecFlowToDoWeb.Steps
{
    [Binding]
    public class ToDoControllerReadSteps
    {
        private ToDo _ToDo = new ToDo();
        private IRestResponse _restResponse;
        string codigoDeResposta = "";
        private List<ToDo> _contextToDo;

        [Given(@"a creation of a ToDo list")]
        public void GivenACreationOfAToDoList(Table table)
        {

            var ToDo = table.CreateInstance<ToDo>();
            _ToDo.Id = ToDo.Id;
            _ToDo.CreationDate = ToDo.CreationDate;
            _ToDo.Description = ToDo.Description;
            _ToDo.ToDoName = ToDo.ToDoName;

            var request = new HttpRequestWrapper()
              .SetMethod(Method.POST)
              .SetResourse("https://localhost:5001/api/todo/create")
              .AddJsonContent(_ToDo);

            request.Execute();

        }

        [When(@"the user send a requisition to get the list to the server")]
        public void WhenTheUserSendARequisitionToGetTheListToTheServer()
        {
            var _request = new HttpRequestWrapper()
              .SetMethod(Method.GET)
              .SetResourse("https://localhost:5001/api/todo/list/");

            _restResponse = new RestResponse();
            _restResponse = _request.Execute();
            _contextToDo = JsonConvert.DeserializeObject<List<ToDo>>(_restResponse.Content);
            //contextToDo = _restResponse.Content;
            codigoDeResposta = _restResponse.StatusDescription;
        }
        
        [Then(@"the result should be a list of ToDo")]
        public void ThenTheResultShouldBeAListOfToDo(Table table)
        {
            var ToDo = table.CreateInstance<ToDo>();
            ToDo.ToDoName.Should().Be(_ToDo.ToDoName);
            ToDo.Id.Should().Be(_ToDo.Id);
            ToDo.Description.Should().Be(_ToDo.Description);
            ToDo.CreationDate.Should().Be(_ToDo.CreationDate);
            
        }

        [Then(@"system should respond with (.*)")]
        public void ThenSystemShouldRespondWith(string response)
        {
            codigoDeResposta.Should().Be(response);
        }
    }
}
