using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportDanych.Zip
{
    internal class DirectoryElementList
    {
        public string Directory { get; private set; }
        public string DirectoryInArchive { get; private set; }
        public DirectoryElementList(string directory, string directoryInArchive)
        {
            Directory = directory;
            DirectoryInArchive = directoryInArchive;
        }
    }
}