using System.Reflection;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Mod;
using Range = SemanticVersioning.Range;

namespace _VanillaCraftAmmo;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.CarbonBased.VanillaCraftAmmo";
    public override string Name { get; init; } = "VanillaCraftAmmo";
    public override string Author { get; init; } = "CarbonBased";
    public override SemanticVersioning.Version Version { get; init; } = new("1.0.3");
    public override Range SptVersion { get; init; } = new("~4.0.1");
    public override string License { get; init; } = "MIT";
    public override bool? IsBundleMod { get; init; } = true;
    public override Dictionary<string, Range>? ModDependencies { get; init; } = new()
    {
        { "com.wtt.commonlib", new Range("~2.0.0") }
    };
    public override string? Url { get; init; }
    public override List<string>? Contributors { get; init; }
    public override List<string>? Incompatibilities { get; init; }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 2)]
public class VanillaAmmoCrafts(
    WTTServerCommonLib.WTTServerCommonLib wttCommon
) : IOnLoad
{
    public async Task OnLoad()
    {

        // Get your current assembly
        var assembly = Assembly.GetExecutingAssembly();




        // Use WTT-CommonLib services
        await wttCommon.CustomHideoutRecipeService.CreateHideoutRecipes(assembly);
       
        
        await Task.CompletedTask;
    }
}