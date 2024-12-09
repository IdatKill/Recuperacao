namespace API.Models;
public class IMC
{
    public int Id { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; }
    public double ValorIMC { get; set; }
    public string? Classificacao { get; set; }
    public DateTime dateTime { get; set; } = DateTime.Now;

    public void CalcularIMC()
    {
        ValorIMC = Peso / (Altura * Altura);
        if (ValorIMC < 18.5)
        {
            Classificacao = "Abaixo do peso";
        }
        else if (ValorIMC >= 18.5 && ValorIMC < 24.9)
        {
            Classificacao = "Peso normal";
        }
        else if (ValorIMC >= 25 && ValorIMC < 29.9)
        {
            Classificacao = "Sobrepeso";
        }
        else if (ValorIMC >= 30 && ValorIMC < 34.9)
        {
            Classificacao = "Obesidade grau 1";
        }
        else if (ValorIMC >= 35 && ValorIMC < 39.9)
        {
            Classificacao = "Obesidade grau 2";
        }
        else
        {
            Classificacao = "Obesidade grau 3";
        }
    }

}
