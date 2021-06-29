using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Test_task_for_Megafon
{
    class Program
    {
        static void Main(string[] args)
        {

            //Задание 3.1
            Class_1 cl1 = new Class_1();
            cl1.RandomStringGeneration(2);
            //Задание 3.2
            Class_2 cl2 = new Class_2();
            cl2.AA();
            //Задание 4
            Class_3 cl3 = new Class_3();
            cl3.Test_1();
            cl3.Test_2();

            string path = AppDomain.CurrentDomain.BaseDirectory;
            Process.Start(path);
            Console.Read();
        }
    }

    class Class_1
    {
        private Random randomChar = new Random();
        private Random randomLengthOfString = new Random();
        public void RandomStringGeneration(int numberOfFolders)
        {

            for (int t = 1; t < 11; t++)//10 папок
            {
                string d = Convert.ToString(Directory.CreateDirectory("Папка" + t));

                for (int i = 1; i < 11; i++)//10 файлов
                {

                    if (t > numberOfFolders) break;
                    


                    for (int h = 0; h < 3; h++)//3 записи
                    {
                        string str = "";

                        using (StreamWriter sw = File.AppendText(d + "/" + "Файл" + i + ".txt"))
                        {
                            int n = (int)randomLengthOfString.Next(3, 10);
                            for (int j = 0; j < n; j++)// 3-10 символов 
                            {

                                char rdChar = (char)randomChar.Next('A', 'z');
                                str += rdChar;

                            }
                            sw.WriteLine(str);
                        }
                        Console.WriteLine(str);
                    }
                }
            }
        }
    }

    class Class_2
    {
        public Class_2()
        {

            using (StreamWriter sw = File.AppendText("input.txt"))
            {
                for (int i = 1; i <= 100; i++)
                {
                    sw.Write(i + ";");
                }
            }
        }

        public void AA()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamReader sr = new StreamReader(path + "input.txt"))
            {
                string str = sr.ReadLine();

                string[] numbers = Regex.Split(str, @"\D+");
                foreach (string value in numbers)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        int i = Convert.ToInt32(value);
                        Console.WriteLine("Number: {0}", i);

                        if (i % 2 != 0)
                        {
                            using (StreamWriter sw = File.AppendText(path + "/" + "output.txt"))
                            {
                                sw.Write(i + " ");
                            }
                        }
                    }
                }
            }
        }
    }

    class Class_3
    {
        private IWebDriver driver_yandex; 
        private IWebDriver driver_avito;

        public Class_3()
        {
            driver_yandex = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver_yandex.Navigate().GoToUrl("https://yandex.ru/");

            driver_avito = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver_avito.Navigate().GoToUrl("https://www.avito.ru/");
        }

        public void Test_1()
        {
            By news_btn = By.XPath("//div[text() = 'Новости']");
            IWebElement aa = driver_yandex.FindElement(news_btn);
            aa.Click();

            IWebElement find1 = driver_yandex.FindElement(By.XPath(@"//div/div[2]/div/div[1]/div[1]/div[1]"));
            string result1 = find1.Text;

            IWebElement find2 = driver_yandex.FindElement(By.XPath(@"//div/div[2]/div/div[1]/div[1]/div[2]"));
            string result2 = find2.Text;

            IWebElement find3 = driver_yandex.FindElement(By.XPath(@"//div/div[2]/div/div[1]/div[1]/div[3]"));
            string result3 = find3.Text;

            IWebElement find4 = driver_yandex.FindElement(By.XPath(@"//div/div[2]/div/div[1]/div[1]/div[4]"));
            string result4 = find4.Text;

            IWebElement find5 = driver_yandex.FindElement(By.XPath(@"//div/div[2]/div/div[1]/div[1]/div[5]"));
            string result5 = find5.Text;

            Console.WriteLine("ya result1 = {0}\n ya result2 = {1}\n ya result3 = {2}\n ya result4 = {3}\n ya result2 = {4}", result1, result2, result3, result4, result5);
        }

        public void Test_2()
        {
            By searchField_input = By.XPath("//input[@placeholder = 'Поиск по объявлениям']");
            IWebElement e1 = driver_avito.FindElement(searchField_input);
            e1.SendKeys("Диван");

            By toFind_btn = By.XPath("//div[@class ='index-button-2q4Wv']");
            IWebElement e2 = driver_avito.FindElement(toFind_btn);
            e2.Click();

            By ad1_btn = By.XPath("//*/div[1]/div[2]/div[1]/a/span");
            IWebElement e3 = driver_avito.FindElement(ad1_btn);
            e3.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement find1 = driver_avito.FindElement(By.XPath("//span[@class = 'title-info-title-text']"));
            string result1 = find1.Text;


            Console.WriteLine($"\n avito result1 = {result1}");
        }
    }

    /*class Class_5
    {
        public async Task<string> GetRequestAsync(string url)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            string dd = Convert.ToString(response.EnsureSuccessStatusCode());

            //string responseBody = await response.Content.ReadAsStringAsync();
                
            
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    return HttpStatusCode 
            //}
            //else { Console.WriteLine("ФУУУУ"); }
            ////return responseBody;
        }
    }*/
}