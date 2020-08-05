namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.DomainDataViaAdoNet.Serializers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    internal abstract class DBSerializerBase<T, TCollection> where TCollection : ICollection<T>
    {
        internal readonly string MessageFailed = " Failed";

        internal T SerializeSingle(IDataReader dataReader)
        {
            TCollection singleItemCollection = this.SerializeCollection(dataReader);

            if (singleItemCollection.Count > 0)
            {
                return singleItemCollection.FirstOrDefault();
            }

            return default(T);
        }

        internal abstract TCollection SerializeCollection(IDataReader dataReader);
    }
}
