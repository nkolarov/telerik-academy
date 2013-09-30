using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebCalculator.Models
{
    public enum MeasureTypes
    {
        [Description("bit - b")]
        bit,
        [Description("Byte - B")]
        Byte,
        [Description("Kilobit - Kb")]
        Kilobit,
        [Description("Kilobyte - KB")]
        Kilobyte,
        [Description("Megabit - Mb")]
        Megabit,
        [Description("Megabyte - MB")]
        Megabyte,
        [Description("Gigabit - Gb")]
        Gigabit,
        [Description("Gigabyte - GB")]
        Gigabyte,
        [Description("Terabit - Tb")]
        Terabit,
        [Description("Terabyte - TB")]
        Terabyte,
        [Description("Petabit - Pb")]
        Petabit,
        [Description("Petabyte - PB")]
        Petabyte,
        [Description("Exabit - Eb")]
        Exabit,
        [Description("Exabyte - EB")]
        Exabyte,
        [Description("Zettabit - Zb")]
        Zettabit,
        [Description("Zettabyte - ZB")]
        Zettabyte,
        [Description("Yottabit - Yb")]
        Yottabit,
        [Description("Yottabyte - YB")]
        Yottabyte
    }
}