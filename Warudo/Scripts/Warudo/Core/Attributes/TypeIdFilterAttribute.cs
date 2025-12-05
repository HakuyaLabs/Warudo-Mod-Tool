using System;

namespace Warudo.Core.Attributes
{
    /// <summary>
    /// Filters Asset or Plugin by their TypeId.
    /// When applied to an Asset DataInput, the autocomplete list will only show assets with the specified TypeId.
    /// When applied to a Plugin field with [AutoInject], the plugin will be automatically injected based on the TypeId.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class TypeIdFilterAttribute : Attribute
    {
        /// <summary>
        /// The TypeId to filter by. This should match the Id property in AssetType or PluginType attribute.
        /// </summary>
        public string TypeId { get; }

        public TypeIdFilterAttribute(string typeId)
        {
            TypeId = typeId;
        }
    }
}
