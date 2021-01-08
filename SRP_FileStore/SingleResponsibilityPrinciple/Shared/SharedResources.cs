using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SRP_FileStore.SingleResponsibilityPrinciple.Shared
{
    public sealed class Log
    {
        public void Information(string message, int id)
            => WriteLog(string.Format(message, id.ToString()));

        public void Debug(string message, int id)
            => WriteLog(string.Format(message, id.ToString()));

        private static void WriteLog(string logEntry)
            => Console.WriteLine(logEntry);
    }


    public sealed class FileProxyClass
    {
        private IDictionary<int, FileElements> _files = new Dictionary<int, FileElements>();

        public FileProxyClass() => Initialize();

        public FileElements GetFileInfo(int fileId)
            => _files.ContainsKey(fileId) ? _files[fileId] : new FileElements();

        public void WriteAllText(string fileName, string text)
        {
            var fileElements = _files.Values.FirstOrDefault(fileEls => fileEls.Name == fileName);
            if (fileElements != null)
            {
                fileElements.Text = string.Concat(fileElements.Text, $"{Environment.NewLine}{text}");
                DisplayFileInformationAndContents(fileElements);
            }
        }

        public string ReadAllText(int fileId)
        {
            if (_files.ContainsKey(fileId))
                return _files[fileId].Text;

            return string.Empty;
        }

        private static void DisplayFileInformationAndContents(FileElements file)
        {
            Console.WriteLine(string.Join(Environment.NewLine, new string[]
            {   $"FileId: {file.Id}",
                $"FileName: {file.Name}",
                $"FileContents: {file.Text}"
            }));
        }

        private void Initialize()
        {
            _files[1] = new FileElements(1, "CowMoon.txt", "The cow jumped over the moon");
            _files[2] = new FileElements(2, "BrokenClockDay.txt", "A broken clock is right twice a day");
            _files[3] = new FileElements(3, "BrokenClockYear.txt", "A broken clock is right 730 times a year");
            _files[4] = new FileElements(4, "ShakepeareAsYouLikeIt.txt", "All the world's a stage");
            _files[5] = new FileElements(5, "RushBastilleDay.txt", "There's no bread, let them eat cake");
        }

        public class FileElements
        {
            public FileElements() { Exists = false; }

            public FileElements(int id, string name, string text)
            {
                Id = id;
                Name = name;
                Text = text;
                Exists = true;
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Text { get; set; }
            public bool Exists { get; set; }
        }
    }

    /// <summary>
    /// Maybe<T> – is a method invocation concept borrowed from functional programming 
    /// Options are used in functional languages to indicate that an object might not be present. 
    /// https://www.codinghelmet.com/articles/understanding-the-option-maybe-functional-type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Maybe<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _values;

        public Maybe()
        {
            _values = new T[0];
        }

        public Maybe(T value)
        {
            _values = new T[] { value };
        }

        public IEnumerator<T> GetEnumerator()
           => this._values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
