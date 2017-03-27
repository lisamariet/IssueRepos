using AutoMapper;

namespace ExampleClassLibrary.Startup
{
    public class MappingConfigFactory
    {
        public static MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddProfiles(typeof(MappingConfigFactory).Assembly);
            });

            return config;
        }
    }
}