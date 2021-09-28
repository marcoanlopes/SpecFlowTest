Feature: ToDoControllerUpdate
	This feature tests the ToDoControllerUpdate

@ToDoControllerUpdate
Scenario: Update a ToDo object
	Given a ToDo id 40
	And the user set new values for the object
	| Field           | Value               |
	| ToDoName        | Novo nome update do objeto ToDo         |
	| Description	  | Nova descrição do objeto ToDo |
	| CreationDate    | 2021/09/20          | 
	Then the system will try to find and update the object
	Then the result should be OK