# Git Branches and Commits

This diagram is based on the provided output of `git log --graph --all --oneline --decorate`.

```mermaid
gitGraph
  commit id: "dc0ee5e" tag: "origin/main, origin/HEAD" msg: "first commit"
  commit id: "5e61221" msg: "Defined Domain Models"
  commit id: "1deeaff" msg: "Created DbContext & DbSet properties in the DbContext"
  commit id: "e04898e" tag: "main, 01/Domain-Models, origin/01/Domain-Models, origin/02/Controllers-CRUD" msg: "Added ConnString to the Database In Appsettings.Json | Inject DbContext Into Application | Ran EF Core Migrations"
  branch 02/Controllers-CRUD
  checkout 02/Controllers-CRUD
  commit id: "b7f285b" msg: "Changed (Region) Methods to Use DTOs"
  commit id: "e2dfdb2" msg: "Created New RegionController.cs | Get all regions & get all regions by id"
  commit id: "b0dcd68" msg: "Created Region Action Method"
  commit id: "d8a044e" msg: "Update Region Action Method"
  commit id: "2c82b5b" msg: "Delete Region Action Method"
```

## Branch pointers

| Branch or ref | Commit | Notes |
|---|---|---|
| `02/Controllers-CRUD` (`HEAD`) | `2c82b5b` | Current branch; contains the Region controller CRUD commits. |
| `origin/02/Controllers-CRUD` | `e04898e` | Remote-tracking ref still points to the shared base commit in the supplied log. |
| `01/Domain-Models` | `e04898e` | Local branch points to the shared base commit. |
| `origin/01/Domain-Models` | `e04898e` | Remote-tracking ref points to the same base commit. |
| `main` | `e04898e` | Local `main` points to the shared base commit. |
| `origin/main`, `origin/HEAD` | `dc0ee5e` | Remote `main` and its `HEAD` point to the initial commit. |

The history shown is linear: the current `02/Controllers-CRUD` branch extends the commit at `e04898e`. The output does not show merge commits.
