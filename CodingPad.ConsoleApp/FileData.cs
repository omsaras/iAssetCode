/*
Copyright (c) 2023, iasset.com
*/

using System.Collections.Generic;

namespace CodingPad.ConsoleApp
{
    public class FileData
    {
        public string Name { get; set; }

        public int Size { get; set; }

        public ISet<string> Collections { get; set; }
    }
}
