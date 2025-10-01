using Microsoft.Playwright;
using NUnit.Framework;

namespace Playwright.NUnit.Testing.Base;

public class TestBase(BrowserKind kind) {
    protected readonly BrowserKind _kind = kind;

    private IPlaywright _pw = default!;
    private IBrowser _browser = default!;
    private IBrowserContext _context = default!;
    protected IPage Page = default!;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync() {
        _pw = await Microsoft.Playwright.Playwright.CreateAsync();

        var launch = new BrowserTypeLaunchOptions {
            Headless = true,               // flip to false to watch the run
            Args = ["--no-sandbox"]        // helpful in some CI agents
        };

        _browser = _kind switch {
            BrowserKind.Chromium => await _pw.Chromium.LaunchAsync(launch),
            BrowserKind.Firefox => await _pw.Firefox.LaunchAsync(launch),
            BrowserKind.WebKit => await _pw.Webkit.LaunchAsync(launch),
            _ => throw new AssertionException($"Unknown browser: {_kind}")
        };
    }

    [SetUp]
    public async Task SetUpAsync() {
        // Fresh, isolated state per test
        _context = await _browser.NewContextAsync(new BrowserNewContextOptions {
            ViewportSize = new ViewportSize { Width = 1280, Height = 800 }
        });
        Page = await _context.NewPageAsync();
    }

    [TearDown]
    public async Task TearDownAsync() {
        if(_context is not null) {
            await _context.CloseAsync();
        }
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDownAsync() {
        if(_browser is not null) {
            await _browser.CloseAsync();
        }
        _pw?.Dispose();
    }
}
