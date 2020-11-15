using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Laba5
{
    //Испытание, Тест, Экзамен, Выпускной экзамен, Вопрос;
    struct Teacher
    {
        public string Name;
        public string Subject;
        public Teacher(string name, string subject)
        {
            Name = name;
            Subject = subject;
        }
        public void Info()
        {
            Console.WriteLine($"Имя преподавателя {Name}, его дисциплина {Subject}");
        }
    }
    public partial class Author
    {
        private object p;

        public Author(object p)
        {
            this.p = p;
        }

        public string Name { get; set; }

    }
    public partial class Author
    {
        public int Age { get; set; }

    }
    ///наследование исключений!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public class PrograExeption : InvalidCastException
    {
        public PrograExeption(string message) : base(message)
        {

        }
    }
    public class YearExeption : InvalidCastException
    {
        public YearExeption(string message) : base(message)
        {

        }
    }
    public class LimitExeption : InvalidCastException
    {
        public string Cause { get; set; }
        public string ExcName { get; set; }
        public string Date { get; set; }
        public LimitExeption(string name, string message)
        {
            Cause = message;
            ExcName = name;
            Date = DateTime.Now.ToLongTimeString();
        }
        public void Info()
        {
            Console.WriteLine($"Error Name: {ExcName}\nReason: {Cause}\nTime: {Date}");
        }
    }
    public class Session
    {


        public Session(string subject_for_exam, string subject_for_offset, int questions)
        {
            this.subject_for_exam = subject_for_exam;
            this.subject_for_offset = subject_for_offset;
            this.questions = questions;
        }
        public void Inf()
        {
            Console.WriteLine($"Информация для сессии студентов специальности {spec}");
        }

        public string subject_for_offset;
        public int questions;
        public string subject_for_exam;

        public string Offset
        {
            get
            {
                return this.subject_for_offset;

            }
            set
            {
                if (value != null)
                {
                    this.subject_for_offset = value;
                }
                else
                {
                    Console.WriteLine("Бред");
                }
            }

        }
        public int Quest
        {
            get
            {
                return this.questions;
            }
            set
            {
                if (value != 0)
                {
                    this.questions = value;
                }
                else
                {
                    Console.WriteLine("Бред");
                }
            }
        }

        public string Exams
        {
            get
            {
                return this.subject_for_exam;

            }
            set
            {
                if (value != null)
                {
                    this.subject_for_exam = value;
                }
                else
                {
                    Console.WriteLine("Бред");
                }
            }

        }
        public string spec;

        public void Show()
        {
            Console.WriteLine("Экзамен: " + subject_for_exam);
            Console.WriteLine("Зачет:" + subject_for_offset);
            Console.WriteLine("Количество вопросов в тесте:" + questions);
        }

        public int Check(int questions, int q, int qq)
        {
            int count = 0;

            if (questions > 15)
            {
                count++;
            }
            if (q > 15)
            {
                count++;
            }
            if (questions > 15)
            {
                count++;
            }
            return count;
        }
        public int Ch1(string s, string e, string h, string k, string l, string o)
        {
            int count = 0;

            if (s != null)
            {
                count++;
            }
            if (e != null)
            {
                count++;
            }
            if (h != null)
            {
                count++;
            }
            if (k != null)
            {
                count++;
            }
            if (l != null)
            {
                count++;
            }
            if (o != null)
            {
                count++;
            }
            return count;
        }
    }


    interface ITest//испытание
    {
        void Move();
    }

    abstract class Exam
    {
        protected string Name;
        protected byte Mark;


        public Exam(string Name, byte Mark)
        {
            this.Name = Name;
            this.Mark = Mark;
        }

        public abstract void Move();

    }

    class FinalExam : Exam
    {
        string specialty;


        public FinalExam(string a, string Name, byte Mark) : base(Name, Mark)
        {
            if (a == " " || a == "" || a == null)
            {
                throw new PrograExeption("введите корректное имя ");//проверка!!!!
            }
            else
            {
                specialty = a;
            }
        }

        public override void Move()
        {
            Console.WriteLine("Выпускной экзамены для специальности " + specialty + ": " + Name + ". Проходной балл: " + Mark);
        }
        public enum Days
        {
            Monday = 1,
            Tuesday,
            Whensday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

    }

    public class Test : ITest
    {
        public int limit = 30;
        public Test(int count)
        {
            if (count <= 0)
            {
                throw new LimitExeption("Лимит", "Произошло исключение ");//проверка
            }
            limit = count;
        }

        public void Move()
        {
            Console.WriteLine("Тест по CorelDraw: ");
        }

        public override bool Equals(object obj)
        {
            if (obj == "-") // проверка
            {
                Console.WriteLine("Что-то не так");
                return false;
            }

            if (obj != "-")
            {
                Console.WriteLine("Тест сдан.");
                return true;
            }

            Console.WriteLine("Нет теста!");
            return false;
        }
        public override int GetHashCode()
        {
            return 444;
        }
    }

    sealed class Question : ITest
    {
        string answer;
        public Question(string answer)
        {
            this.answer = answer;
        }
        public void Move()
        {
            Console.WriteLine("Студент работает? " + answer);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Author aut = new Author(null);
                Debug.Assert(aut.Name != null, "Values array cannot be null");//assert
                int a = 0;
                int b = 100 / a;//1 mistake
                FinalExam exxam= new FinalExam (null, "физика",4);//2 mistake
                Teacher person = new Teacher("Иванов", "физика");
                person.Info();//3 mistake
                string[] stroka = new string[4];
                stroka[5] = "last"; // 4 mistake
                Test newsss = new Test(-78);//5 mistake
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Деление на 0 " + ex.Message);
            }
            catch (PrograExeption ex)
            {
                Console.WriteLine(ex);
            }
            catch (YearExeption ex)
            {
                Console.WriteLine(ex);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (LimitExeption ex)
            {
                ex.Info();
            }
            finally
            {
                Console.WriteLine("конец !");
            }
            
        }
    }
}