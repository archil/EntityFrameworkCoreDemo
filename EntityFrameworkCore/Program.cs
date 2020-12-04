using LearningManagementSystem.Domain.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var importer = new ScoreImporter(new FileContentReader(), new FileContentParser(), new Repository(new Db.LMSDbContext()));

            var importResult = importer.Import(@"C:\Users\User\source\repos\EntityFrameworkCoreDemo\EntityFrameworkCore\data.csv");
            Console.WriteLine($"Import results. Succeeded: {importResult.Succeeded}, Failed: {importResult.Failed}");

            Console.ReadLine();
        }
    }
}
