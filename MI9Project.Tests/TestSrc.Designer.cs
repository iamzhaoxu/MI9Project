﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MI9Project.Tests {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TestSrc {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TestSrc() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MI9Project.Tests.TestSrc", typeof(TestSrc).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;error&quot;: &quot;Could not decode request: JSON parsing failed&quot;
        ///}.
        /// </summary>
        internal static string Error {
            get {
                return ResourceManager.GetString("Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;payload&quot;: [
        ///        {
        ///            &quot;country&quot;: &quot;UK&quot;,
        ///            &quot;description&quot;: &quot;What&apos;s life like when you have enough children to field your own football team?&quot;,
        ///            &quot;drm&quot;: true,
        ///            &quot;episodeCount&quot;: 3,
        ///            &quot;genre&quot;: &quot;Reality&quot;,
        ///            &quot;image&quot;: {
        ///                &quot;showImage&quot;: &quot;http://catchup.ninemsn.com.au/img/jump-in/shows/16KidsandCounting1280.jpg&quot;
        ///            },
        ///            &quot;language&quot;: &quot;English&quot;,
        ///            &quot;nextEpisode&quot;: null,
        ///            &quot;primaryColour&quot;: &quot;#f [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string MI9BadRequest {
            get {
                return ResourceManager.GetString("MI9BadRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;response&quot;: [
        ///        {
        ///            &quot;image&quot;: &quot;http://catchup.ninemsn.com.au/img/jump-in/shows/16KidsandCounting1280.jpg&quot;,
        ///            &quot;slug&quot;: &quot;show/16kidsandcounting&quot;,
        ///            &quot;title&quot;: &quot;16 Kids and Counting&quot;
        ///        },
        ///        {
        ///            &quot;image&quot;: &quot;http://catchup.ninemsn.com.au/img/jump-in/shows/TheTaste1280.jpg&quot;,
        ///            &quot;slug&quot;: &quot;show/thetaste&quot;,
        ///            &quot;title&quot;: &quot;The Taste&quot;
        ///        },
        ///        {
        ///            &quot;image&quot;: &quot;http://catchup.ninemsn.com.au/img/jump-in/shows/Thunderbir [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string MI9Reponse {
            get {
                return ResourceManager.GetString("MI9Reponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;payload&quot;: [
        ///        {
        ///            &quot;country&quot;: &quot;UK&quot;,
        ///            &quot;description&quot;: &quot;What&apos;s life like when you have enough children to field your own football team?&quot;,
        ///            &quot;drm&quot;: true,
        ///            &quot;episodeCount&quot;: 3,
        ///            &quot;genre&quot;: &quot;Reality&quot;,
        ///            &quot;image&quot;: {
        ///                &quot;showImage&quot;: &quot;http://catchup.ninemsn.com.au/img/jump-in/shows/16KidsandCounting1280.jpg&quot;
        ///            },
        ///            &quot;language&quot;: &quot;English&quot;,
        ///            &quot;nextEpisode&quot;: null,
        ///            &quot;primaryColour&quot;: &quot;#f [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string MI9Request {
            get {
                return ResourceManager.GetString("MI9Request", resourceCulture);
            }
        }
    }
}