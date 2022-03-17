using System;
using System.Collections.Generic;
using System.IO;
//Jessika Gyllström
namespace Lists
{
    class Program
    {
        [STAThread]
        //Program som läser in säljare, personnummer, distrikt samt sålda artiklar
        //Presenterar sedan resultatet utefter sålda artiklar och nivåer
        //1: Be om input av användaren angående antal personer som skall registreras
        //2: Spara infon om varje person
        //3: Sortera efter antal sålda artilklar och nivåer
        //4: Spara resultat till fil
        //4: Presentera resultatet i konsoll
        static void Main(string[] args)
        {
            try
            {   //skapar referens till textfil
                using (StreamWriter sw = new StreamWriter("tst.txt"))
                {
                    //skapar variabler
                    int noOfPersons;
                    int counterLvlOne = 0;
                    int counterLvlTwo = 0;
                    int counterLvlThree = 0;
                    int counterLvlFour = 0;

                    //skapar en tom lista
                    List<User> users = new List<User>();

                    Console.WriteLine("Enter the number of persons you want to register: ");
                    //konverterar input till int och sparar det i variabel
                    noOfPersons = Convert.ToInt32(Console.ReadLine());

                    //loopar igenom antalet personer och sparar dessa
                    for (int i = 0; i < noOfPersons; i++)
                    {
                        var user = new User();

                        Console.Write("\nUser Name: ");
                        user.Name = Console.ReadLine();

                        Console.Write("idNr: ");
                        user.idNr = Convert.ToDouble(Console.ReadLine());

                        Console.Write("District: ");
                        user.Dist = Console.ReadLine();

                        Console.Write("Items sold: ");
                        user.Items = Convert.ToInt32(Console.ReadLine());

                        //lägger till i user
                        users.Add(user);
                    }

                        //loopar igenom alla personer och uppdaterar värdena i countern för de olika nivåerna
                        foreach (User u in users)
                    {
                        if (u.Items >= 199)
                        {
                            counterLvlFour++;
                        }
                        else if (u.Items > 100 && u.Items <= 199)
                        {
                            counterLvlThree++;

                        }
                        else if (u.Items > 50 && u.Items <= 99)
                        {
                            counterLvlTwo++;
                        }
                        else if (u.Items < 50)
                        {
                            counterLvlOne++;
                        }
                    }

                    //sorterar antal sålda artiklar
                    users.Sort((x, y) => x.Items.CompareTo(y.Items));

                    Console.WriteLine("\nNamn         Personr         Distrikt          Antal");
                    sw.WriteLine("\nNamn         Personr         Distrikt          Antal");

                    //loopar igenom alla användare och skriver ut info för säljare i nivå 1
                    foreach (User u in users)
                    {
                        if (u.Items < 50) {
                            Console.WriteLine(u.Name + "        " + u.idNr + "          " + u.Dist + "          " + u.Items);
                            sw.WriteLine(u.Name + "        " + u.idNr + "          " + u.Dist + "          " + u.Items);
                        }
                    }
                    //om räknaren för nivå ett är mer än 0, skriv ut antal säljare på nivån
                    if (counterLvlOne > 0)
                    {
                        Console.WriteLine(counterLvlOne + " Säljare har nått nivå 1: 0-50 artiklar");
                        sw.WriteLine(counterLvlOne + " Säljare har nått nivå 1: 0-50 artiklar");
                    }
                    //loopar igenom alla användare och skriver ut info för säljare i nivå 2
                    foreach (User u in users)
                    {
                        if (u.Items > 50 && u.Items <= 99)
                        { 
                          Console.WriteLine(u.Name + "        " + u.idNr + "          " + u.Dist + "          " + u.Items);
                         sw.WriteLine(u.Name + "        " + u.idNr + "          " + u.Dist + "          " + u.Items);
                        }
                    }
                    //om räknaren för nivå två är mer än 0, skriv ut antal säljare på nivån
                    if (counterLvlTwo > 0)
                    {
                        Console.WriteLine(counterLvlTwo + " Säljare har nått nivå 2: 50-99 artiklar");
                        sw.WriteLine(counterLvlTwo + " Säljare har nått nivå 2: 50-99 artiklar");
                    }
                    //loopar igenom alla användare och skriver ut info för säljare i nivå 2
                    foreach (User u in users)
                    {
                        if (u.Items > 100 && u.Items <= 199)
                        {
                            Console.WriteLine(u.Name + "        " + u.idNr + "          " + u.Dist + "          " + u.Items);
                            sw.WriteLine(u.Name + "        " + u.idNr + "          " + u.Dist + "          " + u.Items);
                        }
                    }

                    //om räknaren för nivå tre är mer än 0, skriv ut antal säljare på nivån
                    if (counterLvlThree>0)
                    {
                        Console.WriteLine(counterLvlThree + " Säljare har nått nivå 3: 100-199 artiklar");
                        sw.WriteLine(counterLvlThree + " Säljare har nått nivå 3: 100-199 artiklar");
                    }
                    //loopar igenom alla användare och skriver ut info för säljare i nivå 2
                    foreach (User u in users)
                    {
                        if (u.Items >= 199)
                        {
                            Console.WriteLine(u.Name + "        " + u.idNr + "          " + u.Dist + "          " + u.Items);
                            sw.WriteLine(u.Name + "        " + u.idNr + "          " + u.Dist + "          " + u.Items);
                        }
                    }
                    //om räknaren för nivå 4 är mer än 0, skriv ut antal säljare på nivån
                    if (counterLvlFour>0)
                    {
                        Console.WriteLine(counterLvlFour + " Säljare har nått nivå 4: över 199 artiklar");
                        sw.WriteLine(counterLvlFour + " Säljare har nått nivå 4: över 199 artiklar");
                    }
                }
            }

            //fångar eventuella fel
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
         }
      }

        //skapar en klass som skall innehålla namn, idnr, distrikt samt artiklar
        public class User
        {
            public string Name { get; set; }

            public double idNr { get; set; }

            public string Dist { get; set; }

            public int Items { get; set; }

        }
    }
