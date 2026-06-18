# Lab 4.2 - Proof of Concepting with GitHub Copilot

You did it — you have successfully created automation for your application to validate the code, build the application, and deploy it to a (production) server. Your team is impressed with the progress you've made and the time you've saved by automating these tasks. To prepare for a future feature, your team lead has asked you to explore proof of concepting with live public data APIs. You decide to use GitHub Copilot to help with API integration and visualization — demonstrating both feasibility and immediate value.

## Estimated time to complete

- 30 min

## Learning objectives

- Use GitHub Copilot and Agent Mode to fetch and visualize live public API data
- Generate interactive Leaflet.js maps with dynamic data binding and hover tooltips
- Explore multiple free public APIs with zero authentication friction
- Build functional proof-of-concepts quickly with minimal scaffolding

---

## Choose Your Own Adventure

Pick **one** adventure below. Each adventure includes a complete set of tasks, hints, and expert solutions — you only need to follow the path you choose.

| Adventure | API | Data Type |
|-----------|-----|-----------|
| [Adventure 1: ISS Tracker](#-adventure-1-iss-tracker) | Where The ISS At? | Real-time satellite position |
| [Adventure 2: Earthquake Tracker](#-adventure-2-earthquake-tracker) | USGS Earthquakes | Real-time seismic events (GeoJSON) |
| [Adventure 3: Flight Tracker (Bonus)](#️-adventure-3-flight-tracker-bonus) | OpenSky | Real-time flight data |

---

# 🛰 Adventure 1: ISS Tracker

Track the International Space Station in real time — fetch its current position via PowerShell, then plot it on an interactive map with a rich hover tooltip.

---

## Task 1: Fetch ISS Position via PowerShell

Write a PowerShell script that fetches real-time ISS position data and displays latitude, longitude, altitude, velocity, and visibility status in the console.

**API URL:** `https://api.wheretheiss.at/v1/satellites/ISS`

---

<details>
  <summary>Hint 1</summary>

What programming language would you prefer for your script? The hints assume PowerShell, but Python, Node.js, or bash work too.

</details>

<details>
  <summary>Hint 2</summary>

Open Copilot Chat and ask for a PowerShell script that fetches data from the ISS API URL and displays key fields like position, altitude, and velocity.

</details>

<details>
  <summary>Hint 3</summary>

Here's a sample prompt to get started:

```
Create a PowerShell script that fetches real-time ISS position data
from https://api.wheretheiss.at/v1/satellites/ISS and displays the
current latitude, longitude, altitude (km), velocity (m/s), and
visibility status. Format the output as key-value pairs.
```

</details>

<details>
  <summary>Expert Solution</summary>

- Open GitHub Copilot Chat and enter:

  ```
  Create a PowerShell script that fetches real-time International Space Station (ISS)
  position data from https://api.wheretheiss.at/v1/satellites/ISS and displays
  the current latitude, longitude, altitude (km), velocity (m/s), and visibility
  status. Format the output as key-value pairs.
  ```

- GitHub Copilot will generate a PowerShell script using `Invoke-RestMethod`. The script should look similar to:

  ```powershell
  $url = "https://api.wheretheiss.at/v1/satellites/ISS"

  try {
      $response = Invoke-RestMethod -Uri $url -Method Get

      Write-Output "ISS Position Data:"
      Write-Output "===================="
      Write-Output "Latitude:   $($response.latitude)°"
      Write-Output "Longitude:  $($response.longitude)°"
      Write-Output "Altitude:   $($response.altitude) km"
      Write-Output "Velocity:   $($response.velocity) m/s"
      Write-Output "Visibility: $($response.visibility)"
  } catch {
      Write-Error "Failed to fetch ISS data: $_"
  }
  ```

- Save the script as `get-iss-data.ps1` in the root of your repository and run it:

  ```bash
  pwsh get-iss-data.ps1
  ```

- Expected output:

  ```
  ISS Position Data:
  ====================
  Latitude:   41.8781°
  Longitude:  -87.6298°
  Altitude:   408.0 km
  Velocity:   27600 m/s
  Visibility: eclipsed
  ```

</details>

---

## Task 2: Visualize ISS on an Interactive Map

Create a self-contained HTML file using Leaflet.js that displays the ISS position on a world map. Hovering over the marker shows a tooltip with data pulled live from the API.

---

<details>
  <summary>Hint 1</summary>

Leaflet.js is a free, open-source JavaScript mapping library you can load from a CDN — no installation needed. A basic map requires a `<div>` with an ID and some CSS to set its size.

</details>

<details>
  <summary>Hint 2</summary>

Open Copilot Chat and ask for an HTML file that loads Leaflet, fetches ISS data, places a marker at the ISS coordinates, and shows position details in a hover tooltip.

</details>

<details>
  <summary>Hint 3</summary>

Here's a sample prompt:

```
Create a self-contained HTML file that uses Leaflet.js (CDN) to display
an interactive world map. Fetch real-time ISS position from
https://api.wheretheiss.at/v1/satellites/ISS and display it as a marker.
When hovering over the marker, show a tooltip with latitude, longitude,
altitude (km), velocity (m/s), and visibility status. Auto-center the map
on the ISS location.
```

</details>

<details>
  <summary>Expert Solution</summary>

- Open GitHub Copilot Chat and enter:

  ```
  Create a self-contained HTML file that uses Leaflet.js (CDN) to display
  an interactive world map. Fetch real-time ISS position from
  https://api.wheretheiss.at/v1/satellites/ISS and display it as a circle marker.
  When hovering over the marker, show a tooltip with latitude, longitude,
  altitude (km), velocity (m/s), and visibility status pulled from the API response.
  Auto-center the map on the ISS location. Update the marker position every 10 seconds.
  The page must work by opening it directly in a browser with no server needed.
  ```

- GitHub Copilot will generate an HTML file similar to:

  ```html
  <!DOCTYPE html>
  <html>
  <head>
      <meta charset="UTF-8">
      <title>ISS Tracker</title>
      <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/leaflet@1.9.4/dist/leaflet.css" />
      <script src="https://cdn.jsdelivr.net/npm/leaflet@1.9.4/dist/leaflet.js"></script>
      <style>
          body { margin: 0; padding: 0; }
          #map { position: absolute; top: 0; bottom: 0; width: 100%; }
      </style>
  </head>
  <body>
      <div id="map"></div>
      <script>
          const map = L.map('map').setView([0, 0], 2);
          L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png').addTo(map);

          let marker = null;

          async function updateISS() {
              const response = await fetch('https://api.wheretheiss.at/v1/satellites/ISS');
              const data = await response.json();
              const { latitude, longitude, altitude, velocity, visibility } = data;

              if (marker) marker.remove();
              marker = L.circleMarker([latitude, longitude], { radius: 10, color: 'red' })
                  .bindTooltip(`
                      <b>ISS Position</b><br>
                      Latitude: ${latitude.toFixed(4)}°<br>
                      Longitude: ${longitude.toFixed(4)}°<br>
                      Altitude: ${altitude.toFixed(1)} km<br>
                      Velocity: ${velocity.toFixed(0)} m/s<br>
                      Visibility: ${visibility}
                  `, { permanent: false })
                  .addTo(map);

              map.setView([latitude, longitude], map.getZoom());
          }

          updateISS();
          setInterval(updateISS, 10000);
      </script>
  </body>
  </html>
  ```

- Save the file as `iss-tracker.html` in the root of your repository and open it in your browser.

- Expected behavior:
  - Map loads centered on the ISS's current position
  - A red circle marker appears at the ISS location
  - **Hover over the marker** → tooltip shows latitude, longitude, altitude, velocity, and visibility
  - Marker position refreshes every 10 seconds as the ISS moves

</details>

---

# 🌍 Adventure 2: Earthquake Tracker

Visualize real-time seismic activity worldwide — fetch the day's earthquake data via PowerShell, then plot all events on an interactive map with magnitude-colored markers and hover details.


## Task 1: Fetch Earthquake Data via PowerShell

Write a PowerShell script that fetches real-time earthquake events for the past 24 hours and displays a total count plus the top 5 events by magnitude.

**API URL:** `https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson`

---

<details>
  <summary>Hint 1</summary>

The USGS Earthquakes API returns GeoJSON format. What would be a good way to fetch and parse JSON in PowerShell?

</details>

<details>
  <summary>Hint 2</summary>

Open Copilot Chat and ask for a PowerShell script that fetches from the USGS API URL, counts the total earthquake events, then sorts and displays the top 5 by magnitude.

</details>

<details>
  <summary>Hint 3</summary>

Here's a sample prompt:

```
Create a PowerShell script that fetches earthquake data for the past day from
https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson
and displays the total number of earthquakes plus the top 5 by magnitude.
Show magnitude, location, depth (km), and time for each.
```

</details>

<details>
  <summary>Expert Solution</summary>

- Open GitHub Copilot Chat and enter:

  ```
  Create a PowerShell script that fetches earthquake data for the past day from
  https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson
  and displays the total number of earthquakes and a list of the top 5 by magnitude.
  Show magnitude, location (place), depth (km), and time for each.
  ```

- GitHub Copilot will generate a script similar to:

  ```powershell
  $url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson"

  try {
      $response = Invoke-RestMethod -Uri $url -Method Get

      $earthquakes = $response.features
      Write-Output "Total earthquakes in the past 24 hours: $($earthquakes.Count)"
      Write-Output "`nTop 5 by Magnitude:"
      Write-Output "===================="

      $sorted = $earthquakes | Sort-Object { $_.properties.mag } -Descending | Select-Object -First 5

      foreach ($eq in $sorted) {
          $mag   = $eq.properties.mag
          $place = $eq.properties.place
          $depth = $eq.geometry.coordinates[2]
          $time  = [DateTime]::UnixEpoch.AddMilliseconds($eq.properties.time)

          Write-Output "Magnitude: $mag | Depth: $depth km | Location: $place | Time: $time"
      }
  } catch {
      Write-Error "Failed to fetch earthquake data: $_"
  }
  ```

- Save the script as `get-earthquakes.ps1` in the root of your repository and run it:

  ```bash
  pwsh get-earthquakes.ps1
  ```

- Expected output (varies based on live data):

  ```
  Total earthquakes in the past 24 hours: 157

  Top 5 by Magnitude:
  ====================
  Magnitude: 5.2 | Depth: 12.5 km | Location: Fiji region | Time: 6/16/2026 03:45:22
  Magnitude: 4.8 | Depth: 8.3 km  | Location: New Zealand  | Time: 6/16/2026 01:12:45
  ...
  ```

</details>

---

## Task 2: Visualize Earthquakes on an Interactive Map

Create a self-contained HTML file using Leaflet.js that displays all earthquake events as color-coded circle markers on a world map. Hovering over a marker shows magnitude, location, depth, and time.

---

<details>
  <summary>Hint 1</summary>

The USGS API returns GeoJSON, which Leaflet can work with directly. Each `feature` in the response has `geometry.coordinates` (longitude, latitude, depth) and `properties` (magnitude, place, time).

</details>

<details>
  <summary>Hint 2</summary>

Open Copilot Chat and ask for an HTML file that fetches USGS earthquake data, creates circle markers color-coded by magnitude, and shows earthquake details in a hover tooltip.

</details>

<details>
  <summary>Hint 3</summary>

Here's a sample prompt:

```
Create a self-contained HTML file using Leaflet.js that displays a world map.
Fetch earthquake data from
https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson
and create circle markers for each earthquake. Color-code by magnitude:
red for >= 5.0, orange for 4.0–4.9, yellow for < 4.0.
When hovering over a marker show a tooltip with magnitude, location, depth (km), and time.
```

</details>

<details>
  <summary>Expert Solution</summary>

- Open GitHub Copilot Chat and enter:

  ```
  Create a self-contained HTML file using Leaflet.js that displays a world map.
  Fetch earthquake data from
  https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson
  and create circle markers for each earthquake. Color-code markers by magnitude:
  red for >= 5.0, orange for 4.0–4.9, yellow for < 4.0. Scale the marker radius
  proportionally to magnitude. When hovering over a marker, show a tooltip with
  magnitude, location (place), depth (km), and time pulled from the API response.
  The file must work by opening it directly in a browser with no server needed.
  ```

- GitHub Copilot will generate an HTML file similar to:

  ```html
  <!DOCTYPE html>
  <html>
  <head>
      <meta charset="UTF-8">
      <title>Earthquake Tracker</title>
      <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/leaflet@1.9.4/dist/leaflet.css" />
      <script src="https://cdn.jsdelivr.net/npm/leaflet@1.9.4/dist/leaflet.js"></script>
      <style>
          body { margin: 0; padding: 0; }
          #map { position: absolute; top: 0; bottom: 0; width: 100%; }
      </style>
  </head>
  <body>
      <div id="map"></div>
      <script>
          const map = L.map('map').setView([0, 0], 2);
          L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png').addTo(map);

          async function loadEarthquakes() {
              const response = await fetch('https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson');
              const geojson = await response.json();

              geojson.features.forEach(feature => {
                  const { mag, place, time } = feature.properties;
                  const [lon, lat, depth] = feature.geometry.coordinates;

                  const color = mag >= 5.0 ? 'red' : mag >= 4.0 ? 'orange' : 'yellow';
                  const timeStr = new Date(time).toLocaleString();

                  L.circleMarker([lat, lon], { radius: Math.max(mag * 2, 4), color })
                      .bindTooltip(`
                          <b>Magnitude:</b> ${mag}<br>
                          <b>Location:</b> ${place}<br>
                          <b>Depth:</b> ${depth.toFixed(1)} km<br>
                          <b>Time:</b> ${timeStr}
                      `, { permanent: false })
                      .addTo(map);
              });
          }

          loadEarthquakes();
      </script>
  </body>
  </html>
  ```

- Save the file as `earthquake-tracker.html` in the root of your repository and open it in your browser.

- Expected behavior:
  - World map loads with colored circle markers for each earthquake
  - Red = major (≥ 5.0), orange = moderate (4.0–4.9), yellow = minor (< 4.0)
  - Marker size is proportional to magnitude
  - **Hover over any marker** → tooltip shows magnitude, location, depth, and time

</details>

---

# ✈️ Adventure 3: Flight Tracker (Bonus)

> [!NOTE]
> This adventure requires creating a free account at [opensky-network.org](https://opensky-network.org/). If you prefer to skip signup, the expert solutions include embedded sample data so the tasks still work end-to-end.

Plot real-time aircraft positions from the OpenSky Network — fetch flight data via PowerShell with a graceful auth fallback, then visualize aircraft on a filterable interactive map.

---

## Task 1: Fetch Aircraft Data via PowerShell

Write a PowerShell script that fetches aircraft currently in the airspace and displays a total count. Gracefully handle the `401 Unauthorized` response using sample data as a fallback.

**API URL:** `https://opensky-network.org/api/states/all`

---

<details>
  <summary>Hint 1</summary>

The OpenSky API requires authentication and returns `401` for anonymous requests. For this task, your script should detect that error and fall back to hardcoded sample data so it still runs and demonstrates the feature.

</details>

<details>
  <summary>Hint 2</summary>

Open Copilot Chat and ask for a PowerShell script that attempts to fetch from the OpenSky API, catches the 401 error, and uses a hardcoded `SAMPLE_STATES` array instead.

</details>

<details>
  <summary>Hint 3</summary>

Here's a sample prompt:

```
Create a PowerShell script that tries to fetch aircraft data from the OpenSky API
(https://opensky-network.org/api/states/all). If it returns a 401 error,
use a fallback SAMPLE_STATES array with at least 5 realistic aircraft entries
and display the total count of aircraft.
```

</details>

<details>
  <summary>Expert Solution</summary>

- Open GitHub Copilot Chat and enter:

  ```
  Create a PowerShell script that tries to fetch aircraft data from the OpenSky API
  (https://opensky-network.org/api/states/all). If it returns a 401 error,
  use a fallback SAMPLE_STATES array with at least 5 realistic aircraft entries
  and display the total count of aircraft. Each entry should match OpenSky state
  vector format: icao24, callsign, origin_country, time_position, time_velocity,
  longitude, latitude, altitude, on_ground, velocity, true_track, vertical_rate,
  sensors, geo_altitude, squawk, spi, position_source, category.
  ```

- GitHub Copilot will generate a script similar to:

  ```powershell
  # Fallback sample data when OpenSky API returns 401
  $SAMPLE_STATES = @(
      @("abc123", "N12345 ", "US", 1717200000, 1717200000, -87.6298, 41.8781, 10000, $false, 250, 45, $null, $null, $null, "1234", $false, 0),
      @("def456", "BA0117 ", "GB", 1717200000, 1717200000, -0.4543, 51.4775, 11000, $false, 270, 90, $null, $null, $null, "5600", $false, 0),
      @("ghi789", "LH0400 ", "DE", 1717200000, 1717200000, 8.5622,  50.0379, 9000,  $false, 220, 180, $null, $null, $null, "3400", $false, 0),
      @("jkl012", "AF0001 ", "FR", 1717200000, 1717200000, 2.3522,  48.8566, 12000, $false, 300, 270, $null, $null, $null, "6700", $false, 0),
      @("mno345", "KL0601 ", "NL", 1717200000, 1717200000, 4.9041,  52.3676, 8000,  $false, 200, 0,   $null, $null, $null, "2100", $false, 0)
  )

  $url = "https://opensky-network.org/api/states/all"
  try {
      $response = Invoke-RestMethod -Uri $url -Method Get -ErrorAction Stop
      $states = $response.states
      Write-Output "Fetched live data from OpenSky API"
  } catch {
      Write-Warning "OpenSky API unavailable (401 — authentication required). Using sample data."
      $states = $SAMPLE_STATES
  }

  Write-Output "Total aircraft in the airspace: $($states.Count)"
  ```

- Save the script as `get-aircraft.ps1` in the root of your repository and run it:

  ```bash
  pwsh get-aircraft.ps1
  ```

- Expected output (without credentials):

  ```
  WARNING: OpenSky API unavailable (401 — authentication required). Using sample data.
  Total aircraft in the airspace: 5
  ```

> [!NOTE]
> To use live data, see the **Bonus: Authenticated OpenSky Requests** section at the end of this lab.

</details>

---

## Task 2: Visualize Aircraft on an Interactive Map

Create a self-contained HTML file using Leaflet.js that displays aircraft as color-coded markers on a world map with a country filter dropdown. Hovering over a marker shows callsign, altitude, velocity, and country.

---

<details>
  <summary>Hint 1</summary>

Ask Copilot to embed `SAMPLE_STATES` data directly in the HTML file so the map works without API credentials. The fallback data should follow the OpenSky state vector format.

</details>

<details>
  <summary>Hint 2</summary>

Open Copilot Chat and ask for an HTML file that tries the OpenSky API, falls back to sample data on error, plots aircraft as markers color-coded by ground/airborne status, and includes a country dropdown filter.

</details>

<details>
  <summary>Hint 3</summary>

Here's a sample prompt:

```
Create a self-contained HTML file using Leaflet.js that displays a world map.
Include a country dropdown filter. Try to fetch aircraft data from OpenSky API
(https://opensky-network.org/api/states/all). If the fetch fails, use embedded
SAMPLE_STATES with at least 5 aircraft from different countries (US, GB, DE, FR, NL).
Create circle markers: blue if airborne (on_ground == false), green if on ground.
Hover tooltips show callsign, altitude (m), velocity (m/s), and origin country.
The dropdown filters visible markers by country.
```

</details>

<details>
  <summary>Expert Solution</summary>

- Open GitHub Copilot Chat and enter:

  ```
  Create a self-contained HTML file using Leaflet.js that displays a world map.
  Include a country dropdown filter at the top of the page. Try to fetch aircraft
  data from the OpenSky API (https://opensky-network.org/api/states/all). If the
  fetch fails for any reason (e.g., 401), fall back to embedded SAMPLE_STATES with
  at least 5 aircraft entries in OpenSky state vector format covering different
  countries (US, GB, DE, FR, NL). Create circle markers for each aircraft:
  blue if airborne (on_ground == false), green if on ground (on_ground == true).
  When hovering over a marker show a tooltip with callsign, altitude (meters),
  velocity (m/s), and origin country pulled from the state vector. The dropdown
  filters visible markers by origin country. The file must work by opening it
  directly in a browser with no server needed.
  ```

- GitHub Copilot will generate an HTML file with embedded sample data, a country dropdown, and Leaflet markers color-coded by flight status.

- Save the file as `aircraft-tracker.html` in the root of your repository and open it in your browser.

- Expected behavior:
  - World map loads with a country dropdown (populated from aircraft data)
  - Blue markers = airborne aircraft, green markers = aircraft on ground
  - **Hover over any marker** → tooltip shows callsign, altitude, velocity, and origin country
  - **Select a country from the dropdown** → only aircraft from that country are shown

</details>

---

# (Bonus): Authenticated OpenSkyAPI Requests

To fetch live flight data without falling back to sample states, create a free OpenSky account and pass credentials via Basic Auth.

1. Visit [https://opensky-network.org/](https://opensky-network.org/) and sign up (email verification required)
2. Note your username and password

<details>
  <summary>Click to view authenticated PowerShell example</summary>

<br/>

- Open Copilot Chat and enter:

  ```
  Modify the get-aircraft.ps1 script to authenticate with the OpenSky API
  using HTTP Basic Auth. Use a username and password variable and encode them
  in Base64 for the Authorization header. Remove the sample data fallback —
  the script should now fetch live data successfully.
  ```

- Copilot will generate code similar to:

  ```powershell
  $username   = "your_opensky_username"
  $password   = "your_opensky_password"
  $base64Auth = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes("$username`:$password"))
  $headers    = @{ Authorization = "Basic $base64Auth" }

  $url = "https://opensky-network.org/api/states/all"

  try {
      $response = Invoke-RestMethod -Uri $url -Method Get -Headers $headers
      Write-Output "Total live aircraft: $($response.states.Count)"
  } catch {
      Write-Error "Error: $_"
  }
  ```

> [!NOTE]
> Free accounts are limited to 400 API calls per day. Never commit credentials to version control — use environment variables or a secrets manager in production.

</details>

---

### Congratulations, you've made it to the end! ✈️

You've successfully demonstrated proof-of-concept thinking: fetch live data, visualize it interactively, and show feasibility with zero friction. Great work! 🚀

---

➡️ Continue to [Lab 4.3 • Copilot CLI](../Lab%204.3%20-%20Copilot%20CLI/README.md)
