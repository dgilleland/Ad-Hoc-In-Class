using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame
{
    public class Die
    {
        #region Properties and Fields - What a Die object "looks like"
        // This is a private field, made static
        // This field will be shared by all Die instances (objects)
        private static Random _rnd = new Random();

        // This is an auto-implemented property
        public int FaceValue { get; private set; }

        // A private field with a public explicitly implemented property
        private int _sides;
        public int Sides
        {
            get { return _sides; }
            private set
            {
                // The setter is a good place to ensure only valid values
                // are assigned to the _sides field.
                if (value != 6 && value != 12)
                    throw new Exception("Invalid number of sides - only 6 and 12 are allowed");
                _sides = value;
            }
        }
        #endregion

        #region Constructors and Methods - How a Die object "behaves"
        // A parameterless constructor
        public Die()
        {
            Sides = 6;
            Roll();
        }

        // An overload of the constructor, one that takes in the number of sides for the die.
        public Die(int numberOfSides)
        {
            Sides = numberOfSides;
            Roll();
        }

        public void Roll()
        {
            // .Next(inclusive lowest range value, exclusive highest range value)
            FaceValue = _rnd.Next(1, Sides + 1);
        }
        #endregion
    }
}
