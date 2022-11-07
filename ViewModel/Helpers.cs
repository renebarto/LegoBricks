using System.IO;

namespace LegoBricks.ViewModel
{
    public class Helpers
    {
        public static string GetAbsolutePath(string path)
        {
            var absPath = Directory.GetCurrentDirectory() + "/" + path;
            return absPath;
        }

    }

}
