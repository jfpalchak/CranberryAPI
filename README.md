<br>
<h1 align="center">
  <u><big><b>Cranberry API</b></big></u>
</h1>
<p align="center">
    <!-- Project Avatar/Logo -->
    <br/>
    <a href="https://github.com/jfpalchak/cranberry">
        <img width="100" height="100" src="https://img.icons8.com/external-colored-outline-lafs/100/external-cranberry-flavors-colored-outline-part-2-colored-outline-lafs.png" alt="external-cranberry-flavors-colored-outline-part-2-colored-outline-lafs"/>
    </a>
    <p align="center">
      ___________________________
    </p>
    <!-- GitHub Link -->
    <p align="center">
        <a href="https://github.com/jfpalchak">
            <strong>by Joey Palchak</strong>
        </a>
    </p>
    <!-- Project Shields -->
    <p align="center">
        <!-- <a href="https://github.com/jfpalchak/CranberryAPI/graphs/contributors">
            <img src="https://img.shields.io/github/contributors/jfpalchak/CranberryAPI.svg?style=plastic">
        </a>
        &nbsp; -->
        <a href="https://github.com/jfpalchak/CranberryAPI/stargazers">
            <img src="https://img.shields.io/github/stars/jfpalchak/CranberryAPI.svg?color=yellow&style=plastic">
        </a>
        &nbsp;
        <a href="https://github.com/jfpalchak/CranberryAPI/issues">
            <img src="https://img.shields.io/github/issues/jfpalchak/CranberryAPI?style=plastic">
        </a>
        &nbsp;
        <a href="https://github.com/jfpalchak/CranberryAPI/blob/main/LICENSE.txt">
            <img src="https://img.shields.io/github/license/jfpalchak/CranberryAPI?color=orange&style=plastic">
        </a>
        <!-- &nbsp;
        <a href="">
            <img src="https://img.shields.io/badge/">
        </a> -->
    </p>    
</p>

<p align="center">
  <small>Initiated December 8th, 2023.</small>
</p>

<!-- Project Links -->
<p align="center">
    <a href="https://github.com/jfpalchak/CranberryAPI.git"><big>Project Docs</big></a> ·
    <a href="https://github.com/jfpalchak/CranberryAPI/issues"><big>Report Bug</big></a> ·
    <a href="https://github.com/jfpalchak/CranberryAPI/issues"><big>Request Feature</big></a>
</p>

------------------------------
### <u>Table of Contents</u>
* <a href="#-about-the-project">About the Project</a>
    * <a href="#-description">Description</a>
    * <a href="#-known-bugs">Known Bugs</a>
    * <a href="#-technology-used">Built With</a>
    <!-- * <a href="#-preview">Preview</a> -->
* <a href="#-getting-started">Getting Started</a>
    * <a href="#-prerequisites">Prerequisites</a>
    * <a href="#-setup-and-use">Setup and Use</a>
* <a href="#-api-documentation">API Documentation</a>
    * <a href="#registering-an-account-and-using-the-json-web-token">User Authentication & Authorization</a>
    * <a href="#api-endpoints">API Endpoints</a>
* <a href="#-contributors">Auxiliary</a>
    * <a href="#-contributors">Contributors</a>
    * <a href="#-contact-and-support">Contact</a>
    * <a href="#-license">License</a>
    * <a href="#-acknowledgements">Acknowledgements</a>
    
------------------------------

## 🌐 About the Project

### 📖 Description

The Cranberry API allows users to both register and sign in to their own account, as well as post, put, and delete their own Journal entries and account information. This API utilizes RESTful principles, as well as Json Web Tokens (JWT) for authentication & authorization.

Only authenticated users have access to `GET`, `POST`, `PUT`, and `DELETE` functionality throughout the API.

<!-- Any endpoint in the API that returns a _list_ of Journals utilizes Pagination.  -->

### 🦠 Known Bugs

* If any bugs are discovered, please contact the author.
<!-- * This is not a real API, which is the greatest shame of all. -->

### 🛠 Technology Used
* [Visual Studio Code](https://code.visualstudio.com/)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
* [MySQL 8.0.34](https://dev.mysql.com/)
* [Entity Framework Core 6.0.0](https://docs.microsoft.com/en-us/ef/core/)
* [Entity Framework Core CLI Tools 6.0.0](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
* [Entity Framework Core Identity 6.0.0](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity)
* [JWT Bearer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authentication.jwtbearer)
* [Swagger - NSwag 13.3.0](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-3.1&tabs=visual-studio)
* [Postman](https://www.postman.com/)

<!-- ### 🔍 Preview -->

------------------------------

## 🏁 Getting Started

### 📋 Prerequisites

#### Install .NET Core
* On macOS with Apple Chip:
  * [Click here](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.402-macos-arm64-installer) to download the .NET Core SDK from Microsoft Corp for macOS.
* On macOs with Intel Chip:
  * [Click here](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.402-macos-x64-installer) to download the .NET Core SDK from Microsoft Corp for macOS.
* On Windows:
  * [Click here](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.402-windows-x64-installer) to download the 64-bit .NET Core SDK from Microsoft Corp for Windows.

#### Install dotnet-script
In Terminal for macOS or PowerShell for Windows, enter the following command to install the REPL dotnet-script:

 ```
 $ dotnet tool install -g dotnet-script
 ```

#### Install dotnet-ef
For Entity Framework Core, we'll use a tool called dotnet-ef to reference the project's migrations and update our database accordingly. To install this tool globally, run the following command in your terminal:

```
$ dotnet tool install --global dotnet-ef --version 6.0.0
```

Optionally, you can run the following command to verify that EF Core CLI tools are correctly installed:

```
$ dotnet ef
```

#### Install MySQL Workbench
This project assumes you have MySQL Server and MySQL Workbench installed on your system. If you do not have these tools installed, follow along with the installation steps for the the necessary tools introduced in the series of lessons found here on [LearnHowToProgram](https://full-time.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).

Or, [Download and install the appropriate version of MySQL Workbench](https://dev.mysql.com/downloads/workbench/).

#### Install Postman
(Optional) [Download and install Postman](https://www.postman.com/downloads/).

#### Code Editor

  To view or edit the code, you will need a code editor or text editor. A popular open-source choice for a code editor is VisualStudio Code.

  1) Code Editor Download:
     * [VisualStudio Code](https://code.visualstudio.com/)
  2) Click the download most applicable to your OS and system.
  3) Wait for download to complete, then install -- Windows will run the setup exe and macOS will drag and drop into applications.
  4) Optionally, create a [GitHub Account](https://github.com)

### ⚙️ Setup and Use

  #### Cloning

  1) Navigate to the [Cranberry API repository here](https://github.com/jfpalchak/CranberryAPI.git).
  2) Click 'Clone or download' to reveal the HTTPS url ending with .git and the 'Download ZIP' option.
  3) Open up your system Terminal or GitBash, navigate to your desktop with the command: `cd Desktop`, or whichever location suits you best.
  4) Clone the repository to your desktop: `$ git clone https://github.com/jfpalchak/CranberryAPI.git`
  5) Run the command `cd CranberryAPI/CranberryAPI` to enter into the project directory.
  6) View or Edit:
      * Code Editor - Run the command `code .` to open the project in VisualStudio Code for review and editing.
      * Text Editor - Open by double clicking on any of the files to open in a text editor.

  #### Download

  1) Navigate to the [Cranberry API repository here](https://github.com/jfpalchak/CranberryAPI.git).
  2) Click 'Clone or download' to reveal the HTTPS url ending with .git and the 'Download ZIP' option.
  3) Click 'Download ZIP' and extract.
  4) Open by double clicking on any of the files to open in a text editor.

  #### AppSettings

  1) Create a new file in the CranberryAPI project directory named `appsettings.json`
  2) Add in the following code snippet to the new `appsettings.json` file:
  
  ```json
  {
      "Logging": {
          "LogLevel": {
          "Default": "Warning"
          }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
          "DefaultConnection": "Server=localhost;Port=3306;database=cranberry_api;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
      },
      "JWT": {
          "ValidAudience": "example-audience",
          "ValidIssuer": "example-issuer",
          "Secret": "[YOUR-SECRET-HERE]"
    }
  }
  ```
  3) Change the server, port, and user id as necessary. Replace `[YOUR-USERNAME-HERE]` and `[YOUR-PASSWORD-HERE]` with your personal MySQL username and password (set at installation of MySQL).
  4) In order to properly implement JSON Web Tokens for API authorization, replace `[YOUR-SECRET-HERE]` with your own personalized string.
     1) NOTE: The `Secret` is a special string that will be used to encode our JWTs, to make them unique to our application. Depending on what type of algorithm being used, the Secret string will need to be a certain length. **In this case, it needs to be at least 16 characters long**. 
   
  #### Database
  1) Navigate to CranberryAPI/CranberryAPI directory using the MacOS Terminal or Windows Powershell (e.g. `cd Desktop/CranberryAPI/CranberryAPI`).
  2) Run the command `dotnet ef database update` to generate the database through Entity Framework Core.
  3) (Optional) To update the database with any changes to the code, run the command `dotnet ef migrations add <MigrationsName>` which will use Entity Framework Core's code-first principle to generate a database update. 4) After, run the previous command `dotnet ef database update` to update the database.

  #### Launch the API
  1) Navigate to CranberryAPI/CranberryAPI directory using the MacOS Terminal or Windows Powershell (e.g. `cd Desktop/CranberryAPI/CranberryAPI`).
  2) Run the command `dotnet watch run` to have access to the API in Postman or browser.

------------------------------

## 🛰️ API Documentation
Explore the API endpoints in Postman or a browser. However, take note: you will not be able to utilize authentication in a browser.

### Using Swagger Documentation 
To explore the Cranberry API with NSwag, launch the project using `dotnet run` with the Terminal or Powershell, and input the following URL into your browser: `http://localhost:5000/swagger`

### Registering an Account and Using the JSON Web Token
In order to be authorized to use the `GET`, `POST`, `PUT`, and `DELETE` functionality of the API, please authenticate yourself through Postman:

### Registration
Again, we'll be using Postman for this example. Let's setup a `POST` request to the `users/register` endpoint. Select the 'Body' tab, choose the 'raw' radio button, and select 'JSON' from the dropdown selection.

In the Body of the Post request, use the following format:
```json
{
    "email": "email@test.com",
    "userName": "testUser",
    "password": "Password123!"
}
```

#### Example Query
```
http://localhost:5000/api/users/register
```

#### Sample JSON Response
```json
{
    "status": "Success",
    "message": "User has been successfully created."
}
```

Here's an example of what this should look like in Postman:

<a href="https://ibb.co/h78d8zH"><img src="https://i.ibb.co/dWKpKY6/Register.png" alt="Register endpoint in Postman" border="0" /></a>
  
Note that the password must contain at least six characters, one non-alphanumeric character, at least one digit lowercase letter, at least one uppercase letter and at least two unique characters. An invalid password will generate the following response from the API:  

<a href="https://ibb.co/y00H6yS"><img src="https://i.ibb.co/VVVfgSm/Password-Req.png" alt="Password-Req error in Postman" border="0" /></a>     

### `POST` Sign In
Now that we've registered an account with our API, we'll need to authenticate our account and generate a JSON Web Token. We'll be using Postman again for this example. 

Let's setup another `POST` request to the `users/signin` endpoint. Select the 'Body' tab, choose the 'raw' radio button, and select 'JSON' from the dropdown selection.

In the Body of the Post request, use the following format:
```json
{
    "email": "email@test.com",
    "password": "Password123!"
}
```
#### Example Query
```
http://localhost:5000/api/users/signin
```

#### Sample JSON Response
```json
{
    "status": "Success",
    "message": "email@test.com signed in.",
    "token": "xxxx.xxxx.xxxx",
    "userId": "xxx"
}
```

Here's an example of what this should look like in Postman:

<a href="https://ibb.co/vXGCrG1"><img src="https://i.ibb.co/z6YWLYs/Screenshot-2023-12-17-at-10-56-36-PM.png" alt="Sign In endpoint in Postman" border="0"></a>

#### Using the JSON Web Token
Now let's copy that token from the response, and add it as an authorization header to our next request. Copy the token from the body, and click on the Authorization tab in Postman. On the 'Type', make sure that is set to 'Bearer Token', and then paste in the token in the field on the right.

Here's an example of what that should look like in Postman:

<a href="https://ibb.co/Wzt8kDx"><img src="https://i.ibb.co/2MNVv8n/using-jwt.png" alt="Using a JSON Web Token in Postman" border="0"></a>

Until the Token expires, you should now have access to all endpoints requiring user authorization!

### Note on CORS
CORS is a W3C standard that allows a server to relax the same-origin policy. It is not a security feature, CORS relaxes security. It allows a server to explicitly allow some cross-origin requests while rejecting others. An API is not safer by allowing CORS.
For more information or to see how CORS functions, see the [Microsoft documentation](https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.2#how-cors).

<!-- ### Note on Pagination
For certain endpoints, the Cranberry API returns a default of 10 results per page at a time, which is also the maximum number of results possible.

To modify this, use the query parameters `pageSize` and `pageNumber` to alter the response results displayed. The `pageSize` parameter will specify how many results will be displayed, and the `pageNumber` parameter will specify which element in the response the limit should start counting. -->

<!-- #### Example Query
```
https://localhost:5000/api/parks?pageNumber=1&pageSize=2
```

To use the defaults, _do not include_ `pageNumber` or `pageSize`. -->
<!-- 
### Notes on Adding Search Parameters
When adding more than one search parameter to an endpoint query, be sure to include an `&` between search parameters, as shown in the example query on pagination just above. -->

------------------------------

### API Endpoints
Base URL: `https://localhost:5001`


|          |                      Users                                             |
|  :---:   |                      :---                                              |
| POST     | <a href="#register"> /api/users/register </a>                          |
| POST     | <a href="#signin"> /api/users/signin </a>                              |
| GET      | <a href="#get-apiusersprofile"> /api/users/profile </a>                |  
|          |                                                                        |
| GET      | <a href="#get-apiusersid"> /api/users/{id} </a>                        |
| PUT      | <a href="#put-apiusersid"> /api/users/{id} </a>                        |
| DELETE   | <a href="#delete-apiusersid"> /api/users/{id} </a>                     |
|          |                 Users / Journals                                       |
| GET      | <a href="#get-apiusersidjournals"> /api/users/{id}/journals </a>       |
| POST     | <a href="#get-apiusersidjournals"> /api/users/{id}/journals </a>       |
| PUT      | <a href="#get-apiusersidjournals"> /api/users/{id}/journals/{id} </a>  |
| DELETE   | <a href="#get-apiusersidjournals"> /api/users/{id}/journals/{id} </a>  |

<!-- |            |                    Journals                                            |
|    :---:   |                      :---                                              |
| GET        | <a href="#apijournals"> /api/journals/ </a>                            |  
| POST       | <a href="#apijournals"> /api/journals/</a>                             |  
| PUT        | <a href="#apijournals"> /api/journals/{id} </a>                        |  
| DELETE     | <a href="#apijournals"> /api/journals/{id} </a>                        |   -->

..........................................................................................

### Users Controller
Access functionality to register, sign-in & receive a Token, as well as edit or delete your account. The Users controller also contains endpoints for Users to create, read, update, or delete their own Journal entries.

..........................................................................................

### `GET` /api/users/profile

#### This is an alternative endpoint to `GET` `/api/users/{id}`

Authenticated users, while including their Token in the authorization header of the request, may access this `GET` endpoint. On a successful request, this endpoint returns the User's registered information.

**NOTE**: An authenticated user is only authorized to retrieve their own information, and upon successfully calling this endpoint, will receive only their own registered information.

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| No parameters.  |

#### Example Query
```
https://localhost:5001/api/users/1
```

#### Sample JSON Response
`Status: 200 OK`
```json
{
    "status": "Success",
    "message": "User info retrieved successfully.",
    "data": {
        "userId": "1",
        "userName": "Joey",
        "quitDate": "2023-12-15T12:27",
        "avgSmokedDaily": 5,
        "pricePerPack": 11.55,
        "cigsPerPack": 20
    }
}
```

..........................................................................................

### `GET` /api/users/{id}

#### This is an alternative endpoint to `GET` `/api/users/profile`

Authenticated users, while including their Token in the authorization header of the request, may access this `GET` endpoint. On a successful request, this endpoint returns the User's registered information.

**NOTE**: An authenticated user is only authorized to retrieve their own information. If an ID belonging to an account other than the authenticated user is used, regardless of a present bearer token, the request will receive a 404 response.

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| id | int | none | true | Specify the desired user according to the given User ID. |

#### Example Query
```
https://localhost:5001/api/users/profile
```

#### Sample JSON Response
`Status: 200 OK`
```json
{
    "status": "Success",
    "message": "User info retrieved successfully.",
    "data": {
        "userId": "1",
        "userName": "Joey",
        "quitDate": "2023-12-15T12:27",
        "avgSmokedDaily": 5,
        "pricePerPack": 11.55,
        "cigsPerPack": 20
    }
}
```

..........................................................................................
### `PUT` /api/user/{id}

Authenticated users, while including their Token in the authorization header of the request, may access the `PUT` endpoint to update their registered information.

**NOTE**: An authenticated user is only authorized to access and update their own information.

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| id | int | none | true | Specify the desired user according to the given User ID. |

#### Example Query
```
https://localhost:5001/api/users/1
```
#### Sample JSON Request Body
```json
{
     "userId": "1",
     "userName": "Joey",
     "quitDate": "2023-12-15T12:27",
     "avgSmokedDaily": 10,
     "pricePerPack": 12,
     "cigsPerPack": 20
}
```
> NOTE: When sending a `PUT` request, the User's ID is _required_ in the body of the request.

#### Sample Successful JSON Response
`Status: 204 No Content`
```json

```
..........................................................................................

### `DELETE` /api/users/{id}

Authenticated users, while including their Token in the authorization header of the request, may `DELETE` their own registered account

**NOTE**: An authenticated user is only authorized to access and update their own information. Attempting to access this endpoint with a User ID that does not belong to the authenticated user will result in an unsuccessful request. 

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| id | int | none | true | Specify the desired user according to the given User ID. |

#### Example Query
```
https://localhost:5001/api/users/1
```

#### Sample Successful JSON Response
`Status: 204 No Content`
```json

```

..........................................................................................

### `GET` /api/users/{id}/journals

Authenticated users, while including their Token in the authorization header of the request, may access this `GET` endpoint. On a successful request, this endpoint returns a list of all the User's Journal submissions.

**NOTE**: An authenticated user is only authorized to access and update their own journals. Attempting to access this endpoint with a User ID that does not belong to the authenticated user will result in an unsuccessful request. 

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| id | int | none | true | Specify the desired user according to the given User ID. |


#### Example Query
```
https://localhost:5001/api/users/1/journals
```

#### Sample Successful JSON Response
`Status: 200 OK`
```json
{
    "status": "Success",
    "message": "Journals retrieved successfully.",
    "data": [
        {
            "journalId": 52,
            "date": "2023-12-13T16:58",
            "cravingIntensity": 2,
            "cigsSmoked": 3,
            "notes": "Notes here.",
            "userId": "1"
        },
        {
            "journalId": 53,
            "date": "2023-12-04T16:58",
            "cravingIntensity": 3,
            "cigsSmoked": 5,
            "notes": "Some more notes.",
            "userId": "1"
        }
    ]
}
```
..........................................................................................

### `POST` /api/users/{id}/journals/

Authenticated users, while including their Token in the authorization header of the request, may access this `POST` endpoint to create a new journal entry.

**NOTE**: An authenticated user is only authorized to access and update their own journals. Attempting to access this endpoint with a User ID that does not belong to the authenticated user will result in an unsuccessful request. 

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| id    | int | none | true | Specify the desired user according to the given User ID. |

#### Example Query
```
https://localhost:5001/api/users/1/journals/
```
#### Sample JSON Request Body
```json
{
   "date": "2023-12-13",
   "cravingIntensity": 0,
   "cigsSmoked": 5,
   "notes": "Some test notes.",
}
```

#### Sample Successful JSON Response
`Status: 201 Created`
```json
{
    "status": "Success",
    "message": "Journal created successfully.",
    "data": {
        "journalId": 64,
        "date": "2023-12-13",
        "cravingIntensity": 0,
        "cigsSmoked": 5,
        "notes": "Something new.",
        "userId": "1"
    }
}
```

..........................................................................................

### `PUT` /api/users/{id}/journals/{journalId}

Authenticated users, while including their Token in the authorization header of the request, may access this `PUT` endpoint to update a specific journal they have authored.

**NOTE**: An authenticated user is only authorized to access and update their own journals. Attempting to access this endpoint with a User ID that does not belong to the authenticated user will result in an unsuccessful request. 

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| id        | int | none | true | Specify the desired user according to the given User ID. |
| journalId | int | none | true | Specify the desired journal according to the given Journal ID. |

#### Example Query
```
https://localhost:5001/api/users/1/journals/64
```
#### Sample JSON Request Body
```json
{
   "journalId": 64,
   "date": "2023-12-13",
   "cravingIntensity": 10,
   "cigsSmoked": 5,
   "notes": "Some different notes.",
}
```
> NOTE: When sending a `PUT` request, the Journal's ID is _required_ in the body of the request.

#### Sample Successful JSON Response
`Status: 204 No Content`
```json

```

..........................................................................................


### `DELETE` /api/users/{id}/journals/{id}

Authenticated users, while including their Token in the authorization header of the request, may `DELETE` specific Journal entries in the database that they have authored.

**NOTE**: An authenticated user is only authorized to access and update their own journals. Attempting to access this endpoint with a User ID that does not belong to the authenticated user will result in an unsuccessful request. 

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| id        | int | none | true | Specify the desired user according to the given User ID. |
| journalId | int | none | true | Specify the desired journal according to the given Journal ID. |

#### Example Query
```
https://localhost:5001/api/users/1/journals/52
```

#### Sample Successful JSON Response
`Status: 204 No Content`
```json

```

..........................................................................................

<!-- ### Journals Controller

Access functionality to create, read, update, or delete user journals. 

..........................................................................................

### `GET` /api/journals

Authenticated users, while including their Token in the authorization header of the request, may access this `GET` endpoint. On a successful request, this endpoint returns a list of all Journals submitted by all registered users.


#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| No parameters |


#### Example Query
```
https://localhost:5001/api/journals
```

#### Sample Successful JSON Response
`Status: 200 OK`
```json
{
    "status": "Success",
    "message": "Journals retrieved successfully.",
    "data": [
        {
            "journalId": 52,
            "date": "2023-12-13T16:58",
            "cravingIntensity": 2,
            "cigsSmoked": 3,
            "notes": "Notes here.",
            "userId": "1"
        },
        {
            "journalId": 53,
            "date": "2023-12-04T16:58",
            "cravingIntensity": 3,
            "cigsSmoked": 5,
            "notes": "Some more notes.",
            "userId": "1"
        }
    ]
}
```
..........................................................................................

### `POST` /api/journals/

Authenticated users, while including their Token in the authorization header of the request, may access this `POST` endpoint to create a new journal entry.

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| No Parameters |

#### Example Query
```
https://localhost:5001/api/journals/
```
#### Sample JSON Request Body
```json
{
   "date": "2023-12-13",
   "cravingIntensity": 0,
   "cigsSmoked": 5,
   "notes": "Some test notes.",
}
```

#### Sample Successful JSON Response
`Status: 201 Created`
```json
{
    "status": "Success",
    "message": "Journal created successfully.",
    "data": {
        "journalId": 64,
        "date": "2023-12-13",
        "cravingIntensity": 0,
        "cigsSmoked": 5,
        "notes": "Something new.",
        "userId": "1"
    }
}
```

..........................................................................................

### `PUT` /api/journals/{journalId}

Authenticated users, while including their Token in the authorization header of the request, may access this `PUT` endpoint to update a specific journal.

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| id    | int | none | true | Specify the desired journal according to the given Journal ID. |

#### Example Query
```
https://localhost:5001/api/journals/64
```
#### Sample JSON Request Body
```json
{
   "journalId": 64,
   "date": "2023-12-13",
   "cravingIntensity": 10,
   "cigsSmoked": 5,
   "notes": "Some different notes.",
}
```
> NOTE: When sending a `PUT` request, the Journal's ID is _required_ in the body of the request.

#### Sample Successful JSON Response
`Status: 204 No Content`
```json

```

..........................................................................................

### `DELETE` /api/journals/{id}

Authenticated users, while including their Token in the authorization header of the request, may `DELETE` a specific Journal entry in the database.

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| id    | int | none | true | Specify the desired journal according to the given Journal ID. |

#### Example Query
```
https://localhost:5001/api/journals/52
```

#### Sample Successful JSON Response
`Status: 204 No Content`
```json

```

.......................................................................................... -->

### TO DO:

### Milestones Controller

Access functionality to read from a list of health benefits one might achieve over a period of time after they have quit smoking.

..........................................................................................


------------------------------

### ✉️ Contact and Support

If you have any feedback or concerns, please contact one of the contributors.

<p>
    <a href="https://github.com/jfpalchak/CranberryAPI/issues">Report Bug</a> ·
    <a href="https://github.com/jfpalchak/CranberryAPI/issues">Request Feature</a>
</p>

------------------------------

### ⚖️ License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). Copyright (C) 2023 Joey Palchak. All Rights Reserved.

```
MIT License

Copyright (c) 2023 Joey Palchak.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
```
  
------------------------------

<center><a href="#">Return to Top</a></center>