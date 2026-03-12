# Vehicle-Data-App

Web application to browse vehicle makes, models, and types using the NHTSA API. Built with **.NET Core** (Backend) and **Angular 16** (Frontend). Fully dockerized for easy local setup.

## Features

* Browse all vehicle makes
* Filter by vehicle type and manufacture year
* Pagination for large datasets
* Integrated with NHTSA public APIs

## Technologies

* **Backend:** .NET Core Web API
* **Frontend:** Angular 16
* **API Calls:** HttpClient
* **Containerization:** Docker & Docker Compose

## Prerequisites

* [Docker](https://www.docker.com/get-started) installed
* Node.js & npm (for Angular frontend, if running locally)
* .NET 10 SDK (if running backend locally without Docker)

---

## Getting Started with Docker

1. **Clone the repository**
```bash
git clone https://github.com/ealshaikh/VehicleFinder.git
cd <repo-folder>
```

2. **Build and start both backend & frontend containers**
```bash
docker-compose up --build -d
```

3. **Access the application**

* **Frontend (Web App):** [http://localhost:4200/home](http://localhost:4200/home)
* **Backend Swagger (API Docs):** [http://localhost:7100/swagger/index.html](http://localhost:7100/swagger/index.html)

4. **Stop containers when done**
```bash
docker-compose down
```

---

## Optional: Run Locally Without Docker

### Backend
```bash
cd VehicleDataAPI
dotnet restore
dotnet run
```
- Swagger UI: [http://localhost:7100/swagger/index.html](http://localhost:7100/swagger/index.html)

### Frontend
```bash
cd vehicle-frontend
npm install
ng serve
```
- App: [http://localhost:4200/home](http://localhost:4200/home)

---

## Notes

* Backend container exposes port **7100**
* Frontend container runs on port **4200**
* All API endpoints are preconfigured in the backend; no local setup needed besides Docker
* This setup allows anyone to run the project live on their machine either via Docker **or** directly with SDK & npm