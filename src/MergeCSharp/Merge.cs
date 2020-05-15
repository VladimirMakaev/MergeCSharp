using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MergeCSharp
{
    public class Merge : Task
    {
        [Required]
        public ITaskItem[] InputFiles { get; set; }

        [Required]
        public ITaskItem OutDir { get; set; }

        public override bool Execute()
        {
            var output = SyntaxFactory.CompilationUnit();

            foreach (var inputFile in InputFiles)
            {
                var inputModel =
                    CSharpSyntaxTree.ParseText(File.ReadAllText(inputFile.ItemSpec), CSharpParseOptions.Default);

                var usings = inputModel.GetRoot()
                    .ChildNodes()
                    .OfType<UsingDirectiveSyntax>()
                    .ToArray();

                var rootMembers = inputModel.GetRoot()
                    .ChildNodes()
                    .OfType<MemberDeclarationSyntax>()
                    .ToArray();


                output = output.AddUsings(usings).AddMembers(rootMembers);
            }

            File.WriteAllText(Path.Combine(OutDir.ItemSpec, "output.cs"), output.ToFullString());
            return true;
        }
    }
}