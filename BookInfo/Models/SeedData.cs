﻿using BookInfo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookInfo
{
    public class SeedData
    {
        public static void PopulateDb(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Books.Any())
            {
                Book book = new Book { Title = "Lord of the Rings", Date = DateTime.Parse("1/1/1937") }; // month/day/year
                Author author = new Author { Name = "J. R. R. Tolkien" };
                context.Authors.Add(author);
                context.SaveChanges();
                book.AuthorID = author.AuthorID;
                book.Authors.Add(author);
                context.Books.Add(book);

                book = new Book { Title = "The Lion, the Witch, and the Wardrobe", Date = DateTime.Parse("1/1/1950") };
                author = new Author { Name = "C. S. Lewis" };
                context.Authors.Add(author);
                context.SaveChanges();
                book.AuthorID = author.AuthorID;
                book.Authors.Add(author);
                context.Books.Add(book);

                book = new Book { Title = "Prince of Foxes", Date = DateTime.Parse("1/1/1947") };
                author = new Author { Name = "Samuel Shellabarger" };
                context.Authors.Add(author);
                context.SaveChanges();
                book.AuthorID = author.AuthorID;
                book.Authors.Add(author);
                context.Books.Add(book);
                context.SaveChanges();
            }
        }
    }
}