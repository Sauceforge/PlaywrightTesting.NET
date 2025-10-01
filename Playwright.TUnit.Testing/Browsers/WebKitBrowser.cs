using Playwright.TUnit.Testing.Base;

namespace Playwright.TUnit.Testing.Browsers;

[InheritsTests]
public sealed class WebKitBrowser : CrossBrowserTestsBase {
    public override string BrowserName => "webkit";
}