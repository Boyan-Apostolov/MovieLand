# MovieLand Documentation

This is a simple C# app for searching and reviewing movies /CLI IMDb/

# 🛠 Built with:

- [.NET Core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
- [Entity Framework Core 3.1](https://github.com/dotnet/efcore)
- [MySQL](https://www.mysql.com)
- [IMDb API](imdb-api.com)
- [SendGrid API](https://github.com/sendgrid)

# Users

| **Права**       | Admin | User | Guest |
| --------------- | ----- | ---- | ----- |
| Login           | ❌    | ❌   | ✅    |
| Login           | ❌    | ❌   | ✅    |
| View all movies | ✅    | ✅   | ✅    |
| Serch movies    | ✅    | ✅   | ✅    |
| View Movie Info | ✅    | ✅   | ✅    |
| Review Movie    | ✅    | ✅   | ❌    |
| Create Movie    | ✅    | ❌   | ❌    |
| Seed movies     | ✅    | ❌   | ❌    |
| Delete Movie    | ✅    | ❌   | ❌    |
| Help command    | ✅    | ✅   | ✅    |
| Paging command  | ✅    | ✅   | ✅    |

# Screenshots:

**Start page**

List of all imported movies along with the available commands.
![Home page](https://i.ibb.co/Xyp8KRv/home.png)

**Register page**

This page uses custom **RegEx** checks for email and password.

![Register](https://i.ibb.co/2YWSGWr/reg.png)

**Help section**

Here the user can see all commands.
![Help](https://i.ibb.co/3CLRGz0/help.png)

**Movie info page**

Here the users can see all available information about the movies, along with their reviews.
![Info page](https://i.ibb.co/GRKFPcj/info.png)

**Movie review**

Every logged user can review all movies. When submitting a review, all users with previous reviews on that movie receive an email, telling them about the new review.

![Review](https://i.ibb.co/PMsyLMM/reviw.png)
![Email](https://i.ibb.co/16Nz3mt/email.png)

**Create movie**

Only the admin can create movies

![creating movies](https://i.ibb.co/KGcYHwb/add-movie.png)

**Seeding**

The admin can choose how many movies to import from the IMDb API

![Seed](https://i.ibb.co/26RQ6d1/seed.png)

**Deleting movies**

Only the admin can delete movies after a confirmation.

![del](https://i.ibb.co/7G5GTmp/del.png)
