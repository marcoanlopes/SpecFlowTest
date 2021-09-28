Feature: ToDoControllerDelete
	Feature that tests ToDo tests delete

@ToDoControllerDelete
Scenario: delete a ToDo Object
	Given a creation of an object ToDo
	| Field           | Value               |
	| Id              | 20                  |
	| ToDoName        | objeto ToDo         |
	| Description	  | descrição do objeto ToDo |
	| CreationDate    | 2021/09/20          | 
	And when user send a delete requisition within an id 20
	Then the system execute the requisition
	Then the system should respond with OK