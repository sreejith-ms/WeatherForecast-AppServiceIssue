### Sample app to demonstrate Azure App Service file upload issue

- Deploy the app to Azure app service / Azure app service container
- Test API: POST `/WeatherForecast/maxsizelimit` with various file size ranges typically > 14MB, notice intermittent internal server errors (500/502)
- The issue may not be reproducible when testing from a high network bandwidth connection. In such cases, you can try reproducing it by using browser network throttling. Use Firefox throttling preset: `WIFI` (download: 30 Mbps, upload: 15 Mbps)

