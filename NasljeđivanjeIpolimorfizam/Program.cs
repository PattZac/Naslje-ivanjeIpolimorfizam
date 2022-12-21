using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasljeđivanjeIpolimorfizam
{
    class Dessert
    {
        string name;
        double weight;
        int calories;
        public string Name { get => name; set => name = value; }
        public double Weight { get => weight; set => weight = value; }
        public int Calories { get => calories; set => calories = value; }
        public virtual string getDesertType()
        {
            return "Desert";
        }
        public override string ToString()
        {
            string text = "Desert " + Name + " ima " + Weight + "g težina s " + Calories + " kalorija.";
            return text;
        }
        public Dessert(string N, double W, int C)
        {
            Name = N;
            Weight = W;
            Calories = C;
        }
        public Dessert()
        {
        }
    }
    class Cake : Dessert
    {
        bool containsGluten;
        string cakeType;
        public bool ContainsGluten { get => containsGluten; set => containsGluten = value; }
        public string CakeType { get => cakeType; set => cakeType = value; }

        public override string getDesertType()
        {
            return "Cake";
        }
        public override string ToString()
        {
            string text = "Desert " + Name + " je " + CakeType + " vrsta i ";
            if (ContainsGluten) {
                text += "im";
            } else
            {
                text += "nem";
            }

            text += "a gluten, ima " + Weight + "g težina s " + Calories + " kalorija.";
            return text;
        }
        public Cake(string N, double W, int C, bool CG, string CT)
        {
            Name = N;
            Weight = W;
            Calories = C;
            ContainsGluten = CG;
            CakeType = CT;
        }
    }
    class IceCream : Dessert
    {
        string flavor;
        string color;
        public string Flavor { get => flavor; set => flavor = value; }
        public string Color { get => color; set => color = value; }

        public override string getDesertType()
        {
            return "Ice Cream";
        }
        public override string ToString()
        {
            string text = "Desert " + Name + " je " + Color + " boje i ima okus " + Flavor + ", ima " + Weight + "g težina s " + Calories + " kalorija.";
            return text;
        }
        public IceCream(string N, double W, int C, string F, string CR)
        {
            Name = N;
            Weight = W;
            Calories = C;
            Flavor = F;
            Color = CR;
        }
    }
    class Person
    {
        string name;
        string surname;
        int age;
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
        public Person(string N, string M, int A)
        {
            name = N;
            Surname = M;
            Age = A;
        }
        public Person()
        {
        }
        public override string ToString()
        {
            return "Person " + Name + " " + Surname + " ima " + Age + ".";
        }
        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   Age == person.Age;
        }
    }
    class Student : Person
    {
        string studentId;
        int academicYear;

        public string StudentId { get => studentId; set => studentId = value; }
        public int AcademicYear { get => academicYear; set => academicYear = value; }
        public override string ToString()
        {
            return "Person " + Name + " " + Surname + " ima " + Age + " s id-om " + StudentId + " i razred je " + AcademicYear + ".";
        }
        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   //base.Equals(obj) &&
                   StudentId == student.StudentId;
        }
        public Student(string N, string S, int A, string SI, int AY)
        {
            Name = N;
            Surname = S;
            Age = A;
            StudentId = SI;
            AcademicYear = AY;
        }
    }
    class Teacher : Person
    {
        string email, subject;
        double salary;

        public string Email { get => email; set => email = value; }
        public string Subject { get => subject; set => subject = value; }
        public double Salary { get => salary; set => salary = value; }
        public override string ToString()
        {
            return "Person " + Name + " " + Surname + " ima " + Age + " s e-mailom " + Email + " uči " + Subject + " i ima plača " + Salary + ".";
        }
        public override bool Equals(object obj)
        {
            return obj is Teacher teacher &&
                   //base.Equals(obj) &&
                   Email == teacher.Email;
        }
        public Teacher(string N, string S, int A, string E, string SU, double SA)
        {
            Name = N;
            Surname = S;
            Age = A;
            Email = E;
            Subject = SU;
            Salary = SA;
        }
        public void increaseSalary(double SA)
        {
            Salary += SA;
        }
        public void increaseSalaryStatic(double SA)
        {
            salary += SA; //Neznam kako napraviti da sve objekte od teacher poveča salary bez da pretvorim salary u static varijabla koji mjena sve.
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dessert bdayCake = new Cake("Timmys Cake", 50.7, 400, false, "Birthday");
            Dessert aIce = new IceCream("Alice IceCream", 2.5, 5, "starwberry", "red");
            Console.WriteLine(bdayCake.getDesertType() + "\r\n" + bdayCake.ToString());
            Console.WriteLine("\r\n" + aIce.getDesertType() + "\r\n" + aIce.ToString());

            Student s1 = new Student("Patrik", "Emet", 15, "003232", (short) 1);
            Student s2 = new Student("Raven", "Comical", 18, "002996", (short) 4);
            Student s3 = new Student("Matej", "Markovič", 20, "003444", (short) 1);
            Teacher t1 = new Teacher("Email", "Čenovak", 31, "EmailCCvak@gmail.com", "Programiranje", 531.5);
            Teacher t2 = new Teacher("Jakovič", "Vuk", 61, "VukUMark@gmail.com", "Biologiju", 472.7);

            Console.WriteLine("\r\n" + s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(t1);
            Console.WriteLine(t2);
            t1.increaseSalaryStatic(53.5);
            t2.increaseSalaryStatic(53.5);
            Console.WriteLine("\r\n" + t1);
            Console.WriteLine(t2);

            Person p1 = new Person("Ivo", "Ivic", 20);
            Person p2 = new Person("Ivo", "Ivic", 20);
            Person p3 = new Student("Ivo", "Ivic", 20, "0036312123", (short) 3);
            Person p4 = new Student("Marko", "Marić", 25, "0036312123", (short) 5);

            Console.WriteLine("\r\n" + p1.Equals(p2));
            Console.WriteLine(p1.Equals(p4));
            Console.WriteLine(p3.Equals(p4));

            Console.ReadKey();
        }
    }
}
