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
    internal class AttributeExtensionClassTests
    {
        [Test]
        public void GetAttribute_ClassWithAttributeGetAttributeFromTypeof_ResultIsExpectedAttribute()
        {
            Object actual = typeof(TestClassWithAttributes).GetAttribute<TestDummyAttribute>();

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
        }

        [Test]
        public void GetAttribute_ClassWithoutAttributeGetAttributeFromTypeof_ResultIsNull()
        {
            Object actual = typeof(TestClassWithoutAttributes).GetAttribute<TestDummyAttribute>();

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void GetAttribute_ClassWithAttributeGetAttributeFromInstance_ResultIsExpectedAttribute()
        {
            TestClassWithAttributes instance = new TestClassWithAttributes();

            Object actual = instance.GetAttribute<TestClassWithAttributes, TestDummyAttribute>();

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
        }

        [Test]
        public void GetAttribute_ClassWithoutAttributeGetAttributeFromInstance_ResultIsNull()
        {
            TestClassWithoutAttributes instance = new TestClassWithoutAttributes();

            Object actual = instance.GetAttribute<TestClassWithoutAttributes, TestDummyAttribute>();

            Assert.That(actual, Is.Null);
        }

        [TestCase(PublicPropertyName)]
        [TestCase(PrivateFieldName)]
        [TestCase(ProtectedConstName)]
        [TestCase(PublicStaticName)]
        [TestCase(PublicMethodName)]
        [TestCase(ProtectedMethodName)]
        [TestCase(PrivateMethodName)]
        public void GetAttribute_ClassWithAttributeGetAttributeFromInstanceMember_ResultIsExpectedAttribute(String name)
        {
            TestClassWithAttributes instance = new TestClassWithAttributes();

            Object actual = instance.GetAttribute<TestClassWithAttributes, TestDummyAttribute>(name);

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
            Assert.That(((TestDummyAttribute)actual).Name, Is.EqualTo(name));
        }

        [TestCase(PublicPropertyName)]
        [TestCase(PrivateFieldName)]
        [TestCase(ProtectedConstName)]
        [TestCase(PublicStaticName)]
        [TestCase(PublicMethodName)]
        [TestCase(ProtectedMethodName)]
        [TestCase(PrivateMethodName)]
        public void GetAttribute_ClassWithAttributeGetAttributeFromInstanceMemberLowerCase_ResultIsExpectedAttribute(String name)
        {
            TestClassWithAttributes instance = new TestClassWithAttributes();

            Object actual = instance.GetAttribute<TestClassWithAttributes, TestDummyAttribute>(name.ToLower());

            Assert.That(actual, Is.InstanceOf<TestDummyAttribute>());
            Assert.That(((TestDummyAttribute)actual).Name, Is.EqualTo(name));
        }

        [TestCase(PublicPropertyName)]
        [TestCase(PrivateFieldName)]
        [TestCase(ProtectedConstName)]
        [TestCase(PublicStaticName)]
        [TestCase(PublicMethodName)]
        [TestCase(ProtectedMethodName)]
        [TestCase(PrivateMethodName)]
        public void GetAttribute_ClassWithoutAttributeGetAttributeFromInstanceMember_ResultIsNull(String name)
        {
            TestClassWithoutAttributes instance = new TestClassWithoutAttributes();

            Object actual = instance.GetAttribute<TestClassWithoutAttributes, TestDummyAttribute>(name);

            Assert.That(actual, Is.Null);
        }

        #region Private Helpers

        private const String PublicPropertyName = "PublicProperty";
        private const String PrivateFieldName = "PrivateField";
        private const String ProtectedConstName = "ProtectedConst";
        private const String PublicStaticName = "PublicStatic";
        private const String PublicMethodName = "PublicMethod";
        private const String ProtectedMethodName = "ProtectedMethod";
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
        private class TestClassWithAttributes
        {
            public TestClassWithAttributes()
            {
                // Just to suppress warnings etc.
                var dummy = this.PrivateField;
                this.PrivateMethod();
            }

            [TestDummy(PublicPropertyName)]
            public String PublicProperty { get; set; }

            [TestDummy(PrivateFieldName)]
            private readonly String PrivateField = "";

            [TestDummy(ProtectedConstName)]
            protected const String ProtectedConst = "";

            [TestDummy(PublicStaticName)]
            public static String PublicStatic = "";

            [TestDummy(PublicMethodName)]
            public void PublicMethod() { }

            [TestDummy(ProtectedMethodName)]
            protected void ProtectedMethod() { }

            [TestDummy(PrivateMethodName)]
            private void PrivateMethod() { }
        }

        private class TestClassWithoutAttributes
        {
            public TestClassWithoutAttributes()
            {
                // Just to suppress warnings etc.
                var dummy = this.PrivateField;
                this.PrivateMethod();
            }

            public String PublicProperty { get; set; }

            private readonly String PrivateField = "";

            protected const String ProtectedConst = "";

            public static String PublicStatic = "";

            public void PublicMethod() { }

            protected void ProtectedMethod() { }

            private void PrivateMethod() { }
        }

        #endregion
    }
}
