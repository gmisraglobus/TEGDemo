import React, { useMemo, useState } from "react";
import DatePicker from "react-datepicker";
import "react-calendar/dist/Calendar.css";
import "react-datepicker/dist/react-datepicker.css";

function EventsCalendar({ venueId, events }) {
  const today = new Date();

  // default initial month-year to current month-year
  const [monthYear, setMonthYear] = useState(
    new Date(today.getFullYear(), today.getMonth(), 1)
  );

  // filter events for selected month-year
  const eventsForMonth = useMemo(() => {
    return (events || []).filter((e) => {
      const d = new Date(e.startDate);
      return (
        d.getFullYear() === monthYear.getFullYear() &&
        d.getMonth() === monthYear.getMonth()
      );
    });
  }, [events, monthYear]);

  // Handler when user changes month/year in DatePicker
  const handleMonthYearChange = (date) => {
    setMonthYear(new Date(date.getFullYear(), date.getMonth(), 1));
  };

  return (
    <div>
      <h3>Events Calendar (Venue ID: {venueId})</h3>

      {/* Month-Year Picker using react-datepicker */}
      <div style={{ marginBottom: "1rem" }}>
        <label>Select Month & Year:&nbsp;</label>

        <DatePicker
          selected={monthYear}
          onChange={handleMonthYearChange}
          dateFormat="MMMM yyyy"
          showMonthYearPicker
          showFullMonthYearPicker
        />
      </div>

      {/* Event list - based on Month-Year combination selected from DatePicker.
      React-Calendar component can be used here to show the day-wise events on the grid for the selected Month-Year*/}
      <div style={{ marginTop: "1rem" }}>
        <h4>
          Events for {monthYear.toLocaleString("default", { month: "long" })}{" "}
          {monthYear.getFullYear()}
        </h4>

        {eventsForMonth.length === 0 ? (
          <p>No events this month.</p>
        ) : (
          <ul>
            {eventsForMonth.map((e) => (
              <li key={e.id}>
                <strong>{e.name}</strong> –{" "}
                {new Date(e.startDate).toLocaleDateString()} <br />
              </li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
}

export default EventsCalendar;