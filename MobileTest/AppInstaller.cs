using Xamarin.UITest;

namespace MobileTest
{
    public class AppInstaller
    {
        public static IApp StartApp(Platform platform, string pathToApp)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.
                    Android.
                    ApkFile(pathToApp).
                    StartApp();
            }
            return ConfigureApp.
                iOS.
                StartApp();
        }
    }
}
