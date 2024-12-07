using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Factory
{
    public interface IFactory
    {
        public IWebDriver CreateDriver();
    }
}
