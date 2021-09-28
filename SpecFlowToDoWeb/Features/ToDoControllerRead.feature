Feature: ToDoControllerRead
	Gets a list of the ToDo

@ToDoControllerList
Scenario: Get a list of ToDo
	Given a creation of a ToDo list
	| Field           | Value               |
	| Id              | 30                   |
	| ToDoName        | objeto ToDo         |
	| Description	  | descrição do objeto ToDo |
	| CreationDate    | 2021/09/20          | 
	When the user send a requisition to get the list to the server
	Then the result should be a list of ToDo
	| Field           | Value               |
	| Id              | 30                   |
	| ToDoName        | objeto ToDo         |
	| Description	  | descrição do objeto ToDo |
	| CreationDate    | 2021/09/20          |
	Then system should respond with OK
	