using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace HomeWork_02
{
    /// <summary>
    /// Организация записной книжки и действий с ней
    /// </summary> 

    class Notebook
    {
        /// <summary>
        /// Список студентов
        /// </summary>
        public List<Student> Students { get; set; }

        /// <summary>
        ///  Конструктор, создающий список из 5 учеников
        /// </summary>
        public Notebook()
        {
            this.Students = new List<Student> ();
            this.Students.Add(new Student("Иван", "Терентьев", 12, 150, 5, 5, 5));
            this.Students.Add(new Student("Пётр", "Соловьёв", 11, 147, 3, 4, 5));
            this.Students.Add(new Student("Спиридон", "Сидоров", 13, 156, 5, 3, 3));
            this.Students.Add(new Student("Наталья", "Александрова", 13, 178, 4, 4, 4));
            this.Students.Add(new Student("Мария", "Никоненкова", 11, 156, 3, 3, 5));
        }

        /// <summary>
        /// Метод добавления записи (элемента списка) о новом ученике
        /// </summary>
        // FirstName Имя 
        // LastName Фамилия 
        // Age Возраст 
        // Height Рост 
        // History Оценка по истории 
        // Math оценка по математике 
        // RusLang оценка по русскому языку 
        public void AddStudent()
        {
            string FirstName;
            string LastName; 
            byte Age;
            byte Height;
            byte History;
            byte Math;
            byte RusLang;

            // Ввод данных об ученике с клавиатуры
            // каждое поле вводим с новой строки. 
            // В конце нажимаем возврат "Ввод"

            Console.Write("Введите имя ученика: ");
            FirstName = Console.ReadLine();
            Console.Write("Введите фамилию ученика: ");
            LastName = Console.ReadLine();
            Console.Write("Введите возраст ученика: ");
            Age = byte.Parse(Console.ReadLine());
            Console.Write("Введите рост ученика: ");
            Height = byte.Parse(Console.ReadLine());
            Console.Write("Введите оценку ученика по истории: ");
            History = byte.Parse(Console.ReadLine());
            Console.Write("Введите оценку ученика по математике: ");
            Math = byte.Parse(Console.ReadLine());
            Console.Write("Введите оценку ученика по русскому языку: ");
            RusLang = byte.Parse(Console.ReadLine());

            this.Students.Add(new Student(FirstName, LastName, Age, Height, History, Math, RusLang));
        }

        /// <summary>
        /// Печать неформатированной зап. книжки по строкам
        /// </summary>
        public void PrintNoFormat()
        {
            Console.WriteLine("\n Печать записной книжки без форматирования\n");

            foreach (var student in this.Students)      // для каждого эл-та записной книжки
            {
                student.OutputNoFormat();    // выводим строку неформатированных данных о студенте
            }
        }

        /// <summary>
        /// Печать форматированной зап. книжки по строкам
        /// с выравниванием по правому краю каждого поля
        /// </summary>
        public void PrintFormat()
        {
            Console.WriteLine("\n Печать записной книжки с выравниванием по правому краю каждого поля\n");

            foreach (var student in this.Students)      // для каждого эл-та записной книжки
            {
                student.OutputFormat();    // выводим строку данных о студенте. 
                                           // выразвнивание в каждом поле по правому краю
            }
        }

        /// <summary>
        /// Печать форматированной зап. книжки по строкам
        /// с выравниванием по ЛЕВОМУ краю каждого поля
        /// данных о студенте
        /// </summary>
        public void PrintFormatLeft()
        {
            Console.WriteLine("\n Печать записной книжки с выравниванием по ЛЕВОМУ краю каждого поля\n");

            foreach (var student in this.Students)      // для каждого эл-та записной книжки
            {
                Console.WriteLine(student.OutputFormatLeft());    // выводим строку данных о студенте
                                                                  // выразвнивание в каждом поле по левому краю
            }
        }

        /// <summary>
        /// Выводит заголовок таблицы
        /// Ширина всей выдачи 60 символа.
        /// Имя     - 15
        /// Фамилия - 15
        /// Возраст -  4 
        /// Рост    -  5 (включая начальный пробел)
        /// История -  4
        /// Мат-ка  -  4
        /// Рус.яз. -  4
        /// Ср.балл -  9
        /// </summary>
        public void OutputHeader()      // печатаем заголовок для центра консоли
        {
            Console.WriteLine("      Имя          Фамилия    " +
                       "Возр Рост ИСТ МАТ РУС  Ср.балл");
        }

        /// <summary>
        /// Печать зап. книжки в центре консоли
        /// Выравнивание столбцов по центру
        /// </summary>
        public void PrintCenter()
        {
            // Вычисляем ширину отступа, чтобы расположить таблицу по центру консоли
            // Ширина таблицы 60 символов, если консоль уже, то отступ делаем равным 0 - пустая строка
            // иначе, (ширина консоли - 60) / 2
            // при нечётной ширине консоли, таблица будет на 1 символ левее,
            // т.к. деление даст целое число
            int consoleIndent = Console.WindowWidth > 60 ? 
                                   (Console.WindowWidth - 60) / 2 :
                                   0 ;
            Console.WriteLine("\n Печать записной книжки по центру консоли");
            Console.WriteLine("Ширина консоли: {0} символов", Console.WindowWidth);
            Console.SetCursorPosition(consoleIndent, Console.CursorTop);
            this.OutputHeader();

            foreach (var student in this.Students)   // для каждого элемента записной книжки
            {
                Console.SetCursorPosition(consoleIndent, Console.CursorTop);        // отодвигаем курсор на отступ
                student.OutputFormatCenter();        // печатаем форматированную по центру строку 
                                                     // данных о студенте
            }
        }
    }
}
