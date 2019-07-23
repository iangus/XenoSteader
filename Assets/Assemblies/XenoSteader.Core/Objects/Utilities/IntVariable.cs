using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Utilities
{
    [CreateAssetMenu]
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
        /// Allows things like
        /// IntVariable.Value = 5;
        /// var result = IntVariable + 5;
        /// result would = 10
        /// Unsure how to make this work the other way..
        public static implicit operator int(IntVariable intVariable) => intVariable.Value;
    }
}
