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
    internal class AttributeExtensionStructTests
    {
        [Test]
        public void GetAttribute_StructWithAttributeGetAttributeFromTypeof_ResultIsExpectedAttribute()
        {
            Object actual = typeof(TestStructWithAttributes).GetAttribute<TestDummyAttribute>();

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
        }

        [Test]
        public void GetAttribute_StructWithoutAttributeGetAttributeFromTypeof_ResultIsNull()
        {
            Object actual = typeof(TestStructWithoutAttributes).GetAttribute<TestDummyAttribute>();

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void GetAttribute_StructWithAttributeGetAttributeFromInstance_ResultIsExpectedAttribute()
        {
            TestStructWithAttributes instance = new TestStructWithAttributes();

            Object actual = instance.GetAttribute<TestStructWithAttributes, TestDummyAttribute>();

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
        }

        [Test]
        public void GetAttribute_StructWithoutAttributeGetAttributeFromInstance_ResultIsNull()
        {
            TestStructWithoutAttributes instance = new TestStructWithoutAttributes();

            Object actual = instance.GetAttribute<TestStructWithoutAttributes, TestDummyAttribute>();

            Assert.That(actual, Is.Null);
        }

        [TestCase(PublicPropertyName)]
        [TestCase(PrivateFieldName)]
        [TestCase(PublicStaticName)]
        [TestCase(PublicMethodName)]
        [TestCase(PrivateMethodName)]
        public void GetAttribute_StructWithAttributeGetAttributeFromInstanceMember_ResultIsExpectedAttribute(String name)
        {
            TestStructWithAttributes instance = new TestStructWithAttributes();

            Object actual = instance.GetAttribute<TestStructWithAttributes, TestDummyAttribute>(name);

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
            Assert.That(((TestDummyAttribute)actual).Name, Is.EqualTo(name));
        }

        [TestCase(PublicPropertyName)]
        [TestCase(PrivateFieldName)]
        [TestCase(PublicStaticName)]
        [TestCase(PublicMethodName)]
        [TestCase(PrivateMethodName)]
        public void GetAttribute_StructWithAttributeGetAttributeFromInstanceMemberLowerCase_ResultIsExpectedAttribute(String name)
        {
            TestStructWithAttributes instance = new TestStructWithAttributes();

            Object actual = instance.GetAttribute<TestStructWithAttributes, TestDummyAttribute>(name.ToLower());

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
            Assert.That(((TestDummyAttribute)actual).Name, Is.EqualTo(name));
        }

        [TestCase(PublicPropertyName)]
        [TestCase(PrivateFieldName)]
        [TestCase(PublicStaticName)]
        [TestCase(PublicMethodName)]
        [TestCase(PrivateMethodName)]
        public void GetAttribute_StructWithoutAttributeGetAttributeFromInstanceMember_ResultIsNull(String name)
        {
            TestStructWithoutAttributes instance = new TestStructWithoutAttributes();

            Object actual = instance.GetAttribute<TestStructWithoutAttributes, TestDummyAttribute>(name);

            Assert.That(actual, Is.Null);
        }

        #region Private Helpers

        private const String PublicPropertyName = "PublicProperty";
        private const String PrivateFieldName = "PrivateField";
        private const String PublicStaticName = "PublicStatic";
        private const String PublicMethodName = "PublicMethod";
        private const String PrivateMethodName = "PrivateMethod";

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
        private struct TestStructWithAttributes
        {
            public TestStructWithAttributes(String privateField = "")
                : this()
            {
                // Just to suppress warnings etc.
                this.PrivateField = privateField;
                var dummy = this.PrivateField;
                this.PrivateMethod();
            }

            [TestDummy(PublicPropertyName)]
            public String PublicProperty { get; set; }

            [TestDummy(PrivateFieldName)]
            private readonly String PrivateField;

            [TestDummy(PublicStaticName)]
            public static String PublicStatic = "";

            [TestDummy(PublicMethodName)]
            public void PublicMethod() { }

            [TestDummy(PrivateMethodName)]
            private void PrivateMethod() { }
        }

        private struct TestStructWithoutAttributes
        {
            public TestStructWithoutAttributes(String privateField = "")
                : this()
            {
                // Just to suppress warnings etc.
                this.PrivateField = privateField;
                var dummy = this.PrivateField;
                this.PrivateMethod();
            }

            public String PublicProperty { get; set; }

            private readonly String PrivateField;

            public static String PublicStatic = "";

            public void PublicMethod() { }

            private void PrivateMethod() { }
        }

        #endregion
    }
}
