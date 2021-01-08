using SRP_FileStore.SingleResponsibilityPrinciple.Tests;
using System;

namespace SRP_FileStore
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFileStoreSRPStart();
            Console.ReadLine();
        }

        private static void TestFileStoreSRPStart()
        {
            SRPFileStore_Start_Tests srpStartTests = new SRPFileStore_Start_Tests();
            srpStartTests.RunTests();
        }
    }
}
