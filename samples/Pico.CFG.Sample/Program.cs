// See https://aka.ms/new-console-template for more information

var builder = Cfg.CreateBuilder();

builder
    .Add(
        """
        Database.ConnectionString=localhost:3306
        FeatureFlags.EnableNewUI=true
        """
    )
    .Add(new Dictionary<string, string> { ["Logging:Level"] = "Debug", ["Cache:Timeout"] = "300" })
    .Add(() =>
    {
        var stream = new MemoryStream();
        using var writer = new StreamWriter(stream, leaveOpen: true);
        writer.WriteLine("AppName=MyTestApp");
        writer.WriteLine("Version=1.0.0");
        writer.Flush();
        stream.Position = 0;
        return stream;
    });

var configRoot = await builder.BuildAsync();

Console.WriteLine($"Database.ConnectionString: {await configRoot.GetValueAsync("Database.ConnectionString")}");
Console.WriteLine($"Cache:Timeout: {await configRoot.GetValueAsync("Cache:Timeout")}");
Console.WriteLine($"AppName: {await configRoot.GetValueAsync("AppName")}");

Console.ReadLine();
