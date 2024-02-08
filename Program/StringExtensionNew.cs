namespace Program
{
    public class StringExtensionNew
    {
        public static ReadOnlySpan<char> WithoutExistingSubstringFixed(ReadOnlySpan<char> sourceSpan, ReadOnlySpan<char> skipSpan)
        {
            if (skipSpan.Length == 0) return sourceSpan;

            Span<char> buffer = stackalloc char[sourceSpan.Length];
            int bufferIndex = 0;

            for (int i = 0; i < sourceSpan.Length;)
            {
                if (i <= sourceSpan.Length - skipSpan.Length && sourceSpan.Slice(i, skipSpan.Length).SequenceEqual(skipSpan))
                {
                    // Пропускаем подстроку skipSpan
                    i += skipSpan.Length;
                }
                else
                {
                    // Копируем текущий символ в буфер, если он не начало skipSpan
                    buffer[bufferIndex++] = sourceSpan[i++];
                }
            }

            return new ReadOnlySpan<char>(buffer.Slice(0, bufferIndex).ToArray());
        }
    }
}
