using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.Model
{
    public class Recipe : Identifiable
    {
        public string title;
        public string description;
        public List<Ingredient> ingredients;
        public string steps;
        public string imageLink;
    }

    public class Ingredient : Identifiable
    {
        public string name;
        public float amount;
        public string unit;

        public override string ToString()
        {
            return name + " " + amount + unit;
        }
    }
}
