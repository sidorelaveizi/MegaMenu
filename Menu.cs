using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MegaMenu
{

    /*
     *All the menus are tested, i.e. they go away as soon as mouse pointer is moved. I used Actions
     *to handle it. After clicking on the menus, submenus list are displayed
     *
     */
    class Menu
    {
        IWebDriver driver;
        readonly string url = "https://www.teachaway.com/";

        [Test]
        public void Lunch()
        {
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        //Check job menu and secondary menu are displayed 

        [Test]
        public void JobOpeningSubmenu() //the same procedure for others submenus of the job menu
        {
            Lunch();
            IWebElement mainMenu = driver.FindElement(By.CssSelector(".dropdown-toggle.tb-megamenu-no-link"));
            IWebElement subMenu = driver.FindElement(By.XPath("//span[text()=' Job Openings ']"));
            IWebElement childmenu = driver.FindElement(By.XPath("//*[@id='block-job-list-filters-block']/div/div/div/div[1]/div/ul/li[1]/a"));
            IWebElement viewBtn = driver.FindElement(By.XPath("//*[@id='block-job-list-filters-block']/div/div/div/div[2]/div[1]/div/div/div/div[1]/div/span/div/div/div/div[2]/a"));
            // Move cursor to the Main Menu Element
            Actions actions = new Actions(driver);
            actions.MoveToElement(mainMenu).Build().Perform();
            // Giving 4 Secs for submenu to be displayed
            Thread.Sleep(4000);
            actions.MoveToElement(subMenu).Build().Perform();
            actions.MoveToElement(childmenu).Build().Perform();
            actions.MoveToElement(viewBtn).Click().Build().Perform();
            Thread.Sleep(500);
            driver.Navigate().Back();
        }

        [Test]
        public void JobDestinationSubmenu() //USA regions is tested
        {
            Lunch();
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
        }

        [Test]
        public void JobFeaturedSubmenu() //The same testing for others jobs/featured programs submenus
        {
            Lunch();
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
        public void TechSubmenu() //The same testing for others tech in the usa submenus
        {
            Lunch();
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
        public void CommunitySubmenu() //The same testing for others community submenus
        {
            Lunch();
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
            driver.Quit();
        }

        //logo redirection verification

        [Test]
        public void VerifyLogoRediraction()
        {
            Lunch();
            IWebElement register = driver.FindElement(By.CssSelector("a.navbar-brand.d-none.d-lg-block img"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(register).Click().Build().Perform();
            Thread.Sleep(400);
        }

        //login menu test
        [Test]
        public void LoginRedirectionMenu()
        {
            Lunch();
            IWebElement login = driver.FindElement(By.Id("login"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(login).Click().Build().Perform();
            Thread.Sleep(400);
        }

        //register menu test

        [Test]
        public void RegisterRedirectionMenu()
        {
            Lunch();
            IWebElement register = driver.FindElement(By.Id("register"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(register).Click().Build().Perform();
            Thread.Sleep(400);
        }

        //"Hire Teacher" menu test
        [Test]
        public void HireTeacherRedirectionMenu()
        {
            Lunch();
            driver = new ChromeDriver("C:\\");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            IWebElement hireTeacher = driver.FindElement(By.XPath("//*[@id='block-mainnavigation-2']/div/div/div/ul/li[5]/a"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(hireTeacher).Click().Build().Perform();
            Thread.Sleep(400);

        }

        //"Courses" menu test
        [Test]
        public void CoursesRedirectionMenu()
        {
            Lunch();
            IWebElement course = driver.FindElement(By.CssSelector("a[title='Courses']"));   
            Actions actions = new Actions(driver);
            actions.MoveToElement(course).Click().Build().Perform();
            Thread.Sleep(400);
        }

        [Test]
        public void TeacherRedirectionMenu() //the same procedure for other sumbenus of the "Teacher" submenu
        {
            Lunch();
            IWebElement teacher = driver.FindElement(By.CssSelector("span[title='Teacher Certification']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(teacher).Build().Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement teacherGuide = driver.FindElement(By.CssSelector("a[title='Teacher Certification Guide']"));
            actions.MoveToElement(teacherGuide).Click().Build().Perform();
            Thread.Sleep(400);
        }
       
        //open new tab from website
        [Test]
        public void VerifyOpenEmptyTab()
        {
            Lunch();
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        //test if "course" menu is opened in new tab
        [Test]
        public void OpenNewTab()
        {
            Lunch();
            IWebElement rightClickElement = driver
            .FindElement(By.XPath("//*[@id='block-mainnavigation-2']/div/div/div/ul/li[4]/a"));
            Actions action = new Actions(driver);
            action.ContextClick(rightClickElement).SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        //test if "course" menu is opened in new window
        [Test]
        public void OpenCourseMenuInNewWindow()
        {
            Lunch();
            IWebElement rightClickElement = driver
            .FindElement(By.XPath("//*[@id='block-mainnavigation-2']/div/div/div/ul/li[4]/a"));
            Actions action = new Actions(driver);
            action.ContextClick(rightClickElement).SendKeys(Keys.ArrowDown).SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        // lunch and close the browser

        [Test]
        public void ClosingTabs()
        {
            Lunch();
            driver.Close();
        }


        [Test]
        public void VerifySubmenuLinksforTeflMenu() // the same procedure for others submenus 
        {
            Lunch();
            IWebElement tefl = driver.FindElement(By.CssSelector("span[title='Tefl']"));  
            Actions actions = new Actions(driver);
            actions.MoveToElement(tefl).Build().Perform(); //Mouse over the menu
            Thread.Sleep(400);
            IWebElement teflCourses = driver.FindElement(By.CssSelector("a[title='TEFL Courses']"));
            actions.MoveToElement(teflCourses).Click().Build().Perform();
            Thread.Sleep(1000);
            IList<IWebElement> all = driver.FindElements(By.CssSelector("span[title='Tefl']"));
            String[] allText = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }
        }

    }
}
