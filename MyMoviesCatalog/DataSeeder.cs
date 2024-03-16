using Movies.Data;

namespace MyMoviesCatalog
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<MovieDataContext>();
            context.Database.EnsureCreated();
            AddMovies(context);
        }

        private static void AddMovies(MovieDataContext context)
        {
            var movie = context.Movie.FirstOrDefault();
            if (movie != null) return;

            context.Movie.Add(new Movie
            {
                Title = "Пираты Карибского моря: Сундук мертвеца",
                Producer = "Джерри Брукхаймер",
                Rating = "Рейтинг Кинопоиска 8.1. топ 250185 место",
                Styles = new List<Style>
                {
                    new Style { Styles = "Фентези"},
                    new Style { Styles = "Боевик"},
                    new Style { Styles = "Приключения"}
                }
            });

            context.Movie.Add(new Movie
            {
                Title = "Звёздные войны: Пробуждение силы",
                Producer = "Джей Джей Абрамс",
                Rating = "Рейтинг Кинопоиска 7.1",
                Styles = new List<Style>
                {
                    new Style { Styles = "Фентези"},
                    new Style { Styles = "Боевик"},
                    new Style { Styles = "Приключения"}
                }
            });

            context.SaveChanges();
        }
    }
}