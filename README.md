# DotNetMongo
ORM for .net core and Mongo db

***
This project aims to provide a feasible ORM that supports the connectivity between mongodb and a .net core application. 
Further more, since the Entity framework core does not support MongoDB, we aim to provide an abstract entity framework with the help of the MongoDB driver for .net core.
Project follows the code first approach hence the models should be written manually into the entity project. 

## Setup and Usage 

### Set Up

#### Loading Project 
1. Clone the repository and load the project into your repository. 
2. Reference the entities project into your main project

#### Project Initialization
Add following code snippet into Startup method of the Startup.cs class of the main project

```
public Startup(IConfiguration configuration)
{
    Configuration = configuration;

    //initializes the db context
    new DBContext();
}
```

### Usage 

#### Creating a New Model
Go to the models folder and add a new class under the name of the expected database model. 
Following code snippets shows an example model "Car". 

```
public class Car
{
    public ObjectId Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int TopSpeed { get; set; }
}
```

ObjectId is the shared key in this context. 

#### Initializing the DB Context 
First declare all the models as follows :

```
public AbstractContext<Car> car ;
```

In the above example the Car model is declared. 

In order to initialize the models inside the DB context an entry should be added to the constructor for each model. 

```
 public DBContext()
{
    if(context == null)
    {
        //initialize the models here.
        car = new AbstractContext<Car>();

        //sets the current instance of the DB to a static variable.
        Context = this;
    }
}
```

If there exists a shard key, shard key can be included by calling the setShardKey() method and passing in a BsonDocument which includes the relevant key value pairs.

For a single shard key

```
if(context == null)
{
    //initialize the models here.
    car = new AbstractContext<Car>();
    //add shard key if exist by adding elements to the BsonDocument. 
    car.setShardKey(new BsonDocument().Add("Id", 1));

    //sets the current instance of the DB to a static variable.
    Context = this;
}
```

For multiple shard keys

```
car.setShardKey(new BsonDocument().Add("Id", 1).Add("Model", 1));
```

#### Calling the entitis from your controller

Let us consider the we have the following entity car :

```
 Car c = new Car();
 c.Make = "BMW";
 c.Model = "E30";
 c.TopSpeed = 500;
```
1. Create new entity.

```
Car c1 = (Car)DBContext.Context.car.Create(c);
```
2. Delete an entity.

```
Bool success = DBContext.Context.car.Delete(new ObjectId("60ccd69ba23c6c4306f06798"));
```

3. Get an entity.

```
Car c1 = (Car)DBContext.Context.car.Get(new ObjectId("60ccd69ba23c6c4306f06798"));
```

4. Get all entities.

```
IEnumerable<Car> c1 = DBContext.Context.car.Get();
```

5. Update and entity.
In order to update an entity you need an object of the entity and is important that it contains the correct Id.

For example consider the previously defined object.

```
 Car c = new Car();
 c.Make = "BMW";
 c.Model = "E30";
 c.TopSpeed = 500;
 c.Id = new ObjectId("60cdb47b0f485059b6308da9");
```
Next call the update method.

```
Car c1 = (Car)DBContext.Context.car.Update(new ObjectId("60cdb47b0f485059b6308da9"), c);
```

6. Custom queries 
Frame work also support linq style custom queries. 

```
Car c1 = (Car)DBContext.Context.car.Collection().Find(x => x.Id == c.Id).Single();
```

## Known Issues 
Project does not support the Database first and the lazy loading architecture.