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
using System;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Attributes.Tests.Attributes
{
    [ExcludeFromCodeCoverage]
    internal class AnnotationAttributeTests
    {
        [Test]
        public void AnnotationAttribute_DefaultConstruction_PropertiesSetAsExpected()
        {
            AnnotationAttribute instance = new AnnotationAttribute();

            Assert.That(instance.Display, Is.Not.Null);
            Assert.That(instance.Display, Is.Empty);
            Assert.That(instance.Remarks, Is.Not.Null);
            Assert.That(instance.Remarks, Is.Empty);
            Assert.That(instance.Utilize, Is.Null);
            Assert.That(instance.Visible, Is.False);
        }

        [Test]
        public void AnnotationAttribute_DisplayConstruction_PropertiesSetAsExpected()
        {
            AnnotationAttribute instance = new AnnotationAttribute("display text");

            Assert.That(instance.Display, Is.EqualTo("display text"));
            Assert.That(instance.Remarks, Is.Not.Null);
            Assert.That(instance.Remarks, Is.Empty);
            Assert.That(instance.Utilize, Is.Null);
            Assert.That(instance.Visible, Is.True);
        }

        [Test]
        public void AnnotationAttribute_DisplayRemarksConstruction_PropertiesSetAsExpected()
        {
            AnnotationAttribute instance = new AnnotationAttribute("display text", "remarks text");

            Assert.That(instance.Display, Is.EqualTo("display text"));
            Assert.That(instance.Remarks, Is.EqualTo("remarks text"));
            Assert.That(instance.Utilize, Is.Null);
            Assert.That(instance.Visible, Is.True);
        }

        [Test]
        public void AnnotationAttribute_DisplayUtilizeConstruction_PropertiesSetAsExpected()
        {
            Object utilize = "utilize object";

            AnnotationAttribute instance = new AnnotationAttribute("display text", utilize);

            Assert.That(instance.Display, Is.EqualTo("display text"));
            Assert.That(instance.Remarks, Is.Not.Null);
            Assert.That(instance.Remarks, Is.Empty);
            Assert.That(instance.Utilize, Is.EqualTo(utilize));
            Assert.That(instance.Visible, Is.True);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AnnotationAttribute_DisplayVisibleConstruction_PropertiesSetAsExpected(Boolean visible)
        {
            AnnotationAttribute instance = new AnnotationAttribute("display text", visible);

            Assert.That(instance.Display, Is.EqualTo("display text"));
            Assert.That(instance.Remarks, Is.Not.Null);
            Assert.That(instance.Remarks, Is.Empty);
            Assert.That(instance.Utilize, Is.Null);
            Assert.That(instance.Visible, Is.EqualTo(visible));
        }

        [Test]
        public void AnnotationAttribute_DisplayRemarksUtilizeConstruction_PropertiesSetAsExpected()
        {
            Object utilize = "utilize object";

            AnnotationAttribute instance = new AnnotationAttribute("display text", "remarks text", utilize);

            Assert.That(instance.Display, Is.EqualTo("display text"));
            Assert.That(instance.Remarks, Is.EqualTo("remarks text"));
            Assert.That(instance.Utilize, Is.EqualTo(utilize));
            Assert.That(instance.Visible, Is.True);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AnnotationAttribute_DisplayRemarksVisibleConstruction_PropertiesSetAsExpected(Boolean visible)
        {
            AnnotationAttribute instance = new AnnotationAttribute("display text", "remarks text", visible);

            Assert.That(instance.Display, Is.EqualTo("display text"));
            Assert.That(instance.Remarks, Is.EqualTo("remarks text"));
            Assert.That(instance.Utilize, Is.Null);
            Assert.That(instance.Visible, Is.EqualTo(visible));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AnnotationAttribute_DisplayRemarksUtilizeVisibleConstruction_PropertiesSetAsExpected(Boolean visible)
        {
            Object utilize = "utilize object";

            AnnotationAttribute instance = new AnnotationAttribute("display text", "remarks text", utilize, visible);

            Assert.That(instance.Display, Is.EqualTo("display text"));
            Assert.That(instance.Remarks, Is.EqualTo("remarks text"));
            Assert.That(instance.Utilize, Is.EqualTo(utilize));
            Assert.That(instance.Visible, Is.EqualTo(visible));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("value")]
        [TestCase("  value ")]
        public void Display_SetGet_PropertyAsExpected(String value)
        {
            AnnotationAttribute instance = new AnnotationAttribute
            {
                Display = value
            };

            Assert.That(instance.Display, Is.EqualTo(value));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("value")]
        [TestCase("  value ")]
        public void Remarks_SetGet_PropertyAsExpected(String value)
        {
            AnnotationAttribute instance = new AnnotationAttribute
            {
                Remarks = value
            };

            Assert.That(instance.Remarks, Is.EqualTo(value));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("value")]
        [TestCase("  value ")]
        public void Utilize_SetGet_PropertyAsExpected(Object value)
        {
            AnnotationAttribute instance = new AnnotationAttribute
            {
                Utilize = value
            };

            Assert.That(instance.Utilize, Is.EqualTo(value));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Visible_SetGet_PropertyAsExpected(Boolean value)
        {
            AnnotationAttribute instance = new AnnotationAttribute
            {
                Visible = value
            };

            Assert.That(instance.Visible, Is.EqualTo(value));
        }
    }
}
