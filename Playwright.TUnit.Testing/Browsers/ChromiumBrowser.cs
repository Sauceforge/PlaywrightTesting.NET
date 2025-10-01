using Playwright.TUnit.Testing.Base;

namespace Playwright.TUnit.Testing.Browsers;

[InheritsTests]
public sealed class ChromiumBrowser : CrossBrowserTestsBase {
    public override string BrowserName => "chromium";
}
