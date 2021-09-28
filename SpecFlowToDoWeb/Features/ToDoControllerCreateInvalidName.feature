Feature: ToDoControllerCreateInvalidName
	This feature tests the creation of an object within an invalid name

@ToDoControllerCreateInvalidName
Scenario: Add an object without a valid name
	Given the prop ToDo Id 8
	Then the prop Description "Nova descrição"
	Then the system try to save the object
	Then the error response should be Bad Request
