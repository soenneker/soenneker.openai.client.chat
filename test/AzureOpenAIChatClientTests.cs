using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.OpenAI.Client.Chat.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.OpenAI.Client.Chat.Tests;

[Collection("Collection")]
public class AzureOpenAIChatClientTests : FixturedUnitTest
{
    private readonly IAzureOpenAIChatClient _util;

    public AzureOpenAIChatClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IAzureOpenAIChatClient>(true);
    }
}
