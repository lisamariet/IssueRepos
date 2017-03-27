using System;
using AutomapperEnumBugExample.DomainModels;
using AutomapperEnumBugExample.ViewModels;
using AutoMapper;

namespace AutomapperEnumBugExample.Startup
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Status, ViewStatus>()
              .ConstructUsing(ConvertStatusEnums());
        }

        private Func<Status, ViewStatus> ConvertStatusEnums()
        {
            return statusValue =>
            {
                switch (statusValue)
                {
                    case Status.Finalized:
                    case Status.Initialized:
                        return ViewStatus.Ordered;

                    case Status.Waiting:
                    case Status.Processing:
                    case Status.AttentionNeeded:
                    case Status.ManualCreditCheck:
                        return ViewStatus.Processing;

                    case Status.CompletedWithErrors:
                    case Status.RejectedManually:
                        return ViewStatus.Error;

                    case Status.Canceled:
                    case Status.Done:
                    case Status.CompletedManually:
                        return ViewStatus.Completed;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(statusValue), statusValue, null);
                }
            };
        }
    }
}