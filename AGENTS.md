# AGENTS.md

Personal BSc.CSIT (6th semester) study-repo that mixes an **Obsidian vault** (markdown notes) with several **independent C# / .NET code projects**. It is a knowledge base + learning scratch space, not an application you ship.

## Repo layout

- **Course notes**: root `*.md` files + per-topic dirs. Each course has `Syllabus.md`, `Old_sets/` (past exam papers by TU year, e.g. `2076.md`), and the course notes. Courses: `CDC/` (Compilers), `DOTNET/`, `E-Com/`, `E-Gov/`, `SE/`, `TW/`.
- **Notes are Obsidian**: use YAML frontmatter (`Course`, `Batch: "2080"`, `Year: "2083"`, `tags`) and `[[wikilink]]` cross-references. Match this style in new notes; do not convert links to plain markdown.
- **Code lives under `DOTNET/`** as multiple independent projects — there is **no `.sln`** and no shared root build.

## .NET projects (each is its own csproj, `net10.0` target)

Run `dotnet build` **inside each project directory**; do not expect a single solution to build them all. `.claude/settings.local.json` already whitelists `dotnet build`.

| Project               | Type                             | Notes                                                                                                                               |
| --------------------- | -------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| `DOTNET/Day1`, `Day2` | console app (`Exe`)              | simple language demos                                                                                                               |
| `DOTNET/API/learnAPI` | ASP.NET Core Web API             | has Swagger; DI example (`AddScoped<INotificationService, SmsNotificationService>`)                                                 |
| `DOTNET/MVC/learnMVC` | ASP.NET Core MVC web             | Razor views; uses `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation` (views compile at runtime) + `WebApplication.MapStaticAssets` |
| `DOTNET/DB/LearnDB`   | EF Core console + **PostgreSQL** | requires a running Postgres                                                                                                         |

### DB project quirk

`LearnDB/Program.cs` reads the connection string from the `POSTGRES_CONNECTION_STRING` env var, defaulting to `Host=localhost;Port=5432;Database=postgres;Username=$USER`. It uses `EnsureCreatedAsync` (no migrations) and calls `CanConnectAsync` to validate. Expect a "PostgreSQL connection failed" unless a local Postgres is running — falling back safely is intended, not a bug.

## Toolchain

- Requires **.NET 10 SDK** (`net10.0`); `dotnet --version` is `10.0.301` on this machine.
- Not an app-prod repo: no lint/test/CI config exists. Build is the only verification step.

## Git

- Single `main` branch; remote `origin` (GitHub, `aakku106/Bec.CSit_6th_sem`).
- `bin/`, `obj/`, `*.dll` are gitignored — never commit build artifacts.
- Commit style from history: short imperative summaries per change (e.g. "Add StudentController and Student model").
