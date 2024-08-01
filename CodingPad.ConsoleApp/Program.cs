/*
Copyright (c) 2023, iasset.com
*/

using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingPad.ConsoleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var fileInfo = new FileInfo();
            //desc by size and then
            var topNCollections = fileInfo.GetTopNCollections(3, new List<FileData>
            {
                new FileData 
                {
                     Name = "file1.txt", 
                     Size = 100, 
                     Collections = new HashSet<string>{ "collection4" } 
                },
                new FileData 
                { 
                    Name = "file2.txt", 
                    Size = 200,
                    Collections = new HashSet<string>{ "collection1" } 
                },
                new FileData { Name = "file3.txt", Size = 200, Collections = new HashSet<string>{ "collection1" } },
                new FileData { Name = "file4.txt", Size = 300, Collections = new HashSet<string>{ "collection2", "collection3" } },
                new FileData { Name = "file5.txt", Size = 10, Collections = new HashSet<string>() },
            }).ToList();

            Console.ReadKey();
        }
    }
}
