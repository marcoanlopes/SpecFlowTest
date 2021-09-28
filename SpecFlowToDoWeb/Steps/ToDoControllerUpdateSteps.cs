using FluentAssertions;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ToDoWeb.HttpTest;
using ToDoWeb.Models;

namespace SpecFlowToDoWeb.Steps
{
    [Binding]
    public class ToDoControllerUpdateSteps
    {
        private ToDo _ToDo = new ToDo();
        private ToDo _ToDoTemp;
        private IRestResponse _restResponse;
        string codigoDeResposta = "";

        [Given(@"a ToDo id (.*)")]
        public void GivenAToDoId(int id)
        {
            _ToDo.Id = id;
            _ToDoTemp = new ToDo
            {
                ToDoName = "Novo ToDo",
                CreationDate = null,
                Description = "Descrição",
                Id = 40
            };

            var request = new HttpRequestWrapper()
              .SetMethod(Method.POST)
              .SetResourse("https://localhost:5001/api/todo/create")
              .AddJsonContent(_ToDoTemp);
            request.Execute();
        }
        
        [Given(@"the user set new values for the object")]
        public void GivenTheUserSetNewValuesForTheObject(Table table)
        {
            var ToDo = table.CreateInstance<ToDo>();
            _ToDoTemp.CreationDate = ToDo.CreationDate;
            _ToDoTemp.Description = ToDo.Description;
            _ToDoTemp.ToDoName = ToDo.ToDoName;

            

        }

        [Then(@"the system will try to find and update the object")]
        public void ThenTheSystemWillTryToFindAndUpdateTheObject()
        {
            var request = new HttpRequestWrapper()
              .SetMethod(Method.PUT)
              .SetResourse("https://localhost:5001/api/todo/update/" + _ToDoTemp.Id)
              .AddJsonContent(_ToDoTemp);

            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            //_statusCode = _restResponse.StatusCode;
            codigoDeResposta = _restResponse.StatusDescription;

        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {
            codigoDeResposta.Should().Be(result);
        }
    }
}
