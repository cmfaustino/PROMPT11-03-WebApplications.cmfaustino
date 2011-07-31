using Mod03_ChelasMovies.Rep;

namespace Mod03_ChelasMovies.RepImpl {
    using DomainModel;
    using DomainModel.ServicesRepositoryInterfaces;

    public class EFIMDBAPIMoviesRepository : EFDbContextRepository<Movie, int>, IMoviesRepository
    {
        public EFIMDBAPIMoviesRepository(MovieDbContext moviesContext) : base(moviesContext) { }
        public Movie Search(string title) // alteracao: criado este metodo na interface, e aqui na implementacao
        {
            //throw new NotImplementedException();
            return TheIMDbAPI.SearchByTitle(title);
        }
    }
}