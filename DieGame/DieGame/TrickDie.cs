using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame
{
    public class TrickDie : Die
    {
        #region Properties and Fields
        private int WeightedFaceValue { get; set; }
        #endregion

        #region Constructors
        public TrickDie() : base()
        {
            WeightedFaceValue = 6; // I want to mostly roll a 6
        }
        public TrickDie(int numberOfSides) 
            : base(numberOfSides)
        {
            WeightedFaceValue = numberOfSides;
        }
        #endregion

        #region Methods
        // I am "hiding" the base class' Roll method and doing my own version
        // With the override keyword, I can change the behaviour of my base class
        public override void Roll()
        {
            base.Roll(); // call the Roll() method of the Die class
            if (FaceValue < WeightedFaceValue - 1)
                FaceValue = WeightedFaceValue;
        }
        #endregion
    }
}
