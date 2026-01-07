# Dynasty of Champions

_Official repo for the API and collective web and mobile apps for Dynasty of Champions sports statistics, analytics, and fantasy leagues._

    A XalorTech Project:
    Copyright (C) 2025 XalorTech

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as
    published by the Free Software Foundation, either version 3 of the
    License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see https://www.gnu.org/licenses/.

## About

**Dynasty of Champions** is an open-source, multi-application fantasy sports platform designed for real-time performance, extensibility, and long-term evolution.

### Architecture:

The system is built using a hybrid architecture:

- **OOP + DDD** for core business logic  
- **ECS (Entity Component System)** for high-frequency real-time stat processing  
- **Next.js + Tailwind** for web applications  
- **React Native** for mobile applications  
- **ASP.NET Core WebAPI + EF Core** for backend services  
- **SQL Server** for persistence  
- **SignalR** for real-time updates  

The project is structured into four top-level directories plus a documentation directory:

- apps/
  - Web apps, mobile apps, API
- features/
  - Reusable UI components for web and mobile
- foundation/
  - Domain, application logic, ECS engine, persistence, integrations
- infrastructure/
  - Docker, IaC, scripts, deployment configs
- docs/
  - Documentation sources

## Status

🚧 **Early development phase** — repository structure and foundational components are being established.

## Project Goals

- Real-time fantasy sports engine with scalable ECS processing
- Extensible architecture for new sports, leagues, and scoring systems
- Future AI-driven lineup optimization and projections
- Optional betting module with region-based legal compliance
- Modular UI features for reuse across apps

## Documentation

All project documentation lives in the `docs/` directory.  
We use **DocFX** to generate unified documentation across:

- C# backend (API, domain, ECS engine)
- TypeScript (web + mobile)
- Markdown architecture guides
- Design documents

Documentation will be published as a static site.

## License

This project is licensed under the **GNU Affero General Public License v3.0 (AGPLv3)**.  
See the full license text here: [LICENSE.md](LICENSE.md)
