using System;
using System.Collections.Generic;

using UnityEngine;
using Warudo.Core.Attributes;

namespace Warudo.Core.Utils {
    public class Flags : SingletonMonoBehavior<Flags> {


        public static bool Get(string key, bool defaultValue) {

            return defaultValue;
        }

    }
}
