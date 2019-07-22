namespace Assets.Assemblies.XenoSteader.Core.Objects
{
    public class Item : ThreeDimensionalEntity
    {
        // The line between 3d stuff and items is a bit weird. We might have things that are 3d and items, 
        // But will never go into an inventory. I see this as how rimworld handles some structures
        // 3d objects, but cannot ever be an 'item'
    }
}
