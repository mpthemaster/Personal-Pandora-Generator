using System.IO;

namespace FileStringComparison
{
    public static class DuplicateSearch
    {
        /// <summary>
        /// Check if some text is already in a file.
        /// </summary>
        /// <param name="text">The text to check for.</param>
        /// <param name="fileName">The file's name to check in.</param>
        /// <returns>Returns true if there is a duplicate.</returns>
        public static bool DuplicateCheck(string text, string fileName)
        {
            using (StreamReader file = new StreamReader("../../" + fileName + ".txt"))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                    if (line == text)
                        return true;

                return false;
            }
        }
    }
}
