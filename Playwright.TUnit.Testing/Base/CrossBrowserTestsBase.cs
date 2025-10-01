using TUnit.Playwright;

namespace Playwright.TUnit.Testing.Base;

// Shared tests. Page/Context/Browser/Playwright are provided by PageTest.
public abstract class CrossBrowserTestsBase : PageTest {
    [Test]
    public async Task HomePage_Title_ContainsAppName() {
        await Page.GotoAsync("https://playwright.dev/dotnet/");
        var title = await Page.TitleAsync();
        await Assert.That(title).Contains("Playwright");
    }
}
