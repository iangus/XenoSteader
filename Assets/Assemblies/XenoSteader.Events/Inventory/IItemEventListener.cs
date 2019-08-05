using System.Collections;
using System.Collections.Generic;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;

namespace Assets.Assemblies.XenoSteader.Events.Inventory
{
  public interface IItemEventListener
  {
      ItemEvent itemEvent
      {
        get;
        set;
      }

      void OnItemEventRaised(Item item);
  }
}