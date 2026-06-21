# Server API Test

## 目的

Health API が正常に応答することを、Unit Test と Integration Test で確認する。

## テストプロジェクト作成

```powershell
dotnet new xunit -n TestRPG.Server.Api.Tests -o server/tests/TestRPG.Server.Api.Tests
dotnet add server/tests/TestRPG.Server.Api.Tests/TestRPG.Server.Api.Tests.csproj reference server/src/TestRPG.Server.Api/TestRPG.Server.Api.csproj
dotnet add server/tests/TestRPG.Server.Api.Tests/TestRPG.Server.Api.Tests.csproj package Microsoft.AspNetCore.Mvc.Testing
```
## テスト実行
```powershell
dotnet test
```

### ファイル構想
server/
  src/
    TestRPG.Server.Api/
      Controllers/
        HealthController.cs
      Program.cs

  tests/
    TestRPG.Server.Api.Tests/
      Controllers/
        HealthControllerTests.cs
      HealthApiTests.cs