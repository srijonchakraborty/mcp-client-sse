using Microsoft.Extensions.AI;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();
builder.Services.AddChatClient(services =>
    new ChatClientBuilder(
        new OpenAIClient("OPENAI KEY")
        .GetChatClient("gpt-4.1").AsIChatClient()
    )
    .UseFunctionInvocation()
    .Build());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
