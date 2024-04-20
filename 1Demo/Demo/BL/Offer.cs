using Demo.bl.DI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace Demo.bl
{
    class Offer
    {
        // List to store all offers
        public static List<Offer> offers = new List<Offer>();

        // Offer properties
        public string offerName { get; set; }
        public string offerType { get; set; }
        public string offerSpec { get; set; }
        public string offerPrice { get; set; }

        // Constructor with all properties
        public Offer(string offerName, string offerType, string offerSpec, string offerPrice)
        {
            this.offerName = offerName;
            this.offerType = offerType;
            this.offerSpec = offerSpec;
            this.offerPrice = offerPrice;
        }

        // Constructor without offerPrice property
        public Offer(string offerName, string offerType, string offerSpec)
        {
            this.offerName = offerName;
            this.offerType = offerType;
            this.offerPrice = offerSpec; // Reusing the offerSpec parameter as offerPrice
        }

        // Constructor with only offerName property
        public Offer(string offerName)
        {
            this.offerName = offerName;
        }
        public override string ToString()
        {
            return offerName + "," + offerType + "," + offerSpec + "," + offerPrice;
        }

    }
}