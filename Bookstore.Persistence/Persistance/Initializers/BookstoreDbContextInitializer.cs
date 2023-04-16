using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Shared.Models;
using Bookstore.Infrastructure.Persistance.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Bookstore.Infrastructure.Persistance.Initializers
{
    public class BookstoreDbContextInitializer : IDbContextInitializer
    {
        private readonly IApplicationDbContext _context;

        public BookstoreDbContextInitializer(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            if (!_context.Genres.Any())
            {
                _context.Genres.AddRange(
                    new Genre
                    {
                        Id = 1,
                        Name = "Фантастика"
                    },
                    new Genre
                    {
                        Id = 2,
                        Name = "Комедия"
                    },
                    new Genre
                    {
                        Id = 3,
                        Name = "Роман"
                    },
                    new Genre
                    {
                        Id = 4,
                        Name = "Роман-эпопея"
                    }
                );
                await _context.SaveChangesAsync();
            }
            if (!_context.Authors.Any())
            {
                await _context.Authors.AddRangeAsync(
                     new Author
                     {
                         Id = 1,
                         FirstName = "Джоан",
                         LastName = "Роулинг",
                         ProfilePictureURL =
                         "https://octobercinema.ru/wp-content/uploads/f/4/d/f4de66995a0e4893cbf3874db658e3a1.jpeg",
                         Bio = "Джоан Роулинг (Joanne Rowling) - британская писательница, " +
                         "наиболее известная как автор серии книг о Гарри Поттере. " +
                         "Она родилась 31 июля 1965 года в городе Пейтон, графство " +
                         "Глостершир, Англия.  Роулинг начала писать первую книгу о Гарри Поттере, " +
                         "Гарри Поттер и Философский камень, когда находилась на поезде из Манчестера " +
                         "в Лондон в 1990 году. Книга была опубликована в 1997 году, и стала мировым бестселлером. "
                     },
                     new Author
                     {
                         Id = 2,
                         FirstName = "Максим",
                         LastName = "Горький",
                         ProfilePictureURL =
                         "https://avatars.mds.yandex.net/i?id=86e2d7a661cb55b2146a494d4d126189f8a2bba3-7552414-images-thumbs&n=13",
                         Bio = "Максим Горький (настоящее имя Алексей Максимович Пешков) — " +
                         "русский писатель, общественный деятель, публицист и драматург. " +
                         "Он родился 28 марта 1868 года в городе Нижний Новгород в семье кустаря. " +
                         "В детстве Горький был вынужден работать разночинцем и помощником на торговой лодке. " +
                         "В 1890 году он попал в тюрьму за участие в революционных акциях, где начал писать свои " +
                         "первые произведения.В 1898 году вышла первая книга Горького «Фома Гордеев»,которая сразу принесла ему успех."
                     },
                     new Author
                     {
                         Id = 3,
                         FirstName = "Лев",
                         LastName = "Толстой",
                         ProfilePictureURL =
                         "https://jkkrd.ru/wp-content/uploads/c/9/a/c9a81c76a0c7ce60de007e42a7c79bc8.jpeg",
                         Bio = "Лев Николаевич Толстой (1828-1910) – русский писатель, мыслитель, " +
                         "философ и общественный деятель. Он родился в богатой дворянской семье " +
                         "на имении Ясная Поляна, недалеко от Тулы. Толстой учился в Казанском " +
                         "университете но не закончил его, и вместо этого принял участие в Крымской " +
                         "войне. После войны он вернулся на Ясную Поляну и начал писать свои первые " +
                         "произведения, такие как \"Детство\",\"Отрочество\" и \"Юность\".В 1859 году " +
                         "Толстой женился на Софье Андреевне Берс, с которой у него было 13 детей."
                     },
                     new Author
                     {
                         Id = 4,
                         FirstName = "Федор",
                         LastName = "Достоевский",
                         ProfilePictureURL =
                         "https://api.azbooka.ru/upload/iblock/1de/f7236a03582vz8yal0tf56kb1bwyovq7.jpg",
                         Bio = "Федор Михайлович Достоевский (1821-1881) - русский писатель, известный " +
                         "своими философскими и психологическими произведениями. Он родился в Москве в " +
                         "семье врача. В 1849 году Достоевский был арестован за участие в политической " +
                         "деятельности и приговорен к казни. В последний момент ему был изменен приговор " +
                         "на каторгу в Сибири, где он провел четыре года.После возвращения из ссылки " +
                         "Достоевский начал писать и создал некоторые из своих величайших произведений, " +
                         "такие как \"Преступление и наказание\", \"Братья Карамазовы\""
                     }
                 );
                await _context.SaveChangesAsync();
            }

            if (!_context.Books.Any())
            {
                var book = new Book
                {
                    ImageURL = "https://upload.wikimedia.org/wikipedia/ru/b/b4/Harry_Potter_and_the_Philosopher%27s_Stone_%E2%80%94_movie.jpg",
                    CreatedAt = DateTime.ParseExact("26/06/1997", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Description = "Одиннадцатилетний мальчик-сирота Гарри Поттер живет " +
                        "в семье своей тетки и даже не подозревает, что он – настоящий волшебник. " +
                        "Но однажды прилетает сова с письмом для него, и жизнь Гарри Поттера " +
                        "изменяется навсегда. Он узнает, что зачислен в Школу Чародейства и Волшебства.",
                    GenreId = 1,
                    Price = 40,
                    Name = "Гарри Поттер и философский камень",
                    AuthorBooks = new List<AuthorBook> { }

                };
                await _context.AuthorsBooks.AddAsync(new AuthorBook { AuthorId = 1, Book = book });
            }

            await _context.SaveChangesAsync();
        }
    }
}
