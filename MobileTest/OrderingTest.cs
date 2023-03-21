using NUnit.Framework;
using System.Linq;
using Xamarin.UITest;
using Platform = Xamarin.UITest.Platform;

namespace MobileTest
{
    [TestFixture]
    public class OrderingTest
    {
        private string _path = @"C:\Users\Viktoriia_Sherstiuk\Desktop\ATM\mobile\test.apk";
        private IApp app;
        private Platform platform = Platform.Android;

        [SetUp]
        public void SetUp()
        {
            app = AppInstaller.StartApp(platform, _path);
        }

        //[Test]
        //public void TestDebug()
        //{
        //    app.Repl();
        //}

        [Test]
        public void CheckNewComerInstructionsAreDisplayed()
        {
            var isTextTitleDisplayed = app.Query(c => c.Id("text_title").Text("Добро пожаловать!")).Any();
            Assert.IsTrue(isTextTitleDisplayed);
            var isTextSummaryDisplayed = app.Query(c => c.Id("text_summary").Text("Все товары из каталога Onliner\nу вас под рукой")).Any();
            Assert.IsTrue(isTextSummaryDisplayed);
            app.Tap(c => c.Id("nextView"));
            isTextTitleDisplayed = app.Query(c => c.Id("text_title").Text("Более 700 разделов")).Any();
            Assert.IsTrue(isTextTitleDisplayed);
            isTextSummaryDisplayed = app.Query(c => c.Id("text_summary").Text("Выбирайте среди более 500 000 товаров - от телефонов до красных кроссовок")).Any();
            Assert.IsTrue(isTextSummaryDisplayed);
            app.Tap(c => c.Id("nextView"));
            isTextTitleDisplayed = app.Query(c => c.Id("text_title").Text("Б/у в каталоге")).Any();
            Assert.IsTrue(isTextTitleDisplayed);
            isTextSummaryDisplayed = app.Query(c => c.Id("text_summary").Text("Продавайте свои б/у товары\nчерез каталог")).Any();
            Assert.IsTrue(isTextSummaryDisplayed);
            app.Tap(c => c.Id("nextView"));
            isTextTitleDisplayed = app.Query(c => c.Id("text_title").Text("Корзина")).Any();
            Assert.IsTrue(isTextTitleDisplayed);
            isTextSummaryDisplayed = app.Query(c => c.Id("text_summary").Text("Покупайте товары из каталога\nчерез приложение")).Any();
            Assert.IsTrue(isTextSummaryDisplayed);
            app.Tap(c => c.Id("nextView"));
            isTextTitleDisplayed = app.Query(c => c.Id("text_title").Text("Удобное сравнение")).Any();
            Assert.IsTrue(isTextTitleDisplayed);
            isTextSummaryDisplayed = app.Query(c => c.Id("text_summary").Text("Добавляйте товары в сравнение\nпростым движением пальца")).Any();
            Assert.IsTrue(isTextSummaryDisplayed);
        }

        [Test]
        public void CheckThatItemIsSearchable()
        {
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("menu_search"));
            app.EnterText(c => c.Id("menu_search"), "samsung");
            app.DismissKeyboard();
            var isSearchableWordPresent = app.Query(c => c.Id("text_name")).All(c => c.Text.Contains("Samsung"));
            Assert.IsTrue(isSearchableWordPresent);
        }
    }
}
