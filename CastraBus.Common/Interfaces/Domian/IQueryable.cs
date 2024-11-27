namespace CastraBus.Common.Interfaces.Domian
{
    public interface IQueryable
    {
        /// <summary>
        /// Retrieves the parameter list for queries with this entity
        /// </summary>
        /// <returns></returns>
        object GetParamList();
    }
}
