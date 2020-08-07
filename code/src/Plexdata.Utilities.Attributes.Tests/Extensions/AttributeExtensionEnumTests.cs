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

using NUnit.Framework;
using Plexdata.Utilities.Attributes.Extensions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Attributes.Tests.Extensions
{
    [ExcludeFromCodeCoverage]
    [Category("IntegrationTest")]
    internal class AttributeExtensionEnumTests
    {
        [Test]
        public void GetAttribute_EnumWithAttributeGetAttributeFromTypeof_ResultIsExpectedAttribute()
        {
            Object actual = typeof(TestEnumWithAttributes).GetAttribute<TestDummyAttribute>();

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
        }

        [Test]
        public void GetAttribute_EnumWithoutAttributeGetAttributeFromTypeof_ResultIsNull()
        {
            Object actual = typeof(TestEnumWithoutAttributes).GetAttribute<TestDummyAttribute>();

            Assert.That(actual, Is.Null);
        }

        [TestCase(Value1Name)]
        [TestCase(Value2Name)]
        [TestCase(Value3Name)]
        public void GetAttribute_EnumWithAttributeGetAttributeFromInstancByName_ResultIsExpectedAttribute(String name)
        {
            TestEnumWithAttributes instance = default;

            Object actual = instance.GetAttribute<TestEnumWithAttributes, TestDummyAttribute>(name);

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
            Assert.That(((TestDummyAttribute)actual).Name, Is.EqualTo(name));
        }

        [TestCase(Value1Name)]
        [TestCase(Value2Name)]
        [TestCase(Value3Name)]
        public void GetAttribute_EnumWithAttributeGetAttributeFromInstancByNameLowerCase_ResultIsExpectedAttribute(String name)
        {
            TestEnumWithAttributes instance = default;

            Object actual = instance.GetAttribute<TestEnumWithAttributes, TestDummyAttribute>(name.ToLower());

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
            Assert.That(((TestDummyAttribute)actual).Name, Is.EqualTo(name));
        }

        [TestCase(Value1Name)]
        [TestCase(Value2Name)]
        [TestCase(Value3Name)]
        public void GetAttribute_EnumWithoutAttributeGetAttributeFromInstancByName_ResultIsNull(String name)
        {
            TestEnumWithoutAttributes instance = default;

            Object actual = instance.GetAttribute<TestEnumWithoutAttributes, TestDummyAttribute>(name);

            Assert.That(actual, Is.Null);
        }

        [TestCase(TestEnumWithAttributes.Value1)]
        [TestCase(TestEnumWithAttributes.Value2)]
        [TestCase(TestEnumWithAttributes.Value3)]
        public void GetAttribute_EnumWithAttributeGetAttributeFromInstancByValue_ResultIsExpectedAttribute(Object value)
        {
            Object actual = ((TestEnumWithAttributes)value).GetAttribute<TestEnumWithAttributes, TestDummyAttribute>();

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
            Assert.That(((TestDummyAttribute)actual).Name, Is.EqualTo(value.ToString()));
        }

        [TestCase(TestEnumWithoutAttributes.Value1)]
        [TestCase(TestEnumWithoutAttributes.Value2)]
        [TestCase(TestEnumWithoutAttributes.Value3)]
        public void GetAttribute_EnumWithoutAttributeGetAttributeFromInstancByValue_ResultIsNull(Object value)
        {
            Object actual = ((TestEnumWithoutAttributes)value).GetAttribute<TestEnumWithoutAttributes, TestDummyAttribute>();

            Assert.That(actual, Is.Null);
        }

        #region Private Helpers

        private const String Value1Name = "Value1";
        private const String Value3Name = "Value3";
        private const String Value2Name = "Value2";

        [AttributeUsage(AttributeTargets.All)]
        public class TestDummyAttribute : Attribute
        {
            public TestDummyAttribute() : this(null) { }

            public TestDummyAttribute(String name)
                : base()
            {
                this.Name = name;
            }

            public String Name { get; }
        }

        [TestDummy]
        private enum TestEnumWithAttributes
        {
            [TestDummy(Value1Name)]
            Value1,
            [TestDummy(Value2Name)]
            Value2,
            [TestDummy(Value3Name)]
            Value3
        }

        private enum TestEnumWithoutAttributes
        {
            Value1,
            Value2,
            Value3
        }

        #endregion
    }
}
