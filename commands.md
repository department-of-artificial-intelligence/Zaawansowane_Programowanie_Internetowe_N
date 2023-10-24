
### create migration with name Initial
```console
dotnet ef migrations add n1 --project WebStore.DAL/WebStore.DAL.csproj --startup-project WebStore.Web/WebStore.Web.csproj
```

### remove the newest migration
```console
dotnet ef migrations remove --project WebStore.DAL/WebStore.DAL.csproj --startup-project WebStore.Web/WebStore.Web.csproj
```

### update database to newest migration
```console
dotnet ef database update --project WebStore.DAL/WebStore.DAL.csproj --startup-project WebStore.Web/WebStore.Web.csproj
```

### drop database
```console
dotnet ef database drop --project WebStore.DAL/WebStore.DAL.csproj --startup-project WebStore.Web/WebStore.Web.csproj
```
