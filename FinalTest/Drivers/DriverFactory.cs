using OpenQA.Selenium;

namespace FinalTest.Drivers
{
    public class DriverFactory
    {
        /// <summary>
        /// Call driver depend on the type which is assigned from UnitTest1 class
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IWebDriver GetDriver(string type)
        {
            IDriver idriver;
            switch (type)
            {
                case "CHROME":
                    idriver = new Chrome();
                    return idriver.StartService();
                case "FIREFOX":
                    idriver = new Firefox();
                    return idriver.StartService();
                default:
                    idriver = new Chrome();
                    return idriver.StartService();
            }

        }
    }
}
