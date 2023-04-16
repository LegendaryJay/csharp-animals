namespace csharp_animals
{
    public class FileOutput : IDisposable
    {
        private readonly StreamWriter? _out;
        private readonly string _fileName;

        public FileOutput(string fileName)
        {
            _fileName = fileName;
            try
            {
                _out = new StreamWriter(new FileStream(fileName, FileMode.Create));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File Open Error: {_fileName} {e}");
            }
        }

        public void FileWrite(string line)
        {
            try
            {
                if (_out != null)
                {
                    _out.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"File Write Error: {_fileName} {e}");
            }
        }

        public void FileClose() => _out?.Close();

        public void Dispose() => FileClose();
    }
}