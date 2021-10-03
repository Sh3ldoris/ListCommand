using System;
using System.IO;

namespace HomeWork1
{
    public class LSCommand
    {
        private const int DefaultSectionSpace = 2;
        private readonly string _section;
        private readonly bool _isFilesColored;
        private readonly bool _isSeparation;
        private int maxRecursion;

        public LSCommand(int _maxRecursion = -1, bool _isSeparation = false, int _separation = DefaultSectionSpace, bool _isFilesColored = false)
        {
            maxRecursion = _maxRecursion;
            this._isSeparation = _isSeparation;
            this._isFilesColored = _isFilesColored;
            var initSeparation = "";
            for (var i = 0; i < _separation; i++)
            {
                initSeparation += " ";
            }
            _section = initSeparation;
        }

        public void RunCommand(string _path)
        {
            var directory = new DirectoryInfo(_path);
            GetDirInfo(directory, 0, maxRecursion);
        }
        
        private void GetDirInfo(DirectoryInfo directory, int separation, int recursion)
        {
            var subDirectories = directory.GetDirectories(); 
            var files = directory.GetFiles();

            var separationSpace = "";
            if (_isSeparation)
            {
                // Defines tree section space
                for (var i = 0; i < separation; i++)
                {
                    separationSpace += _section;
                }
            }
            
            // Writes Directories info
            foreach (var subDir in subDirectories)
            {
                Console.WriteLine($"{subDir.LastWriteTimeUtc:dd.MM.yyyy HH:mm:ss}     {separationSpace}{subDir.Name}/");
                switch (recursion)
                {
                    case > 0:
                        GetDirInfo(subDir, separation + 1, recursion - 1);
                        break;
                    case -1:
                        GetDirInfo(subDir, separation + 1, -1);
                        break;
                }
            }
            
            // Writes Files info
            foreach ( var file in files)
            {
                if (_isFilesColored)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine($"{file.LastWriteTimeUtc.ToString("dd.MM.yyyy HH:mm:ss")}     {separationSpace}{file.Name}");
                Console.ResetColor();
            }
        }
    }
}