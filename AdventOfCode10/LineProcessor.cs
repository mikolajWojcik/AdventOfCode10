using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode10
{
    public class LineProcessor
    {
        public int ReadLine(string line)
        {
            if (line.Length % 2 != 0)
                return 0;

            var corrupted = FindCorruptedCharacters(line);

            return MapCharacterToInt(corrupted.First());
        }

        public string FindCorruptedCharacters(string line)
        {
            var itemsToRemove = new List<int>();
            
            var first = new Stack<int>();
            var second = new Stack<int>();
            var third = new Stack<int>();
            var fourth = new Stack<int>();

            for (int i = 0; i < line.Length; i++)
            {
                switch (line[i])
                { 
                    case '(':
                        AddToStack(first, i);
                        break;
                    case ')':
                        RemoveCharacterFromStack(first, itemsToRemove, i);
                        break;
                    case '[': 
                        AddToStack(second, i);
                        break;
                    case ']':
                        RemoveCharacterFromStack(second, itemsToRemove, i);
                        break;
                    case '{':
                        AddToStack(third, i);
                        break;
                    case '}':
                        RemoveCharacterFromStack(third, itemsToRemove, i);
                        break;
                    case '<':
                        AddToStack(fourth, i);
                        break;
                    case '>':
                        RemoveCharacterFromStack(fourth, itemsToRemove, i);
                        break;
                }
            }

            return new string(line.Where((x,i) => !itemsToRemove.Contains(i)).ToArray());
        }

        private static void AddToStack(Stack<int> stack, int i) => stack.Push(i);

        private static void RemoveCharacterFromStack(Stack<int> stack, ICollection<int> output, int i)
        {
            if (stack.Count <= 0) 
                return;
            
            var index = stack.Pop();
            output.Add(index);
            output.Add(i);
        }

        private static int MapCharacterToInt(char character)
        {
            return character switch
            {
                ')' => 3,
                ']' => 57,
                '}' => 1197,
                '>' => 25137,
                _ => 0
            };
        }
    }
}