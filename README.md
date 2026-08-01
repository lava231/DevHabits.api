# DevHabits.api

Short description: API project for DevHabits (ASP.NET Core, .NET 10).

Quick start
1. Open the solution in Visual Studio: DevHabits.api.slnx
2. Build and run from Visual Studio or via CLI: dotnet build && dotnet run --project ./src/YourProject

Create a GitHub repo and push (recommended: GitHub CLI)
1. Install and authenticate gh: gh auth login
2. From the repo root (PowerShell):
   cd "D:\Practice Projects\DevHabit\DevHabits.api\"
   gh repo create DevHabits.api --public --source=. --remote=origin --push

Fallback using git + GitHub web:
1. Create an empty repository on github.com named DevHabits.api (no README)
2. Then run:
   git init
   git add .
   git commit -m "Initial commit"
   git branch -M main
   git remote add origin https://github.com/<USERNAME>/DevHabits.api.git
   git push -u origin main

Notes
- For private repos, use --private with gh or set repo visibility on GitHub.
- Use a Personal Access Token (repo scope) for HTTPS authentication if needed.
