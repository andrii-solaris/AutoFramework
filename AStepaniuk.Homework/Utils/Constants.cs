using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stepaniuk.Homework.Utils
{
    struct Constants
    {
        public static readonly string Directory = $@"Reports_{ DateTime.Now:HH_ mm_ ss}";
        public static readonly string CurrentDirectory = $"{System.IO.Directory.GetParent(Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.WorkDirectory)))}";
    }
}
