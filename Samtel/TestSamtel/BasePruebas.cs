

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
//using ChekcListAPI.Helpers;
using NetTopologySuite;
//using peliculasapi.context;
using BackendSamtelDomain;

namespace TestSamtel
{
    public class BasePruebas
    {
        //protected ApplicationDbContext ConstruirContext(string nombreDB)
        //{
        //    var opciones = new DbContextOptionsBuilder<ApplicationDbContext>()
        //            .UseInMemoryDatabase(nombreDB).Options;

        //    var dbContext = new ApplicationDbContext(opciones);
        //    return dbContext;
        //}

        //protected IMapper ConfigurarAutoMapper()
        //{
        //    var config = new MapperConfiguration(options =>
        //    {
        //        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
        //        options.AddProfile(new AutoMapperProfiles(geometryFactory));
        //    });

        //    return config.CreateMapper();
        //}
    }
}
