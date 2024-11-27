using CastraBus.Common.Extensions;
using System.Runtime.Serialization;

namespace CastraBus.Common.Util
{
    [DataContract]
    public class Paginate
    {

        /// <summary>
        /// Returns the number of items displayed per page. Default Size is 10
        /// </summary>
        [DataMember]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Returns the number of the current page.
        /// </summary>
        [DataMember]
        public int CurrentPage { get; set; }

        /// <summary>
        /// returns the number of total itens.
        /// </summary>
        [DataMember]
        public int TotalItemsCount { get; set; }

        /// <summary>
        /// Returns the number of pages
        /// </summary>
        [DataMember]
        public int Pages => TotalItemsCount % PageSize != 0 ? TotalItemsCount / PageSize + 1 : TotalItemsCount / PageSize;

        /// <summary>
        /// Returns the number of the next page.
        /// </summary>
        [DataMember]
        public int Next => CurrentPage == Pages ? Pages : (TotalItemsCount == 0 ? 1 : CurrentPage + 1);

        /// <summary>
        /// Returns the number of the Previous page.
        /// </summary>
        [DataMember]
        public int Previous => CurrentPage == 1 ? 0 : CurrentPage - 1;

        /// <summary>
        /// Object necessary to filter queries
        /// </summary>
        [DataMember]
        public object Filter { get; set; }

        /// <summary>
        /// Make a simple count query paginated with limit
        /// </summary>
        /// <param name="sQuery"></param>
        /// <returns></returns>

        public string MakeCountQuery(string sQuery)
        {
            int posSelect = sQuery.ToUpper().IndexOf("SELECT") + 6;
            int posFrom = sQuery.ToUpper().IndexOf("FROM") - 1;
            int posOrderBy = sQuery.ToUpper().IndexOf("ORDER BY") - 1;
            string countQuery = $"{sQuery.Substring(0, posSelect)} Count(1) total {(posOrderBy > 0 ? sQuery.Substring(posFrom, posOrderBy - posFrom) : sQuery.Substring(posFrom))}";

            return countQuery;
        }

        /// <summary>
        /// Make a complex count query paginated with limit
        /// </summary>
        /// <param name="sPaginatedQuery"></param>
        /// <returns></returns>

        public string MakePaginatedCountQuery(string sPaginatedQuery)
        {
            int posSelect = sPaginatedQuery.ToUpper().IndexOf("SELECT") + 6;
            int posFrom = sPaginatedQuery.ToUpper().IndexOf("FROM") - 1;
            int posGroupby = sPaginatedQuery.ToUpper().LastIndexOf("GROUP BY") - 1;
            int posOrderby = sPaginatedQuery.ToUpper().IndexOf("ORDER BY") - 1;
            int posFinal = (posGroupby > 0) ? posGroupby : posOrderby;

            string countQuery = sPaginatedQuery.Substring(posSelect - 6, 6)
                                + " Count("
                                + sPaginatedQuery.Substring(posSelect, posFrom - posSelect)
                                + ") "
                                + ((posFinal > 0) ?
                                    sPaginatedQuery.Substring(posFrom, posFinal - posFrom) :
                                    sPaginatedQuery.Substring(posFrom));

            return countQuery;
        }

        /// <summary>
        /// Make asimple query paginated with limit
        /// </summary>
        /// <param name="sQuery"></param>
        /// <returns></returns>

        public string MakePaginateQuery(string sQuery)
        {
            int offset = (CurrentPage - 1) * PageSize;
            string limit = $" LIMIT {offset},{PageSize} ";

            var indexes = sQuery.AllIndexesOf(";");
            if (!indexes.Any())
            {
                sQuery = $"{sQuery} {limit}";
            }
            else
            {
                foreach (var i in indexes)
                {
                    sQuery = $"{sQuery.Substring(0, i)} {limit} {sQuery.Substring(i)}";
                }
            }
            return sQuery;
        }

        /// <summary>
        /// Make a complex query paginated with limit
        /// </summary>
        /// <param name="sQueryOnly"></param>
        /// <param name="sQueryOrderBy"></param>
        /// <param name="sPaginatedQuery"></param>
        /// <returns></returns>

        public string MakePaginateQuery(string sQueryOnly, string sQueryOrderBy, string sPaginatedQuery)
        {
            int offset = (CurrentPage - 1) * PageSize;
            string limit = $" LIMIT {offset},{PageSize} ";

            string finalQuery;
            if (sPaginatedQuery.IsNullOrWhiteSpace())
            {
                finalQuery = $" {sQueryOnly} {sQueryOrderBy} {limit} ";
            }
            else
            {
                var lastIndex = sPaginatedQuery.Length - 1;//Ultimo char que deve ser o parenteses
                sPaginatedQuery = $"{sPaginatedQuery.Substring(0, lastIndex)}{limit}{sPaginatedQuery.Substring(lastIndex)}";
                finalQuery = $"{sQueryOnly} {sPaginatedQuery} {sQueryOrderBy} ";
            }
            return finalQuery;
        }

        public override string ToString()
        {
            return $"PageSize: {PageSize}, CurrentPage: {CurrentPage}, TotalItemsCount: {TotalItemsCount}, Filter: {((Filter != null) ? Filter.GetType().Name : "null")}";
        }
    }
}
