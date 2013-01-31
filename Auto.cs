using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;

namespace Intec.Demo.OOP.Les13
{
    class AutoTester
    {
        public static void Runner()
        {
            Console.WriteLine("***** Simple Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Auto myCar = new Auto("Zippy", 20);
            myCar.RadioAan(true);


            try
            {
                for (int i = 0; i < 10; i++)
                    myCar.Accelereer(10);
            }

            //catch (ArgumentOutOfRangeException e)
            //{
            //    //Console.WriteLine("Param name: {0}\nFout: {1}", e.ParamName, e.Message);
            //    throw;
            //}
            //catch (CarIsDeadException e)
            //{

            //    Console.WriteLine("Method: {0}", e.TargetSite);
            //    Console.WriteLine("Message: {0}", e.Message);
            //    Console.WriteLine("Source: {0}", e.Source);

            //    Console.WriteLine(e.HelpLink);
            //    //throw e;
            //    //if (e.Data.Count != 0)
            //    //{
            //    //    foreach (DictionaryEntry data in e.Data)
            //    //    {
            //    //        Console.WriteLine("{0}:{1}", data.Key, data.Value);
            //    //    }
            //    //}          

            //}
            catch (Exception e)
            {

                try
                {
                    FileStream fs = File.Open(@"c:\intec\error.txt", FileMode.Open);
                }
                catch (Exception e2)
                {
                    throw new CarIsDeadException(e.Message, e2);
                }

                Console.WriteLine("Error!!: {0}", e.Message);
            }
            finally
            {
                myCar.RadioAan(false);
            }

            Console.ReadLine();



            Console.ReadLine();
        }
    }

    class Auto
    {
        public const int MAXSNELHEID = 100;

        public int HuidigeSnelheid { get; set; }
        public string MerkNaam { get; set; }

        private bool _isDood;

        private Radio _radio = new Radio();

        public Auto() { }
        public Auto(string merkNaam, int snelheid)
        {
            HuidigeSnelheid = snelheid;
            MerkNaam = merkNaam;
        }

        public void RadioAan(bool status)
        {
            _radio.TurnOn(status);
        }

        public void Accelereer(int snelheid)
        {
            if (snelheid <= 0)
            {
                throw new ArgumentOutOfRangeException("Snelheid", "Snelheid is kleiner of dan 0!");
            }

            if (_isDood)
            {
                Console.WriteLine("{0} is buiten bewust!", MerkNaam);
            }
            else
            {
                HuidigeSnelheid += snelheid;
                if (HuidigeSnelheid > MAXSNELHEID)
                {
                    //Console.WriteLine("{0} is oververhit!", MerkNaam);
                    HuidigeSnelheid = 0;
                    _isDood = true;

                    //Exception exception = new Exception(string.Format("{0} is oververhit!", MerkNaam));
                    //exception.HelpLink = "www.intecbrussel.be/help";

                    //exception.Data.Add("TimeStamp",DateTime.Now);
                    //exception.Data.Add("Oorzaak", "Zware voet");


                    CarIsDeadException exception = new CarIsDeadException(string.Format("{0} is oververhit!",
                                            MerkNaam), "Zware voet!",
                                            DateTime.Now);
                    exception.HelpLink = "http://www.intecbrussel.be/help";

                    throw exception;

                }
                else
                {
                    Console.WriteLine("=> huidige snelheid = {0}", HuidigeSnelheid);
                }
            }
        }
    }

    class Radio
    {
        public void TurnOn(bool on)
        {
            if (on)
                Console.WriteLine("Jamming...");
            else
                Console.WriteLine("Quiet time...");
        }
    }
}
