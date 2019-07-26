using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Utilities
{
    [CreateAssetMenu(menuName = "Utilities/IntVariable")]
    public class IntVariable : ScriptableObject
    {
        public int IntegerValue;
        public int ConstantValue;
        public bool UseConstantValue;

        private int _value => UseConstantValue ? ConstantValue : IntegerValue;

        public int Value
        {
            get => _value;
            set => IntegerValue = value;
        }

        /// <summary>
        /// Magic operator to handle conversion.
        /// </summary>
        /// <param name="intVariable"></param>
        /// This is here to override all the implicit Comparison operators
        /// such as ==
        public static implicit operator int(IntVariable intVariable) => intVariable.Value;


        // Left Bound arguments
        public static int operator +(IntVariable intVariable, int integer) => intVariable.Value + integer;
        public static int operator -(IntVariable intVariable, int integer) => intVariable.Value - integer;
        public static int operator *(IntVariable intVariable, int integer) => intVariable.Value * integer;
        public static int operator /(IntVariable intVariable, int integer) => intVariable.Value / integer;


        // Right bound arguments
        public static int operator +(int integer, IntVariable intVariable) => integer + intVariable.Value;
        public static int operator -(int integer, IntVariable intVariable) => integer - intVariable.Value;
        public static int operator *(int integer, IntVariable intVariable) => integer * intVariable.Value;
        public static int operator /(int integer, IntVariable intVariable) => integer / intVariable.Value;
    }
}
