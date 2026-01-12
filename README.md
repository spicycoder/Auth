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
- [x] JWT Implementation using `Keycloak` IdP
- [ ] Load Balancer Scenario
- [ ] SSO

---

## Token from Keycloak

**Endpoint:**  
`POST` <http://localhost:8282/realms/AuthRealm/protocol/openid-connect/token>

**Body:**
`x-www-form-urlencoded`

| Key | Value |
| --- | --- |
| grant_type | password |
| client_id | auth-public-client |
| scope | email openid |
| username | hello@world.com |
| password | helloWorld18! |

**Follow:** <https://youtu.be/HAvCoQ0tOTs?si=H8CsGmlNZfdetiiQ>
