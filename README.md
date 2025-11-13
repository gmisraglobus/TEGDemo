The Events listing Web app is a single one App solution (React + minimal API) deployed to an Azure App Service running on .Net 8 platform.
  
  Front End (SPA) Endpoint - https://tegdemoapp-d9cha4bacta6azgd.australiaeast-01.azurewebsites.net/
  
  Back End (Minimal API) endpoint - https://tegdemoapp-d9cha4bacta6azgd.australiaeast-01.azurewebsites.net/api/Venues

TEGDemo/TEGDemoApp
  - ASP.Net Core API project has 2 code folders -
    1. eventsapp - Frontend/UI React app logic which retrieves all venues and their associated Events from a single API call and then filters the display of events client-side via a
       Datepicker component.
    2. Features - Back-end Logic which is divided into Venues, Events and a Shared folder. The Venues feature hosts a single API endpoint (/api/Venues) which retrieves all venues and
       its associated events from a JSON Data Set - https://teg-coding-challenge.s3.ap-southeast-2.amazonaws.com/events/event-data.json

Production Deployment (Manual)
  1. Run the Front end build using - npm run build.
  2. Copy the assets from eventsapp/build folder to wwwroot. This is important otherwise .Net Core will not pick up any front-end changes.
  3. Finally, right-click project "TEGDemoApp" in VS solution and click on Publish to deploy changes to the Azure App Service.

Improvements (due to time constraint) - 
1. Build & deployment process -
    - We can configure an automatic Build + Copy (using MSBuild), when the VS .Net Publish is triggered to Azure App Service. This will auto run npm install -> npm run build -> copy
      eventsapp/build assets to wwwroot folder.
    - We can also configure a CI/CD pipeline which will build and deploy front-end and .Net code triggered on code commit.
2. Front End
   - In the EventCalendar component a React-Calendar can also be used to display the Events on the calendar grid for any selected month/year, which will allow user to click on the Event
     where we can show more information in a popup style div.
3. Back End API
   - As the event source might experience outage/un-reliable, we can implement a resilient API pattern to serve the event data from a cache / store (backup repo) when the API is down or timing out.
       - Retry using Polly framework.
       - If still not responsive, use the data built in the backup repo to serve the client app
       - The backup repo can be refreshed whenever the JSON endpoint is invoked and returns data. In the event of an outage (timeout, communication, unhandled errors), the data from the backup repo
         can be returned in the response. The backup repo should be invalidated whenever the Json content is updated to keep it fresh - using webhooks, Azure function trigger
    - Implement a Global Exception handler
    - Implement logging (preferrably centralized)
