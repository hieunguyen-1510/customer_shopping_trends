using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _16_NguyenLeHoaiHieu_WebDriver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            IWebDriver driver = null;

            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.facebook.com/");

                // Đăng nhập
                var emailField = driver.FindElement(By.Id("email"));
                var passwordField = driver.FindElement(By.Id("pass"));
                var loginButton = driver.FindElement(By.Name("login"));

                emailField.SendKeys("your-email@example.com");
                passwordField.SendKeys("your-password");
                loginButton.Click();

                // Chờ đợi để xử lý đăng nhập
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElement(By.XPath("//div[@aria-label='Account']")));

                // Điều hướng lại trang chủ để thực hiện đăng ký
                driver.Navigate().GoToUrl("https://www.facebook.com/");

                // Đăng ký
                var firstNameField = driver.FindElement(By.Name("firstname"));
                var lastNameField = driver.FindElement(By.Name("lastname"));
                var regEmailField = driver.FindElement(By.Name("reg_email__"));
                var regPasswordField = driver.FindElement(By.Name("reg_passwd__"));
                var signUpButton = driver.FindElement(By.Name("websubmit"));

                firstNameField.SendKeys("FirstName");
                lastNameField.SendKeys("LastName");
                regEmailField.SendKeys("your-new-email@example.com");
                regPasswordField.SendKeys("your-new-password");

                // Chọn ngày tháng năm sinh
                var daySelect = new SelectElement(driver.FindElement(By.Name("birthday_day")));
                daySelect.SelectByValue("1");

                var monthSelect = new SelectElement(driver.FindElement(By.Name("birthday_month")));
                monthSelect.SelectByValue("1");

                var yearSelect = new SelectElement(driver.FindElement(By.Name("birthday_year")));
                yearSelect.SelectByValue("2000");

                // Chọn giới tính (giả sử chọn nữ)
                var genderRadioButton = driver.FindElement(By.XPath("//input[@type='radio' and @value='1']"));
                genderRadioButton.Click();

                signUpButton.Click();

                // Đợi để xử lý đăng ký
                await Task.Delay(5000); // Thêm chờ đợi nếu cần

                // Đóng trình duyệt
                driver.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                driver?.Quit();
            }
        }

        private class SelectElement
        {
            private IWebElement webElement;

            public SelectElement(IWebElement webElement)
            {
                this.webElement = webElement;
            }

            internal void SelectByValue(string v)
            {
                throw new NotImplementedException();
            }
        }
    }
}
