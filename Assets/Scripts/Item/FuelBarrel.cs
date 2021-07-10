using UnityEngine;

public class FuelBarrel : ItemAction {
    [Tooltip ("物品恢复燃料量")]
    public float FuelSupplyAmount;
    public override void Action () {
        GameManager.Instance.SupplyFuel(FuelSupplyAmount);
    }
}