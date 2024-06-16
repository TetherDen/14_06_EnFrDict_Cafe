using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace hw_14_06_dict_or_queue
{
    internal class Program
    {
        public static class EngFrenchDict
        {
            public static Dictionary<string, string> list;
            static EngFrenchDict() { list = new Dictionary<string, string>(); }

            public static void Add(string key, string value) 
            {
                list[key] = value; 
            }
            public static void RemoveByWord(string key)
            {
                if(list.ContainsKey(key))
                {
                    list.Remove(key);
                }
            }
            public static void RemoveByTranslation(string value)
            {
                foreach (var el in list)
                {
                    if (el.Value == value)
                    {
                        list.Remove(el.Key);
                        return;
                    }
                }
            }
            public static void Clear()
            {
                list = new Dictionary<string, string>();
            }

            public static void ChangeWord(string word, string newWord)
            {
                if(list.ContainsKey(word))
                {
                    string value = list[word];
                    list.Remove(word);
                    list.Add(newWord, value);
                }     
            }
            public static void ChangeTranslation(string word, string newTranslation)
            {
                if(list.ContainsKey(word))
                {
                    list[word] = newTranslation;
                }
            }

            public static string SearchWord(string word)
            {
                if (list.ContainsKey(word))
                {
                    return list[word];
                }
                return null;
            }
            public static string Show()
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Key + " - " + item.Value);
                }
                return "";
            }
        }




        static void Main(string[] args)
        {
            //            Завдання 2:
            //Створіть додаток «Англо - французький словник», який має зберігати наступну інформацію:
            // слово англійською мовою;
            // варіанти перекладу французькою.
            //Для зберігання інформації використовуйте Dictionary<T>.
            //Додаток має надавати таку функціональність:
            // додати слово і варіанти перекладу;
            // видалити слово;
            // видалити варіанти перекладу;
            // зміна слова;
            // зміна варіанта перекладу;
            // пошук перекладу слова.

            EngFrenchDict.Add("Hello", "Bonjour");
            EngFrenchDict.Add("Greate", "Le greate");
            EngFrenchDict.Add("Run", "Le run");
            EngFrenchDict.Add("Pardon", "Le pardon");
            EngFrenchDict.Add("Water", "La water");
            EngFrenchDict.Add("test", "La test");

            //foreach (var el in EngFrenchDict.list)
            //{
            //    Console.WriteLine(el.Key + " - " + el.Value);
            //}
            EngFrenchDict.Show();

            Console.WriteLine("\nTEST: ");
            EngFrenchDict.RemoveByWord("Hello");
            EngFrenchDict.RemoveByTranslation("Le run");
            EngFrenchDict.ChangeWord("Pardon", "sry");
            EngFrenchDict.ChangeTranslation("test", "Le test");

            EngFrenchDict.Show();

            Console.WriteLine($"searchWord: { EngFrenchDict.SearchWord("Greate")}");

            Console.WriteLine("\n===========\nCafe Queue \n===========");
            //            Завдання 3:
            //Створіть додаток, що емулює чергу в популярне кафе.Відвідувачі
            //кафе приходять та потрапляють у чергу, якщо немає вільного
            //місця.Коли столик в кафе стає вільним, перший відвідувач з
            //черги займає його.Якщо приходить відвідувач, який резервував
            //столик на певний час, він отримує зарезервований столик
            //позачергово.
            //Під час розробки додатка використовуйте клас Queue<T>.

            Cafe cafe = new Cafe("myCafe", 5);
            //Visitor vis1 = new Visitor("john");
            //Visitor vis2 = new Visitor("jeffry");
            //Visitor vis3 = new Visitor("joe");
            //Visitor vis4 = new Visitor("jessica");
            //Visitor vis5 = new Visitor("jesse");
            //Visitor vis6 = new Visitor("jen");
            //Visitor vis7 = new Visitor("jack");

            cafe.AddVisitor(new Visitor("john"));
            cafe.AddVisitor(new Visitor("jeffry"));
            cafe.AddVisitor(new Visitor("joe"));
            cafe.AddVisitor(new Visitor("jessica"));
            cafe.AddVisitor(new Visitor("jesse"));
            cafe.AddVisitor(new Visitor("jen"));
            cafe.AddVisitor(new Visitor("jack"));

            Console.WriteLine("ShowTables():");
            cafe.showTables();
            Console.WriteLine("ShowQueue():");
            cafe.ShowQueue();

            Console.WriteLine("Joe left table()");
            cafe.RemoveVisitor(2);   // удаление по индексу

            Console.WriteLine("ShowTables():");
            cafe.showTables();
            Console.WriteLine("ShowQueue():");
            cafe.ShowQueue();

            // TODO:  Reserved Queue for Visitors 
            // TODO: class tables? 


        }
    }
}
