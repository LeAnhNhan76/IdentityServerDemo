using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region IdentityServer4
            //var client = new HttpClient();
            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            //if (disco.IsError)
            //{
            //    Console.WriteLine(disco.Error);
            //    return;
            //}

            ////Console.WriteLine("=================================================================");

            //// request token
            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            //{
            //    Address = disco.TokenEndpoint,

            //    ClientId = "webapp",
            //    ClientSecret = "webapp-secret",
            //    Scope = "myapi"
            //});

            //if (tokenResponse.IsError)
            //{
            //    Console.WriteLine(tokenResponse.Error);
            //    return;
            //}

            //Console.WriteLine(tokenResponse.Json);

            //Console.WriteLine("=================================================================");

            //// call api
            //var apiClient = new HttpClient();
            //apiClient.SetBearerToken(tokenResponse.AccessToken);

            //var response = await apiClient.GetAsync("https://localhost:44300/api/identity");
            //if (!response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine(response.StatusCode);
            //}
            //else
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(JArray.Parse(content));
            //}

            //Console.ReadKey();

            #endregion

            //#region Yield

            //List<int> ids = new List<int>() { 1, 2, 4, 4, 7, 8, 4, 8, 4, 4, 3 };

            //Console.Write("Output: ");
            //foreach (var item in GetIdsYield(ids, 4)) 
            //{
            //    Console.Write($"\t{item}");
            //}

            //Console.Read();

            //#endregion

            #region Factory Design Pattern

            //AnimalFactory landAnimalFactory = AnimalFactory.CreateAnimalFactory(AnimalFactoryType.Land);
            //Animal animal = landAnimalFactory.GetAnimal(AnimalType.Cat);

            //Console.WriteLine($"Animal speak: {animal.Speak()}");

            //IOrderService orderService = OrderFactory.GetOrder(OrderType.II);

            //if (orderService == null)
            //    return;

            //Console.WriteLine($"Discount of the order: {orderService.CalDiscount()}");

            #endregion

            Console.Read();
        }

        #region Yield
        private static IEnumerable<int> GetIdsYield(List<int> ids, int valueFind)
        {
            var lengthIds = ids.Count;
            for (int i = 0; i < lengthIds; i++)
            {
                if (i == lengthIds - 5)
                   yield break;
                if (ids[i] == valueFind)
                    yield return i;
            }
            Console.WriteLine("Done");
        }

        #endregion

        #region Factory Design Pattern

        public interface Animal
        {
            string Speak();
        }
        public class Cat : Animal
        {
            public string Speak()
            {
                return "Meow Meow";
            }
        }
        public class Lion : Animal
        {
            public string Speak()
            {
                return "Roar Roar";
            }
        }
        public class Dog : Animal
        {
            public string Speak()
            {
                return "Bark Bark";
            }
        }
        public class Octopus : Animal
        {
            public string Speak()
            {
                return "SQUACK";
            }
        }
        public class Shark : Animal
        {
            public string Speak()
            {
                return "Cannot Speak";
            }
        }

        public abstract class AnimalFactory
        {
            public abstract Animal GetAnimal(AnimalType animalType);

            public static AnimalFactory CreateAnimalFactory(AnimalFactoryType animalFactoryType)
            {
                switch(animalFactoryType)
                {
                    case AnimalFactoryType.Land:
                        return new LandAnimalFactory(); 
                    case AnimalFactoryType.Sea:
                        return new SeaAnimalFactory();
                    default:
                        return null;
                }
            }
        }
        public class LandAnimalFactory : AnimalFactory
        {
            public override Animal GetAnimal(AnimalType animalType)
            {
                switch (animalType)
                {
                    case AnimalType.Cat:
                        return new Cat();
                    case AnimalType.Lion:
                        return new Lion();
                    case AnimalType.Dog:
                        return new Dog();
                    default:
                        return null;
                }
            }
        }
        public class SeaAnimalFactory : AnimalFactory
        {
            public override Animal GetAnimal(AnimalType animalType)
            {
                switch (animalType)
                {
                    case AnimalType.Octopus:
                        return new Octopus();
                    case AnimalType.Shark:
                        return new Shark();
                    default:
                        return null;
                }
            }
        }

        public enum AnimalType { Cat, Dog, Lion, Octopus, Shark }
        public enum AnimalFactoryType { Land, Sea }

        public interface IOrderService
        {
            decimal CalDiscount();
        }

        public class OrderFactory
        {
            public static IOrderService GetOrder(OrderType orderType)
            {
                switch (orderType)
                {
                    case OrderType.I:
                        return new OrderServiceTypeI();
                    case OrderType.II:
                        return new OrderServiceTypeII();
                    default:
                        return null;
                }
            }
        }

        public class Order
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string CustomerName { get; set; }
        }

        public class OrderServiceTypeI : IOrderService
        {
            public decimal CalDiscount()
            {
                return 1000;
            }
        }
        public class OrderServiceTypeII : IOrderService
        {
            public decimal CalDiscount()
            {
                return 2000;
            }
        }

        public enum OrderType { I, II }

        #endregion
    }

}
