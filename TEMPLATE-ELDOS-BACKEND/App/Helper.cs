namespace TEMPLATE_ELDOS_BACKEND.App
{
    public class Helper
    {
        public static string ConvertVideoUrl(string url)
        {
            string newUrl = url.Replace("youtu.be", "youtube.com/embed");
            return newUrl;
        }
    }
}