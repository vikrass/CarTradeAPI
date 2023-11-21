namespace CarTradeAPI
{
    public record Car(
        string CompanyName,
        string CarName,
        string Variant,
        float EngineCapacity,
        string FuelType,
        ushort ManufacturingYear,
        ushort RegistrationYear,
        uint SellerPrice
        )
    {
    }
}