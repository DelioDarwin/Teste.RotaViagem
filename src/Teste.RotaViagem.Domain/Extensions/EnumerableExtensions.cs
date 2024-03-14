
namespace Teste.RotaViagem.Domain.Extensions
{
    public static class EnumerableExtensions
    {
        public static string FormatStringFor<T, V>(this IEnumerable<T> enumerable, Func<T, V> filter) => string.Format(",",  enumerable.Select(filter));
        public static string ToFormatString<T>(this IEnumerable<T> enumerable) =>string.Format(",", enumerable) ;
    }
}
