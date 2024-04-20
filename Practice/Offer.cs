using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Offer
    {
        static List<Offer> offers = new List<Offer>();
        public string offerName { get; set; }
        public string offerType { get; set; }
        public string price { get; set; }
        public Offer(string offerName, string offerType, string price)
        {
            this.offerName = offerName;
            this.offerType = offerType;
            this.price = price;
        }
        public static Offer takeInput()
        {
            Console.Write("Enter NAme:");
            string tempName = Console.ReadLine();
            Console.Write("Enter Type:");
            string tempType = Console.ReadLine();
            Console.Write("Enter Price:");
            string tempPrice = Console.ReadLine();
            Offer offer = new Offer(tempName, tempType, tempPrice);
            storeDataInList(offers, offer);
            return offer;
        }
        public static void storeDataInList(List<Offer> offers, Offer offer)
        {
            offers.Add(offer);
        }
        public static void viewOffer()
        {
            foreach (Offer offerList in offers)
            {
                Console.WriteLine("Offer Name:" + offerList.offerName + "Offer Type:" + offerList.offerType + "Offer Price:" + offerList.price);
            }
        }
        public static void removeOffer(Offer offer)
        {
            Console.WriteLine("Enter Name:");
            string tempName = Console.ReadLine();
            foreach (Offer offerList in offers)
            {
                string offer1 = offerList.offerName;
                if (tempName == offer1)
                {
                    removeDataInList(offers, offer);
                }
            }
        }
        public static void removeDataInList(List<Offer> offers, Offer offer)
        {
            offers.Remove(offer);
        }
        public static void home()
        {
            Console.WriteLine("1.Add");
            Console.WriteLine("2.View");
            Console.WriteLine("3.Remove");
        }
    }
}
