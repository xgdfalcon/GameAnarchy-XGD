using ICities;

namespace GameAnarchy.Patches {
    public class ConstructionRefund : EconomyExtensionBase {
        public override int OnGetRefundAmount(int constructionCost, int refundAmount, Service service, SubService subService, Level level) {
            if (GAMod.Refund) return constructionCost;
            return refundAmount;
        }
    }
}
