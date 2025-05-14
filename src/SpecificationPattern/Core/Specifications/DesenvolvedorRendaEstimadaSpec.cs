using Core.Entities;

namespace Core.Specifications;

public class DesenvolvedorRendaEstimadaSpec : BaseSpecification<Developer>
{
    public DesenvolvedorRendaEstimadaSpec(decimal renda) : base(x => x.EstimatedIncome > renda)
    {
        AddOrderByDescending(x => x.EstimatedIncome);
    }
}
