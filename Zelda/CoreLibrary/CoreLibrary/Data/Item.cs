
namespace CoreLibrary.Data; 

public record ItemData(string ItemName, int MaxAmmo, int MagicCosts, string SFXAsset); 

public static class Item
{
    public static readonly ItemData HookShot = new ItemData("Hookshot", MaxAmmo : 0, MagicCosts: 0, SFXAsset : "X" ); 
}