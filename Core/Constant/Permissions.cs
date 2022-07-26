using System.Collections.Generic;

namespace Core.Constants
{
public static class Permissions
{
    public static List<string> GeneratePermissionsForModule(string module)
    {
        return new List<string>()
        {
            $"Permissions.{module}.Add",
            $"Permissions.{module}.Get",
            $"Permissions.{module}.Update",
            $"Permissions.{module}.Delete",
        };
    }

    public static class Products
    {
        public const string Get = "Permissions.Products.Get";
        public const string Create = "Permissions.Products.Add";
        public const string Update = "Permissions.Products.Update";
        public const string Delete = "Permissions.Products.Delete";
    }
}
}