namespace API.Models;
public class IMC
{
    public int Id { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; }
    public double ValorIMC { get; set; }
    public string? Classificacao { get; set; }
    public DateTime dateTime { get; set; } = DateTime.Now;

    public Aluno? Aluno { get; set; }
}
