using System.Text.RegularExpressions;

namespace BetterAssets
{
    internal class Program
    {
        const string PredefinedAssetTag = "[Embed(source=\"Sprites/.png\")]";
        const string PredefinedDataTag = "[Embed(source=\"Xmls/.xml\", mimeType=\"application/octet-stream\")]";
        static void Main(string[] args)
        {
            Console.WriteLine("Working...");

            var paths = Directory.EnumerateFiles(Environment.CurrentDirectory).ToArray();

            if (!Directory.Exists(Environment.CurrentDirectory + "/Sprites"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "/Sprites");

            if (!Directory.Exists(Environment.CurrentDirectory + "/Xmls"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "/Xmls");

            string embeddedassets = "";
            string embeddeddata = "";

            for (var i = 0; i < paths.Length; i++)
            {
                var path = paths[i];
                var dest = path;

                if (path.Contains("EmbeddedAssets.as"))
                {
                    embeddedassets = path;
                    continue;
                }
                else if (path.Contains("EmbeddedData.as"))
                {
                    embeddeddata = path;
                    continue;
                }


                if (path.Contains("CXML.as") || path.Contains("Embed_.as"))
                {
                    File.Delete(path);
                    continue;
                }

                if (path.Contains(".png"))
                {
                    dest = path.Replace("EmbeddedAssets_", "Sprites/");
                }

                if (path.Contains("CXML.dat"))
                {
                    dest = path.Replace("EmbeddedData_", "Xmls/");
                }

                File.Move(path, dest.Replace("EmbeddedAssets_", "").Replace("EmbeddedData_", "").Replace("Embed_", "").Replace("CXML.dat", ".xml"));
            }

            if (!string.IsNullOrEmpty(embeddedassets))
            {
                var code = File.ReadAllText(embeddedassets);
               // var codelines = File.ReadAllLines(embeddedassets);

                var output = Regex.Replace(code, @"(?<=:Class)(.*?)(?=;)", "");
                output = Regex.Replace(output, @"(?<=;)(\n    )", $"\n    {PredefinedAssetTag}\n    ");

                File.WriteAllText("EmbeddedAssets.as", output);
            }

            if (!string.IsNullOrEmpty(embeddeddata))
            {
                var code = File.ReadAllText(embeddeddata);
                //var codelines = File.ReadAllLines(embeddeddata);

                var output = Regex.Replace(code, @"(?<=:Class)(.*?)(?=;)", "");
                output = Regex.Replace(output, @"(?<=;)(\n    )", $"\n    {PredefinedDataTag}\n    ");

                File.WriteAllText("EmbeddedData.as", output);
            }

            Console.WriteLine("Done :D");
            Console.ReadKey();
        }
    }
}
