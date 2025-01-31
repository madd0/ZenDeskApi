﻿#region License
//   Copyright 2010 John Sheehan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion

using System;
using RestSharp.Extensions;

namespace ZenDeskApi.XmlSerializers
{
    /// <summary>
    /// Allows control how class and property names and values are serialized by XmlSerializer
    /// Currently not supported with the JsonSerializer
    /// When specified at the property level the class-level specification is overridden
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ZenDeskSerializationAttribute : Attribute
    {
        public ZenDeskSerializationAttribute() {
            NameStyle = NameStyle.AsIs;
            Index = int.MaxValue;
        }

        /// <summary>
        /// Some ZenDesk objects have alternate names like UserEmailIdentities is sometimes passed back as Records
        /// </summary>
        public string AlternateName { get; set; }

        /// <summary>
        /// Skips the element. Seems ZenDesk throws strange errors if you give them extra fields (even if the values are the same, like setting IsActive to true when it already is).
        /// </summary>
        public bool Skip { get; set; }

        /// <summary>
        /// The name to use for the serialized element
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Used to serialize a List of values ex: List<int> as "<Name><SerializeValueName>value</SerializeValueName></Name>"
        /// </summary>
        public string ListItemName { get; set; }
        
        /// <summary>
        /// Sets the value to be serialized as an Attribute instead of an Element
        /// </summary>
        public bool Attribute { get; set; }

        /// <summary>
        /// Transforms the casing of the name based on the selected value.
        /// </summary>
        public NameStyle NameStyle { get; set; }

        /// <summary>
        /// The order to serialize the element. Default is int.MaxValue.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Called by the attribute when NameStyle is speficied
        /// </summary>
        /// <param name="input">The string to transform</param>
        /// <returns>String</returns>
        public string TransformName(string input) {
            var name = Name ?? input;
            switch (NameStyle) {
                case NameStyle.CamelCase:
                    return name.ToCamelCase();
                case NameStyle.PascalCase:
                    return name.ToPascalCase();
                case NameStyle.LowerCase:
                    return name.ToLower();
            }

            return input;
        }
    }

    /// <summary>
    /// Options for transforming casing of element names
    /// </summary>
    public enum NameStyle
    {
        AsIs,
        CamelCase,
        LowerCase,
        PascalCase
    }
}
