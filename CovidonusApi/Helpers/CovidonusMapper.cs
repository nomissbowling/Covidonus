﻿using AutoMapper;
using CovidonusApi.Models;
using CovidonusApi.Models.DTOs;
using System;
using System.Globalization;

namespace CovidonusApi.Helpers
{
    public static class CovidonusMapper
    {
        public static IMapper GetMapper()
        {
            IConfigurationProvider configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CasesTimeSeries, CasesTimeSeries>()
                .ForMember(s => s.DateFull, t => t.MapFrom(x => ConvertDate(x.Date)));
                cfg.CreateMap<StateWiseData, StateWiseData>()
                 .ForMember(s => s.DistrictData, t => t.Ignore())
                .ForMember(s => s.Id, t => t.Ignore());
                cfg.CreateMap<DistrictWiseData, DistrictWiseData>()
                .ForMember(s => s.DeltaId, t => t.Ignore())
                .ForMember(s => s.Id, t => t.Ignore())
                .ForMember(s => s.StateCode, t => t.Ignore())
                 .ForMember(s => s.Delta, t => t.Ignore());
                cfg.CreateMap<DeltaData, DeltaData>()
                .ForMember(s => s.Id, t => t.Ignore());
                cfg.CreateMap<Tested, Tested>();
                cfg.CreateMap<DeltaData, Delta>();

            });
            return new Mapper(configuration);
        }

        private static string GetDeathRation(CasesTimeSeries x)
        {
            if (x.TotalConfirmed == 0)
            {
                return string.Empty;
            }
            double per = (double)x.TotalDeceased / (double)x.TotalConfirmed * 100;
            return Convert.ToString(Math.Round(per, 2));
        }

        private static DateTime ConvertDate(string date)
        {
            var da = $"{date}{DateTime.Now.Year}";
            CultureInfo provider = CultureInfo.InvariantCulture;
            if (!string.IsNullOrEmpty(date) && DateTime.TryParseExact(da, "dd MMMM yyyy", provider, DateTimeStyles.None, out DateTime newdate))
            {
                return newdate;
            }
            return default(DateTime);
        }
    }
}