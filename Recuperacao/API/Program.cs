using API.Models;
using Microsoft.AspNetCore.Mvc;

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

app.Run();
