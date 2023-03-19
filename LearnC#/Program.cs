using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace LearnC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Performer work1 = new Performer("Ivan");
            Performer work2 = new Performer("Petro");

            Task[] task = { new Task(work1, "Vikopat yamu"), new Task(work2, "Postroit dom") };

            Boar sch = new Boar(task);
            sch.ShowAllTasks();

            Console.ReadLine();
        }


    }
    class Performer
    {
        public string Name;
        public Performer(string name)
        {
            Name = name;
        }

    }
    class Boar
    {
        public Task[] Tasks;
        public Boar(Task[] tasks)
        {
            Tasks = tasks;
        }
        public void ShowAllTasks()
        {
            for (int i = 0; i < Tasks.Length; i++)
            {
                Tasks[i].ShowInfo();

            }
        }
    }

    class Task
    {
        public Performer Worker;
        public string Description;
        public Task(Performer worker, string description)
        {
            Worker = worker;
            Description = description;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"otvetsven: {this.Worker.Name}\nOpicanie Zada4i: {this.Description}");
        }
    }

}


