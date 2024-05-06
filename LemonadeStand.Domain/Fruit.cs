﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.Domain
{
    public class Fruit : IFruit
    {
        public string Name { get; }

        public Fruit(string name) 
        {
            Name = name;
        }
    }
}
