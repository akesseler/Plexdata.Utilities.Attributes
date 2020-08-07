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
    internal class AnnotationExtensionEnumTests
    {
        [Test]
        public void GetAnnotation_EnumAnnotationFromTypeof_ResultIsAnnotationAttribute()
        {
            AnnotationAttribute actual = typeof(TestEnumWtithAnnotation).GetAnnotation();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(TestEnumDisplay));
            Assert.That(actual.Remarks, Is.EqualTo(TestEnumRemarks));
        }

        [Test]
        public void GetAnnotation_EnumAnnotationFromGetType_ResultIsAnnotationAttribute()
        {
            AnnotationAttribute actual = (new TestEnumWtithAnnotation()).GetType().GetAnnotation();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(TestEnumDisplay));
            Assert.That(actual.Remarks, Is.EqualTo(TestEnumRemarks));
        }

        [TestCase(Value1Name, TestEnumValue1Display, TestEnumValue1Remarks)]
        [TestCase(Value2Name, TestEnumValue2Display, TestEnumValue2Remarks)]
        [TestCase(Value3Name, TestEnumValue3Display, TestEnumValue3Remarks)]
        public void GetAnnotation_ChildAnnotationFromTypeof_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = typeof(TestEnumWtithAnnotation).GetAnnotation(name);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        [TestCase(Value1Name, TestEnumValue1Display, TestEnumValue1Remarks)]
        [TestCase(Value2Name, TestEnumValue2Display, TestEnumValue2Remarks)]
        [TestCase(Value3Name, TestEnumValue3Display, TestEnumValue3Remarks)]
        public void GetAnnotation_ChildAnnotationFromGetType_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = (new TestEnumWtithAnnotation()).GetType().GetAnnotation(name);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        [TestCase(Value1Name, TestEnumValue1Display, TestEnumValue1Remarks)]
        [TestCase(Value2Name, TestEnumValue2Display, TestEnumValue2Remarks)]
        [TestCase(Value3Name, TestEnumValue3Display, TestEnumValue3Remarks)]
        public void GetAnnotation_ChildAnnotationFromInstance_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = (new TestEnumWtithAnnotation()).GetAnnotation(name);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        [TestCase(Value1Name, TestEnumValue1Display, TestEnumValue1Remarks)]
        [TestCase(Value2Name, TestEnumValue2Display, TestEnumValue2Remarks)]
        [TestCase(Value3Name, TestEnumValue3Display, TestEnumValue3Remarks)]
        public void GetAnnotation_ChildAnnotationFromInstanceLowerCase_ResultIsAnnotationAttribute(String name, String display, String remarks)
        {
            AnnotationAttribute actual = (new TestEnumWtithAnnotation()).GetAnnotation(name.ToLower());

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        [TestCase(TestEnumWtithAnnotation.Value1, TestEnumValue1Display, TestEnumValue1Remarks)]
        [TestCase(TestEnumWtithAnnotation.Value2, TestEnumValue2Display, TestEnumValue2Remarks)]
        [TestCase(TestEnumWtithAnnotation.Value3, TestEnumValue3Display, TestEnumValue3Remarks)]
        public void GetAnnotation_ChildAnnotationFromValues_ResultIsAnnotationAttribute(Object value, String display, String remarks)
        {
            AnnotationAttribute actual = ((TestEnumWtithAnnotation)value).GetAnnotation();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Display, Is.EqualTo(display));
            Assert.That(actual.Remarks, Is.EqualTo(remarks));
        }

        #region Private Helpers

        private const String Value1Name = "Value1";
        private const String Value3Name = "Value3";
        private const String Value2Name = "Value2";
        private const String TestEnumDisplay = "test-enum-display";
        private const String TestEnumRemarks = "test-enum-remarks";
        private const String TestEnumValue1Display = "enum-value1-display";
        private const String TestEnumValue1Remarks = "enum-value1-remarks";
        private const String TestEnumValue2Display = "enum-value2-display";
        private const String TestEnumValue2Remarks = "enum-value2-remarks";
        private const String TestEnumValue3Display = "enum-value3-display";
        private const String TestEnumValue3Remarks = "enum-value3-remarks";

        [Annotation(TestEnumDisplay, TestEnumRemarks)]
        private enum TestEnumWtithAnnotation
        {
            [Annotation(TestEnumValue1Display, TestEnumValue1Remarks)]
            Value1,
            [Annotation(TestEnumValue2Display, TestEnumValue2Remarks)]
            Value2,
            [Annotation(TestEnumValue3Display, TestEnumValue3Remarks)]
            Value3
        }

        #endregion
    }
}
