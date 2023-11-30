// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;

namespace Slimforge.Api.Momo.Remittance.Brokers.DateTimes
{
    public interface IDateTimeBroker
    {
        DateTimeOffset ConvertToDateTimeOffSet(int totalSeconds);
    }
}
