using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    internal class Navigation : IEnumerator<char>
    {
        private char[] instructions;
        private int index = -1;
        public char Current => instructions[index];

        public Navigation(char[] instructions)
        {
            this.instructions = instructions;
        }

        public Navigation(string instructions) : this(instructions.ToCharArray()) { }
        object IEnumerator.Current => Current;
        public void Dispose() { }
        public bool MoveNext()
        {
            index = (index + 1) % instructions.Length;
            return true;
        }
        public void Reset()
        {
            index = -1;
        }
    }
}
