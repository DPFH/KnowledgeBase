# KnowledgeBase V1
Contains ASP.NET Core 3.1 project with Vue.js 2 front end. Is a simple, personal knowledge base that can have items created, deleted or updated.

# How to build
Import into Visual Studio (2019 recommended). Import via "KnowledgeBaseDPFH.sln" into Visual Studio and VS should take care of the rest. For the Node.js/Vue.js, make sure to open a command prompt and run the following commands (need to have Node.js already installed):

To install Vue and its cli globally, use this (might need to do it differently in the future as Vue 3 just released and this project is Vue 2)
```bash
npm install -g vue
npm install -g vue-cli
```

To install needed packages and dependencies, make sure you have set current directory to .../KnowledgeBase/clientapp 
```bash
npm install
```
This will install all Node.js packages with their dependencies as defined in the Vue project's package-lock.json that VS2019 will not install for the .NET part of the project. **When updating or pulling from a branch from any Node.js project, you should always set your command prompt to this location and run this command to install/update dependencies that may have added to the project or changed.**

# How to run JS by itself
You can follow the other README.md that is found within the clientapp folder for NPM run instructions (plus other stuff). The front-end will run by itself on http://localhost:8080, but it will not be connected to the database or make any database calls since the back end is not running. It is not recommended to run the JS alone here for this project, but available if you just want to style a few components on the main page (SplashHeader.vue). 

If the command line accidentally closes before hitting "Ctrl+c" and stopping the node process, you can open a new command line and enter this command on Windows to stop all running background node processes if they are clogging up ports:

```bash
taskkill -F -IM node.exe
```

# How to run JS and .NET together
Under the top menu bar of VS2019, set the drop-down to debug, the other drop down to any CPU and switch the configuration drop down by the green play button to "KnowledgeBaseDPFH". This might currently be set to "IIS Express", but we want to use our own custom configuration of "KnowledgeBaseDPFH" that will run both our front and back end on http://localhost:8081. A powershell window will pop open that will show when the JS is done building and deployed. 

There appears to be some bug with the Vue plugin used in this project such that there are 2 front-end instances running on ports 8080 and 8081, but only the one running on the same port as our back-end (8081 in this case) will actually work and be able to make calls to the .NET back end. If you accidentally run the "IIS Express" configuration, it will be served on http://localhost:5000. Don't use this config or calls from the front-end will not go anywhere, as they are set to call to a back-end with port 8081.

You can close the browser window, hit stop in VS2019, or close the powershell window to stop the program from running. **Closing the powershell window is the best method to stop the program** as it also stops the zombie 8080 instance from still running and prevent you from having more command prompts open up as you run the program again. 

The Vue.js hot reloads, so it will automatically add your code changes to the running browser instance or just auto-refresh the page if it needs to. The .NET side does not. Changes to the back end require you to stop the program and then hit the play button at the top again to run the project again.

# Database
I used a PostgreSQL 12.3 database deployed on AWS. The .NET part of the project (specifically, Controllers/KnowledgeItemController.cs) hooks up to this database using the Dapper and Npgsql libraries for .NET. So using a different database might require a different package and some stuff to be rewritten. I have included the SQL scripts that define the schema as well as other calls if you want to re-create the DB in the "schemaDPFH.txt" file. The "connectionString" var in the controller would need to be changed for your project (you could keep it as-is, but that DB is likely not running on that URL anymore and even if it is, it would have a different password). 

You can replace with a local database or an AWS database following [these instructions](https://aws.amazon.com/getting-started/tutorials/create-connect-postgresql-db/). The only part missing with those docs is adding your own IP address to the VPC security group. Under your database instance, click on the hyperlinked VPC security group (this is the security group your DB belongs to) and click "Edit inbound rules" in the "Inbound rules" section. Set the type to PostgreSQL with TCP protocol. If you followed default instruction to make the DB (please do for simplicity), it will automatically fill the port as "5432", which is default for postgres in general. Then under source, add your own IP address and you will be set. If you changed the port, set it to the port you set your postgres DB to when you configured it. Outbound traffic can be left as-is.

You can use SQLWorkbench as recommended by the AWS instructions, but I recommend using [pgAdmin 4](https://www.pgadmin.org/) instead. I found that SQLWorkbench was not committing my created tables for some reason and after about 5 minutes my table would randomly disappear for some reason.

# Endpoints and endpoint testing
The endpoints are defined in the "KnowledgeItemController.cs" inside the "Controllers" folder, along with what HTTP method and C# handling method. For endpoint testing, I recommend [Postman](https://www.postman.com/). I included a "KBV1.postman_collection.json" file that you can import into Postman to run tests so you don't have to re-create them manually. You might need to change the id's at the end of certain URL's so the tests actually work.

# KnowledgeBaseV2 and shelving this version
Overall, I didn't really like working with .NET Core, so I wanted to use something else like [Django REST Framework](https://www.django-rest-framework.org/) or even [Express.js](https://expressjs.com/) would be a better choice. If you like JS and even more back-end simplicity, Express would be better. I wanted more Python experience, so I went with Django REST Framework (not to be confused with regular Django, which is more complex and you have to make RESTful on your own). ASP.NET Core 3.1 is better for larger, more complex projects with more complex data structures where you would use things like Entity-Framework to maximize performance rather than how I used Dapper and simple SQL calls on a single table.

Overall, KnowledgeBaseV2 will iterate on this knowledge base by using actual dates rather than strings, having a more fleshed-out front end and greater functionality in the future. I left this project as a public repo as a sample for others who want to make a simple CRUD app using this tech stack (however, Vue 3 literally just released as I was finishing this) and for the person I originally wanted to work on it as a project he can reference for when he wants to use .NET Core. KnowledgeBaseV2 will be divided into 2 separate, private repos hosted on my own GitHub page.

---JaivirBali
