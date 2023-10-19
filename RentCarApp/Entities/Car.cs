using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCarApp.Entities
{
    public class Car : EntityBase
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }        
        public override string ToString() => $"Id: {Id}, Brand: {Brand}, Model: {Model}.";
    }
}
