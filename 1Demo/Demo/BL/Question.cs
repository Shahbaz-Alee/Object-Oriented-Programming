using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.bl
{
    class Question
    {
        // Properties of the Question class
        public string text { get; }   // The text of the question
        public string answer { get; } // The answer to the question

        // Constructor for the Question class
        public Question(string text, string answer)
        {
            this.text = text;
            this.answer = answer;
        }
    }
}
