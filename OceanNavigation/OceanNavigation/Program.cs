using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanNavigation
{
    public class Ship
    {
        public string serialNumber;
        public Angle latitude;
        public Angle longitude;

        public Ship(string serialNumber, int latDegrees, float latMinutes, char latDirection, int longDegrees, float longMinutes, char longDirection)
        {
            this.serialNumber = serialNumber;
            this.latitude = new Angle(latDegrees, latMinutes, latDirection);
            this.longitude = new Angle(longDegrees, longMinutes, longDirection);
        }

        public void PrintPosition()
        {
            Console.WriteLine($"Latitude: {latitude}, Longitude: {longitude}");
        }

        public void PrintSerialNumber()
        {
            Console.WriteLine($"Serial Number: {serialNumber}");
        }
    }

    public class Angle
    {
        private int degrees;
        private float minutes;
        private char direction;

        public Angle(int degrees, float minutes, char direction)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.direction = direction;
        }

        public void SetAngle(int degrees, float minutes, char direction)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.direction = direction;
        }

        public override string ToString()
        {
            return $"{degrees}°{minutes:0.0}' {direction}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Ship> mySHIP = new List<Ship>();
            while (true)
            {


                int number = mainMenu();
                {
                    if (number == 1)
                    {
                        Ship myShip = addShip();
                        mySHIP.Add(myShip);
                        myShip.PrintSerialNumber();
                        myShip.PrintPosition();
                    }
                    if (number == 2)
                    {
                        Console.WriteLine("Enter the serial number: ");
                        string num = Console.ReadLine();
                        Ship mySHip = FindBySerialNumber(num, mySHIP);
                        mySHip.PrintPosition();
                    }
                }

                Console.ReadLine();
            }
        }
        public static int mainMenu()
        {
            int num;
            Console.WriteLine("ADD SHIP");
            Console.WriteLine("VIEW SHIP POSITION");
            Console.WriteLine("VIEW SHIP SERIAL NUMBER");
            Console.WriteLine("CHANGE SHIP POSITION");
            Console.WriteLine("EXIT");
            num = int.Parse(Console.ReadLine());
            return num;
        }
        public static Ship addShip()
        {
            Console.WriteLine("Enter Ship Serial Number: ");
            string serialNumber = Console.ReadLine();
            Console.WriteLine("Enter Ship Latitude: ");
            Console.WriteLine("Enter Ship Latitude's Degree : ");
            int latDegree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Latitude's Minute : ");
            float latMinute = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Latitude's Direction : ");
            char latDirection = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Longitude: ");
            Console.WriteLine("Enter Ship Longitude's Degree : ");
            int lonDegree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Longitude's Minute : ");
            float longMinute = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Longitude's Direction : ");
            char lonDirection = char.Parse(Console.ReadLine());
            Ship myShip = new Ship(serialNumber, latDegree, latMinute, latDirection, lonDegree, longMinute, lonDirection);
            return myShip;
        }
        public static Ship FindBySerialNumber(string serialNumber, List<Ship> ships)
        {
            foreach (Ship ship in ships)
            {
                if (ship.serialNumber == serialNumber)
                {
                    return ship;
                }
            }
            return null;
        }
    }
}
