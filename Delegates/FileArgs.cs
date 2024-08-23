namespace Delegates
{
    /// <summary>
    /// Событие
    /// </summary>
    public class FileArgs : EventArgs
    {
        public string SearchFile { get; }

        public bool CancelingSearch { get; set; }

        public event EventHandler<FileArgs> FileFound;

        public FileArgs(string searchFile) => SearchFile = searchFile;
    }
}