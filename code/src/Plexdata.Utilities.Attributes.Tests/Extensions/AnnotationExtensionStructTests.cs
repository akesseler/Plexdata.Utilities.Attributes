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
    internal class AnnotationExtensionStructTests
    {
        [Test]
        public void GetAnnotation_StructAnnotationFromTypeof_ResultIsAnnotationAttribute()
        {
            AnnotationAttribute actual = typeof(TestStructWtithAnnotation).GetAnnotation();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(TestStructDisplay));
            Assert.That(actual.Remarks, Is.EqualTo(TestStructRemarks));
        }

        [Test]
        public void GetAnnotation_StructAnnotationFromGetType_ResultIsAnnotationAttribute()
        {
            AnnotationAttribute actual = (new TestStructWtithAnnotation()).GetType().GetAnnotation();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(TestStructDisplay));
            Assert.That(actual.Remarks, Is.EqualTo(TestStructRemarks));
        }

        [Test]
        public void GetAnnotation_StructAnnotationFromInstance_ResultIsAnnotationAttribute()
        {
            AnnotationAttribute actual = (new TestStructWtithAnnotation()).GetAnnotation();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(TestStructDisplay));
            Assert.That(actual.Remarks, Is.EqualTo(TestStructRemarks));
        }

        [TestCase(PublicPropertyName, TestStructPublicPropertyDisplay, TestStructPublicPropertyRemarks)]
        [TestCase(PublicStaticName, TestStructPublicStaticDisplay, TestStructPublicStaticRemarks)]
        [TestCase(PrivateFieldName, TestStructPrivateFieldDisplay, TestStructPrivateFieldRemarks)]
        public void GetAnnotation_ChildAnnotationFromTypeof_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = typeof(TestStructWtithAnnotation).GetAnnotation(name);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        [TestCase(PublicPropertyName, TestStructPublicPropertyDisplay, TestStructPublicPropertyRemarks)]
        [TestCase(PublicStaticName, TestStructPublicStaticDisplay, TestStructPublicStaticRemarks)]
        [TestCase(PrivateFieldName, TestStructPrivateFieldDisplay, TestStructPrivateFieldRemarks)]
        public void GetAnnotation_ChildAnnotationFromGetType_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = (new TestStructWtithAnnotation()).GetType().GetAnnotation(name);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        [TestCase(PublicPropertyName, TestStructPublicPropertyDisplay, TestStructPublicPropertyRemarks)]
        [TestCase(PublicStaticName, TestStructPublicStaticDisplay, TestStructPublicStaticRemarks)]
        [TestCase(PrivateFieldName, TestStructPrivateFieldDisplay, TestStructPrivateFieldRemarks)]
        public void GetAnnotation_ChildAnnotationFromInstance_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = (new TestStructWtithAnnotation()).GetAnnotation(name);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        [TestCase(PublicPropertyName, TestStructPublicPropertyDisplay, TestStructPublicPropertyRemarks)]
        [TestCase(PublicStaticName, TestStructPublicStaticDisplay, TestStructPublicStaticRemarks)]
        [TestCase(PrivateFieldName, TestStructPrivateFieldDisplay, TestStructPrivateFieldRemarks)]
        public void GetAnnotation_ChildAnnotationFromInstanceLowerCase_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = (new TestStructWtithAnnotation()).GetAnnotation(name.ToLower());

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        #region Private Helpers

        private const String PublicPropertyName = "PublicProperty";
        private const String PublicStaticName = "PublicStatic";
        private const String PrivateFieldName = "PrivateField";
        private const String TestStructDisplay = "test-class-display";
        private const String TestStructRemarks = "test-class-remarks";
        private const String TestStructPublicPropertyDisplay = "public-property-display";
        private const String TestStructPublicPropertyRemarks = "public-property-remarks";
        private const String TestStructPrivateFieldDisplay = "private-field-display";
        private const String TestStructPrivateFieldRemarks = "private-field-remarks";
        private const String TestStructPublicStaticDisplay = "public-static-display";
        private const String TestStructPublicStaticRemarks = "public-static-remarks";

        [Annotation(TestStructDisplay, TestStructRemarks)]
        private struct TestStructWtithAnnotation
        {
            public TestStructWtithAnnotation(String privateField = "")
                : this()
            {
                // Just to suppress warnings etc.
                this.PrivateField = privateField;
                var dummy = this.PrivateField;
            }

            [Annotation(TestStructPublicPropertyDisplay, TestStructPublicPropertyRemarks)]
            public String PublicProperty { get; set; }

            [Annotation(TestStructPrivateFieldDisplay, TestStructPrivateFieldRemarks)]
            private readonly String PrivateField;

            [Annotation(TestStructPublicStaticDisplay, TestStructPublicStaticRemarks)]
            public static String PublicStatic = "";
        }

        #endregion
    }
}
