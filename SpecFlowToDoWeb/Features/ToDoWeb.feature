Feature: ToDoWeb
	This feature creates a ToDo Object

@TesteDaModelToDo
Scenario: Create an object ToDo
	Given the first name is objeto ToDo
	Given the description is descrição do objeto ToDo
	Given the unique id: 7
	Given the object creation date 2021/09/20
	Then get them all and you have your ToDo object
	| Field           | Value               |
	| Id              | 7                   |
	| ToDoName        | objeto ToDo         |
	| Description	  | descrição do objeto ToDo |
	| CreationDate    | 2021/09/20          | 
