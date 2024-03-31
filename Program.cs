using System.IO;

namespace Anarchy_Online_UVG_Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(args[0]) + "//" + Path.GetFileNameWithoutExtension(args[0]);
            StreamReader uvgi = new(File.OpenRead(path + ".uvgi"));
            BinaryReader uvga = new(File.OpenRead(path + ".uvga"));
            int fileCount = int.Parse(uvgi.ReadLine());

            Directory.CreateDirectory(path);
            for (int i = 0; i < fileCount; i++)
            {
                var file = uvgi.ReadLine().Split(' ');
                uvga.BaseStream.Position = int.Parse(file[1]);
                BinaryWriter bw = new(File.Create(path + "//" + file[0] + ".png"));
                bw.Write(uvga.ReadBytes(int.Parse(file[2])));
                bw.Close();
            }
        }
    }
}
