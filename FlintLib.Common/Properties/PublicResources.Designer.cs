﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlintLib.Common.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class PublicResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PublicResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FlintLib.Common.Properties.PublicResources", typeof(PublicResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter must be of type {0} and not type {1}.
        /// </summary>
        public static string fMessage_ParameterIsNotAValidType {
            get {
                return ResourceManager.GetString("fMessage_ParameterIsNotAValidType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value {0} is unhandled..
        /// </summary>
        public static string fMessage_UnhandledEnumValue {
            get {
                return ResourceManager.GetString("fMessage_UnhandledEnumValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must be between {0} and {1}..
        /// </summary>
        public static string fMessage_ValueMustBeBetween {
            get {
                return ResourceManager.GetString("fMessage_ValueMustBeBetween", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to yyyy-MM-dd.
        /// </summary>
        public static string Format_DateTime_YearFirst {
            get {
                return ResourceManager.GetString("Format_DateTime_YearFirst", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This string is empty..
        /// </summary>
        public static string Message_StringIsEmpty {
            get {
                return ResourceManager.GetString("Message_StringIsEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This string is white space..
        /// </summary>
        public static string Message_StringIsWhiteSpace {
            get {
                return ResourceManager.GetString("Message_StringIsWhiteSpace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unhandled Enum Value: .
        /// </summary>
        public static string Message_UnhandledEnumValue {
            get {
                return ResourceManager.GetString("Message_UnhandledEnumValue", resourceCulture);
            }
        }
    }
}
