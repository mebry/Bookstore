using AutoMapper;
using Bookstore.Application.Common.Interfaces.Context;
using Bookstore.Application.Shared.Identity;
using Bookstore.Application.Shared.Models;
using Bookstore.Infrastructure.Persistance.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            if (!_context.Books.Any() && !_context.Genres.Any() && !_context.Authors.Any())
            {
                var comedy = new Genre
                {
                    Name = "Комедия"
                };

                var fantasy = new Genre
                {
                    Name = "Фантастика"
                };

                var novel = new Genre
                {
                    Name = "Роман"
                };

                var rowling = new Author
                {
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
                };

                var georgeOrwell = new Author
                {
                    FirstName = "Джордж",
                    LastName = "Оруэлл",
                    ProfilePictureURL =
                         "https://www.film.ru/sites/default/files/people/_tmdb/ga93NdMTy6MAIxz35NtVWCN2NBM.jpg",
                    Bio = "Джордж Оруэлл (George Orwell) был британским писателем и журналистом, " +
                    "настоящее имя которого Эрик Артур Блэр (Eric Arthur Blair). Он родился 25 " +
                    "июня 1903 года в Индии и умер 21 января 1950 года в Лондоне, Англия." +
                    "Оруэлл был также журналистом и комментатором. Он работал в различных газетах и " +
                    "журналах, в том числе в Би-би-си. "
                };

                var leoTolstoy = new Author
                {
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
                };

                var dostoevsky = new Author
                {
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
                };

                var harperLee = new Author
                {
                    FirstName = "Харпер",
                    LastName = "Ли",
                    ProfilePictureURL =
                    "https://static01.nyt.com/images/2018/02/28/arts/28lee4/merlin_104816688_15cd379c-9afd-4c70-bce2-dcf3affa8e84-articleLarge.jpg?quality=75&auto=webp&disable=upscale",
                    Bio = "Она родилась 28 апреля 1926 года в городе Монроувилль, штат Алабама, " +
                    "и умерла 19 февраля 2016 года. \"Убить пересмешника\" является ее самой " +
                    "известной и популярной работой, за которую она была удостоена Пулитцеровской премии в 1961 году."
                };

                var fredrikBackman = new Author
                {
                    FirstName = "Фредрик",
                    LastName = "Бакман",
                    ProfilePictureURL =
                    "https://img01.rl0.ru/afisha/-x-i/daily.afisha.ru/uploads/images/e/b2/eb2a304eae26f7f346fa4a9b020f09d0.png",
                    Bio = "шведский писатель и журналист, родился 2 июня 1981 " +
                    "года в городе Бруйннузунде. Он начал свою карьеру как блогер " +
                    "и в конечном итоге стал автором нескольких бестселлеров, " +
                    "переведенных на многие языки мира. Бакман начал писать, " +
                    "чтобы скрыть свою реальную работу, но его блоги быстро " +
                    "набрали популярность благодаря его чувству юмора и умению " +
                    "выразить свои мысли простым языком.Его первая книга \"Мужчины, " +
                    "которые ненавидят женщин\" вышла в 2013 году и стала настоящим бестселлером."
                };


                var firstBook = new Book
                {
                    ImageURL = "https://upload.wikimedia.org/wikipedia/ru/b/b4/Harry_Potter_and_the_Philosopher%27s_Stone_%E2%80%94_movie.jpg",
                    CreatedAt = DateTime.ParseExact("26/06/1997", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Description = "Одиннадцатилетний мальчик-сирота Гарри Поттер живет " +
                        "в семье своей тетки и даже не подозревает, что он – настоящий волшебник. " +
                        "Но однажды прилетает сова с письмом для него, и жизнь Гарри Поттера " +
                        "изменяется навсегда. Он узнает, что зачислен в Школу Чародейства и Волшебства.",
                    Genre = fantasy,
                    Price = 40,
                    Name = "Гарри Поттер и философский камень"
                };

                var secondBook = new Book
                {
                    ImageURL = "https://s1-goods.ozstatic.by/2000/70/87/101/101087070_0.jpg",
                    CreatedAt = DateTime.ParseExact("26/03/1867", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Description = "Это эпический роман Льва Толстого, который описывает жизнь " +
                    "нескольких аристократических семей в России во время наполеоновских войн. " +
                    "Роман является широкоизвестным произведением мировой литературы, объемный и " +
                    "пышный, с богатой галереей персонажей, описывающих жизнь и любовь, войну и мир.",
                    Genre = novel,
                    Price = 40,
                    Name = "Война и мир"
                };

                var thirdBook = new Book
                {
                    ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRPpl2cPRLs66ExPhTIr2KxieYaAzxue7jXpw&usqp=CAU",
                    CreatedAt = DateTime.ParseExact("17/08/1945", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Description = "Это аллегория на революцию, в которой фермерские " +
                    "животные свергают человеческое господство и создают свою собственную " +
                    "идеологическую систему, но вскоре сталкиваются с новой формой тирании и угнетения.",
                    Genre = novel,
                    Price = 50,
                    Name = "Скотный двор"
                };

                var fourthBook = new Book
                {
                    ImageURL = "https://s5-goods.ozstatic.by/2000/888/47/101/101047888_0.jpg",
                    CreatedAt = DateTime.ParseExact("08/06/1949", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Description = "Это дистопический роман, в котором правительство контролирует " +
                    "каждый аспект жизни граждан, используя технологии массового наблюдения и " +
                    "манипуляции информацией. Главный герой, Уинстон Смит, борется с системой и " +
                    "пытается сохранить свою индивидуальность и свободу мысли в мире, где даже " +
                    "сам язык используется для укрепления власти",
                    Genre = novel,
                    Price = 50,
                    Name = "1984"
                };

                var fifthBook = new Book
                {
                    ImageURL = "https://www.moscowbooks.ru/image/book/644/orig/i644064.jpg?cu=20180101000000",
                    CreatedAt = DateTime.ParseExact("11/07/1960", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Description = "Это книга о расовой дискриминации и неравенстве " +
                    "в южных штатах США. Рассказывая историю маленькой девочки по имени " +
                    "Скаут и ее брата Джема, автор Харпер Ли описывает жестокость и неправду, " +
                    "которые сопутствовали расовому разделению в тех временах",
                    Genre = novel,
                    Price = 20.3,
                    Name = "Убить пересмешника"
                };

                var sixthBook = new Book
                {
                    ImageURL = "https://img3.labirint.ru/rc/e27b47675ed29ec975fc4e75e2994806/363x561q80/books49/482353/cover.jpg?1612679174",
                    CreatedAt = DateTime.ParseExact("11/04/1866", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Description = "Роман исследует темы вины, искупления, морали и справедливости, " +
                    "а также психологические аспекты преступления и уголовного преследования." +
                    "рассказывает о молодом студенте Родионе Раскольникове, который совершает " +
                    "убийство старой залетной кредиторши в порыве идеологической убежденности",
                    Genre = novel,
                    Price = 41.3,
                    Name = "Преступление и наказание"
                };

                var seventhBook = new Book
                {
                    ImageURL = "https://upload.wikimedia.org/wikipedia/ru/9/9d/%D0%92%D1%82%D0%BE%D1%80%D0%B0%D1%8F_%D0%B6%D0%B8%D0%B7%D0%BD%D1%8C_%D0%A3%D0%B2%D0%B5_%28%D1%84%D0%B8%D0%BB%D1%8C%D0%BC%29.jpg",
                    CreatedAt = DateTime.ParseExact("25/12/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Description = "Это книга, написанная фразильским писателем " +
                    "Фредриком Бакманом, которая рассказывает о жизни угрюмого " +
                    "и недовольного собой пенсионера по имени Уве. Он пытается " +
                    "покончить с собой, но ему мешают соседи, которые вскрывают " +
                    "его тайные желания и открывают для него новые возможности в " +
                    "жизни. Роман исследует темы одиночества, смысла жизни и дружбы, " +
                    "показывая, как любовь и взаимопомощь могут изменить судьбу даже самых угрюмых и закрытых людей.",
                    Genre = novel,
                    Price = 35.2,
                    Name = "Вторая жизнь Уве"
                };

                var eightBook = new Book
                {
                    ImageURL = "https://upload.wikimedia.org/wikipedia/ru/9/9d/%D0%92%D1%82%D0%BE%D1%80%D0%B0%D1%8F_%D0%B6%D0%B8%D0%B7%D0%BD%D1%8C_%D0%A3%D0%B2%D0%B5_%28%D1%84%D0%B8%D0%BB%D1%8C%D0%BC%29.jpg",
                    CreatedAt = DateTime.ParseExact("25/12/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Description = "Это книга, написанная фразильским писателем " +
                    "Фредриком Бакманом, которая рассказывает о жизни угрюмого " +
                    "и недовольного собой пенсионера по имени Уве. Он пытается " +
                    "покончить с собой, но ему мешают соседи, которые вскрывают " +
                    "его тайные желания и открывают для него новые возможности в " +
                    "жизни. Роман исследует темы одиночества, смысла жизни и дружбы, " +
                    "показывая, как любовь и взаимопомощь могут изменить судьбу даже самых угрюмых и закрытых людей.",
                    Genre = novel,
                    Price = 35.2,
                    Name = "Вторая жизнь Уве"
                };

                await _context.AuthorsBooks.AddAsync(new AuthorBook { Author = rowling, Book = firstBook });
                await _context.AuthorsBooks.AddAsync(new AuthorBook { Author = leoTolstoy, Book = secondBook });
                await _context.AuthorsBooks.AddAsync(new AuthorBook { Author = georgeOrwell, Book = thirdBook });
                await _context.AuthorsBooks.AddAsync(new AuthorBook { Author = georgeOrwell, Book = fourthBook });
                await _context.AuthorsBooks.AddAsync(new AuthorBook { Author = harperLee, Book = fifthBook });
                await _context.AuthorsBooks.AddAsync(new AuthorBook { Author = dostoevsky, Book = sixthBook });
                await _context.AuthorsBooks.AddAsync(new AuthorBook { Author = fredrikBackman, Book = seventhBook });
            }

            await _context.SaveChangesAsync();
        }

        public async Task InitialiseUsersAndRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string adminPassword = "Admin1234_";
            string firstNameAdmin = "Vadim";
            string lastNameAdmin = "Goncharov";

            string clientEmail = "mebry@gmail.com";
            string clientPassword = "Mebry1234_";
            string firstNameClient = "Mebry";
            string lastNameClient = "Goncharov";

            string adminRole = AvailableRoles.Admin;
            string clientRole = AvailableRoles.Client;

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (await roleManager.FindByNameAsync(clientRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(clientRole));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                ApplicationUser admin = new ApplicationUser
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    FirstName = firstNameAdmin,
                    LastName = lastNameAdmin,
                };

                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, adminRole);
                }
            }

            if (await userManager.FindByNameAsync(clientEmail) == null)
            {
                ApplicationUser client = new ApplicationUser
                {
                    Email = clientEmail,
                    UserName = clientEmail,
                    FirstName = firstNameClient,
                    LastName = lastNameClient
                };

                IdentityResult result = await userManager.CreateAsync(client, clientPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(client, clientRole);
                }
            }
        }
    }
}



