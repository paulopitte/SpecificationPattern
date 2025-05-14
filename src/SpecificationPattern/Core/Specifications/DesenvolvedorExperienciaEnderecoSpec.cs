using Core.Entities;

namespace Core.Specifications;

public class DesenvolvedorExperienciaEnderecoSpec : BaseSpecification<Developer>
{
    public DesenvolvedorExperienciaEnderecoSpec(int anos) : base(x => x.YearsExperience > anos)
    {
        AddInclude(x => x.Address);
    }
}
