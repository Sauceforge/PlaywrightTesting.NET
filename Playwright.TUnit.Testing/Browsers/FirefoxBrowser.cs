using Playwright.TUnit.Testing.Base;

namespace Playwright.TUnit.Testing.Browsers;

[InheritsTests]
public sealed class FirefoxBrowser : CrossBrowserTestsBase {
    public override string BrowserName => "firefox";
}