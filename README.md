# Create a web API with ASP.NET Core MVC

### macOS

```console
cd todoapi
```
Generate cert and configure local machine:

```console
dotnet dev-certs https -ep ${HOME}/.aspnet/https/TodoApi.pfx -p crypticpassword
dotnet dev-certs https --trust
```
Note: The certificate name, in this case TodoApi.pfx must match the project assembly name.
Note: crypticpassword is used as a stand-in for a password of your own choosing.
Configure application secrets, for the certificate:

```console
dotnet user-secrets -p TodoApi.csproj set "Kestrel:Certificates:Development:Password" "crypticpassword"
```
Note: The password must match the password used for the certificate.
