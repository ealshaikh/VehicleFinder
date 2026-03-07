# Vehicle-Data-App

Web application to browse vehicle makes, models, and types using the NHTSA API. Built with **.NET Core** (Backend) and **Angular 16** (Frontend).

## Features
- Browse all vehicle makes
- Filter by vehicle type and manufacture year
- Pagination for large datasets
- Integrated with NHTSA public APIs

## Technologies
- .NET Core Web API
- Angular 16
- HttpClient for API calls
- Docker 
- Hosted on AWS 

## Getting Started

### Backend
1. Configure API URLs in `appsettings.json`.
2. Run `dotnet restore` and `dotnet run` in `VehicleDataAPI` project.

### Frontend
1. Navigate to `vehicle-frontend` folder.
2. Run `npm install` then `ng serve`.

## Notes
- Supports cancellation tokens and validation
- Pagination is implemented for all endpoints
