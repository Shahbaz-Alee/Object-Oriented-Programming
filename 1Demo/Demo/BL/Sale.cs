using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.bl
{
    // Sale class, derived from Offer
    class Sale : Offer
    {
        private float offerPrice; // Shadowing the offerPrice property in the base class

        public Sale(string offerName, string offerType, string offerSpec, float saleOfferPrice) : base(offerName, offerType, offerSpec)
        {
            this.offerPrice = offerPrice; // Assigning the value to the shadowed offerPrice field
        }
    }

    // Override ToString() method to provide a string representation of the Offer object
    
}
