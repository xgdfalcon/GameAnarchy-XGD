using ICities;
using ColossalFramework;

namespace GameAnarchy.Patches {
    public class OilAndOreResourcePatch : ResourceExtensionBase {
        public override void OnAfterResourcesModified(int x, int z, NaturalResource type, int amount) {
            if ((type == NaturalResource.Oil || type == NaturalResource.Ore) && amount < 0) {
                if (type == NaturalResource.Oil) {
                    // Vanilla original rate (100%)
                    if (GAMod.OilCapacity == 0) return;
                    if (GAMod.OilCapacity == 100) {
                        // Vanilla original UnlimitedOilAndOre mod
                        resourceManager.SetResource(x, z, type, (byte)(resourceManager.GetResource(x, z, type) - amount), false);
                    } else
                    {
                        // 1% ~ 99%
                        if (Singleton<SimulationManager>.instance.m_randomizer.Int32(100u) <= GAMod.OilCapacity) {
                            resourceManager.SetResource(x, z, type, (byte)(resourceManager.GetResource(x, z, type) - amount), false);
                        }
                    }
                }
                else if (type == NaturalResource.Ore) {
                    // Vanilla original rate (100%)
                    if (GAMod.OreCapacity == 0) return;
                    if (GAMod.OreCapacity == 100) {
                        // Vanilla original UnlimitedOilAndOre mod
                        resourceManager.SetResource(x, z, type, (byte)(resourceManager.GetResource(x, z, type) - amount), false);
                    } else {
                        // 1% ~ 99%
                        if (Singleton<SimulationManager>.instance.m_randomizer.Int32(100u) <= GAMod.OreCapacity) {
                            resourceManager.SetResource(x, z, type, (byte)(resourceManager.GetResource(x, z, type) - amount), false);
                        }
                    }
                }
            }
        }
    }
}
