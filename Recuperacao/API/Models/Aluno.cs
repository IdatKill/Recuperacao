namespace API.Models;

public class Aluno
{
    public int id { get; set; }

    public string? Nome { get; set; }

    public string? Sobrenome { get; set; }

    public List<IMC>? IMC { get; set; }
}
