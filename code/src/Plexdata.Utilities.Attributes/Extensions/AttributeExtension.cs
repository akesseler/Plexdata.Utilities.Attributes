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
using System.Linq;
using System.Reflection;

namespace Plexdata.Utilities.Attributes.Extensions
{
    /// <summary>
    /// This class provides extension methods that allow to get instances 
    /// of <see cref="Attribute"/> derived classes from types, instances 
    /// and instance members.
    /// </summary>
    /// <remarks>
    /// The generic methods of this extension class allow to obtain any 
    /// kind of attributes.
    /// </remarks>
    public static class AttributeExtension
    {
        #region Public Methods

        /// <summary>
        /// Tries to get an attribute from provided type.
        /// </summary>
        /// <remarks>
        /// This method tries to get an attribute from provided type.
        /// </remarks>
        /// <typeparam name="TResult">
        /// The generic result type descriptor.
        /// </typeparam>
        /// <param name="source">
        /// The type to get an attribute from.
        /// </param>
        /// <returns>
        /// An instance of an <see cref="Attribute"/> derived class or <c>null</c> 
        /// if requested attribute could not be found.
        /// </returns>
        public static TResult GetAttribute<TResult>(this Type source) where TResult : Attribute
        {
            return source?.GetCustomAttributes(typeof(TResult), false).FirstOrDefault() as TResult ?? default;
        }

        /// <summary>
        /// Tries to get an attribute from provided instances.
        /// </summary>
        /// <remarks>
        /// This method tries to get an attribute from provided instances.
        /// </remarks>
        /// <typeparam name="TSource">
        /// The generic source type descriptor.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The generic result type descriptor.
        /// </typeparam>
        /// <param name="source">
        /// The instances to get an attribute from.
        /// </param>
        /// <returns>
        /// An instance of an <see cref="Attribute"/> derived class or <c>null</c> 
        /// if requested attribute could not be found.
        /// </returns>
        public static TResult GetAttribute<TSource, TResult>(this TSource source) where TResult : Attribute
        {
            Type type = (source is Type) ? (source as Type) : source?.GetType() ?? typeof(TSource);

            // Check for class, struct and enum types (fall through in case of an enum type).
            if (type.IsClass || (type.IsValueType && !type.IsEnum))
            {
                return type.GetAttribute<TResult>();
            }

            return source.GetAttribute<TSource, TResult>(source?.ToString());
        }

        /// <summary>
        /// Tries to get an attribute for a particular instance member.
        /// </summary>
        /// <remarks>
        /// This method tries to get an attribute for a particular instance member.
        /// </remarks>
        /// <typeparam name="TSource">
        /// The generic source type descriptor.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The generic result type descriptor.
        /// </typeparam>
        /// <param name="source">
        /// The instances to get an attribute from.
        /// </param>
        /// <param name="member">
        /// The name of the requested instance member.
        /// </param>
        /// <returns>
        /// An instance of an <see cref="Attribute"/> derived class or <c>null</c> 
        /// if requested attribute could not be found.
        /// </returns>
        public static TResult GetAttribute<TSource, TResult>(this TSource source, String member) where TResult : Attribute
        {
            if (String.IsNullOrWhiteSpace(member))
            {
                return default;
            }

            Type type = (source is Type) ? (source as Type) : source?.GetType() ?? typeof(TSource);

            BindingFlags flags = BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            MemberInfo info = type.GetMember(member, flags).FirstOrDefault();

            if (info != null)
            {
                return info.GetCustomAttributes(typeof(TResult), false).FirstOrDefault() as TResult;
            }

            return default;
        }

        #endregion
    }
}
