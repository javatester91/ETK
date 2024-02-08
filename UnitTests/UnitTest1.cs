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
            [Description("Проверяем, что в исходной строке нет совпадений с подстрокой для пропуска.")]

            public void WithoutExistingSubstringFixed_NoMatch_ReturnsOriginal()
            {
                ReadOnlySpan<char> source = "Hello World".AsSpan();
                ReadOnlySpan<char> skip = "XYZ".AsSpan();
                var result = StringExtensionNew.WithoutExistingSubstringFixed(source, skip);

                Assert.That("Hello World", Is.EqualTo(new string(result)));
            }

            [Test]
            [Description("Проверяем, что совпадение находится в начале исходной строки")]
            public void WithoutExistingSubstringFixed_MatchAtStart_ReturnsSubstring()
            {
                ReadOnlySpan<char> source = "TestHello World".AsSpan();
                ReadOnlySpan<char> skip = "Test".AsSpan();
                var result = StringExtensionNew.WithoutExistingSubstringFixed(source, skip);

                Assert.That("Hello World", Is.EqualTo(new string(result)));
            }

            [Test]
            [Description("Проверяем, что совпадение находится в конце исходной строки")]
            public void WithoutExistingSubstringFixed_MatchAtEnd_ReturnsSubstring()
            {
                ReadOnlySpan<char> source = "Hello WorldTest".AsSpan();
                ReadOnlySpan<char> skip = "Test".AsSpan();
                var result = StringExtensionNew.WithoutExistingSubstringFixed(source, skip);

                Assert.That("Hello World", Is.EqualTo(new string(result)));
            }

            [Test]
            [Description("Проверяем несколько совпадений в исходной строке.")]
            public void WithoutExistingSubstringFixed_MultipleMatches_ReturnsCorrectResult()
            {
                ReadOnlySpan<char> source = "TestHelloTest WorldTest".AsSpan();
                ReadOnlySpan<char> skip = "Test".AsSpan();
                var result = StringExtensionNew.WithoutExistingSubstringFixed(source, skip);

                Assert.That("Hello World", Is.EqualTo(new string(result)));
            }

            [Test]
            [Description("Проверяем, когда исходная строка пуста.")]
            public void WithoutExistingSubstringFixed_EmptySource_ReturnsEmpty()
            {
                ReadOnlySpan<char> source = "".AsSpan();
                ReadOnlySpan<char> skip = "Test".AsSpan();
                var result = StringExtensionNew.WithoutExistingSubstringFixed(source, skip);

                Assert.That(result.IsEmpty, Is.EqualTo(true));
            }

            [Test]
            [Description("Проверяем, когда подстрока пуста.")]
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