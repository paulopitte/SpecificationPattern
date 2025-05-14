 
namespace Core.Entities;
public interface IEntity
{
    int Id { get; }
}

public class Developer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int YearsExperience { get; set; }
    public decimal EstimatedIncome { get; set; }
    public Address? Address { get; set; }
    public string Level { get; init; }

    public Developer(int yearsExperience)
    {
        YearsExperience = yearsExperience;
        Level = DefineLevel(yearsExperience);
    }

    private string DefineLevel(int years)
    {
        if (new IsTechLeadSpecification().IsSatisfiedBy(this))
            return "Tech Lead";
        if (new IsSeniorSpecification().IsSatisfiedBy(this))
            return "Senior";
        if (new IsMidLevelSpecification().IsSatisfiedBy(this))
            return "Mid-Level";

        return "Junior";
    }
}

public record Address(string City, string Location) : IEntity
{
    public int Id { get; set; }
}

interface ISpecification<T> where T : IEntity
{
    bool IsSatisfiedBy(T entity);
}

class IsTechLeadSpecification : ISpecification<Developer>
{
    private const int LeadExperienceRequirement = 11;

    public bool IsSatisfiedBy(Developer entity) =>
          entity.YearsExperience >= LeadExperienceRequirement;
}

class IsSeniorSpecification : ISpecification<Developer>
{
    private const int SeniorExperienceRequirement = 10;

    public bool IsSatisfiedBy(Developer entity) =>
          entity.YearsExperience >= SeniorExperienceRequirement
          && entity.YearsExperience < 11;
}

class IsMidLevelSpecification : ISpecification<Developer>
{
    public bool IsSatisfiedBy(Developer entity) =>
          entity.YearsExperience >= 5
          && entity.YearsExperience < 10;
}
