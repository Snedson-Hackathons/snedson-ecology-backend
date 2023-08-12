using System.Text.Json;
using snedson_ecology_backend.core.ExtensionMethods;

namespace snedson_ecology_backend.infrastructure.NamingPolicies
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public static SnakeCaseNamingPolicy Instance { get; } = new SnakeCaseNamingPolicy();

        public override string ConvertName(string name)
        {
            return name.ToSnakeCase();
        }
    }
}
