using UnityEngine;
using System;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace RootMotion
{
    public enum ShowIfMode
    {
        Disabled = 0,
        Hidden = 1
    }

    public class ShowIfAttribute : PropertyAttribute
    {
        public string propName { get; protected set; }

        public object propValue { get; protected set; }

        public object otherPropValue { get; protected set; }

        public bool indent { get; private set; }

        public ShowIfMode mode { get; protected set; }

        public ShowIfAttribute(string propertyName, object propertyValue = null, object otherPropertyValue = null, bool indent = false, ShowIfMode mode = ShowIfMode.Hidden)
        {
            throw new NotImplementedException();
        }
    }

    public class ShowRangeIfAttribute : ShowIfAttribute
    {
        public float min { get; private set; }

        public float max { get; private set; }

        public ShowRangeIfAttribute(float min, float max, string propertyName, object propertyValue = null, object otherPropertyValue = null, bool indent = false, ShowIfMode mode = ShowIfMode.Hidden) : base(propertyName, propertyValue, otherPropertyValue, indent, mode)
        {
            throw new NotImplementedException();
        }
    }

    public class ShowLargeHeaderIf : ShowIfAttribute
    {
        public string name;
        public string color = "white";
        public ShowLargeHeaderIf(string name, string propertyName, object propertyValue = null, object otherPropertyValue = null, bool indent = false, ShowIfMode mode = ShowIfMode.Hidden) : base(propertyName, propertyValue, otherPropertyValue, indent, mode)
        {
            throw new NotImplementedException();
        }

        public ShowLargeHeaderIf(string name, string color, string propertyName, object propertyValue = null, object otherPropertyValue = null, bool indent = false, ShowIfMode mode = ShowIfMode.Hidden) : base(propertyName, propertyValue, otherPropertyValue, indent, mode)
        {
            throw new NotImplementedException();
        }
    }

    public class LargeHeader : PropertyAttribute
    {
        public string name;
        public string color = "white";
        public LargeHeader(string name)
        {
            throw new NotImplementedException();
        }

        public LargeHeader(string name, string color)
        {
            throw new NotImplementedException();
        }
    }
}