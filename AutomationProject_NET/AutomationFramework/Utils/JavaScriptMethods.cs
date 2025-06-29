using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Utils
{
    public class JavaScriptMethods
    {
        private IWebDriver _driver;

        private IJavaScriptExecutor _executor;

        public JavaScriptMethods(IWebDriver driver) 
        { 
            _driver = driver;
            _executor = (IJavaScriptExecutor)driver;
        }

        public void ScrollPageHorizontally(int pixelsOnXAxe)
        {
            _executor.ExecuteScript($"window.scrollTo({pixelsOnXAxe},0)");
        }

        public void ScrollPageVertically(int pixelsOnYAxe)
        {
            _executor.ExecuteScript($"window.scrollTo(0,{pixelsOnYAxe})");
        }

        public void ScrollPageDynamically(int pixelsOnXAxe, int pixelsOnYAxe)
        {
            _executor.ExecuteScript($"window.scrollTo({pixelsOnXAxe},{pixelsOnYAxe})");
        }
    }
}
