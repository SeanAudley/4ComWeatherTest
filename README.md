# 4ComWeatherTest
Simple weather app that connects to multiple simulated api's, agregates the results using ASP.Net Core

Items not Implemented
=====================
I've not added any TDD yet as I've only started learning how to use ASP.Net CORE as i've been mostly ASP.Net MVC v3-5
Also the graceful handling of it taking into account slow services has not been implemented. To do this I would look at setting the
timeouts and retries for the HttpClients/Connections.

Things that are Implemented
===========================
The solution does what its required to do as in ask user to enter their location and desired display measurement types, it talks to 
the APIs and creates the aggregated avg result.

There are a lot of things I'd like to change (i've spent about 1.5 hrs doing this in total), like taking out the enumerated types for 
measurements and having inheritance do some work!

I've used 
  1. a simple task factory as standard that uses HttpClient to call the AccuWeather and Bbc simulated APIs
  2. to make it easily configurable, ive set the services used in appsettings.json to contain the url, service name, default wind and temp 
     measurements. 
  3. asynchronous methods as nobody wants to go make a cup of tea and find it still trying to spit data out!
  4. Just 2 interfaces to expose functionality to the WeatherApp.
  5. The website uses dataannotations to make it easily configurable to change labels on the MVC forms being rendered, and also a modded site.css just to display errors in red+bold. I also stored default settings for the webpage to use upon loading to MPH and Celsius.
  6. Uses JSON deserialiser and copies result into the relevant weather object thats the current weather api/service thats being processed uses.
   
On reflection, I could of used a simple factory to handle all the HttpClients, but i wanted to make this a simple quick app due to time 
constraints and not over complicating it. I could of also put some more exception handling. I believe i've coded it pretty close to SOLID as possible, but whats one mans spoon is another laddle ;-)

If I had the extra time with TDD i would of used NUnit and Moq to handle my test scripts for the api's, controllers and meassurements, 
this is something I'm planning to look at doing over the holiday period as I use TDD a lot with C#,WCF and WebAPI.

On a personal note it would of been quicker for me to get the location of the user using the html5 commands and tying in a full api to demonstrate consuming larger volumes of data and rendering it ;-)

     


