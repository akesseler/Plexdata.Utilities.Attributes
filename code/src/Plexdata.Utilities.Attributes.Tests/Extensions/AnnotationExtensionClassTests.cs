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
    internal class AnnotationExtensionClassTests
    {
        [Test]
        public void GetAnnotation_ClassAnnotationFromTypeof_ResultIsAnnotationAttribute()
        {
            AnnotationAttribute actual = typeof(TestClassWtithAnnotation).GetAnnotation();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(TestClassDisplay));
            Assert.That(actual.Remarks, Is.EqualTo(TestClassRemarks));
        }

        [Test]
        public void GetAnnotation_ClassAnnotationFromGetType_ResultIsAnnotationAttribute()
        {
            AnnotationAttribute actual = (new TestClassWtithAnnotation()).GetType().GetAnnotation();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(TestClassDisplay));
            Assert.That(actual.Remarks, Is.EqualTo(TestClassRemarks));
        }

        [Test]
        public void GetAnnotation_ClassAnnotationFromInstance_ResultIsAnnotationAttribute()
        {
            AnnotationAttribute actual = (new TestClassWtithAnnotation()).GetAnnotation();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(TestClassDisplay));
            Assert.That(actual.Remarks, Is.EqualTo(TestClassRemarks));
        }

        [TestCase(PublicPropertyName, TestClassPublicPropertyDisplay, TestClassPublicPropertyRemarks)]
        [TestCase(PublicStaticName, TestClassPublicStaticDisplay, TestClassPublicStaticRemarks)]
        [TestCase(PrivateFieldName, TestClassPrivateFieldDisplay, TestClassPrivateFieldRemarks)]
        [TestCase(ProtectedConstName, TestClassProtectedConstDisplay, TestClassProtectedConstRemarks)]
        public void GetAnnotation_ChildAnnotationFromTypeof_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = typeof(TestClassWtithAnnotation).GetAnnotation(name);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        [TestCase(PublicPropertyName, TestClassPublicPropertyDisplay, TestClassPublicPropertyRemarks)]
        [TestCase(PublicStaticName, TestClassPublicStaticDisplay, TestClassPublicStaticRemarks)]
        [TestCase(PrivateFieldName, TestClassPrivateFieldDisplay, TestClassPrivateFieldRemarks)]
        [TestCase(ProtectedConstName, TestClassProtectedConstDisplay, TestClassProtectedConstRemarks)]
        public void GetAnnotation_ChildAnnotationFromGetType_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = (new TestClassWtithAnnotation()).GetType().GetAnnotation(name);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        [TestCase(PublicPropertyName, TestClassPublicPropertyDisplay, TestClassPublicPropertyRemarks)]
        [TestCase(PublicStaticName, TestClassPublicStaticDisplay, TestClassPublicStaticRemarks)]
        [TestCase(PrivateFieldName, TestClassPrivateFieldDisplay, TestClassPrivateFieldRemarks)]
        [TestCase(ProtectedConstName, TestClassProtectedConstDisplay, TestClassProtectedConstRemarks)]
        public void GetAnnotation_ChildAnnotationFromInstance_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = (new TestClassWtithAnnotation()).GetAnnotation(name);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        [TestCase(PublicPropertyName, TestClassPublicPropertyDisplay, TestClassPublicPropertyRemarks)]
        [TestCase(PublicStaticName, TestClassPublicStaticDisplay, TestClassPublicStaticRemarks)]
        [TestCase(PrivateFieldName, TestClassPrivateFieldDisplay, TestClassPrivateFieldRemarks)]
        [TestCase(ProtectedConstName, TestClassProtectedConstDisplay, TestClassProtectedConstRemarks)]
        public void GetAnnotation_ChildAnnotationFromInstanceLowerCase_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = (new TestClassWtithAnnotation()).GetAnnotation(name.ToLower());

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        #region Private Helpers

        private const String PublicPropertyName = "PublicProperty";
        private const String PublicStaticName = "PublicStatic";
        private const String PrivateFieldName = "PrivateField";
        private const String ProtectedConstName = "ProtectedConst";
        private const String TestClassDisplay = "test-class-display";
        private const String TestClassRemarks = "test-class-remarks";
        private const String TestClassPublicPropertyDisplay = "public-property-display";
        private const String TestClassPublicPropertyRemarks = "public-property-remarks";
        private const String TestClassPrivateFieldDisplay = "private-field-display";
        private const String TestClassPrivateFieldRemarks = "private-field-remarks";
        private const String TestClassProtectedConstDisplay = "protected-const-display";
        private const String TestClassProtectedConstRemarks = "protected-const-remarks";
        private const String TestClassPublicStaticDisplay = "public-static-display";
        private const String TestClassPublicStaticRemarks = "public-static-remarks";

        [Annotation(TestClassDisplay, TestClassRemarks)]
        private class TestClassWtithAnnotation
        {
            public TestClassWtithAnnotation()
            {
                // Just to suppress warnings etc.
                var dummy = this.PrivateField;
            }

            [Annotation(TestClassPublicPropertyDisplay, TestClassPublicPropertyRemarks)]
            public String PublicProperty { get; set; }

            [Annotation(TestClassPrivateFieldDisplay, TestClassPrivateFieldRemarks)]
            private readonly String PrivateField = "";

            [Annotation(TestClassProtectedConstDisplay, TestClassProtectedConstRemarks)]
            protected const String ProtectedConst = "";

            [Annotation(TestClassPublicStaticDisplay, TestClassPublicStaticRemarks)]
            public static String PublicStatic = "";
        }

        #endregion
    }
}
