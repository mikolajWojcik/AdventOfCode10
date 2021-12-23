using System;
using AdventOfCode10;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("{([(<{}[<>[]}>{[]{[(<()>", 1197)]
        [InlineData("[[<[([]))<([[{}[[()]]]", 3)]
        [InlineData("[[<[([]))<([[{}[[()]]]", 57)]
        [InlineData("<{([([[(<>()){}]>(<<{{", 25137)]
        public void Test1(string line, int expected)
        {
            var lineProcessor = new LineProcessor();

            var result = lineProcessor.ReadLine(line);

            Assert.Equal(expected, result);


        }
    }
}