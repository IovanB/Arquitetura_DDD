using Api.CrossCutting.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Teste.UnitTests.Service
{
    public abstract class BaseTestService
    {
        public IMapper Mapper { get; set; }
        public BaseTestService()
        {
            Mapper = new AutoMapperFixture().GetMap(); /*cria a instancia de mapeamento*/
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMap()
            {
                var config = new MapperConfiguration(ctg =>
                {
                    ctg.AddProfile(new ModelToEntityProfile());
                    ctg.AddProfile(new DtoModelProfile());
                    ctg.AddProfile(new EntityDtoProfile());
                });

                return config.CreateMapper();
            }
            public void Dispose()
            {
            }
        }
    }
}
