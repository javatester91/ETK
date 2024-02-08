using NUnit.Framework;
using Program;

namespace UnitTests
{
    public class Tests
    {
        [TestFixture]
        public class StringExtensionNewTests
        {
            [Test]
            [Description("���������, ��� � �������� ������ ��� ���������� � ���������� ��� ��������.")]

            public void WithoutExistingSubstringFixed_NoMatch_ReturnsOriginal()
            {
                ReadOnlySpan<char> source = "Hello World".AsSpan();
                ReadOnlySpan<char> skip = "XYZ".AsSpan();
                var result = StringExtensionNew.WithoutExistingSubstringFixed(source, skip);

                Assert.That("Hello World", Is.EqualTo(new string(result)));
            }

            [Test]
            [Description("���������, ��� ���������� ��������� � ������ �������� ������")]
            public void WithoutExistingSubstringFixed_MatchAtStart_ReturnsSubstring()
            {
                ReadOnlySpan<char> source = "TestHello World".AsSpan();
                ReadOnlySpan<char> skip = "Test".AsSpan();
                var result = StringExtensionNew.WithoutExistingSubstringFixed(source, skip);

                Assert.That("Hello World", Is.EqualTo(new string(result)));
            }

            [Test]
            [Description("���������, ��� ���������� ��������� � ����� �������� ������")]
            public void WithoutExistingSubstringFixed_MatchAtEnd_ReturnsSubstring()
            {
                ReadOnlySpan<char> source = "Hello WorldTest".AsSpan();
                ReadOnlySpan<char> skip = "Test".AsSpan();
                var result = StringExtensionNew.WithoutExistingSubstringFixed(source, skip);

                Assert.That("Hello World", Is.EqualTo(new string(result)));
            }

            [Test]
            [Description("��������� ��������� ���������� � �������� ������.")]
            public void WithoutExistingSubstringFixed_MultipleMatches_ReturnsCorrectResult()
            {
                ReadOnlySpan<char> source = "TestHelloTest WorldTest".AsSpan();
                ReadOnlySpan<char> skip = "Test".AsSpan();
                var result = StringExtensionNew.WithoutExistingSubstringFixed(source, skip);

                Assert.That("Hello World", Is.EqualTo(new string(result)));
            }

            [Test]
            [Description("���������, ����� �������� ������ �����.")]
            public void WithoutExistingSubstringFixed_EmptySource_ReturnsEmpty()
            {
                ReadOnlySpan<char> source = "".AsSpan();
                ReadOnlySpan<char> skip = "Test".AsSpan();
                var result = StringExtensionNew.WithoutExistingSubstringFixed(source, skip);

                Assert.That(result.IsEmpty, Is.EqualTo(true));
            }

            [Test]
            [Description("���������, ����� ��������� �����.")]
            public void WithoutExistingSubstringFixed_EmptySkip_ReturnsOriginal()
            {
                ReadOnlySpan<char> source = "Hello World".AsSpan();
                ReadOnlySpan<char> skip = "".AsSpan();
                var result = StringExtensionNew.WithoutExistingSubstringFixed(source, skip);

                Assert.That("Hello World", Is.EqualTo(new string(result)));
            }
        }
    }
}