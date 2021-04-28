using System.Collections.Generic;

namespace SchiffeVersenken.Helpers
{
    public static class ListOperations
    {
        /* Member/Fields */

        /* Constructors */

        /* Getter/Setter */

        /* Methods */

        /// <summary>
        /// Copy elements from a list into another list
        /// </summary>
        /// <typeparam name="T">Type of the elements in the list</typeparam>
        /// <param name="listToCopy">List to copy</param>
        /// <returns>New list</returns>
        public static List<T> CopyList<T>(List<T> listToCopy)
        {
            List<T> newList = new List<T>();

            foreach (T el in listToCopy)
            {
                newList.Add(el);
            }

            return newList;
        }
    }
}
