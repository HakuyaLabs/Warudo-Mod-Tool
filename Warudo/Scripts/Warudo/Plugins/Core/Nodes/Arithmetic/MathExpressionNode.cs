using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Random = UnityEngine.Random;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class MathExpressionNode : Node
    {
        public string MathExpression = "x + 1";
        public string CompilationError;
        public float OutputFloat()
        {
            throw new NotImplementedException();
        }

        public float Evaluate(Dictionary<string, float> variableValues)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<string> ExtractVariableNames(string formula)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }
    }

    public static class MathFunctions
    {
        public static float Deg(float radians)
        {
            throw new NotImplementedException();
        }

        public static float Rad(float degrees)
        {
            throw new NotImplementedException();
        }

        public static float Rand(float min, float max)
        {
            throw new NotImplementedException();
        }

        public static float RandInt(int min, int max)
        {
            throw new NotImplementedException();
        }
    }

    public class ExpressionParser
    {
        public static readonly Dictionary<string, MethodInfo> Functions = new(StringComparer.OrdinalIgnoreCase)
        {{"deg", typeof(MathFunctions).GetMethod("Deg", BindingFlags.Static | BindingFlags.Public)}, {"rad", typeof(MathFunctions).GetMethod("Rad", BindingFlags.Static | BindingFlags.Public)}, {"sin", typeof(Mathf).GetMethod("Sin", BindingFlags.Static | BindingFlags.Public)}, {"cos", typeof(Mathf).GetMethod("Cos", BindingFlags.Static | BindingFlags.Public)}, {"tan", typeof(Mathf).GetMethod("Tan", BindingFlags.Static | BindingFlags.Public)}, {"asin", typeof(Mathf).GetMethod("Asin", BindingFlags.Static | BindingFlags.Public)}, {"acos", typeof(Mathf).GetMethod("Acos", BindingFlags.Static | BindingFlags.Public)}, {"atan", typeof(Mathf).GetMethod("Atan", BindingFlags.Static | BindingFlags.Public)}, {"atan2", typeof(Mathf).GetMethod("Atan2", BindingFlags.Static | BindingFlags.Public)}, {"noise", typeof(Mathf).GetMethod("PerlinNoise", BindingFlags.Static | BindingFlags.Public)}, {"sqrt", typeof(Mathf).GetMethod("Sqrt", BindingFlags.Static | BindingFlags.Public)}, {"abs", typeof(Mathf).GetMethod("Abs", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float)}, null)}, {"min", typeof(Mathf).GetMethod("Min", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float)}, null)}, {"max", typeof(Mathf).GetMethod("Max", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float)}, null)}, {"pow", typeof(Mathf).GetMethod("Pow", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float)}, null)}, {"exp", typeof(Mathf).GetMethod("Exp", BindingFlags.Static | BindingFlags.Public)}, {"log", typeof(Mathf).GetMethod("Log", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float)}, null)}, {"ln", typeof(Mathf).GetMethod("Log", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float)}, null)}, {"log10", typeof(Mathf).GetMethod("Log10", BindingFlags.Static | BindingFlags.Public)}, {"ceil", typeof(Mathf).GetMethod("Ceil", BindingFlags.Static | BindingFlags.Public)}, {"floor", typeof(Mathf).GetMethod("Floor", BindingFlags.Static | BindingFlags.Public)}, {"round", typeof(Mathf).GetMethod("Round", BindingFlags.Static | BindingFlags.Public)}, {"sign", typeof(Mathf).GetMethod("Sign", BindingFlags.Static | BindingFlags.Public)}, {"clamp", typeof(Mathf).GetMethod("Clamp", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float), typeof(float)}, null)}, {"clamp01", typeof(Mathf).GetMethod("Clamp01", BindingFlags.Static | BindingFlags.Public)}, {"lerp", typeof(Mathf).GetMethod("Lerp", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float), typeof(float)}, null)}, {"ulerp", typeof(Mathf).GetMethod("LerpUnclamped", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float), typeof(float)}, null)}, {"alerp", typeof(Mathf).GetMethod("LerpAngle", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float), typeof(float)}, null)}, {"smoothstep", typeof(Mathf).GetMethod("SmoothStep", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float), typeof(float)}, null)}, {"repeat", typeof(Mathf).GetMethod("Repeat", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float)}, null)}, {"pingpong", typeof(Mathf).GetMethod("PingPong", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float)}, null)}, {"ilerp", typeof(Mathf).GetMethod("InverseLerp", BindingFlags.Static | BindingFlags.Public, null, new[]{typeof(float), typeof(float), typeof(float)}, null)}, {"rand", typeof(MathFunctions).GetMethod("Rand", BindingFlags.Static | BindingFlags.Public)}, {"randint", typeof(MathFunctions).GetMethod("RandInt", BindingFlags.Static | BindingFlags.Public)}};
        public static readonly Dictionary<string, float> Constants = new(StringComparer.OrdinalIgnoreCase)
        {{"pi", Mathf.PI}};
        public ExpressionParser(string formula, Dictionary<string, ParameterExpression> variableMap)
        {
            throw new NotImplementedException();
        }

        public Expression Parse()
        {
            throw new NotImplementedException();
        }
    }
}