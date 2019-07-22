using System;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects
{
    [Serializable]
    public abstract class ThreeDimensionalEntity : Entity
    {
        public Mesh Model { get; set; }
    }
}
