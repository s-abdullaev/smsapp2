using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.ExtensionMethods
{
    public static class CollectionExtensions
    {
        public static ObservableCollection<T> xToObservableCollection<T>(this IEnumerable<T> lst)
        {
            var lst2 = new ObservableCollection<T>();

            lst2.AddRange<T>(lst);

            return lst2;
        }

    }
}
