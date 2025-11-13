import { useEffect, useState } from "react";
import EventsCalendar from "./EventsCalendar";
import API_BASE_URL from "../config";

console.log(API_BASE_URL);

function VenueSelector() {
  const [venues, setVenues] = useState([]);
  const [loading, setLoading] = useState(false);
  const [selectedVenueId, setSelectedVenueId] = useState(""); // empty = none selected

  useEffect(() => {
    const fetchVenues = async () => {
      try {
        setLoading(true);
        const response = await fetch(`${API_BASE_URL}/venues`);
        if (!response.ok) {
          throw new Error("Failed to fetch venues");
        }
        const data = await response.json();
        setVenues(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchVenues();
  }, []);

  const handleVenueChange = (e) => {
    const value = e.target.value;
    setSelectedVenueId(value);
  };

  const selectedVenue =
    selectedVenueId === ""
      ? null
      : venues.find((v) => v.id === Number(selectedVenueId));

  return (
    <div>
      <label htmlFor="venue-dropdown">Select a venue:</label>
      <select
        id="venue-dropdown"
        value={selectedVenueId}
        onChange={handleVenueChange}
      >
        {/* Initial state: No Venue is selected */}
        <option value="" disabled>
          -- Choose a venue --
        </option>
        {venues.map((venue) => (
          <option key={venue.id} value={venue.id}>
            {venue.name}
          </option>
        ))}
      </select>

      {loading && <p>Loading venues...</p>}

      {!loading && selectedVenue && (
        <div>
          <h2>{selectedVenue.name}</h2>
          <p>
            <strong>Location:</strong> {selectedVenue.location}
          </p>
          <p>
            <strong>Capacity:</strong> {selectedVenue.capacity}
          </p>
          <br /><br />
          {/* Pass venueId + events to child component */}
          { <EventsCalendar
            venueId={selectedVenue.id}
            events={selectedVenue.events || []}
          /> }
        </div>
      )}
    </div>
  );
}

export default VenueSelector;