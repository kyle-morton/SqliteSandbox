using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Data;
using SqliteEFDemo.Models;

namespace SqliteEFDemo
{
    static class MappingUtil
    {

        static MappingUtil()
        {
            Mapper.Initialize(cfg => { cfg.AddDataReaderMapping(); });
        }

        /// <summary>
        /// read data from data reader and convert to list of given-type models
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public static List<T> ReadData<T>(IDataReader dataReader)
        {
            var mappedData = AutoMapper.Mapper.Map<IDataReader, List<T>>(dataReader);
            return mappedData;
        }

        #region MAPPING

        public static List<Track> ToTracks(List<IDataRecord> records)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IDataRecord, Track>());
            var mapper = config.CreateMapper();
            foreach (var record in records)
            {
                var mappedRecord = mapper.Map<IDataRecord, Track>(record);
            }

            //return mapper.Map<List<IDataRecord>, List<Track>>(records);
            return new List<Track>();

        }

        #endregion
    }
}
