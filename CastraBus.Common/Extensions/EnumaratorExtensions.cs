namespace CastraBus.Common.Extensions
{
    public static class EnumaratorExtensions
    {
        /// <summary>
        /// Return Paged list - Where 1st Page is Number 1. IT'S NOT ZERO BASED
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static IEnumerable<T> Page<T>(this IEnumerable<T> list, int pageSize, int page)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Return Paged List - Where 1st Page is Number 1. IT'S NOT ZERO BASED
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static IEnumerable<T> Page<T>(this IQueryable<T> list, int pageSize, int page)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).AsEnumerable();
        }
    }
}
