using Soenneker.OpenAI.Client.Chat.Abstract;
using Soenneker.Tests.HostedUnit;


namespace Soenneker.OpenAI.Client.Chat.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class OpenAIChatClientTests : HostedUnitTest
{
    private readonly IOpenAIChatClient _util;

    public OpenAIChatClientTests(Host host) : base(host)
    {
        _util = Resolve<IOpenAIChatClient>(true);
    }

    [Test]
    public void Default()
    { 
    }
}
