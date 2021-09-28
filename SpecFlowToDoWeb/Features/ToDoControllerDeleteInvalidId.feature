Feature: ToDoControllerDeleteInvalidId
	This feature tests a delete execution within an invalid Id

@ToDoControllerDeleteInvalidId
Scenario: Delete a ToDo object with an invalid Id.
	Given a creation of an object ToDo
	| Field           | Value               |
	| Id              | 7                  |
	| ToDoName        | objeto ToDo invalid delete         |
	| Description	  | descrição do objeto ToDo |
	| CreationDate    | 2021/09/20          | 
	And when user send a delete requisition within an id 10
	Then the system execute the requisition
	Then the system should respond with Not Found