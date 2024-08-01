/*
Copyright (c) 2023, iasset.com
*/

using System.Collections.Generic;
using System.Linq;

namespace CodingPad.ConsoleApp
{
    public class FileInfo
    {
        public IEnumerable<CollectionData> GetTopNCollections(int n, List<FileData> fileDatas)
        {
            var result = fileDatas
                        .SelectMany(
                            fileData => fileData.Collections,
                            (fileData, collection) => new
                            {
                                FileData = fileData,
                                Collection = collection
                            }
                        )
                        .GroupBy(
                            item => item.Collection,
                            item => item.FileData.Size,
                            (collection, sizes) => new CollectionData
                            {
                                Name = collection,
                                Size = sizes.Sum()
                            }
                        )
                        .OrderByDescending(data => data.Size)
                        .Take(n)
                        .ToList();


            return result;
        }

        public int GetTotalSize(List<FileData> fileDatas)
        {
            return fileDatas.Sum(x => x.Size);
        }
    }
}
