/*
Copyright (c) 2023, iasset.com
*/

using CodingPad.ConsoleApp;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodingPad.Tests
{

    public class FileDataObject : TheoryData<int?, List<FileData>>
    {
        public FileDataObject()
        {
            Add(3, new List<FileData>
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
                    });
        }
    }

    public class FileInfoTests
    {
        public static IEnumerable<object[]> GetFileDataList()
        {
            return new List<object[]>
            {
               new object[]
               {
                   new List<FileData>
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
                    }
               }
            };
        }

        [Theory]
        [ClassData(typeof(FileDataObject))]
        public void GetTopN_Should_ReturnTopNCollectionInDescendingCollectionSizeOrder_WhenGivenAListOfFiles(int n, List<FileData> fileDatas)
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

            Assert.Equal(3, result.Count);
        }

        [Theory]
        [ClassData(typeof(FileDataObject))]
        public void GetTotalSize_Should_ReturnSizeOfAllFilesInAllCollections_WhenGivenAListOfFiles(int n, List<FileData> fileDatas)
        {
            int expectedSize = 810;
            var result = fileDatas
                        .Sum(item => item.Size);

            Assert.Equal(expectedSize, result);
        }
    }
}
