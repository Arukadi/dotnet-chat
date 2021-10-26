using App.Chat.Models;
using MaterialDesignThemes.Wpf;

namespace App.Chat.Client
{
    public static class ChatApp
    {
        public static User CurrentUser { get; set; }
        public static string ChatBackground { get; set; } = "../_img/ChatBG.png";

        public static void SetTheme(IBaseTheme themeToChange)
        {
            var paletteHelper = new PaletteHelper();
            //Retrieve the app's existing theme
            ITheme theme = paletteHelper.GetTheme();

            //Change the base theme to Dark
            theme.SetBaseTheme(themeToChange);

            //Change the app's current theme
            paletteHelper.SetTheme(theme);
        }
    }
}
