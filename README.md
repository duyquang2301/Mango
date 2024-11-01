# Mango.Web

## Overview

The `Mango.Web` project is a web application that serves as the front-end for the Mango E-Commerce System. It is built using .NET 8 and C# 12.

## Prerequisites

- .NET 8 SDK
- A running instance of the Mango API services

## Configuration

1. **Update AppSettings**:
    - Ensure the `appsettings.json` file contains the correct API URLs and other necessary configurations.

## Running the Application

1. **Restore Dependencies**:
    - Restore the required NuGet packages: 
   ```
   dotnet restore
   ```
2. **Build the Application**:
    - Build the project:
   ```
   dotnet build
   ```
3. **Run the Application**:
    - Start the application:
    ```
    dotnet run
   ```
## Project Structure

### Controllers

- **AuthController**: Manages authentication-related actions such as login, registration, and logout.

### Services

- **BaseService**: A base service class for making HTTP requests.
- **CouponService**: Service for interacting with the coupon API.

### Views

- **Auth**: Contains views for authentication-related pages like login and registration.

### Models

- **RequestDto**: Data transfer object for making API requests.
- **ResponseDto**: Data transfer object for receiving API responses.
- **LoginRequestDto**: Data transfer object for login requests.
- **RegistrationRequestDto**: Data transfer object for registration requests.

## Code Overview

### `BaseService.cs`

Handles HTTP requests and includes methods for sending requests with or without bearer tokens.
```
public class BaseService : IBaseService { private readonly IHttpClientFactory _httpClientFactory; private readonly ITokenProvider _tokenProvider;
```

```
public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
{
    _httpClientFactory = httpClientFactory;
    _tokenProvider = tokenProvider;
}

public async Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true)
{
    // Method implementation
}
```
### `AuthController.cs`

Manages user authentication, including login and registration.
```
public class AuthController : Controller { private readonly IAuthService _authService; private readonly ITokenProvider _tokenProvider;
[HttpGet]
public IActionResult Login()
{
    // Method implementation
}

[HttpPost]
public async Task<IActionResult> Login(LoginRequestDto model)
{
    // Method implementation
}

[HttpGet]
public IActionResult Register()
{
    // Method implementation
}

[HttpPost]
public async Task<IActionResult> Register(RegistrationRequestDto model)
{
    // Method implementation
}

public async Task<IActionResult> Logout()
{
    // Method implementation
}

private async Task SignInUser(LoginResponseDto model)
{
    // Method implementation
}
}
```
## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE.md) file for details.

## Acknowledgements

- [ASP.NET Core](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [Swagger](https://swagger.io/)

For more information, visit the [official documentation](https://docs.microsoft.com/).
