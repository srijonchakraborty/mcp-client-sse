# MCP Client - .NET Web API

A .NET 9.0 Web API application that integrates OpenAI's GPT-4 with Model Context Protocol (MCP) to provide intelligent chat interfaces with access to external tools and services. The application supports multiple MCP server endpoints for different use cases.

## �� What it does

This application provides a REST API that:

- **Dual Chat Interfaces**: Offers two different chat endpoints with different MCP server connections
- **AI-Powered Responses**: Uses OpenAI's GPT-4.1 model for intelligent conversation
- **MCP Integration**: Connects to multiple Model Context Protocol servers to access external tools
- **Tool Discovery**: Dynamically discovers and utilizes available tools from MCP servers
- **Streaming Responses**: Provides real-time streaming chat responses for enhanced user experience
- **Swagger Documentation**: Includes built-in API documentation for easy testing and integration

## 🛠️ Technology Stack

- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core Web API** - RESTful API framework
- **OpenAI SDK** - Integration with GPT-4 model
- **Model Context Protocol (MCP)** - Protocol for AI model tool integration
- **Swagger/OpenAPI** - API documentation and testing interface
- **Microsoft.Extensions.AI** - AI service abstractions

## 📋 Prerequisites

Before running this application, ensure you have:

- **.NET 9.0 SDK** installed on your machine
- **OpenAI API Key** with access to GPT-4
- **Internet Connection** to access the remote MCP servers

## ⚙️ Configuration

### 1. Environment Setup

The application uses the following configuration:

#### OpenAI Configuration
Currently, the OpenAI API key is hardcoded in `Program.cs`. **For production use, move this to environment variables or secure configuration.**

```csharp
// In Program.cs - Replace with your OpenAI API key
new OpenAIClient("your-openai-api-key-here")
```

#### MCP Server Configuration
The application connects to two different MCP servers:

1. **Primary MCP Server** (Chat endpoint):
   ```csharp
   Endpoint = new Uri("http://mcpserversijon.runasp.net/sse")
   ```

2. **Math-focused MCP Server** (ChatMath endpoint):
   ```csharp
   Endpoint = new Uri("https://remote-mcp-server-authless2.srijonchakraborty2022.workers.dev/sse")
   ```

### 2. Environment Variables (Recommended)

Create a `.env` file or set environment variables:

```bash
# OpenAI Configuration
OPENAI_API_KEY=your-openai-api-key-here

# MCP Server Configuration
MCP_SERVER_ENDPOINT=http://mcpserversijon.runasp.net/sse
MCP_MATH_SERVER_ENDPOINT=https://remote-mcp-server-authless2.srijonchakraborty2022.workers.dev/sse

# Application Configuration
ASPNETCORE_ENVIRONMENT=Development
```

### 3. App Settings

The application uses standard ASP.NET Core configuration files:

- `appsettings.json` - Production settings
- `appsettings.Development.json` - Development settings

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone <your-repository-url>
cd McpClient
```

### 2. Install Dependencies

```bash
dotnet restore
```

### 3. Configure API Keys

Update the OpenAI API key in `Program.cs` or set it as an environment variable.

### 4. Run the Application

```bash
# Development mode
dotnet run

# Or specify the profile
dotnet run --launch-profile https
```

The application will start on:
- **HTTP**: `http://localhost:5058`
- **HTTPS**: `https://localhost:7044`

### 5. Access the API

- **Swagger UI**: `https://localhost:7044/swagger`
- **Chat Endpoint**: `POST https://localhost:7044/chat`
- **Math Chat Endpoint**: `POST https://localhost:7044/chat/chatmath`

## 📡 API Usage

### 1. General Chat Endpoint

**POST** `/chat`

Send a message to the AI assistant with access to the primary MCP server tools.

**Request Body:**
```json
"Your message here"
```

**Response:**
Depending on available tools.

### 2. Math-focused Chat Endpoint

**POST** `/chat/chatmath`

Send a message to the AI assistant with access to math-focused MCP server tools.

**Request Body:**
```json
"Solve this equation: 2x + 5 = 15"
```

**Response:**

### Example Usage

#### General Chat
```bash
curl -X POST "https://localhost:7044/chat" \
     -H "Content-Type: application/json" \
     -d "\"Hello, can you help me with a task?\""
```

#### Math Chat
```bash
curl -X POST "https://localhost:7044/chat/chatmath" \
     -H "Content-Type: application/json" \
     -d "\"What is the derivative of x^2 + 3x + 1?\""
```

## 🔧 Dependencies

The project uses the following NuGet packages:

- **Azure.AI.OpenAI** (2.1.0) - OpenAI client library
- **Microsoft.AspNetCore.OpenApi** (9.0.5) - OpenAPI support
- **Microsoft.Extensions.AI** (9.7.1) - AI service abstractions
- **Microsoft.Extensions.AI.OpenAI** (9.7.1-preview.1.25365.4) - OpenAI integration
- **ModelContextProtocol** (0.3.0-preview.3) - MCP client library
- **Swashbuckle.AspNetCore** (9.0.3) - Swagger documentation

## 📁 Project Structure
McpClient/
├── Controller/
│ └── ChatController.cs # Main chat API controller with dual endpoints
├── Properties/
│ └── launchSettings.json # Application launch configuration
├── Program.cs # Application entry point and configuration
├── appsettings.json # Production configuration
├── appsettings.Development.json # Development configuration
└── McpClient.csproj # Project file with dependencies

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## �� Acknowledgments

- OpenAI for providing the GPT-4.1 API
- Model Context Protocol community for the MCP specification
- Microsoft for .NET and ASP.NET Core frameworks
- The MCP server providers for hosting the tool servers
