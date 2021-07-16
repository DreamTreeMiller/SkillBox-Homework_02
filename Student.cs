using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork_02
{
    /// <summary>
    /// Класс, описывающий модель ученика
    /// Поля данных и действия по выводу 
    /// </summary>
    /// <param name="Student"> Класс, описывающий модель ученика</param>

    public class Student
    {
        /// <summary>
        /// Объявляем переменные - поля значение соответствующим полям ученика
        /// </summary>
        string FirstName;   // имя
        string LastName;    // фамилия
        byte Age;         // возраст лет
        byte Height;      // рост в см
        byte History;     // оценка по истории 
        byte Math;        // оценка по математике
        byte RusLang;     // оценка по русскому языку
        public float AvgMark;     // средняя оценка

        /// <summary>
        /// Конструктор, присваивающий значение полям ученика
        /// </summary>
        /// <param name="FirstName">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Height">Рост</param>
        /// <param name="History">Оценка по истории</param>
        /// <param name="Math">оценка по математике</param>
        /// <param name="RusLang">оценка по русскому языку</param>
        public Student(string FirstName, string LastName, byte Age, byte Height,
                           byte History, byte Math, byte RusLang)
        {
            this.FirstName = FirstName; // Сохранить переданное значение имени
            this.LastName = LastName;   // Сохранить переданное значение фамилии
            this.Age = Age;             // Сохранить переданное значение возраста
            this.Height = Height;       // Сохранить переданное значение роста
            this.History = History;     // Сохранить переданную оценку по истории
            this.Math = Math;           // Сохранить переданную оценку по математике
            this.RusLang = RusLang;     // Сохранить переданную оценку по русскому языку
            AvgMark = ((float)this.History + (float)this.Math + (float)this.RusLang) / (float)3.0; // вычисляем средний балл
        }

        /// <summary>
        /// Метод неформатированый вывод данных о ученике в одну строку
        /// </summary> 
        public void OutputNoFormat()
        {
            Write("Ученик: " + FirstName + " " + LastName + " ");
            Write(Age.ToString() + " лет, рост " + Height.ToString() + " см");
            Write(". Баллы: история - " + History.ToString());
            Write(", мат-ка - " + Math.ToString());
            Write(", рус.язык - " + RusLang.ToString());
            WriteLine(", средний: " + AvgMark.ToString());
            return;
        }

        /// <summary>
        /// Форматированный вывод данных в одну строку 
        /// с выравниванием по правому краю каждой позиции
        /// </summary>
        public void OutputFormat()
        {
            string pattern = "Имя: {0,15} {1,15}, {2,5} лет, рост {3,3} см," +
                             " история {4,2}, мат-ка {5,2}, рус.яз. {6,2}, ср. балл {7,4:#.##}";

            WriteLine(pattern,
                      FirstName, LastName, Age, Height,
                      History, Math, RusLang, AvgMark);
        }
       
        /// <summary>
        /// Форматированный вывод данных
        /// в одну строку для таблицы
        /// с выравниванием по левому краю каждой позиции
        /// </summary>
        public string OutputFormatLeft()
        {
            return $"{FirstName,-15} {LastName,-15} {Age,-7} {Height,-7} " +
                   $"{History,-7} {Math,-7} {RusLang,-7} {AvgMark.ToString("###.##"),-7}";
        }


        /// <summary>
        /// Форматированный вывод данных c интерполяцией
        /// в одну строку для таблицы
        /// с выравниванием по центру каждой позиции
        /// количество символов для каждой позиции.
        /// </summary>
        public void OutputFormatCenter()
        {
            // BFN - строка из необходимого количества пробелов ПЕРЕД именем в 15 символьном поле
            String BFN = new String(' ', (15 - FirstName.Length) / 2);

            // AFN - строка из необходимого количества пробелов ПОСЛЕ имени в 15 символьном поле
            String AFN = ("").PadRight((15 - FirstName.Length - BFN.Length), ' ');

            // BLN - строка из необходимого количества пробелов ПЕРЕД фамилией в 15 символьном поле
            String BLN = new String(' ', (15 - LastName.Length) / 2);

            // ALN - строка из необходимого количества пробелов ПОСЛЕ имени в 15 символьном поле
            String ALN = ("").PadRight((15 - LastName.Length - BLN.Length), ' ');

            // Формируем строку, где каждый элемент распологается по центру своего столбца
            WriteLine($"{BFN}{FirstName}{AFN}" +       // ширина поля имени 15 символов 
                      $"{BLN}{LastName}{ALN}" +        // ширина поля фамилии 15 символов
                      $" {Age,2} " +            // обычно возраст 2 цифры. Расположим под "оз" из "Возр"
                      $" {Height,4}" +          // обычно рост 3 цифры. Располжим под "ост" из "Рост"                   
                      $" {History,2} " +        // оценка 1 цифра. Располжим под средней буквой С 
                      $" {Math,2} " +           // оценка 1 цифра. Располжим под средней буквой А     
                      $" {RusLang,2} " +        // оценка 1 цифра. Располжим под средней буквой У
                      $"{AvgMark,7:#.##}");     // Ср.балл в формате #,## под р.ба
        }
    }
}
