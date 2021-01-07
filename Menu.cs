using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MegaMenu
{
    class Menu
    {
        IWebDriver driver;
        string url = "https://www.teachaway.com/";
        public List<IWebElement> elements;

        [Test]
        public void MouseOver()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            IWebElement mainMenu = driver.FindElement(By.CssSelector(".dropdown-toggle.tb-megamenu-no-link"));
            //IWebElement mainMenu = driver.FindElement(By.XPath("//@class='dropdown-toggle tb-megamenu-no-link'"));
            
            IWebElement subMenu = driver.FindElement(By.XPath("//a[text()=' Job Board ']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(mainMenu).Build().Perform();
            Thread.Sleep(2000);
            actions.MoveToElement(subMenu).Click().Build().Perform();
            Thread.Sleep(2000);

            //driver.Navigate().Refresh();
            //driver.Navigate().Back();
            //driver.Close();
        }


        [Test]
        public void OpenEmptyTab()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            //if you want to switch back to your first window
            driver.SwitchTo().Window(driver.WindowHandles.First());
            //Actions action = new Actions(driver);
            //action.KeyDown(Keys.Control).MoveToElement(body).Click().Perform();
            //driver.SwitchTo().Window(driver.WindowHandles.Last());
            //driver.Navigate().GoToUrl("http://www.google.com");
            //driver.SwitchTo().Window(driver.WindowHandles.First());

        }
        [Test]
        public void OpenNewTab()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement rightClickElement = driver
            .FindElement(By.XPath("//*[@id='block-mainnavigation-2']/div/div/div/ul/li[4]/a"));
            //IWebElement rightClickElement = driver.FindElement(By.LinkText("Courses"));
            Actions action = new Actions(driver);
            action.ContextClick(rightClickElement).SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
            action.SendKeys(Keys.Control + 't');
            driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(5);                

        }
        [Test]
        public void JobOpeningSubmenu()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement mainMenu = driver.FindElement(By.CssSelector(".dropdown-toggle.tb-megamenu-no-link"));
            IWebElement subMenu = driver.FindElement(By.XPath("//span[text()=' Job Openings ']"));
            IWebElement childmenu = driver.FindElement(By.XPath("//*[@id='block-job-list-filters-block']/div/div/div/div[1]/div/ul/li[1]/a"));
            IWebElement viewBtn = driver.FindElement(By.XPath("//*[@id='block-job-list-filters-block']/div/div/div/div[2]/div[1]/div/div/div/div[1]/div/span/div/div/div/div[2]/a")); 
            Actions actions = new Actions(driver);
            actions.MoveToElement(mainMenu).Build().Perform();
            Thread.Sleep(400);
            actions.MoveToElement(subMenu).Build().Perform();
            actions.MoveToElement(childmenu).Build().Perform();
            actions.MoveToElement(viewBtn).Click().Build().Perform();
            Thread.Sleep(500);
            driver.Navigate().Back();

        }

        [Test]
        public void JobDestinationSubmenu() //USA
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement mainMenu = driver.FindElement(By.CssSelector(".dropdown-toggle.tb-megamenu-no-link"));
            IWebElement subMenu = driver.FindElement(By.CssSelector("span[title='Destinations']"));
            IWebElement childmenu = driver.FindElement(By.CssSelector("a[title='USA']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(mainMenu).Build().Perform();
            Thread.Sleep(1000);
            actions.MoveToElement(subMenu).Build().Perform();
            Thread.Sleep(600);
            actions.MoveToElement(childmenu).Click().Build().Perform();
           
            Thread.Sleep(500);
            //driver.Navigate().Back();

        }
        [Test]
        public void FeaturedSubmenu() //The same testing for others feature jobs submenus
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement mainMenu = driver.FindElement(By.CssSelector(".dropdown-toggle.tb-megamenu-no-link"));
            IWebElement subMenu = driver.FindElement(By.CssSelector("span[title='Featured Programs']"));
            IWebElement childmenu = driver.FindElement(By.CssSelector("a[title='Abu Dhabi Public Schools']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(mainMenu).Build().Perform();
            Thread.Sleep(1000);
            actions.MoveToElement(subMenu).Build().Perform();
            Thread.Sleep(600);
            actions.MoveToElement(childmenu).Click().Build().Perform();

            Thread.Sleep(500);
        }


            [Test]
        public void LoginRedirectionMenu()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement login = driver.FindElement(By.Id("login"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(login).Click().Build().Perform();
            Thread.Sleep(400);
        }


        [Test]
        public void TechSubmenu() //The same testing for others tech to the usa submenus
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement mainMenu = driver.FindElement(By.CssSelector(".dropdown-toggle.tb-megamenu-no-link"));
            IWebElement subMenu = driver.FindElement(By.CssSelector("span[title='Teach in the US']"));
            IWebElement childmenu = driver.FindElement(By.CssSelector("a[title='New York City']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(mainMenu).Build().Perform();
            Thread.Sleep(1000);
            actions.MoveToElement(subMenu).Build().Perform();
            Thread.Sleep(600);
            actions.MoveToElement(childmenu).Click().Build().Perform();

            Thread.Sleep(500);
        }



        [Test]
        public void ComunitySubmenu() //The same testing for others tech to the usa submenus
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement mainMenu = driver.FindElement(By.CssSelector(".dropdown-toggle.tb-megamenu-no-link"));
            IWebElement subMenu = driver.FindElement(By.CssSelector("span[title='Community']"));
            IWebElement childmenu = driver.FindElement(By.CssSelector("a[title='Blog']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(mainMenu).Build().Perform();
            Thread.Sleep(1000);
            actions.MoveToElement(subMenu).Build().Perform();
            Thread.Sleep(600);
            actions.MoveToElement(childmenu).Click().Build().Perform();
            Thread.Sleep(500);
        }
        [Test]
        public void VerifyLogoRediraction()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement register = driver.FindElement(By.CssSelector("a.navbar-brand.d-none.d-lg-block img"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(register).Click().Build().Perform();
            Thread.Sleep(400);
        }

        [Test]
        public void RegisterRedirectionMenu()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement register = driver.FindElement(By.Id("register"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(register).Click().Build().Perform();
            Thread.Sleep(400);
        }
        [Test]
        public void HireTeacherRedirectionMenu()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement hireTeacher = driver.FindElement(By.XPath("//*[@id='block-mainnavigation-2']/div/div/div/ul/li[5]/a"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(hireTeacher).Click().Build().Perform();
            Thread.Sleep(400);

        }
        [Test]
        public void CoursesRedirectionMenu()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement course = driver.FindElement(By.CssSelector("a[title='Courses']"));
      
            Actions actions = new Actions(driver);
            actions.MoveToElement(course).Click().Build().Perform();
            Thread.Sleep(400);
        }

        [Test]
        public void TeacherRedirectionMenu() //the same procedure for other sumbenus
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement teacher = driver.FindElement(By.CssSelector("span[title='Teacher Certification']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(teacher).Build().Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement teacherGuide = driver.FindElement(By.CssSelector("a[title='Teacher Certification Guide']"));
            actions.MoveToElement(teacherGuide).Click().Build().Perform();
            Thread.Sleep(400);
        }




        [Test]
        public void ClosingTabs()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.Close();
        }


        [Test]
        public void VerifySubmenuLinksNames()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            List<IWebElement> dropdowns;
             driver.FindElements(By.TagName("a"));
           
            driver.Close();

        }

        [Test]
        public void TeacherCertification()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IList<IWebElement> all = driver.FindElements(By.XPath("//*[@id='block- ainnavigation-2]/div/div/div/ul/li[3]/span"));

            String[] allText = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }

        }

        [Test]
        public void VerifySubmenuLinksforTeflMenu() // the same procedure for others submenus 
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            //IWebElement jobs = driver.FindElement(By.XPath("/html/body/div[1]/nav/div/a/img"));
            IWebElement tefl = driver.FindElement(By.CssSelector("span[title='Tefl']"));
            //IWebElement teacherCertification = driver.FindElement(By.XPath("/html/body/div[1]/nav/div/a/img"));
            //IWebElement courses = driver.FindElement(By.XPath("/html/body/div[1]/nav/div/a/img"));
            //IWebElement hireTeachers = driver.FindElement(By.CssSelector(".dropdown-toggle.hire-teachers"));
            //IWebElement login = driver.FindElement(By.Id("login"));
            //IWebElement register = driver.FindElement(By.Id("register"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(tefl).Build().Perform(); //Mouse over the menu
            Thread.Sleep(400);
            IWebElement teflCourses = driver.FindElement(By.CssSelector("a[title='TEFL Courses']"));
            actions.MoveToElement(teflCourses).Click().Build().Perform();
            Thread.Sleep(1000);
            //IWebElement teflCertification = driver.FindElement(By.CssSelector("a[title='TEFL Certification Guide']"));
            //actions.KeyDown(Keys.Control).Click(teflCourses).Click(teflCertification).Build().Perform();
            //actions.MoveToElement(teflCertification).Click().Build().Perform();

           
            IList<IWebElement> all = driver.FindElements(By.CssSelector("span[title='Tefl']"));

            String[] allText = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }
        }

        [Test]
        public void VerifyLogo()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement logo = driver.FindElement(By.XPath("/html/body/div[1]/nav/div/a/img"));
            string ExpectedText = "TeachAway";   
            Assert.AreEqual(ExpectedText, logo.Text);
            Console.WriteLine("TechAway test is epected");
        }

        [Test]
        public void VerifyDropdownList()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement element = driver
            .FindElement(By.CssSelector(".dropdown-toggle.tb-megamenu-no-link"));
            SelectElement selectElement = new SelectElement(element);
            IList<IWebElement> elements = selectElement.Options;
            Console.WriteLine(elements.Count());
            foreach (var item in elements)
            {
                Console.WriteLine(item.Text);
            }
            driver.Quit();
        }


        //[Test]
        //public void Login()
        //{
        //    driver.FindElement(By.Id("login")).Click();
        //    driver.FindElement(By.Id("username")).SendKeys("admin");
        //    driver.FindElement(By.Id("password")).SendKeys("admin");
        //    driver.FindElement(By.Id("login-button")).Click();
        //}
    }
}
