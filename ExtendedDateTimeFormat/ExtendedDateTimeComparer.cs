﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ExtendedDateTimeFormat
{
    public class ExtendedDateTimeComparer : IComparer<ExtendedDateTime>
    {
        public int Compare(ExtendedDateTime x, ExtendedDateTime y)
        {
            if (y == null)
            {
                return 1;
            }

            if (x.Year == null || y.Year == null)
            {
                throw new InvalidOperationException("Cannot compare extended date times without a year.");
            }

            long longXYear = x.Year.Value;
            long longYYear = y.Year.Value;


            if (x.YearExponent.HasValue)
            {
                try
                {
                    longXYear *= Convert.ToInt64(Math.Pow(10, x.YearExponent.Value));
                }
                catch (Exception)
                {
                    if (x.Year.Value < 0)
                    {
                        longXYear = long.MinValue;
                    }
                    else
                    {
                        longXYear = long.MaxValue;
                    }

                }
            }

            if (y.YearExponent.HasValue)
            {
                try
                {
                    longYYear *= Convert.ToInt64(Math.Pow(10, y.YearExponent.Value));
                }
                catch (Exception)
                {
                    if (y.Year.Value < 0)
                    {
                        longYYear = long.MinValue;
                    }
                    else
                    {
                        longYYear = long.MaxValue;
                    }

                }
            }

            if (longXYear > longYYear)
            {
                return 1;
            }
            else if (longXYear < longYYear)
            {
                return -1;
            }

            if (x.Season != Season.Undefined || y.Season != Season.Undefined)
            {
                if (y.Season == Season.Undefined)
                {
                    return 1;
                }
                else if (x.Season == Season.Undefined)
                {
                    return -1;
                }
                else if (x.Season > y.Season)
                {
                    return 1;
                }
                else if (x.Season < y.Season)
                {
                    return -1;
                }
            }

            if (x.Month == null && y.Month == null)
            {
                return 0;
            }
            else if (y.Month == null)
            {
                return 1;
            }
            else if (x.Month == null)
            {
                return -1;
            }
            else if (x.Month > y.Month)
            {
                return 1;
            }
            else if (x.Month < y.Month)
            {
                return -1;
            }

            if (x.Day == null && y.Day == null)
            {
                return 0;
            }
            else if (y.Day == null)
            {
                return 1;
            }
            else if (x.Day == null)
            {
                return -1;
            }
            else if (x.Day > y.Day)
            {
                return 1;
            }
            else if (x.Day < y.Day)
            {
                return -1;
            }

            if (x.Hour == null && y.Hour == null)
            {
                return 0;
            }
            else if (y.Hour == null)
            {
                return 1;
            }
            else if (x.Hour == null)
            {
                return -1;
            }
            else if (x.Hour > y.Hour)
            {
                return 1;
            }
            else if (x.Hour < y.Hour)
            {
                return -1;
            }

            if (x.Minute == null && y.Minute == null)
            {
                return 0;
            }
            else if (y.Minute == null)
            {
                return 1;
            }
            else if (x.Minute == null)
            {
                return -1;
            }
            else if (x.Minute > y.Minute)
            {
                return 1;
            }
            else if (x.Minute < y.Minute)
            {
                return -1;
            }

            if (x.Second == null && y.Second == null)
            {
                return 0;
            }
            else if (y.Second == null)
            {
                return 1;
            }
            else if (x.Second == null)
            {
                return -1;
            }
            else if (x.Second > y.Second)
            {
                return 1;
            }
            else if (x.Second < y.Second)
            {
                return -1;
            }

            return 0;
        }
    }
}