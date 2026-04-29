using System;
using Warudo.Core.Localization;

namespace Warudo.Core.Data {

    [Serializable]
    public class DataInputProperties : PortProperties {
        public bool transient;
        public object typeProperties;
        public override void Localize() {
            base.Localize();
            ((IDataInputTypeProperties) typeProperties)?.Localize();
        }
        public DataInputProperties Clone() {
            var ret = new DataInputProperties();
            CopyTo(ret);
            ret.transient = transient;
            ret.typeProperties = ((IDataInputTypeProperties) typeProperties)?.Clone();
            return ret;
        }
    }

    public interface IDataInputTypeProperties : ILocalizable {
        public IDataInputTypeProperties Clone();
    }
    
    [Serializable]
    public class IntegerDataInputTypeProperties : IDataInputTypeProperties {
        public int? min;
        public int? max;
        public int step = 1;
        public void Localize() {
        }
        public IDataInputTypeProperties Clone() {
            return new IntegerDataInputTypeProperties {
                min = min,
                max = max,
                step = step
            };
        }
    }
    
    [Serializable]
    public class FloatDataInputTypeProperties : IDataInputTypeProperties {
        public float? min;
        public float? max;
        public float step = 0.1f;
        public void Localize() {
        }
        public IDataInputTypeProperties Clone() {
            return new FloatDataInputTypeProperties {
                min = min,
                max = max,
                step = step
            };
        }
    }
    
    [Serializable]
    public class StringDataInputTypeProperties : IDataInputTypeProperties {
        public bool markdown;
        public bool markdownPrimary;

        public bool multiline;
        public bool autoComplete;
        public Guid autoCompleteId;
        public bool forceSelection;
        public string defaultLabel;
        public bool previewGallery;
        public void Localize() {
            defaultLabel = defaultLabel.Localized();
        }
        public IDataInputTypeProperties Clone() {
            return new StringDataInputTypeProperties {
                markdown = markdown,
                markdownPrimary = markdownPrimary,
                multiline = multiline,
                autoComplete = autoComplete,
                autoCompleteId = autoCompleteId,
                forceSelection = forceSelection,
                defaultLabel = defaultLabel,
                previewGallery = previewGallery
            };
        }
    }
    
    [Serializable]
    public class StructuredDataInputTypeProperties : IDataInputTypeProperties {
        public void Localize() {
        }
        public IDataInputTypeProperties Clone() {
            return new StructuredDataInputTypeProperties();
        }
    }
    
    [Serializable]
    public class ColorDataInputTypeProperties : IDataInputTypeProperties {
        public bool hdr;
        public void Localize() {
        }
        public IDataInputTypeProperties Clone() {
            return new ColorDataInputTypeProperties {
                hdr = hdr
            };
        }
    }
    
    [Serializable]
    public class EnumDataInputTypeProperties : IDataInputTypeProperties {
        public bool cardSelect;
        public void Localize() {
        }
        public IDataInputTypeProperties Clone() {
            return new EnumDataInputTypeProperties {
                cardSelect = cardSelect
            };
        }
    }
}