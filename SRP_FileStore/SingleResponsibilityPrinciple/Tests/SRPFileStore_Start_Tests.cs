using SRP_FileStore.SingleResponsibilityPrinciple.Shared;
using SRP_FileStore.SingleResponsibilityPrinciple.Start;
using System;
using System.Linq;

namespace SRP_FileStore.SingleResponsibilityPrinciple.Tests
{
    public class SRPFileStore_Start_Tests
    {
        private SRPFileStore_Start _fileStoreStart;

        public void RunTests()
        {
            _fileStoreStart = new SRPFileStore_Start();

            for (int i = 1; i < 7; i++)
                ReadAFile(i);

            WriteToAFile(5);
        }

        public void ReadAFile(int id)
        {
            Maybe<string> result;
            result = _fileStoreStart.Read(id);
            Console.WriteLine(result.Count() > 0 ? result.ElementAt(0) : "No results");

        }

        public void WriteToAFile(int id)
        {
            _fileStoreStart.Save(id, "Additional Text to Add Then Save");
        }
    }
}
