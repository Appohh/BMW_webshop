using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Car : Product
    {
        public string ChassisNumber { get; set; }
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string Milage { get; set; }
        public string Engine { get; set; }
        public int Fuel { get; set; }
        public int HorsePower { get; set; }
        public int Torque { get; set; }
        public decimal Time0to60 { get; set; }
        public int TopSpeed { get; set; }
        public int Weight { get; set; }

        public Car() : base(0, "", 0, "", "", "", 0)
        {
        }
        public Car(string chassisNumber, string plate, string brand, string model, string make, string milage, string engine, int fuel, int horsePower, int torque, decimal time0to60, int topSpeed, int weight, int id, string name, decimal price, string description, string imageUrl, string keyword, int taxrate) : base(id, name, price, description, imageUrl, keyword, taxrate)
        {
            ChassisNumber = chassisNumber;
            Plate = plate;
            Brand = brand;
            Model = model;
            Make = make;
            Milage = milage;
            Engine = engine;
            Fuel = fuel;
            HorsePower = horsePower;
            Torque = torque;
            Time0to60 = time0to60;
            TopSpeed = topSpeed;
            Weight = weight;
        }

        public override string getDetails()
        {
            return base.getDetails() + $"Chassis Number: {ChassisNumber}\nPlate: {Plate}\nBrand: {Brand}\nModel: {Model}\nMake: {Make}\nMilage: {Milage}\nEngine: {Engine}\nFuel: {Fuel}\nHorsepower: {HorsePower}ps\nTorque: {Torque}nm\n0-60 Time: {Time0to60}/s\nTop Speed: {TopSpeed}km/h\nWeight: {Weight}kg";
        }
    }
}
