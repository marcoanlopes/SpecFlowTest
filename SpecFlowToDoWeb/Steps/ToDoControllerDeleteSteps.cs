using FluentAssertions;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ToDoWeb.HttpTest;
using ToDoWeb.Models;

namespace SpecFlowToDoWeb.Features
{
    [Binding]
    public class ToDoControllerDeleteSteps
    {
        private ToDo _ToDo = new ToDo();
        private IRestResponse _restResponse;
        int deleteId = 0;
        string codigoDeResposta = "";

        [Given(@"a creation of an object ToDo")]
        public void GivenACreationOfAnObjectToDo(Table table)
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
        
        [Given(@"when user send a delete requisition within an id (.*)")]
        public void GivenWhenUserSendADeleteRequisitionWithinAnId(int id)
        {
            deleteId = id;
        }
        
        [Then(@"the system execute the requisition")]
        public void ThenTheSystemExecuteTheRequisition()
        {
            var _request = new HttpRequestWrapper()
              .SetMethod(Method.DELETE)
              .SetResourse("https://localhost:5001/api/todo/delete/" + deleteId);

            _restResponse = new RestResponse();
            _restResponse = _request.Execute();
            codigoDeResposta = _restResponse.StatusDescription;
        }
        
        [Then(@"the system should respond with (.*)")]
        public void ThenTheSystemShouldRespond(string response)
        {
            codigoDeResposta.Should().Be(response);
        }
    }
}
