
This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## Available Scripts

In the project directory, you can run:

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

### `npm start`

Runs the app in the development mode.\
1. Open (http://localhost:3000) to view the app in your browser.

2. When the page loads, an API call is made to retrieve all venues and their associated Events. The Venue names are populated in the dropdown. 
By default, no venue is selected when the app starts.

3. Select a venue from the list to see the events for that venue (if any) in the Events Calendar component below. The Events Calendar section has a date picker
which allows you to filter by month and year and only events which exist in that month/year will be shown.

4. To run the app in development mode, the API Base Url is configured in the "env.development" which must match the URL configured on development server (Kestrel).

5. The app will call the API once only when it loads to get all venues and events. All filtering is done on the frontend.

This repo contains all of the frontend code for the Events listed by Venue.

1. src/index.jsx - creates the main root of the app in the DOM to render the App component.
2. src/App.jsx - main App component which renders the "VenueSelector" to display the Venues dropdown list.
3. src/components/VenueSelector.jsx - contains logic to retrieve all venues and their associated events. On change, the venue id and event list is passed to the child "EventsCalendar" component.
4. src/components/EventsCalendar.jsx - contains logic to filter all events (passed by parent VenueSelector) by month and year using the datepicker component. Any matching events by Month and year are then displayed in the list below.
5. src/.env.* - Environment file to configure API Base Url by environment (Dev or Prod).