using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class LessonsGetterService : ILessonsGetterService
    {
        private readonly ILessonsRepository _lessonsRepository;

        public LessonsGetterService(ILessonsRepository lessonsRepository)
        {
            _lessonsRepository = lessonsRepository;
        }
    }
}