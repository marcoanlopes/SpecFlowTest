Feature: ToDoController
	This feature tests controller create

@ToDoControllerCreate
Scenario: create a ToDo object in memory (or database)
	Given a user has entered information about ToDo novo nome
	Given it gives more information about ToDo descriptionaaa
	Then that ToDo should be stored in the system
	Then the response should be OK



#
#
#	| Field           | Value                    |
#	| ToDoName        | objeto ToDo              |
#	| Description	  | descrição do objeto ToDo |
#	| CreationDate    | 2021/09/20               | 
	#When the controller should send the object to the repository
	#Then the repository save the object in database