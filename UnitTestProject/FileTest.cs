using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using UnitTestEx;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject
{
    [TestClass]
    public class FileTest
    {

        public const string SIZE_EXCEPTION = "Wrong size";
        public const string NAME_EXCEPTION = "Wrong name";
        public const string SPACE_STRING = " ";
        public const string FILE_PATH_STRING = "@D:\\JDK-intellij-downloader-info.txt";
        public const string CONTENT_STRING = "Some text";
        public double lenght;

        /* ПРОВАЙДЕР */
        static object[] FilesData =
        {
            new object[] { new File(FILE_PATH_STRING, CONTENT_STRING), FILE_PATH_STRING, CONTENT_STRING},
            new object[] { new File(SPACE_STRING, SPACE_STRING), SPACE_STRING, SPACE_STRING}
        };

        /* Тестируем получение размера */
        [Test, TestCaseSource(nameof(FilesData))]
        public void GetSizeTest(File newFile, String name, String content)
        {
            lenght = content.Length / 2;

            Assert.That(newFile.GetSize(), Is.EqualTo(lenght), SIZE_EXCEPTION);
        }

        /* Тестируем получение имени */
        [Test, TestCaseSource(nameof(FilesData))]
        public void GetFilenameTest(File newFile, String name, String content)
        {
            Assert.That(newFile.GetFilename(), Is.EqualTo(name), NAME_EXCEPTION);
        }

        /* Тестируем создание файла без расширения */
        [Test]
        public void CreateNewFileWithoutExtension_ShouldHandleCorrectly()
        {
            string filename = "noextension";
            string content = "Some content";
            Assert.DoesNotThrow(() => new File(filename, content), "Constructor should handle filename without extension");
            File file = new File(filename, content);
            Assert.That(file.GetFilename(), Is.EqualTo(filename), "Filename should be set correctly");
        }

        /* Тестируем создание файла с пустым содержимым */
        [Test]
        public void CreateNewFileWithEmptyContent_ShouldSetZeroSize()
        {
            string filename = "empty.txt";
            string content = "";
            File file = new File(filename, content);
            Assert.That(file.GetSize(), Is.EqualTo(0), "File size should be 0 for empty content");
        }
    }
}
