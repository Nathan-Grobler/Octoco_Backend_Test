<h1>Project Title</h1>

SSN (Zombie Survival Social Network). The world as we know it has fallen into an apocalyptic scenario. A laboratory-made virus is transforming human beings and animals into zombies, hungry for fresh flesh.

You, as a zombie resistance member (and the last survivor who knows how to code), was designated to develop a system to share resources between non-infected humans.

<h3>Introduction</h3>

This project contains 4 api endpoints to fulfill the following use cases for and about survivors of the apocalypse.
- Add survivors to the database
- List all survivors
- Update survivor location
- Flag survivor as infected

This was achieved using a ASP.Net Core Web Api project with C# and a local database that is generated with entity frameworks via the package manager console.

<h3>Getting Started</h3>

To Run Api:
- Open up octoco_backend_test.sln in Visual Studio
- Navigate to Package Manager Console and run Update-Database command to setup the database for the api
- Run octoco_backend_test 
- Have fun playing around with the endpoints

<h2>Api Documentation</h2>
<h3>GetAllSurvivors</h3>

**URL** : /api/Survivors/GetAllSurvivors'

**RequestType** : GET

**Description** : Returns a List of all the Survivors in the database with the name,age,gender(0=Male,1=Female,2=Other),latitude

**Returns**: 200, [
  {
    "name": "John",
    "age": 26,
    "gender": 0,
    "latitude": -32.241844,
    "longitude": 22.2995
  },
  {
    "name": "Mary",
    "age": 33,
    "gender": 1,
    "latitude": 40.712776,
    "longitude": -74.005974
  },
  {
    "name": "Tom",
    "age": 45,
    "gender": 0,
    "latitude": 51.507351,
    "longitude": -0.127758
  }
]
<h3>CreateSurvivor</h3>

**URL** : /api/Survivors/CreateSurvivor

**Request Type** : POST

**Description** : Create Survivors takes in a survivor object and adds a survivor to the database

**Body Example** : {
  "id": 0,
  "name": "string",
  "age": 0,
  "gender": 0,
  "latitude": 0,
  "longitude": 0,
  "inventory": {
    "additionalProp1": 0,
    "additionalProp2": 0,
    "additionalProp3": 0
  },
  "isInfected": true
}

**Returns** : 200, "New Survivor {survivor.Name} has been added to the Zombie Survival Social Network"

<h4>UpdateLocation</h4>

**URL** : /api/Survivors/UpdateLocation/{id}/{latitude}/{longitude}

**Request Type** : PUT

**Desrciption** : takes in a Id and updates the longitude and latitude of that survivor

**Returns** : 200, "location of survivor {id} updated to ({latitude}, {longitude})".

<h4>FlagAsInfected</h4>

**URL** : /api/Survivors/FlagAsInfected/{id}

**Request Type** : PUT

**Description** : Takes in a Id of a survivor and marks that survivor as infected

**Returns** : 200, "Survivor {id} updated to Infected".

<h3> Challenges </h3>
Faced a few challenges regarding this project from loadshedding to time management. It was a interesting small project and quite enjoyable.
Biggest coding problems faced on this project would be think about how to incoporate the inventory system for the survivors I was between two choices one building a table in Sql
or having a dictionary within the survivor class called inventory where a key and value combos could be stored to represent inventory I choose the second option due to the fact that it would 
be the easiest to add inventory when adding the survivor rather than handling a whole other table with key pairs linking the 2 
