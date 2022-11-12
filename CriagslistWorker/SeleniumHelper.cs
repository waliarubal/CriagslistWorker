using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CriagslistWorker;

class SeleniumHelper: IDisposable
{
    IWebDriver _driver;
    EdgeDriverService _service;
    static SeleniumHelper _instance;

    private SeleniumHelper()
    {

    }

    #region properties

    public bool IsTorNetwork { get; set; }

    public bool IsConsoleHidden { get; set; }

    public bool IsBrowserHidden { get; set; }

    public static SeleniumHelper Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SeleniumHelper();

            return _instance;
        }
    }

    #endregion

    IWebDriver GetDriver()
    {
        if (_driver != null)
            return _driver;

        _service = EdgeDriverService.CreateDefaultService();
        _service.HideCommandPromptWindow = IsConsoleHidden;

        var options = new EdgeOptions();
        options.PageLoadStrategy = PageLoadStrategy.Normal;
        options.LeaveBrowserRunning = false;
        options.AddArgument("InPrivate");
        options.AddAdditionalOption("useAutomationExtension", false);
        options.AddExcludedArgument("enable-automation");

        if (IsTorNetwork)
        {
            var proxy = new Proxy();
            proxy.Kind = ProxyKind.Manual;
            proxy.SocksProxy = "127.0.0.1:9150";
            proxy.SocksVersion = 5;
            options.Proxy = proxy;
        }

        if (IsBrowserHidden)
            options.AddArgument("--headless");

        _driver = new EdgeDriver(_service, options);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        return _driver;
    }

    public void Navigate(string url) => GetDriver()
        .Navigate()
        .GoToUrl(url);

    public bool IsElementVisible(string xPath, int seconds = 20)
    {
        try
        {
            var wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));

            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
        catch(NoSuchElementException)
        {
            return false;
        }
    }

    public IReadOnlyCollection<IWebElement> FindElements(string xPath)
    {
        return GetDriver()
            .FindElements(By.XPath(xPath));
    }

    public IWebElement FindElement(string xPath)
    {
        try
        {
            return GetDriver()
                .FindElement(By.XPath(xPath));
        }
        catch (NoSuchElementException)
        {
            return null;
        }
    }

    public void Dispose()
    {
        if (_driver != null)
        {
            _driver.Quit();
            _driver.Dispose();

            _driver = null;
        }

        if (_service != null)
        {
            _service.Dispose();

            _service = null;
        }
    }
}
