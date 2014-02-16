using System;
using System.IO;
using System.Collections.Generic;
using ExportDanych.Models;
using Ionic.Zip;


namespace ExportDanych.Zip
{
    public class Backup
    {
        public string HomeDirectory { get; private set; }

        public Backup(string homeDirectory)
        {
            HomeDirectory = homeDirectory;
        }

        public Stream ZipFilesInRange(ExportModel movie)
        {
            Stream zipStream = new MemoryStream();

            using (ZipFile zip = new ZipFile())
            {
                List<DirectoryElementList> directoryList = GetDirectoryElementList(movie.FromDate, movie.ToDate);
                foreach (DirectoryElementList element in directoryList)
                {
                    zip.AddDirectory(element.Directory, element.DirectoryInArchive);
                }
                zip.Save(zipStream);
                zipStream.Position = 0;
            }
            return zipStream;

        }
        private List<DirectoryElementList> GetDirectoryElementList(DateTime from, DateTime to)
        {
            List<DirectoryElementList> elementsList = new List<DirectoryElementList>();
            do
            {
                string directoryInArchive = GetDirectoryInArchiveNamefromTime(from);
                string directory = Path.Combine(HomeDirectory, directoryInArchive);
                if (Directory.Exists(directory))
                {
                    elementsList.Add(new DirectoryElementList(directory, directoryInArchive));
                }
                from = from.Date.AddDays(1);
            } 
            while (from <= to);

            return elementsList;
        }
        private string GetDirectoryInArchiveNamefromTime(DateTime time)
        {
            return Path.Combine(Path.Combine(
                        String.Format("{0:yyyy}", time), String.Format("{0:MM}", time)),
                        String.Format("{0:dd}", time));
        }

    }
}