using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Demo.bl.UI;

namespace Demo.bl.DI
{
    class OfferCRUD
    {
        // Add an offer to the file
        public static Offer addOffer(string OfferPath)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Offer Name: ");
            string offerName = Console.ReadLine();
            offerName = offerName.ToUpper();
            Console.Write("Enter Offer Type: ");
            string offerType = Console.ReadLine();
            offerType = offerType.ToUpper();

            // Check if offerName and offerType already exist in OfferFile
            if (isOfferExists(offerName, offerType, OfferPath))
            {
                Console.WriteLine("Offer already exists.");
                return null;
            }

            Console.Write("Enter Offer Specification: ");
            string offerSpec = Console.ReadLine();
            offerSpec = offerSpec.ToUpper();
            Console.Write("Enter Offer Price: ");
            string offerPrice = Console.ReadLine();

            if (offerName != null && offerType != null && offerSpec != null)
            {
                Offer offer = new Offer(offerName, offerType, offerSpec, offerPrice);
                appendOfferToFile(offer, OfferPath);
                return offer;
            }

            return null;
        }

        // Add a discount offer to the file
        public static Offer addDiscountOffer(string OfferPath, Offer offer, List<Offer> offers)
        {
            Console.Write("Enter Offer Name: ");
            string offerName = Console.ReadLine();
            offerName = offerName.ToUpper();
            if (offerName != null)
            {
                checkOffer(OfferPath, offer, offers);
                if (checkOffer(OfferPath, offer, offers) == true)
                {
                    Offer offer1 = new Offer(offerName);
                    return offer1;
                }
                else
                {
                    Console.WriteLine("No Record Found");
                }
            }
            return null;
        }

        // Check if an offer exists in the file
        public static bool checkOffer(string OfferPath, Offer offer1, List<Offer> offers)
        {
            if (File.Exists(OfferPath))
            {
                StreamReader file = new StreamReader(OfferPath);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    string[] splitRecord = record.Split(',');
                    string name = splitRecord[0];
                    if (offer1.offerName == name)
                    {
                        Console.Write("Enter Offer Price: ");
                        string offerPrice = Console.ReadLine();
                        offerPrice = offerPrice.ToUpper();
                        Offer offer = new Offer(offerPrice);
                        storeDataInList(offers, offer);
                    }

                }
                file.Close();
                return true;
            }
            return false;
        }

        // Store offer data in the list
        public static void storeDataInList(List<Offer> offers, Offer offer)
        {
            offers.Add(offer);
        }

        // Store offer data in the file
        public static void storeDataInFile(string OfferPath, Offer offer)
        {
            StreamWriter file = new StreamWriter(OfferPath, true);
            file.WriteLine(offer.offerName + "," + offer.offerType + "," + offer.offerSpec + "," + offer.offerPrice);
            file.Flush();
            file.Close();
        }

        // Append an offer to the file
        public static void appendOfferToFile(Offer offer, string OfferPath)
        {
            StreamWriter file = File.AppendText(OfferPath);
            file.WriteLine(offer.ToString());
            file.Close();
        }

        // Read data from the file and store it in the list
        public static bool readData(string OfferPath, List<Offer> offers)
        {
            if (File.Exists(OfferPath))
            {
                StreamReader fileVariable = new StreamReader(OfferPath);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string[] splitRecord = record.Split(',');
                    string offerName = splitRecord[0];
                    string offerType = splitRecord[1];
                    string offerSpec = splitRecord[2];
                    string offerPrice = splitRecord[3];
                    Offer offer = new Offer(offerName, offerType, offerSpec, offerPrice);
                    storeDataInList(offers, offer);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }

        // Parse data from a record based on the field number
        public static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }

        // Remove an offer from the file
        public static bool removeOffer(string OfferPath)
        {
            Offer.offers.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Offer Name: ");
            string offerName = Console.ReadLine();
            offerName = offerName.ToUpper();
            Console.Write("Enter Offer Type: ");
            string offerType = Console.ReadLine();
            offerType = offerType.ToUpper();

            bool offerRemoved = false;

            List<string> remainingOffers = new List<string>();
            string line;
            if (File.Exists(OfferPath))
            {
                using (StreamReader file = new StreamReader(OfferPath))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string existingOfferName = parseData(line, 1);
                        existingOfferName = existingOfferName.ToUpper();
                        string existingOfferType = parseData(line, 2);
                        existingOfferType = existingOfferType.ToUpper();
                        if (existingOfferName == offerName && existingOfferType == offerType)
                        {
                            Console.WriteLine("Offer removed successfully:");
                            offerRemoved = true;
                        }
                        else
                        {
                            remainingOffers.Add(line);
                        }
                    }
                }
            }

            using (StreamWriter file1 = new StreamWriter(OfferPath))
            {
                foreach (string offer1 in remainingOffers)
                {
                    file1.WriteLine(offer1);
                }
            }

            return offerRemoved;
        }

        // Add offers from a list to the file
        public static void addFromListToFile(string path, List<Offer> offers)
        {
            StreamWriter file = new StreamWriter(path);
            foreach (Offer temp in offers)
            {
                file.WriteLine(temp.offerName + "," + temp.offerType + "," + temp.offerSpec + "," + temp.offerPrice);
                file.Flush();
            }
            file.Close();
        }

        // Add offers from the file to the list
        public static void addFromFileToList(string OfferPath)
        {
            if (File.Exists(OfferPath))
            {
                StreamReader file = new StreamReader(OfferPath);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    string tempName = AdminCRUD.parseData(record, 1);
                    string tempType = AdminCRUD.parseData(record, 2);
                    string tempSpec = AdminCRUD.parseData(record, 3);
                    string tempPrice = AdminCRUD.parseData(record, 4);
                    Offer offer = new Offer(tempName, tempType, tempSpec, tempPrice);
                    Offer.offers.Add(offer);
                }
                file.Close();
            }
        }

        // Update the price of an offer
        public static void offers(string OfferPath, List<Offer> offers)
        {
            offers.Clear();
            OfferCRUD.addFromFileToList(OfferPath);
            Console.WriteLine("Enter the offer name: ");
            string offerName = Console.ReadLine();
            offerName = offerName.ToUpper();
            Offer temp = Offer.offers.Find(x => x.offerName == offerName);//Lambda Function
            if (temp != null)
            {
                Console.WriteLine("Enter the new Price you want to Assign ");
                string price = (Console.ReadLine());
                temp.offerPrice = price;
                OfferCRUD.addFromListToFile(OfferPath, offers);
            }
            else
            {
                Console.WriteLine("NO offer found");
                Console.ReadKey();
                Console.Clear();
                OfferCRUD.offers(OfferPath, offers);
            }
        }

        // Check if an offer with the same name and type already exists in the file
        public static bool isOfferExists(string offerName, string offerType, string OfferPath)
        {
            string[] existingOffers = File.ReadAllLines(OfferPath);

            foreach (string offer in existingOffers)
            {
                string[] offerParts = offer.Split(',');
                string existingOfferName = offerParts[0].ToUpper();
                string existingOfferType = offerParts[1].ToUpper();

                if (existingOfferName == offerName && existingOfferType == offerType)
                {
                    return true;
                }
            }

            return false;
        }

        // View the list of offers stored in the file
        public static void viewOfferList(string OfferPath)
        {
            if (File.Exists(OfferPath))
            {
                StreamReader file = new StreamReader(OfferPath);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    string tempName = AdminCRUD.parseData(record, 1);
                    string tempType = AdminCRUD.parseData(record, 2);
                    string tempSpec = AdminCRUD.parseData(record, 3);
                    string tempPrice = AdminCRUD.parseData(record, 4);
                    Offer offer = new Offer(tempName, tempType, tempSpec, tempPrice);

                    // Check if the offer already exists before adding it
                    bool offerExists = false;
                    foreach (Offer existingOffer in Offer.offers)
                    {
                        if (existingOffer.offerName == offer.offerName && existingOffer.offerType == offer.offerType)
                        {
                            offerExists = true;
                            break;
                        }
                    }

                    if (!offerExists)
                    {
                        Offer.offers.Add(offer);
                    }
                }
                file.Close();
            }

            Console.WriteLine("Offer NAME\tType\tSpec\tPrice");
            foreach (Offer offerList in Offer.offers)
            {
                Console.WriteLine("   " + offerList.offerName + "\t\t" + offerList.offerType + "\t" + offerList.offerSpec + "\t" + offerList.offerPrice);
            }

            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }

        // Get a list of offers based on the offer type
        public static List<Offer> getOffersByType(string OfferPath, string offerType)
        {
            List<Offer> offersByType = new List<Offer>();

            if (File.Exists(OfferPath))
            {
                StreamReader file = new StreamReader(OfferPath);
                string record;

                while ((record = file.ReadLine()) != null)
                {
                    string tempName = AdminCRUD.parseData(record, 1);
                    string tempType = AdminCRUD.parseData(record, 2);
                    string tempSpec = AdminCRUD.parseData(record, 3);
                    string tempPrice = AdminCRUD.parseData(record, 4);
                    Offer offer = new Offer(tempName, tempType, tempSpec, tempPrice);

                    if (offer.offerType == offerType)   
                    {
                        offersByType.Add(offer);
                    }
                }

                file.Close();
            }

            return offersByType;
        }
    }
}
