using System;
using System.Collections.Generic;
using System.Text;

namespace task_1
{
    class Text
    {
        private string _text;

        public Text()
        {
            Console.WriteLine("Write your text :");
            _text = Console.ReadLine();
        }

        public void Info() // Lorem Ipsum - это текст-"рыба", часто используемый в печати и вэб-дизайне
        {
            string word = "";
            double wordsCount = 0;
            double withOutSpace = _text.Length;
            string lastWordsSumbols = "";

            for(var i = 0; i < _text.Length; i++)
            {
                if (_text[i] == ' ')
                    withOutSpace--;

                if (Char.IsLetter(_text[i]))
                {
                    word += _text[i];
                }
                else
                {
                    if (word.Length > 1)
                    {
                        wordsCount++;
                        lastWordsSumbols += word[word.Length - 1];
                        word = "";
                    }
                }
            }

            if (word.Length > 1)
            {
                wordsCount++;
                lastWordsSumbols += word[word.Length - 1];
                word = "";
            }

            Console.WriteLine($"Количество слов: {wordsCount};");
            Console.WriteLine($"Количество символов без пробелов: {withOutSpace};");
            Console.WriteLine("Соотношение количество символов без пробелов к количеству слов: {0:N2};", System.Math.Round((withOutSpace / wordsCount), 2));
            Console.WriteLine($"Слово из последних символов слов: '{lastWordsSumbols}'.");
        }
    }
}
