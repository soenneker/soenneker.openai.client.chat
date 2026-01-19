using Soenneker.OpenAI.Client.Chat.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.OpenAI.Client.Chat.Tests;

[Collection("Collection")]
public class OpenAIChatClientTests : FixturedUnitTest
{
    private readonly IOpenAIChatClient _util;

    public OpenAIChatClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IOpenAIChatClient>(true);
    }

    [Fact]
    public void Default()
    { 
    }
}
