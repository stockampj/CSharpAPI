# _Hair Salon_

#### _This web app was created to test C# API calls through controller. This project uses Swagger to quickly test and run the endpoints. All of this is done in the .Net environment. Data is handled using Entity which is linked to a local SQL server._

#### By _Joel Stockamp_

## Description

_A person can track a park, associated trails, and add various activities shared throughout the parks. _

## Setup/Installation Requirements

* download this package from github: https://github.com/stockampj/CSharpAPI.git
* open a terminal and navigate to the project folder
* enter the command "dotnet restore"
* you will need a SQL database to hold the data tables for this project. You may need to download the necessary software to run it. Once you've set up a local server on Port 3306, continue to the next step
* if you want the database to be built by the code, run the command "dotnet ef database update". Enter the command "dotnet run" and open a browser to http://localhost:5000/.
* At this point run the command "dotnet run" from a terminal and open a browser to http://localhost:5000/.

Activities can searched by activityName or activityId vit a GET request to retrieve a specific type or the whole list can be pulled if those parameters are not specified. A POST request requires a JSON with activityName as a required field. PUT requests require ActivityId field in the url path. DELETE requests require this as well.

Parks can be searched with a GET request by parkName or parkId to retrieve a specific type or the whole list can be pulled if those parameters are not specified. Additionally, a parkActivity bool can be supplied if you want the request to return with associated activities. A POST request requires a JSON with the following fields parkName, description, location. PUT requests require parkId field to be supplied in the path.. DELETE requests require this as well.

Trails can be searched with a GET request if no parameters are not specified. The parkId field will return all trails in a park. Min and max length and challenge ratings (1-5) can be specified by lengthMin, lengthMax, challengeMin, challengeMax. A POST request requires a JSON with the following fields trailName, ParkId, length, and challengRating. PUT requests require the parkId to be supplied in the path.. DELETE requests require this as well.


## Known Bugs

_The park should have a many to many relationship with activities but I was unable to accomplish this. I disabled half the relationship so that a park can contain many activities, but the activities are unware of the relationship._

## Support and contact details

_Please let me know if you want to chat: stockampj@gmail.com_

## Technologies Used

_C#, VSCode NuGet, MVC, Entity_

### License

*MIT License*

Copyright (c) 2019 **_Joel Stockamp_**
