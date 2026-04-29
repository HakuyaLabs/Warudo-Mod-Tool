using System;
using System.Threading.Tasks;
using EmbedIO;
using EmbedIO.WebApi;
using Newtonsoft.Json;

namespace Warudo.Core.Utils {
    [AttributeUsage(AttributeTargets.Parameter)]
    public class JsonDataAttribute : Attribute, IRequestDataAttribute<WebApiController> {
        public async Task<object> GetRequestDataAsync(WebApiController controller, Type type, string parameterName) {
            string body;
            using (var reader = controller.HttpContext.OpenRequestText()) {
                body = await reader.ReadToEndAsync().ConfigureAwait(false);
            }

            try {
                return JsonConvert.DeserializeObject(body, type);
            } catch (FormatException) {
                throw HttpException.BadRequest($"Expected request body to be deserializable to {type.FullName}.");
            }
        }
    }
}
