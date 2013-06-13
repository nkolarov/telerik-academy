// ********************************
// <copyright file="TestDirectoryStructure.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace DirectoryStructureTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DirectoryStructure;
    using System.IO;

    [TestClass]
    public class TestDirectoryStructure
    {
        [TestMethod]
        public void FolderObjectCreation()
        {
            Folder sample = new Folder("..\\..\\SampleDir");
            Assert.IsNotNull(sample);
        }

        [TestMethod]
        public void FileObjectCreation()
        {
            FileInfo file = new FileInfo("..\\..\\SampleDir\\sampleFile.txt");
            DirectoryStructure.File sample = new DirectoryStructure.File(file.Name, file.Length);
            Assert.IsNotNull(sample);
        }

        [TestMethod]
        public void GenerateFoldersTestFiles()
        {
            Folder sample = new Folder("..\\..\\SampleDir");
            DirectoryStructureDemo.GenerateFolders(sample);
            int expectedFiles = 1;
            int actualFiles = sample.Files.Count;
            Assert.AreEqual(expectedFiles, actualFiles);
        }

        [TestMethod]
        public void GenerateFoldersTestSubFiles()
        {
            Folder sample = new Folder("..\\..\\SampleDir");
            DirectoryStructureDemo.GenerateFolders(sample);
            int expectedFiles = 2;
            int actualFiles = sample.ChildFolders[0].Files.Count;
            Assert.AreEqual(expectedFiles, actualFiles);
        }

        [TestMethod]
        public void GenerateFoldersTestSubFolders()
        {
            Folder sample = new Folder("..\\..\\SampleDir");
            DirectoryStructureDemo.GenerateFolders(sample);
            int expectedFolders = 2;
            int actualFolders = sample.ChildFolders.Count;
            Assert.AreEqual(expectedFolders, actualFolders);
        }

        [TestMethod]
        public void GenerateFoldersTestSubSubFolders()
        {
            Folder sample = new Folder("..\\..\\SampleDir");
            DirectoryStructureDemo.GenerateFolders(sample);
            int expectedFolders = 1;
            int actualFolders = sample.ChildFolders[0].ChildFolders.Count;
            Assert.AreEqual(expectedFolders, actualFolders);
        }

        [TestMethod]
        public void GenerateFoldersTestFileSizeOneDir()
        {
            Folder sample = new Folder("..\\..\\SampleDir");
            DirectoryStructureDemo.GenerateFolders(sample);
            long expectedFileSize = 33;
            long actualFileSize = sample.ChildFolders[1].GetSize();
            Assert.AreEqual(expectedFileSize, actualFileSize);
        }

        [TestMethod]
        public void GenerateFoldersTestFileSizeAllDir()
        {
            Folder sample = new Folder("..\\..\\SampleDir");
            DirectoryStructureDemo.GenerateFolders(sample);
            long expectedFileSize = 66;
            long actualFileSize = sample.GetSize();
            Assert.AreEqual(expectedFileSize, actualFileSize);
        }
    }
}