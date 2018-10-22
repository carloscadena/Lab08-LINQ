using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab08_LINQ.Classes;
using Newtonsoft.Json;

namespace Lab08_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            JsonConversion();
        }

        static void JsonConversion()
        {
            string path = "../../../resources/data.json";
            string text = "";

            // using streamreader to access the file. 
            using (StreamReader sr = File.OpenText(path))
            {
                // get all the text
                text = sr.ReadToEnd();
            }

            // deserialize the JSON to convert to the Neighborhoods object.
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(text);
            List<Feature> features = rootObject.features;
            var manhattanData = (from properties in features
                                                    select properties.properties);

            var neighborhoods = manhattanData.Select(x => x.neighborhood);
            Console.WriteLine("All the neighborhoods in the data:");
            foreach (var item in neighborhoods)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press enter to continue...");
            Console.WriteLine("---------------------------------------------------------");
            Console.ReadLine();

            Console.WriteLine("All the neighborhoods that actually have names:");
            var neighborhoodsWithNames = neighborhoods.Where(x => x != "");
            foreach (var item in neighborhoodsWithNames)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press enter to continue...");
            Console.WriteLine("---------------------------------------------------------");
            Console.ReadLine();

            Console.WriteLine("All the neighborhoods without duplicates:");
            var neighborhoodsDistinct = neighborhoods.Where(x => x != "").Distinct();
            Console.WriteLine("");
            foreach (var item in neighborhoodsDistinct)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press enter to continue...");
            Console.WriteLine("---------------------------------------------------------");
            Console.ReadLine();


            Console.WriteLine("Get Distinct with single line query:");
            var singleLineQuery = manhattanData.Select(x => x.neighborhood).Where(x => x != "").Distinct();
            foreach (var item in singleLineQuery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press enter to continue...");
            Console.WriteLine("---------------------------------------------------------");
            Console.ReadLine();

            Console.WriteLine("Distinct without Lambda");
            var noLambda = (from x in neighborhoods
                        where x != ""
                        select x).Distinct();

            foreach (var item in noLambda)
            {
                Console.WriteLine(item);
            }

        }
    }
}
