using System;
using System.IO;
using System.Threading;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Wepie.YuqueConverter
{
    public class Converter
    {
        /*
        * mac 使用时需要注意以下问题
        * 1、google浏览器与ChromeDriver版本不一致问题
        * 解决方案：
        * a、先下载对应浏览器的版  http://chromedriver.storage.googleapis.com/index.html
        * b、替换该工程目录下的chromedriver文件 路径：YuqueConverter/bin/Debug/netcoreapp3.1/chromedriver
         
        * 2、转换的网页显示不全
        * 解决方案：
        * a、这个是debug chrome打开方式不正确
        * b、先配置环境变量 https://www.cnblogs.com/zhaikunkun/p/12610312.html
        * c、使用命令打开debug浏览器（只能用这个命令打开） Google\ Chrome -remote-debugging-port=9222
        
        3、chromedriver的版本下载是对的，但还是提示版本不对
        * 解决方案：
        * 检查YuqueConverter.csproj里面的Selenium.WebDriver.ChromeDriver Version是否是对应的版本
        */


        public static void Run(string[] args)
        {
            // 运行前先关闭所有浏览器，再通过命令打开一个debug浏览器，例如：
            // "C:\Program Files\Google\Chrome\Application\chrome.exe" --remote-debugging-port=9222
            var options = new ChromeOptions();
            options.DebuggerAddress = "localhost:9222";
            options.AddArgument("--user-agent=Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25");
            using (var driver = new ChromeDriver(options))
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);

                //HandlePrivacyPolicy(driver);
                //HandleThirdInformation(driver);
                // HandleLegalRequire(driver);
                HandleMostImportant(driver);
            }
        }

        //以后每次更新sdk信息用这个就行了
        private static void HandleMostImportant(IWebDriver driver)
        {
            //《坦克无敌》隐私政策
            HandleHtmlContent(driver, "https://wepie.yuque.com/liuhongmin-private-group-2838/vn9wz8/kixv7u?singleDoc#", @"/Users/tangjian/Desktop/Work/finaltank-home/src/policy/privacy/Policy.html", "《坦克无敌》隐私政策");
            //《坦克无敌隐私政策摘要》
            HandleHtmlContent(driver, "https://wepie.yuque.com/liuhongmin-private-group-2838/vn9wz8/kaxglq?singleDoc#", @"/Users/tangjian/Desktop/Work/finaltank-home/src/policy/privacy/Policybrief.html", "《坦克无敌隐私政策摘要》");
            //《坦克无敌》第三方共享清单—通用版本
            HandleHtmlContent(driver, "https://wepie.yuque.com/liuhongmin-private-group-2838/vn9wz8/ks0wbi?singleDoc#", @"/Users/tangjian/Desktop/Work/finaltank-home/src/policy/third/Thirdcommon.html", "《坦克无敌》第三方共享清单—通用版本");
        }

        private static void HandlePrivacyPolicy(IWebDriver driver)
        {
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/08c1a0f2-3fe6-4edb-9da3-6ff23f620fb0?#", @"C:\Workspace\finaltank-home\src\policy\privacy\Yeshen.html", "《坦克无敌》隐私政策");
        }

        private static void HandleThirdInformation(IWebDriver driver)
        {
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/e87695d5-bfec-475f-8c16-fc4b4ff9f3d5?#", @"C:\Workspace\finaltank-home\src\policy\third\official.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/058fd1f7-e659-4951-8295-cc43b97c674f?#", @"C:\Workspace\finaltank-home\src\policy\third\M233.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/c8922220-8d82-4546-8ba5-5d7a93e6a8cf?#", @"C:\Workspace\finaltank-home\src\policy\third\M4399.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/66193558-7f04-4ad2-8aa4-9b304cf0226e?#", @"C:\Workspace\finaltank-home\src\policy\third\BiliBili.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/c32c9339-82b2-4dcb-8741-6416fc89cb83?#", @"C:\Workspace\finaltank-home\src\policy\third\AliGame.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/6dac359f-e731-4247-8815-77f76ca6f04a?#", @"C:\Workspace\finaltank-home\src\policy\third\Meizu.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/dd5ee736-8cb4-4331-b0ad-e159ef27eb6b?#", @"C:\Workspace\finaltank-home\src\policy\third\Xiaomi.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/cf24a080-95c9-4284-aeea-718909502079?#", @"C:\Workspace\finaltank-home\src\policy\third\Huawei.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/a557105a-77a0-4432-8d8b-e6dea2bb1f5b?#", @"C:\Workspace\finaltank-home\src\policy\third\Vivo.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/1c271d56-4a74-4116-9c53-2ce5337511b2?#", @"C:\Workspace\finaltank-home\src\policy\third\Oppo.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/a6b65f9d-8a1e-4f01-98ff-ad3c5c079136?#", @"C:\Workspace\finaltank-home\src\policy\third\Yingyongbao.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/b5399759-e940-41ca-b359-0073d8a4daff?#", @"C:\Workspace\finaltank-home\src\policy\third\Xiao7.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/5b10a600-69ff-456a-a035-741c0431f744?#", @"C:\Workspace\finaltank-home\src\policy\third\Douyin.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/e87695d5-bfec-475f-8c16-fc4b4ff9f3d5?#", @"C:\Workspace\finaltank-home\src\policy\third\Momoyu.html", "坦克无敌第三方信息共享清单");
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/c9caf20e-b16f-425b-9ec1-5feb578341b2?#", @"C:\Workspace\finaltank-home\src\policy\third\Yeshen.html", "坦克无敌第三方信息共享清单");
        }

        private static void HandleLegalRequire(IWebDriver driver)
        {
            HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/4183adae-1246-4b26-825e-f6c05fad38f2?#", @"/Users/tangjian/Desktop/Work/finaltank-home/src/policy/CancelInternational.html", "坦克无敌隐私政策摘要");
            // HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/5b47a695-493a-4bcc-908f-1077a1c9dc5e?#", @"/Users/tangjian/Desktop/Work/finaltank-home/src/policy/privacy/Policy.html", "《坦克无敌》隐私政策");
            //HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/19741296-b79b-445c-a035-67f052f850c8?#", @"/Users/tangjian/Desktop/Work/finaltank-home/src/policy/privacy/ChildrenPolicy.html", "坦克无敌儿童隐私保护声明");
            //HandleHtmlContent(driver, "https://wepie.yuque.com/docs/share/c3deb9a0-5791-4e03-84a3-c5a8622abca3?#", @"/Users/tangjian/Desktop/Work/finaltank-home/src/policy/third/Thirdcommon.html", "《坦克无敌》第三方共享清单");
        }

        private static void HandleHtmlContent(IWebDriver driver, string url, string localFilePath, string title)
        {
            Console.WriteLine($"url:{url}");
            driver.Navigate().GoToUrl(url);

            for (int i = 1; i <= 10; i++)
            {
                string jsCode = "window.scrollTo({top: document.body.scrollHeight / 10 * " + i + ", behavior: \"smooth\"});";
                //使用IJavaScriptExecutor接口运行js代码
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(jsCode);
                //暂停滚动
                Thread.Sleep(1000);
            }
            
            IWait<IWebDriver> wait=new WebDriverWait(driver, TimeSpan.FromSeconds(60.00));                
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            
            
            
            var entries = driver.Manage().Logs.GetLog(LogType.Browser);
            foreach (var entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }

            var source = driver.PageSource;

            File.WriteAllText("test.html", source);

            var sourceDoc = new HtmlDocument();
            sourceDoc.LoadHtml(source);

            var sourceBodyNode = sourceDoc.DocumentNode.SelectSingleNode("//div[@class='ne-viewer-body']");
            if (sourceBodyNode == null)
            {
                Console.WriteLine($"can't find node in {url}");
                return;
            }

            var targetFileText = File.ReadAllText(localFilePath);
            var targetDoc = new HtmlDocument();
            targetDoc.LoadHtml(targetFileText);
            var targetBodyNode = targetDoc.DocumentNode.SelectSingleNode("//div[@class='ne-viewer']");
            targetBodyNode = targetBodyNode.ParentNode.ReplaceChild(sourceBodyNode.Clone(), targetBodyNode);
            targetBodyNode.ReplaceClass("ne-viewer", "ne-viewer-body");

            var titleNode = targetDoc.DocumentNode.SelectSingleNode("//title");
            ((HtmlTextNode)titleNode.FirstChild).Text = title;
            var descriptionNode = targetDoc.DocumentNode.SelectSingleNode("//meta[@name='description']");
            descriptionNode.SetAttributeValue("content", title);
            var h1Node = targetDoc.DocumentNode.SelectSingleNode("//body/h1");
            ((HtmlTextNode)h1Node.FirstChild).Text = title;

            targetDoc.Save(localFilePath);
            Console.WriteLine("convert success");
        }
    }
}
