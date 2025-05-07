# Sprout Hackathon Starter

Welcome to the Sprout Hackathon! This starter repo helps you use your company's Partner API and build AI-enhanced apps — no full Visual Studio required.

---

## 🧰 What’s Included

- ASP.NET Core 9.0 Web API (VS Code friendly)
- 🔁 Reusable token-based Partner API integration
- Clean architecture: API (Presentation), BLL (Business Logic), Services (External APIs)
- Ready-to-use endpoint: `/api/employees/{id}`
- Open for AI extensibility

---
## 🚀 Getting Started (VS Code Friendly)

### Install These First:
1. **[Visual Studio Code](https://code.visualstudio.com/)**  
   - A lightweight editor for code and web apps

2. **C# Extension for VS Code**  
   - Open VS Code > Extensions (Ctrl+Shift+X)  
   - Search for `C#` and install the one by Microsoft (`ms-dotnettools.csharp`)

3. **[.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)**  
   - Needed to run and build the app  
   - After install, check by running in terminal:  
     ```bash
     dotnet --version
     ```

---

## 📁 Project Structure

```bash
SproutHackathon/
├── SproutHackathon.API/         # Presentation Layer (Startup project)
│   ├── Controllers/             # API endpoints
│   ├── appsettings.json         # Environment config (tenant, URLs, secrets)
│   └── Program.cs               # Startup logic
│
├── SproutHackathon.Business/    # Business Logic Layer
│   ├── DTOs/                    # BData Transfer Objects
│   └── LogicCollection/         # Business Service Implementations
│
├── SproutHackathon.DataAccess/  # Database abstraction layer
│   ├── Contexts/                # EF Core DbContext
│   ├── Entities/                # ORM entity models
│   └── Repositories/            # DB repositories (per entity)
│
├── SproutHackathon.Services/    # Partner + Ecosystem integrations
│   ├── ServiceCollection/       # Organized per domain (e.g., Sprout, Ecosystem)
│   ├── Models/                  # Raw API models (external response shape)
│   └── Helpers/                 # Auth, HTTP clients, etc.
│
├── SproutHackathon.sln          # Solution file
└── README.md                    # Hackathon guide
```

---

### Steps to Run

#### ✅ Option 1: Using **VS Code**

1. Open the folder in VS Code
2. Update your `SproutHackathon.API/appsettings.json` with real API credentials
3. Press `F5` to launch with the debugger
4. Open your browser to `https://localhost:5069/`

#### ✅ Option 2: Using **.NET CLI** (for any editor or IDE)

```bash
cd SproutHackathon.API
dotnet restore
dotnet build
dotnet run

---

That's it — you're ready to start building!


## 🧠 Sample AI Prompts

- "Generate a form in Razor to edit employee details"
- "Create a service that retrieves a list of employees from an endpoint"
- "Style this HTML using our internal design system"
- "Add a search bar that filters employees by name"

---

Have fun and build something awesome!
