using TUnit.Core;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using Pico.CFG;

namespace Pico.CFG.Tests;

public class CfgTests
{
    [Test]
    public async Task CreateBuilder_ReturnsNonNull()
    {
        var builder = CFG.CreateBuilder();
        await Assert.That(builder).IsNotNull();
    }
}