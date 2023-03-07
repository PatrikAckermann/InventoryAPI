
# InventoryAPI
API made in C# to talk to an Entity Framework database.

To use this program you have to create the database by using the following 2 commands in the Package-Manager-Console in Visual Studio:
-   "Add-Migration name" - Replace name with a name for the migration
-   "Update-Database" After this you should be able to run the API

### API Endpoints 
The following string shows how to contact the API:
"{domain}/api/{requestType}".

"domain" has to be replaced by the server domain. If hosted on your own machine you can use "https://localhost:7070/". "requestType" has to be replaced with the type of request you want to make. So for a post request you have to replace it with "post".

You can then either use the id parameter or add "/list" to get a list with all entries. With the list endpoint you can also use additional parameters to filter the list.

URL example: "https://bestinventorysystem.com/api/get/item?id=1" or "https://localhost:7070/api/get/location/list?name=office"
#### Get

 - /api/get/user
	 - You can get a user by ID and by list. The API returns a JSON with the user id and name.
	 - List parameters:
		 - name (string): The name parameter searches for users whose names include the provided string.
 - /api/get/category
	 - You can get a category by ID and by list. The API returns a JSON with the category id and name.
	 - List parameters:
		 - name (string): The name parameter searches for categories whose names include the provided string.
 - /api/get/location
	 - You can get a location by ID and by list. The API returns a JSON with the location id and name.
	 - List parameters:
		 - name (string): The name parameter searches for locations whose names include the provided string.
 - /api/get/object
	 - You can get an object type by ID and by list. The API returns a JSON with the object id, category, and name.
	 - List parameters:
		 - name (string): The name parameter searches for object types whose names include the provided string.
		 - category (int id): The category searches for object types that are in the provided category id.
 - /api/get/item
	 - You can get an item by ID and by list. The API returns a JSON with the item id, the object type, the location, the description, the user (can be null), and the amount.
	 - List parameters:
		 - description (string): The description parameter searches for items whose descriptions include the provided string.
		 - objectType(int id): The objectType parameter searches for items that are the provided object type id.
		 - location (int id): The location parameter searches for items that are located at the provided location id.
		 - user (int id): The user parameter searches for items that are used by the provided user id.
		 - minAmount (int amount): The minAmount parameter searches for items that have at least the provided amount in the inventory.
		 - maxAmount (int amount): The maxAmount parameter searches for items that have at most the provided amount in the inventory.

#### Post
- /api/post/user
	- Takes raw json data to create a new user.
	- Keys:
		- name (string): The name key gives the user a name.
- /api/post/category
	- Takes raw json data to create a new category.
	- Keys:
		- categoryName (string): The categoryName key gives the category a name.
- /api/post/location
	- Takes raw json data to create a new location.
	- Keys:
		- locationName (string): The locationName key gives the location a name.
- /api/post/object
	- Takes form data to create a new object type.
	- Keys:
		- name (string): The name key gives the object type a name.
		- category (int id): The category key gives the object type a category.
- /api/post/item
	- Takes form data to create a new item.
	- Keys:
		- description (string): The description key gives the item a description/name.
		- objectType (int id): The object type key gives the item an object type.
		- location (int id): The location key gives the item a location.
		- amount (int): The amount key specifies the amount of this item in the given location.
		- user (int id, optional): The user key specifies the user of the item. It is optional for items that are for general use instead of by a specific user.

#### Update
The update endpoint is currently not implemented.
#### Delete
- /api/delete/user
	- Deletes the user using the query-parameter specified id.
- /api/delete/category
	- Deletes the category using the query-parameter specified id.
- /api/delete/location
	- Deletes the location using the query-parameter specified id.
- /api/delete/object
	- Deletes the object using the query-parameter specified id.
- /api/delete/item
	- Deletes the item using the query-parameter specified id.
