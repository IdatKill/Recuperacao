using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Prova final!");

// Cadastrar Aluno
app.MapPost("/api/aluno/cadastrar", ([FromBody] Aluno aluno, [FromServices] AppDataContext ctx) => {
    var alunoExistente = ctx.Alunos.FirstOrDefault(a => a.Nome == aluno.Nome && a.Sobrenome == aluno.Sobrenome);
    if (alunoExistente != null)
    {
        return Results.BadRequest("Aluno já cadastrado");
    }
    ctx.Alunos.Add(aluno);
    ctx.SaveChanges();
    return Results.Created("",aluno);
});

//listar alunos
app.MapGet("/api/aluno/listar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx ) => {

    Aluno? tarefa = ctx.Alunos.Find(id);
    if (tarefa is null)
    {
        return Results.NotFound();
    }   

    return Results.Ok(tarefa);
});

//cadastrar IMC utilizando o id do aluno
app.MapPost("/api/imc/cadastrar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) => {
    IMC imc = new IMC();
    var aluno = ctx.Alunos.Find(id);
    if (aluno is null)
    {
        return Results.NotFound("Aluno não encontrado");
    }
    imc.ValorIMC = imc.Peso / (imc.Altura * imc.Altura);
    if (imc.ValorIMC < 18.5)
    {
        imc.Classificacao = "Abaixo do peso";
    }
    else if (imc.ValorIMC <= 24.9)
    {
        imc.Classificacao = "Peso normal";
    }
    else if (imc.ValorIMC <= 29.9)
    {
        imc.Classificacao = "Sobrepeso";
    }
    else if (imc.ValorIMC <= 30.9)
    {
        imc.Classificacao = "Obesidade";
    }
    else
    {
        imc.Classificacao = "Obesidade Grave";
    }
    ctx.IMC.Add(imc);
    ctx.SaveChanges();
    return Results.Created("", imc);
});

//Listar IMC
app.MapGet("/api/imc/listar", async (AppDataContext ctx) => 
    await ctx.IMC.Include(i => i.Aluno).ToListAsync());

//Listar IMC por aluno
app.MapGet("/api/imc/listarporaluno/{alunoId}", async (int alunoId, AppDataContext ctx) =>
    await ctx.IMC.Include(i => i.Aluno).Where(i => i.Id != alunoId).ToListAsync());

app.MapPut("/api/imc/alterar/{id}", async (int id, IMC iMC, AppDataContext ctx) =>
{
    var imc = await ctx.IMC.FindAsync(id);
    if (imc == null) return Results.NotFound("IMC não encontrado.");
imc.Altura = iMC.Altura;
imc.Peso = iMC.Peso;
imc.ValorIMC = iMC.Peso / (iMC.Altura * iMC.Altura);
if (imc.ValorIMC < 18.5)
{
    imc.Classificacao = "Abaixo do peso";
}
else if (imc.ValorIMC <= 24.9)
{
    imc.Classificacao = "Peso normal";
}
else if (imc.ValorIMC <= 29.9)
{
    imc.Classificacao = "Sobrepeso";
}
else if (imc.ValorIMC <= 30.9)
{
    imc.Classificacao = "Obesidade";
}
else
{
    imc.Classificacao = "Obesidade Grave";
}
    await ctx.SaveChangesAsync();
    return Results.Ok(imc);
});

app.Run();
