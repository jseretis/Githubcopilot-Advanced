---
name: tokenoptimization
description: Tips for reducing token usage when prompting Copilot in the Wright Brothers API project (ASP.NET Core backend + React/TypeScript frontend).
---

## Token Optimization for the Wright Brothers Project

### Target only what's needed

- **Backend changes**: Reference only the relevant layer — `Controllers/`, `Repositories/`, or `Models/` — not the whole backend.
- **Frontend changes**: Scope to `src/components/`, `src/pages/`, or `src/services/` as appropriate.
- **Tests**: Reference the specific test file (e.g., `PlanesControllerTests.cs`) and the interface being mocked (`IPlaneRepository`).

### Avoid over-attaching context

| Task | Attach | Skip |
|------|--------|------|
| Add a new endpoint | `PlanesController.cs` + `IPlaneRepository.cs` | Models, frontend, tests |
| Add a new model property | `Plane.cs` | Controllers, repositories |
| Write a unit test | The controller + its interface | Repository implementation |
| Fix a frontend service | `PlaneService.ts` or `FlightService.ts` | Backend files |

### Prompt patterns that reduce tokens

- **Be layer-specific**: "Add a `DELETE` endpoint to `PlanesController` using `IPlaneRepository`" vs. "update the project to delete planes."
- **Reference existing conventions**: "Follow the pattern in `GetById`" instead of describing the pattern in full.
- **Name the mock library**: "Use NSubstitute to mock `IPlaneRepository`" to avoid generated boilerplate.
- **Name the assertion library**: "Use FluentAssertions `.Should().Be()`" to get correct syntax immediately.

### Key file map (quick reference)

```
Backend
  Models/Plane.cs              – Plane data class (Id, Name, Year, Description, RangeInKm, LastUpdated)
  Repositories/IPlaneRepository.cs  – Interface to mock in tests
  Controllers/PlanesController.cs   – REST endpoints; inject IPlaneRepository + ILogger

Frontend
  src/services/PlaneService.ts  – Axios calls to http://localhost:1903/planes/
  src/components/PlaneList.tsx  – List component with spec file
  src/pages/PlaneDetail.tsx     – Detail page
```

### What to avoid

- Don't attach `Program.cs` unless the task involves DI registration or middleware.
- Don't attach `bin/` or `obj/` files — they add noise with zero value.
- Don't paste full repository seed data when asking about a single endpoint; the interface signature is sufficient.