using CommandLine;

namespace CG.RayTracer.ConsoleApp
{
    public class CommandLineArgs
    {
        [Option('s', "source", Required = true, HelpText = "Input file name")]
        public string FileName { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output file name")]
        public string Output { get; set; }
    }
}