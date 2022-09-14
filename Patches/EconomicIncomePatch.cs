using ICities;

namespace GameAnarchy.Patches {
    public  class EconomicIncomePatch : EconomyExtensionBase {
        public override int OnAddResource(EconomyResource resource, int amount, Service service, SubService subService, Level level) {
            if (service == Service.Residential) {
                int residentialAmount = amount * GAMod.ResidenticalMultiplierFactor;
                return residentialAmount;
            }
            if (service == Service.Industrial) {
                int industrialAmount = amount * GAMod.IndustrialMultiplierFactor;
                return industrialAmount;
            }
            if (service == Service.Commercial) {
                int commercialAmount = amount * GAMod.CommercialMultiplierFactor;
                return commercialAmount;
            }
            if (service == Service.Office) { 
                int officeAmount = amount * GAMod.OfficeMultiplierFactor;
                return officeAmount;
            }
            return amount;
        }
    }
}
