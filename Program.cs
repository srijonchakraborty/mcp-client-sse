using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

//// Create an IChatClient using Azure OpenAI.
//IChatClient client =
//    new ChatClientBuilder(
//        new AzureOpenAIClient(new Uri("<your-azure-openai-endpoint>"),
//        new ApiKeyCredential(""))
//        .GetChatClient("gpt-4o").AsIChatClient())
//    .UseFunctionInvocation()
//    .Build();

//OPEN AI Implemtation 
builder.Services.AddChatClient(services =>
    new ChatClientBuilder(
         new OpenAIClient("OPENAI KEY")
        .GetChatClient("gpt-4.1").AsIChatClient()
    )
    .UseFunctionInvocation()
    .Build());
var app = builder.Build();

//Ollama
//Need to update ollama implementation to use the new ChatClientBuilder
//builder.Services.AddChatClient(services =>
//    new ChatClientBuilder(
//      new OllamaChatClient(new Uri("http://localhost:11434"), "llama3")
//    )
//    .UseFunctionInvocation()
//    .Build());
//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
