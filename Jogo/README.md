# Jogo MVC simplificado

Projeto C# (.NET 8) para Visual Studio. Mantém MVC e os padrões Factory Method, Proxy e Command.

## Simplificação
Foi adicionada `PersonagemBase.cs` para reunir vida, dano, movimento e fuga. `Guerreiro`, `Mago` e `Arqueiro` agora contêm apenas suas diferenças. Os demais arquivos foram preservados para manter o fluxo e as regras originais.

## Onde estão os padrões?
- **Factory Method:** `Model/Padroes/Factory.cs` (criadores concretos).
- **Proxy:** `Model/Padroes/Proxy.cs` (verificação de ações).
- **Command:** `Controller/Comandos/` (comando de andar e executor).
- **MVC:** `Model/`, `View/` e `Controller/`.

## Como abrir
Abra `Jogo.sln` no Visual Studio com o SDK .NET 8 instalado e execute o projeto `Jogo`. Também é possível usar `dotnet run --project Jogo/Jogo.csproj`.