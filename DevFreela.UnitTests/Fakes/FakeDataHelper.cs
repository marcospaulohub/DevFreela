using Bogus;
using DevFreela.Application.Commands.Projects.DeleteProject;
using DevFreela.Application.Commands.Projects.InsertProject;
using DevFreela.Core.Entities;

namespace DevFreela.UnitTests.Fakes
{
    public class FakeDataHelper
    {
        private static readonly Faker _faker = new();

        public static Project CreateFakeProjectV1()
        {
            return new Project(
                _faker.Commerce.ProductName(),
                _faker.Lorem.Sentence(),
                _faker.Random.Int(1, 100),
                _faker.Random.Int(1, 100),
                _faker.Random.Decimal(1000, 10000) 
                );
        }

        private static readonly Faker<Project> _projectFakerV1 = new Faker<Project>()
            .CustomInstantiator(f => new Project(
                f.Commerce.ProductName(),
                f.Lorem.Sentence(),
                f.Random.Int(1, 100),
                f.Random.Int(1, 100),
                f.Random.Decimal(1000, 10000)));

        private static readonly Faker<InsertProjectCommand> _insertProjectCommandFaker = new Faker<InsertProjectCommand>()
            .RuleFor(c => c.Title, f => f.Commerce.ProductName())
            .RuleFor(c => c.Description, f => f.Lorem.Sentence())
            .RuleFor(c => c.IdClient, f => f.Random.Int(1, 100))
            .RuleFor(c => c.IdFreelancer, f => f.Random.Int(1, 100))
            .RuleFor(c => c.TotalCost, f => f.Random.Decimal(1000, 10000));

        private static readonly Faker<User> _userFakerClient = new Faker<User>()
            .RuleFor(u => u.Id, f => f.Random.Int(1, 1000))
            .RuleFor(u => u.FullName, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.BirthDate, DateTime.Now.AddYears(-20))
            .RuleFor(u => u.Password, f => f.Internet.Password(10))
            .RuleFor(u => u.Role, "client");

        private static readonly Faker<User> _userFakerFreelancer = new Faker<User>()
            .RuleFor(u => u.Id, f => f.Random.Int(1, 1000))
            .RuleFor(u => u.FullName, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.BirthDate, DateTime.Now.AddYears(-20))
            .RuleFor(u => u.Password, f => f.Internet.Password(10))
            .RuleFor(u => u.Role, "freelancer");

        private static readonly Faker<Skill> _skillFaker = new Faker<Skill>()
            .RuleFor(s => s.Id, f => f.Random.Int(1, 1000))
            .RuleFor(s => s.Description, f => f.Commerce.ProductName());

        private static readonly Faker<Project> _projectFaker = new Faker<Project>()
            .RuleFor(p => p.Id, f => f.Random.Int(1, 1000))
            .RuleFor(p => p.Title, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(p => p.IdClient, f => f.Random.Int(1, 100))
            .RuleFor(p => p.IdFreelancer, f => f.Random.Int(1, 100))
            .RuleFor(p => p.TotalCost, f => f.Random.Decimal(1000, 10000));

        public static User CreateFakeUserClient() => _userFakerClient.Generate();

        public static User CreateFakeUserFreelancer() => _userFakerFreelancer.Generate();

        public static Skill CreateFakeSkill() => _skillFaker.Generate();

        public static Project CreateFakeProject() => _projectFaker.Generate();

        public static List<Project> CreateFakeProjectList() => _projectFaker.Generate(5);

        public static InsertProjectCommand CreateFakeInsertProjectCommand()
            => _insertProjectCommandFaker.Generate();

        // Precisamos realmente disso?
        public static DeleteProjectCommand CreateFakeDeleteProjectCommand(int id)
            => new(id);
    }
}
