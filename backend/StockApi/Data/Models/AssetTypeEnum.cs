namespace StockApi.Data.Models
{
    public enum AssetTypeEnum
    {
        Share = 0, // Акция
        Bond = 1, // Облигация
        Currency = 2, // Валюта
        Other = 3, // Другое
    }

    public static class AssetTypeExtensions
    {
        public static string GetStringName(this AssetTypeEnum assetType) => assetType switch
        {
            AssetTypeEnum.Share => "Акция",
            AssetTypeEnum.Bond => "Облигация",
            AssetTypeEnum.Currency => "Валюта",
            AssetTypeEnum.Other => "Другое",
            _ => "-"
        };
    }
}
