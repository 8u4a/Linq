using System;  // base clase tot ce inseamna C#
using System.Collections.Generic; //  manipularea de colectii ( arrays) - make your life easy when working with arrays
using System.Linq; // object collection (arrays)
using System.Text; 
using System.Threading.Tasks;

namespace homies
{
    class Program
    {
        static void Main(string[] args)
        {

            Homie budak = new Homie(new HomieAddress("PT", "Lisbon"), "Bog", "Bud", 31);
            Homie andrei = new Homie(new HomieAddress("TH", "Bangkok"), "Andrei", "Sensei", 38);
            Homie buhanu = new Homie(new HomieAddress("BT", "Thimphu"), "Alecs", "ElBuha", 33);
            Homie piere = new Homie(new HomieAddress("JP", "Tokyo"), "Piere", "Vome", 28);
            Homie sai = new Homie(new HomieAddress("CZ", "Prague"), "Psy", "Tzu", 28);
            Homie borch = new Homie(new HomieAddress("NL", "Amsterdam"), "Borcho", "Coiotul", 30);
            Homie craci = new Homie(new HomieAddress("ES", "Madrid"), "Craci", "Cra", 31);
            Homie scoby = new Homie(new HomieAddress("UK", "London"), "Scoby", "Snake", 32);
            Homie gabitzu = new Homie(new HomieAddress("US", "Seattle"), "Gabi", "Tud", 28); 
            Homie felipe = new Homie(new HomieAddress("IT", "Torino"), "Felipe", "Stalianu", 31);
            Homie superman = new Homie(new HomieAddress("IT", "Torino"), "Radoo", "Petarda", 31);
            Homie batman = new Homie(new HomieAddress("IT", "Torino"), "Bardo", "Mache", 31);
            Homie aquaman = new Homie(new HomieAddress("IT", "Torino"), "Macaz", "Barda", 31);
            Homie pulerman = new Homie(new HomieAddress("NL", "Amsterdam"), "Tic", "Darada", 31);

            List<Homie> allHomies = new List<Homie>() {
                budak,
                andrei,
                buhanu,
                piere,
                sai,
                borch,
                craci,
                scoby,
                gabitzu,
                new Homie(new HomieAddress("IT", "Torino"), "Felipe", "Stalianu", 31),
                superman,
                batman,
                aquaman,
                pulerman
            };


            allHomies.ForEach(homie =>
            {
                var myCity = homie.Address.City;
                var myCountry = homie.Address.Country;

                Func<Homie,bool> itIsNotME = h => h.Firstname != homie.Firstname;

                var otherHomiesFromMyCity = allHomies.
                    Where(h => h.Address.City == myCity).
                    Where(itIsNotME);

                var otherHomiesFromMyCountry = allHomies.
                    Where(h => h.Address.Country == myCountry).
                    Where(itIsNotME);

                homie.Friends.AddRange(otherHomiesFromMyCountry);               
                homie.Friends.AddRange(otherHomiesFromMyCity);
            });

            //foreach (var homie in allHomies)
            //{
            //    if (homie.Age < 30)
            //    {

            //    Console.WriteLine(homie.ShowHomieDetail());

            //    }

            //}

            //void showIfAgeLessThan30(Homie homie) { 

            //if (homie.Age > 30 && homie.Address.City == "Torino") 
            //        {

            //       Console.WriteLine(homie.ShowHomieDetail());

            //        }

            //}

            allHomies
                //.Where(currentHomie => currentHomie.Age > 30)
                .GroupBy(currentHomie => currentHomie.Age)
                //.Where(group => group.ToList().Any (h => h.Age >30))
                //.Where(currentHomie => currentHomie.Address.City == "Torino")
                .ToList()
                .ForEach(group =>
                {
                    //Console.WriteLine(group.Key);
                    //group.ToList().ForEach(h => Console.WriteLine(h.ShowHomieDetail()));

                });


            //.ForEach(currentHomie => Console.WriteLine(currentHomie.ShowHomieDetail()));

            // var over25List = allHomies.Where(h => h.Age > 25).ToList();
            var over25List = from homie in allHomies where homie.Age > 25 select homie;

            var over25ListFromTorino = over25List.Where(h => h.Address.City == "Torino").ToList();
            var anyFromTorino = allHomies.Any(h => h.Address.City == "Torino");
            var anyFromTorino2 = allHomies.Where(h => h.Address.City == "Torino").Count();


            var primulGasitDinTorino = allHomies.First(h => h.Address.City == "Torino");

            var theHomiesFromAmsterdam = allHomies.Where(h => h.Address.City == "Amsterdam").ToList();

            var allHomiesFromSpainAndJapan = allHomies.Where(h => h.Address.Country == "ES" || h.Address.Country == "JP").ToList();

            allHomies.OrderBy(h => h.Firstname)
                .ToList()
                .ForEach(h => Console.WriteLine (h.ShowHomieDetail()));
            
            Console.ReadLine();
        }
    }
}
