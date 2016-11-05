using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
namespace Services.Common
{
    public static class MapEntities
    {
        public static TDestinationEntity Map<TSourceEntity, TDestinationEntity>(TSourceEntity sourceEntity)
            where TSourceEntity : class
            where TDestinationEntity : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSourceEntity, TDestinationEntity>();
            });
            return config.CreateMapper().Map<TSourceEntity, TDestinationEntity>(sourceEntity);
        }
        public static IEnumerable<TDestinationEntity> MapIEnumerableCollection<TSourceEntity, TDestinationEntity>(IEnumerable<TSourceEntity> sourceEntity)
            where TSourceEntity : class
            where TDestinationEntity : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSourceEntity, TDestinationEntity>();
            });
            return config.CreateMapper().Map<IEnumerable<TSourceEntity>, IEnumerable<TDestinationEntity>>(sourceEntity);
        }
        public static List<TDestinationEntity> MapList<TSourceEntity, TDestinationEntity>(List<TSourceEntity> sourceEntity)
            where TSourceEntity : class
            where TDestinationEntity : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSourceEntity, TDestinationEntity>();
            });
            return config.CreateMapper().Map<List<TSourceEntity>, List<TDestinationEntity>>(sourceEntity);
        }
    }

   
}