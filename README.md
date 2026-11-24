# Sports Store

An ASP.NET Core MVC e-commerce web application for a sports equipment store. Customers browse products by category, add items to a session-based cart and check out. An admin area manages products and orders.

## Features

**Storefront**
- Browse products with paging (4 per page) and filter by category
- Shopping cart stored in session state, with add, remove and running total
- Checkout form with validation (name, address, city, state, country, optional gift wrap)
- Order confirmation page

**Admin area**
- Create, edit and delete products, with a category drop-down
- View unshipped and shipped orders, and mark an order as shipped

**Other**
- Prices displayed in South African rands (`en-ZA`)
- Database created and seeded automatically on first run (3 categories, 9 products)

## Tech stack

- ASP.NET Core MVC and Razor Pages (.NET 8)
- C#
- Entity Framework Core 8 with SQL Server (LocalDB), using migrations
- Repository pattern (`IRepositoryWrapper` over product, category and order repositories)
- View components (cart summary, navigation menu) and a custom pagination tag helper
- Bootstrap, Font Awesome, jQuery

## Project structure

```
Controllers/      Home (storefront), Order (checkout), Admin (product management)
Pages/            Razor Pages: Cart, Completed, Orders
Components/       View components: CartSummary, NavigationMenu
Data/             DbContext, repositories, seed data, session cart
Models/           Product, Category, Order, Cart and view models
Infrastructure/   Pagination tag helper and session/URL extensions
Migrations/       EF Core migrations
Views/            Razor views and layouts
```

## Getting started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) (or newer; update `TargetFramework` in `SportsStore.csproj` to match)
- SQL Server LocalDB (installed with Visual Studio's "ASP.NET and web development" or "Data storage" workload). LocalDB is Windows-only.

### Run

```bash
git clone <your-repo-url>
cd SportsStore_App
dotnet run
```

Then open http://localhost:5000. Or open `SportsStore.csproj` in Visual Studio and press F5.

The database `SportsStoreDB_Assign2` is created and seeded on first launch. To use a different SQL Server instance, change `DefaultConnection` in `appsettings.json`.

### Useful commands

```bash
dotnet ef migrations add <Name>   # add a migration after changing a model
dotnet ef database update         # apply migrations manually
```

## Routes

| URL | Description |
| --- | --- |
| `/` | Product list |
| `/Soccer`, `/Soccer/Page2` | Category filter and paging |
| `/Cart` | Shopping cart |
| `/Order/Checkout` | Checkout form |
| `/Admin` | Product management |
| `/Orders` | Order list and shipping |

## Known limitations

- The admin area and orders page have no authentication; anyone who knows the URL can use them.
- Seed prices are plain numbers formatted as rands, not converted from another currency.

## Author

Solomon Rantlhago
