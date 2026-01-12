# Auth

AuthN and AuthZ

## EF Core Commands

> ⚠️ Must generate DB before running the app

```pwsh
dotnet tool restore
dotnet ef migrations add Init -p .\SimpleAuth\SimpleAuth.csproj -s .\SimpleAuth\SimpleAuth.csproj
dotnet ef database update -p .\SimpleAuth\SimpleAuth.csproj -s .\SimpleAuth\SimpleAuth.csproj
```

---

## To cover

- [x] Cookie based Auth
- [x] Bearer token based Auth
- [ ] JWT Implementation
- [ ] Load Balancer Scenario
- [ ] IdP Integration - `Keycloak`
- [ ] SSO
