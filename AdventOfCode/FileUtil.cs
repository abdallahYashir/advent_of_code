using System;
using System.IO;
using System.Linq;

 public static class FileUtil
{
    public static string[] ReadFile(string filename)
    {
        string path = Path.Combine("input", filename);
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File {filename} not found in input directory");
        }

        return File.ReadAllLines(path);
    }
}