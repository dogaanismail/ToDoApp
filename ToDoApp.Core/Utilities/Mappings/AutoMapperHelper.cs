using AutoMapper;
using System.Collections.Generic;

namespace ToDoApp.Core.Utilities.Mappings
{
    public class AutoMapperHelper
    {
        /// <summary>
        /// It can be used to fill up same object as a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> MapToSameTypeList<T>(List<T> list)
        {
            Mapper.Initialize(c => { c.CreateMap<T, T>(); });

            List<T> result = Mapper.Map<List<T>, List<T>>(list);
            return result;
        }

        /// <summary>
        ///  It can be used to fill up same object as a single object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T MapToSameType<T>(T obj)
        {
            Mapper.Initialize(c => { c.CreateMap<T, T>(); });

            T result = Mapper.Map<T, T>(obj);
            return result;
        }
    }
}
