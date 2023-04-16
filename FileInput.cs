namespace csharp_animals
{
    public class FileInput : IDisposable
    {
        private readonly StreamReader _in;
        private readonly string _fileName;

        public FileInput(string fileName)
        {
            _fileName = fileName;
            try
            {
                _in = new StreamReader(new FileStream(fileName, FileMode.Open));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File Open Error: {_fileName} {e}");
            }
        }

        public void FileRead()
        {
            try
            {
                while (_in?.ReadLine() is { } line)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"File Write Error: {_fileName} {e}");
            }
        }

        public string? FileReadLine()
        {
            try
            {
                if (_in != null)
                {
                    return _in.ReadLine();
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"File Write Error: {_fileName} {e}");
                return null;
            }
        }

        public void FileClose() => _in.Close();

        public void Dispose() => FileClose();
    }
}