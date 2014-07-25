﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace YCPU
{
    class Program
    {
        static void Main(string[] args)
        {
            string in_path, out_path;
#if DEBUG
            args = new string[1] { "../../../../Tests/rain.yasm" };
#endif

            if (args.Length == 1)
            {
                in_path = args[0];
                out_path = args[0] + ".bin";
            }
            else if (args.Length == 2)
            {
                in_path = args[0];
                out_path = args[1];
            }
            else
            {
                Console.WriteLine("Usage: ycpuassember in_path [out_path]");
                return;
            }

            AssemblerResult result = Assemble(in_path, Path.GetDirectoryName(in_path), out_path);
            Console.WriteLine(AssemblerResultMessages[(int)result]);
            Console.ReadKey();
        }

        public static string[] GetFileContents(string in_path)
        {
            if (!File.Exists(in_path))
            {
                return null;
            }

            string in_code = null;
            using (StreamReader sr = new StreamReader(in_path))
            {
                in_code = sr.ReadToEnd().Trim();
            }

            if (in_code == string.Empty)
                return null;

            string[] lines = in_code.Split('\n');

            return lines;
        }

        static AssemblerResult Assemble(string in_path, string out_dir, string out_filename)
        {
            string[] lines = GetFileContents(in_path);
            if (lines == null)
                return AssemblerResult.EmptyDocument;

            Assembler.Parser parser = new Assembler.Parser();
            byte[] machineCode = parser.Parse(lines, Path.GetDirectoryName(in_path));

            if (machineCode == null)
            {
                Console.WriteLine(parser.MessageOuput);
                return AssemblerResult.ParseError;
            }

            Assembler.Generator generator = new Assembler.Generator();
            string output = generator.Generate(machineCode, out_dir, out_filename);
            if (output == string.Empty)
                return AssemblerResult.GenerateError;

            // note both assemble.MessageOutput and generator.MessageOutput have content.
            return AssemblerResult.Success;
        }

        private enum AssemblerResult
        {
            Success,
            EmptyDocument,
            ParseError,
            GenerateError
        }

        private static string[] AssemblerResultMessages = new string[4]
        {
            "Success.",
            "Nothing to compile.",
            "Parser error.",
            "Generator error."
        };

    }
}
