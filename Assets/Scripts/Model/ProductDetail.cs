using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.Model
{
    public class ProductDetail : Product
    {
        public DateTime buyDate; 
        public DateTime expiryDate;
        public double remainingAmount;
        public string unit;
    }
}

