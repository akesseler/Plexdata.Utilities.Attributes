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

namespace Plexdata.Utilities.Attributes.Extensions
{
    /// <summary>
    /// This class provides extension methods that allow to get instances of 
    /// <see cref="AnnotationAttribute"/> from types, instances and instance 
    /// members.
    /// </summary>
    /// <remarks>
    /// Annotation attributes might be put on classes, on structs or on enumeration 
    /// types.This extension class allows to obtain such attributes from those types.
    /// </remarks>
    /// <example>
    /// <para>
    /// In this example a class named <c>MyClass</c> is assumed that is tagged with 
    /// Annotation attributes, one on the class and one on each member. The following 
    /// code snippet show how to get Annotation attributes from that class.
    /// </para>
    /// <code>
    /// MyClass myClass = new MyClass();
    /// 
    /// // Get Annotation attribute from class.
    /// var attrib1 = myClass.GetAnnotation&lt;MyClass&gt;();
    /// 
    /// // Get Annotation attribute from public property.
    /// var attrib2 = myClass.GetAnnotation&lt;MyClass&gt;(nameof(MyClass.MyString));
    ///             
    /// // Get Annotation attribute from private field.
    /// var attrib3 = myClass.GetAnnotation&lt;MyClass&gt;("MyField");
    ///             
    /// // Get Annotation attribute from private protected constant.
    /// var attrib4 = myClass.GetAnnotation&lt;MyClass&gt;("MyConst");
    ///             
    /// // Get Annotation attribute from public static field.
    /// var attrib5 = myClass.GetAnnotation&lt;MyClass&gt;(nameof(MyClass.MyStatic));
    /// </code>
    /// <para>
    /// In this example a struct named <c>MyStruct</c> is assumed that is tagged with 
    /// Annotation attributes, one on the struct and one on each member. The following 
    /// code snippet show how to get Annotation attributes from that struct.
    /// </para>
    /// <code>
    /// MyStruct myStruct = new MyStruct();
    /// 
    /// // Get Annotation attribute from struct.
    /// var attrib1 = myStruct.GetAnnotation&lt;MyStruct&gt;();
    /// 
    /// // Get Annotation attribute from public property.
    /// var attrib2 = myStruct.GetAnnotation&lt;MyStruct&gt;(nameof(MyStruct.MyString));
    /// 
    /// // Get Annotation attribute from private field.
    /// var attrib3 = myStruct.GetAnnotation&lt;MyStruct&gt;("MyField");
    /// 
    /// // Get Annotation attribute from public static field.
    /// var attrib4 = myStruct.GetAnnotation&lt;MyStruct&gt;(nameof(MyStruct.MyStatic));
    /// </code>
    /// <para>
    /// In contrast to <c>class</c> and <c>struct</c>, Annotation attributes on enumeration 
    /// types work a bit different. See next code snippet how to get Annotation attributes 
    /// from <c>enum</c> types.
    /// </para>
    /// <code>
    /// MyEnum myEnum = default;
    /// 
    /// // Get Annotation attribute from enum (the only way).
    /// var attrib1 = typeof(MyEnum).GetAnnotation()
    /// 
    /// // Get Annotation attribute from enum by value.
    /// var attrib2 = myEnum.GetAnnotation&lt;MyEnum&gt;();
    /// 
    /// // Get Annotation attribute from an enum value by nameof operator.
    /// var attrib3 = myEnum.GetAnnotation&lt;MyEnum&gt;(nameof(MyEnum.Value1));
    /// 
    /// // Get Annotation attribute from an enum value by explicit value name.
    /// var attrib4 = myEnum.GetAnnotation&lt;MyEnum&gt;("Value2");
    /// </code>
    /// <para>
    /// As shown above, getting Annotation attributes from enumeration types seems to be a bit 
    /// inflexible. But against the background that enumeration values are usually used in combo 
    /// boxes, it is recommended to read all Annotation attributes in a loop. Next example will 
    /// demonstrate how to obtain all Annotation attributes from an enumeration type.
    /// </para>
    /// <code>
    /// List&lt;AnnotationAttribute&gt; annotations = new List&lt;AnnotationAttribute&gt;();
    /// 
    /// foreach (String current in Enum.GetNames(typeof(MyEnum)))
    /// {
    ///     var attrib = typeof(MyEnum).GetAnnotation(current);
    /// 
    ///     if (attrib != null &amp;&amp; attrib.Visible)
    ///     {
    ///         annotations.Add(attrib);
    ///     }
    /// }
    /// </code>
    /// <para>
    /// In contrast to the above solution, collecting all Annotation attributes for an enumeration 
    /// can be done by stepping through all of the values. Example below shows how to iterate 
    /// through all enumeration values.
    /// </para>
    /// <code>
    /// List&lt;AnnotationAttribute&gt; annotations = new List&lt;AnnotationAttribute&gt;();
    /// 
    /// foreach (MyEnum current in Enum.GetValues(typeof(MyEnum)))
    /// {
    ///     var attrib = current.GetAnnotation();
    /// 
    ///     if (attrib != null &amp;&amp; attrib.Visible)
    ///     {
    ///         annotations.Add(attrib);
    ///     }
    /// }
    /// </code>
    /// </example>
    public static class AnnotationExtension
    {
        #region Public Methods

        /// <summary>
        /// Convenient method to get annotation attributes from types.
        /// </summary>
        /// <remarks>
        /// This is just a convenient method to get annotation attributes from types.
        /// </remarks>
        /// <param name="source">
        /// The type to get an annotation attribute from.
        /// </param>
        /// <returns>
        /// An instance of <see cref="AnnotationAttribute"/> or <c>null</c> if an annotation 
        /// attribute could not be found.
        /// </returns>
        /// <seealso cref="AttributeExtension.GetAttribute{TResult}(Type)"/>
        public static AnnotationAttribute GetAnnotation(this Type source)
        {
            return source.GetAttribute<AnnotationAttribute>();
        }

        /// <summary>
        /// Convenient method to get annotation attributes from instances.
        /// </summary>
        /// <remarks>
        /// This is just a convenient method to get annotation attributes from instances.
        /// </remarks>
        /// <typeparam name="TSource">
        /// The generic type descriptor.
        /// </typeparam>
        /// <param name="source">
        /// An instance of a particular type.
        /// </param>
        /// <returns>
        /// An instance of <see cref="AnnotationAttribute"/> or <c>null</c> if an annotation 
        /// attribute could not be found.
        /// </returns>
        /// <seealso cref="AttributeExtension.GetAttribute{TSource, TResult}(TSource)"/>
        public static AnnotationAttribute GetAnnotation<TSource>(this TSource source)
        {
            return source.GetAttribute<TSource, AnnotationAttribute>();
        }

        /// <summary>
        /// Convenient method to get annotation attributes for a particular instance member.
        /// </summary>
        /// <remarks>
        /// This is just a convenient method to get annotation attributes for a particular 
        /// instance member.
        /// </remarks>
        /// <typeparam name="TSource">
        /// The generic type descriptor.
        /// </typeparam>
        /// <param name="source">
        /// An instance of a particular type.
        /// </param>
        /// <param name="member">
        /// The name of the requested instance member.
        /// </param>
        /// <returns>
        /// An instance of <see cref="AnnotationAttribute"/> or <c>null</c> if an annotation 
        /// attribute could not be found.
        /// </returns>
        /// <seealso cref="AttributeExtension.GetAttribute{TSource, TResult}(TSource, String)"/>
        public static AnnotationAttribute GetAnnotation<TSource>(this TSource source, String member)
        {
            return source.GetAttribute<TSource, AnnotationAttribute>(member);
        }

        #endregion
    }
}
