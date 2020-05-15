using MergeCSharp;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Tests.Stubs;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class MergeTaskTests
    {
        private readonly ITestOutputHelper helper;

        public MergeTaskTests(ITestOutputHelper helper)
        {
            this.helper = helper;
        }

        [Fact]
        public void Test1()
        {
            var task = new Merge();
            task.BuildEngine = new MockBuildEngine(helper);
            task.InputFiles = new ITaskItem[]
            {
                new TaskItem("E:\\Projects\\OpenSource\\MergeCSharp\\src\\Tests\\Stubs\\MockBuildEngine.cs"),
                new TaskItem("E:\\Projects\\OpenSource\\MergeCSharp\\src\\Tests\\Stubs\\MockBuildLog.cs")
            };
            task.OutDir =
                new TaskItem("E:\\Projects\\OpenSource\\MergeCSharp\\src\\MergeCSharp\\bin\\Debug\\netstandard2.0");
            task.Execute();
        }
    }
}