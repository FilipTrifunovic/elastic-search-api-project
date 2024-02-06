using elastic_search_api.Application.Common.Interfaces;
using System;

namespace elastic_search_api.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
