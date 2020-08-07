/*
 * MIT License
 * 
 * Copyright (c) 2020 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Diagnostics;

namespace Plexdata.Utilities.Attributes
{
    /// <summary>
    /// An attribute to annotate classes, structs and enumerations.
    /// </summary>
    /// <remarks>
    /// This class represents an attribute to be used to extend classes, 
    /// structs and enumerations by annotations. For example such annotations 
    /// could be useful to show them in user interfaces. 
    /// </remarks>
    /// <example>
    /// <para>
    /// The first example shows how to use the Annotation attribute together with 
    /// a public <c>class</c>. It should be noted, an annotation is possible on 
    /// each visibility level.
    /// </para>
    /// <code>
    /// [Annotation("my-class", "my-class-remarks")]
    /// public class MyClass
    /// {
    ///     [Annotation("my-string", "my-string-remarks")]
    ///     public string MyString { get; set; }
    /// 
    ///     [Annotation("my-field", "my-field-remarks")]
    ///     private string MyField;
    /// 
    ///     [Annotation("my-const", "my-const-remarks")]
    ///     protected const string MyConst = "my-const";
    /// 
    ///     [Annotation("my-static", "my-static-remarks")]
    ///     public static string MyStatic = "my-static";
    /// }
    /// </code>
    /// <para>
    /// The next example shows how to use the Annotation attribute together with 
    /// a private <c>struct</c>. It should be noted, the usage of the Annotation 
    /// attribute is pretty much the same as for classes.
    /// </para>
    /// <code>
    /// [Annotation("my-struct", "my-struct-remarks")]
    /// private struct MyStruct
    /// {
    ///     [Annotation("my-string", "my-string-remarks")]
    ///     public string MyString { get; set; }
    /// 
    ///     [Annotation("my-field", "my-field-remarks")]
    ///     private string MyField;
    /// 
    ///     [Annotation("my-static", "my-static-remarks")]
    ///     public static string MyStatic = "my-static";
    /// }
    /// </code>
    /// <para>
    /// In the following example is shown how to use the Annotation attribute together 
    /// with a private <c>enum</c>. Additionally, it is demonstrated the usage of the 
    /// property <see cref="AnnotationAttribute.Utilize"/>.
    /// </para>
    /// <code>
    /// [Annotation("my-enum", "my-enum-remarks")]
    /// private enum MyEnum
    /// {
    ///     [Annotation("my-value-1", "my-value-1-remarks", MyEnum.Value1)]
    ///     Value1,
    ///     
    ///     [Annotation("my-value-2", "my-value-2-remarks", MyEnum.Value2)]
    ///     Value2,
    ///     
    ///     [Annotation("my-value-3", "my-value-3-remarks", MyEnum.Value3)]
    ///     Value3
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    [DebuggerDisplay("Display: {this.Display}, Visible: {this.Visible}, Utilize: {this.Utilize}, Remarks: {this.Remarks}")]
    public class AnnotationAttribute : Attribute
    {
        #region Construction

        /// <summary>
        /// Default construction.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This constructor initializes all attribute properties by their default values.
        /// </para>
        /// <para>
        /// Using this constructor may require to set at least property <see cref="AnnotationAttribute.Display"/>.
        /// </para>
        /// <para>
        /// Property <see cref="AnnotationAttribute.Visible"/> is set to 
        /// <c>false</c>.
        /// </para>
        /// </remarks>
        /// <seealso cref="AnnotationAttribute(String, String, Object, Boolean)"/>
        public AnnotationAttribute()
            : this(null, null, null, false)
        {
        }

        /// <summary>
        /// Construction with display text.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This constructor initializes property <see cref="AnnotationAttribute.Display"/> with provided display 
        /// text. All other properties are initialized by their default values.
        /// </para>
        /// <para>
        /// Property <see cref="AnnotationAttribute.Visible"/> is set to <c>true</c>.
        /// </para>
        /// </remarks>
        /// <param name="display">
        /// The value of property <see cref="AnnotationAttribute.Display"/>.
        /// </param>
        /// <seealso cref="AnnotationAttribute(String, String, Object, Boolean)"/>
        public AnnotationAttribute(String display)
            : this(display, null, null, true)
        {
        }

        /// <summary>
        /// Construction with display text and remarks.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This constructor initializes property <see cref="AnnotationAttribute.Display"/> as well as property 
        /// <see cref="AnnotationAttribute.Remarks"/> with provided values. All other properties are initialized 
        /// by their default values.
        /// </para>
        /// <para>
        /// Property <see cref="AnnotationAttribute.Visible"/> is set to <c>true</c>.
        /// </para>
        /// </remarks>
        /// <param name="display">
        /// The value of property <see cref="AnnotationAttribute.Display"/>.
        /// </param>
        /// <param name="remarks">
        /// The value of property <see cref="AnnotationAttribute.Remarks"/>.
        /// </param>
        /// <seealso cref="AnnotationAttribute(String, String, Object, Boolean)"/>
        public AnnotationAttribute(String display, String remarks)
            : this(display, remarks, null, true)
        {
        }

        /// <summary>
        /// Construction with display text and utilize value.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This constructor initializes property <see cref="AnnotationAttribute.Display"/> as well as property 
        /// <see cref="AnnotationAttribute.Utilize"/> with provided values. All other properties are initialized 
        /// by their default values.
        /// </para>
        /// <para>
        /// Property <see cref="AnnotationAttribute.Visible"/> is set to <c>true</c>.
        /// </para>
        /// </remarks>
        /// <param name="display">
        /// The value of property <see cref="AnnotationAttribute.Display"/>.
        /// </param>
        /// <param name="utilize">
        /// The value of property <see cref="AnnotationAttribute.Utilize"/>.
        /// </param>
        /// <seealso cref="AnnotationAttribute(String, String, Object, Boolean)"/>
        public AnnotationAttribute(String display, Object utilize)
            : this(display, null, utilize, true)
        {
        }

        /// <summary>
        /// Construction with display text and visible value.
        /// </summary>
        /// <remarks>
        /// This constructor initializes property <see cref="AnnotationAttribute.Display"/> as well as property 
        /// <see cref="AnnotationAttribute.Visible"/> with provided values. All other properties are initialized 
        /// by their default values.
        /// </remarks>
        /// <param name="display">
        /// The value of property <see cref="AnnotationAttribute.Display"/>.
        /// </param>
        /// <param name="visible">
        /// The value of property <see cref="AnnotationAttribute.Visible"/>.
        /// </param>
        /// <seealso cref="AnnotationAttribute(String, String, Object, Boolean)"/>
        public AnnotationAttribute(String display, Boolean visible)
            : this(display, null, null, visible)
        {
        }

        /// <summary>
        /// Construction with display text, remarks and utilize value.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This constructor initializes property <see cref="AnnotationAttribute.Display"/>, property <see cref="AnnotationAttribute.Remarks"/> 
        /// as well as property <see cref="AnnotationAttribute.Utilize"/> with provided values. All other properties are initialized by their 
        /// default values.
        /// </para>
        /// <para>
        /// Property <see cref="AnnotationAttribute.Visible"/> is set to <c>true</c>.
        /// </para>
        /// </remarks>
        /// <param name="display">
        /// The value of property <see cref="AnnotationAttribute.Display"/>.
        /// </param>
        /// <param name="remarks">
        /// The value of property <see cref="AnnotationAttribute.Remarks"/>.
        /// </param>
        /// <param name="utilize">
        /// The value of property <see cref="AnnotationAttribute.Utilize"/>.
        /// </param>
        /// <seealso cref="AnnotationAttribute(String, String, Object, Boolean)"/>
        public AnnotationAttribute(String display, String remarks, Object utilize)
            : this(display, remarks, utilize, true)
        {
        }

        /// <summary>
        /// Construction with display text, remarks and visible value.
        /// </summary>
        /// <remarks>
        /// This constructor initializes property <see cref="AnnotationAttribute.Display"/>, property <see cref="AnnotationAttribute.Remarks"/> 
        /// as well as property <see cref="AnnotationAttribute.Visible"/> with provided values. All other properties are initialized by their 
        /// default values.
        /// </remarks>
        /// <param name="display">
        /// The value of property <see cref="AnnotationAttribute.Display"/>.
        /// </param>
        /// <param name="remarks">
        /// The value of property <see cref="AnnotationAttribute.Remarks"/>.
        /// </param>
        /// <param name="visible">
        /// The value of property <see cref="AnnotationAttribute.Visible"/>.
        /// </param>
        /// <seealso cref="AnnotationAttribute(String, String, Object, Boolean)"/>
        public AnnotationAttribute(String display, String remarks, Boolean visible)
            : this(display, remarks, null, visible)
        {
        }

        /// <summary>
        /// Construction with display text and remarks as well as utilize and visible value.
        /// </summary>
        /// <remarks>
        /// This constructor initializes property <see cref="AnnotationAttribute.Display"/>, property <see cref="AnnotationAttribute.Remarks"/>,
        /// property <see cref="AnnotationAttribute.Utilize"/>, as well as property <see cref="AnnotationAttribute.Visible"/> with provided 
        /// values.
        /// </remarks>
        /// <param name="display">
        /// The value of property <see cref="AnnotationAttribute.Display"/>.
        /// </param>
        /// <param name="remarks">
        /// The value of property <see cref="AnnotationAttribute.Remarks"/>.
        /// </param>
        /// <param name="utilize">
        /// The value of property <see cref="AnnotationAttribute.Utilize"/>.
        /// </param>
        /// <param name="visible">
        /// The value of property <see cref="AnnotationAttribute.Visible"/>.
        /// </param>
        public AnnotationAttribute(String display, String remarks, Object utilize, Boolean visible)
            : base()
        {
            this.Display = display ?? String.Empty;
            this.Remarks = remarks ?? String.Empty;
            this.Utilize = utilize;
            this.Visible = visible;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets and sets the text to be displayed.
        /// </summary>
        /// <remarks>
        /// The value of this property might useful for example as text to be shown in a user interface.
        /// </remarks>
        /// <value>
        /// The display text to be used.
        /// </value>
        public String Display { get; set; }

        /// <summary>
        /// Gets and sets additional remarks that could be used for example 
        /// for tooltips.
        /// </summary>
        /// <remarks>
        /// The value of this property might useful for example as source of additional information to be 
        /// shown in a user interface, such as the content of a tooltip.
        /// </remarks>
        /// <value>
        /// The remarks to be used.
        /// </value>
        public String Remarks { get; set; }

        /// <summary>
        /// Gets and sets the value assigned to this attribute. Such a value 
        /// could be useful for example for enumeration types.
        /// </summary>
        /// <remarks>
        /// The value of this property can be any kind of an object that serves for example as default value 
        /// of a property.
        /// </remarks>
        /// <value>
        /// The utilize object to be used.
        /// </value>
        public Object Utilize { get; set; }

        /// <summary>
        /// Gets and sets the visibility state of this attribute.
        /// </summary>
        /// <remarks>
        /// The value of this property might useful to control the visibility of an related item. For example, 
        /// it can be used filter out enumeration values.
        /// </remarks>
        /// <value>
        /// The visibility state to be used.
        /// </value>
        public Boolean Visible { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string representing current attribute instance.
        /// </summary>
        /// <remarks>
        /// This method returns a string that represents the current attribute instance.
        /// </remarks>
        /// <returns>
        /// A string representing current attribute instance.
        /// </returns>
        public override String ToString()
        {
            return $"Display: {this.Display ?? "null"}, Visible: {this.Visible.ToString().ToLowerInvariant()}, Utilize: {this.Utilize?.ToString() ?? "null"}, Remarks: {this.Remarks ?? "null"}";
        }

        #endregion
    }
}
