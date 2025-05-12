namespace Core.Entities;

public record Endereco
{
    public int Id { get; set; }
    public string Cidade { get; set; } = string.Empty;
    public string Localidade { get; set; }= string.Empty;
}
