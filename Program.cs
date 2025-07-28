using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();


//Azure code is tested and working
//builder.Services.AddSingleton<IChatClient>(provider =>
//{
//    return new ChatClientBuilder(
//        new AzureOpenAIClient(new Uri("<https://some.azure.com/>"),
//       new ApiKeyCredential(""))
//        .GetChatClient("gpt-4.1").AsIChatClient())
//    .UseFunctionInvocation()
//    .Build();
//});

//OPEN AI Implemtation 
builder.Services.AddSingleton<IChatClient>(provider =>
{
    return new ChatClientBuilder(
         new OpenAIClient("")
        .GetChatClient("gpt-4.1").AsIChatClient()
    )
    .UseFunctionInvocation()
    .Build();
});

//builder.Services.AddChatClient(services =>
//    new ChatClientBuilder(
//         new OpenAIClient("OPENAI KEY")
//        .GetChatClient("gpt-4.1").AsIChatClient()
//    )
//    .UseFunctionInvocation()
//    .Build());
//var app = builder.Build();

//Ollama
//Need to update ollama implementation to use the new ChatClientBuilder
//builder.Services.AddChatClient(services =>
//    new ChatClientBuilder(
//      new OllamaChatClient(new Uri("http://localhost:11434"), "llama3")
//    )
//    .UseFunctionInvocation()
//    .Build());
var app = builder.Build();

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
