// Install:
// Once per repo/machine:  dotnet playwright install
using NUnit.Framework;
using Playwright.NUnit.Testing.Base;

namespace Playwright.NUnit.Testing;

[TestFixtureSource(nameof(AllBrowsers))]
[Parallelizable(ParallelScope.Fixtures)]
public class CrossBrowserTests(BrowserKind kind) : TestBase(kind) {

    private static readonly BrowserKind[] AllBrowsers = [
        BrowserKind.Chromium,
        BrowserKind.Firefox,
        BrowserKind.WebKit];

    [Test]
    public async Task HomePage_Title_ContainsAppName() {
        await Page.GotoAsync("https://playwright.dev/dotnet/");
        var title = await Page.TitleAsync();
        StringAssert.Contains("Playwright", title,
            $"[{_kind}] title should contain 'Playwright'");
    }
}
