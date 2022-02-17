using System;

namespace Zadacha1
{
    struct ComplexStruct
    {
        public double im;
        public double re;

        public ComplexStruct Plus(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }
        //  произведения двух комплексных чисел
        public ComplexStruct Multi(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public ComplexStruct Minus(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        public ComplexStruct Delenia(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = (x.re * im - x.im * re) / (Math.Pow(x.re, 2) + Math.Pow(x.im, 2));
            y.re = (re * x.re + im * x.im) / (Math.Pow(x.re, 2) + Math.Pow(x.im, 2));
            return y;
        }
        public override string ToString()
        {
            return re + "+" + im ;
        }
        class Program
        {

            // а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.

            static void Task1a()
            {
                ComplexStruct complex1;
                complex1.re = 1;
                complex1.im = 6;

                ComplexStruct complex2;
                complex2.re = 4;
                complex2.im = 2;

                ComplexStruct result = complex1.Delenia(complex2);
                Console.WriteLine(result.ToString());
                result = complex1.Minus(complex2);
                Console.WriteLine(result.ToString());
            }



            // б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
            // в) Добавить диалог с использованием switch демонстрирующий работу класса.

            static void Task1b()
            {
                Complex complex1 = new Complex(2, 5);
                Console.WriteLine($"Результат {complex1.ActionComplex()}");
            }


            /// Проверка на четность числа

            public static bool IsOdd(int x)
            {
                return x % 2 == 0;
            }

            public static bool IsPositiv(int x)
            {
                return x > 0;
            }

            public static bool CanContinue(int x)
            {
                return x != 0;
            }

            // Функция для запроса у пользователя

            public static int RequestToUser(string msg)
            {
                int number;
                bool success;
                Console.WriteLine(msg);
                success = int.TryParse(Console.ReadLine(), out number);
                while (!success)
                {
                    Console.WriteLine("Вы не верно ввели, нужно ввести целое число");
                    success = int.TryParse(Console.ReadLine(), out number);
                }
                return number;
            }



            //С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.

            public static int SumPosNotOddVal()
            {
                int result = 0;
                 Console.WriteLine();
                Console.WriteLine("Задния  номер 2");
                int inputNumber = RequestToUser("Введите число");
                while (CanContinue(inputNumber))
                {
                    if (!IsOdd(inputNumber) && IsPositiv(inputNumber))
                    {
                        result += inputNumber;
                    }
                    inputNumber = RequestToUser("Введите число");
                }
                return result;
            }


            static void Main(string[] args)
            {
                Task1a();//Задание 1 а
                Task1b();//Задание 1 в
                Console.WriteLine("сумма положительных нечетных чисел {0}", SumPosNotOddVal());// Задание 2
             
                Console.ReadLine();
            }
        }









        //задача 2

        class Complex
        {
            // Поля приватные.
            private double im;
            // По умолчанию элементы приватные, поэтому private можно не писать.
            double re;

            // Конструктор без параметров.
            public Complex()
            {
                im = 0;
                re = 0;
            }

            // Конструктор, в котором задаем поля.    
            // Специально создадим параметр re, совпадающий с именем поля в классе.
            public Complex(double _im, double re)
            {
                // Здесь имена не совпадают, и компилятор легко понимает, что чем является.              
                im = _im;
                // Чтобы показать, что к полю нашего класса присваивается параметр,
                // используется ключевое слово this
                // Поле параметр
                this.re = re;
            }
            public Complex Plus(Complex x2)
            {
                return new Complex(x2.im + im, x2.re + re);
            }
            public Complex Sub(Complex x2)
            {
                return new Complex(im - x2.im, re - x2.re);
            }
            public Complex Multi(Complex x2)
            {
                return new Complex(re * x2.im + im * x2.re, re * x2.re - im * x2.im);
            }
            bool CheckAction(char answ)
            {
                answ = char.ToLower(answ);
                if (answ == '+' || answ == '-' || answ == '*')
                    return true;
                else
                {
                    Console.WriteLine(" Ввели не правильно попробуйте ещё раз");
                    return false;
                }
            }
            public string ActionComplex()
            {
                char answ;
                double newim, newre;
                Console.WriteLine($"Выберите действие с комплексным числом {this.ToString()}");
                Console.WriteLine("Для этого нажмите на гужную операнд");
                Console.WriteLine("введите + или - или *");
              
                do
                {
                    answ = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                } while (!CheckAction(answ));
                Console.WriteLine("Задайте второй операнд");
                do
                    Console.WriteLine("введите первое число");
                while (!Double.TryParse(Console.ReadLine(), out newre));
                do
                    Console.WriteLine("введите второе число");
                while (!Double.TryParse(Console.ReadLine(), out newim));
                switch (answ)
                {
                    case '+':
                        return this.Plus(new Complex(newim, newre)).ToString();
                    case '-':
                        return this.Sub(new Complex(newim, newre)).ToString();
                    case '*':
                        return this.Multi(new Complex(newim, newre)).ToString();
                    default:
                        return "";
                }
            }

            // Свойства - это механизм доступа к данным класса.
            public double Im
            {
                get { return im; }
                set
                {
                    // Для примера ограничимся только положительными числами.
                    if (value >= 0) im = value;
                }
            }
            public double Re
            {
                get { return re; }
                set
                {
                    // Для примера ограничимся только положительными числами.
                    if (value >= 0) re = value;
                }
            }
            // Специальный метод, который возвращает строковое представление данных.
            public override string ToString()
            {
                return re + "+" + im;
            }
        }
    }
}
