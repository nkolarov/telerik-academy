using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalculator.Models
{
    public class UnitCalculator
    {
        private List<SelectListItem> measureTypeItems = new List<SelectListItem>();

        private List<SelectListItem> kiloTypeItems = new List<SelectListItem>();

        private Dictionary<string, double> decimalQuotients;

        private Dictionary<string, double> binaryQuotients;

        public Dictionary<string, double> Conversions { get; set; }

        public string SelectedUnit { get; set; }

        public int SelectedKilo { get; set; }

        public double Quantity { get; set; }

        public IEnumerable<SelectListItem> MeasureTypeItems
        {
            get
            {
                return this.measureTypeItems;
            }
        }

        public IEnumerable<SelectListItem> KiloTypeItems
        {
            get
            {
                return this.kiloTypeItems;
            }
        }

        public UnitCalculator()
        {
            this.LoadMeasureTypeItems();
            this.LoadKiloTypeItems();
            this.LoadBinaryQuotients();
            this.LoadDecimalQuotients();
        }

        public void ConvertUnits()
        {
            this.Conversions = new Dictionary<string, double>();
            double commonQuotient = 0;

            if (this.SelectedKilo == 1000)
            {
                commonQuotient = this.Quantity / this.decimalQuotients[((MeasureTypes)int.Parse(this.SelectedUnit)).ToDescription()];

                for (int i = 0; i < Enum.GetValues(typeof(MeasureTypes)).Length; i++)
                {
                    var currentItemDescription = ((MeasureTypes)i).ToDescription();

                    this.Conversions.Add(currentItemDescription, commonQuotient * this.decimalQuotients[currentItemDescription]);
                }
            }
            if (this.SelectedKilo == 1024)
            {
                commonQuotient = this.Quantity / this.binaryQuotients[((MeasureTypes)int.Parse(this.SelectedUnit)).ToDescription()];

                for (int i = 0; i < Enum.GetValues(typeof(MeasureTypes)).Length; i++)
                {
                    var currentItemDescription = ((MeasureTypes)i).ToDescription();

                    this.Conversions.Add(currentItemDescription, commonQuotient * this.binaryQuotients[currentItemDescription]);
                }
            }
        }

        private void LoadMeasureTypeItems()
        {
            for (int i = 0; i < Enum.GetValues(typeof(MeasureTypes)).Length; i++)
            {
                var description = ((MeasureTypes)i).ToDescription();
                this.measureTypeItems.Add(
                    new SelectListItem
                    {
                        Text = description,
                        Value = (i).ToString()
                    });
            }
        }

        private void LoadKiloTypeItems()
        {
            this.kiloTypeItems = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="1000",
                    Value = "1000"
                },
                new SelectListItem
                {
                    Text = "1024",
                    Value = "1024"
                }
            };
        }

        private void LoadBinaryQuotients()
        {
            this.binaryQuotients = new Dictionary<string, double>();

            this.binaryQuotients.Add(MeasureTypes.bit.ToDescription(), 9.671406556917E+24);
            this.binaryQuotients.Add(MeasureTypes.Byte.ToDescription(), 1.2089258196146E+24);
            this.binaryQuotients.Add(MeasureTypes.Kilobit.ToDescription(), 9.4447329657393E+21);
            this.binaryQuotients.Add(MeasureTypes.Kilobyte.ToDescription(), 1.1805916207174E+21);
            this.binaryQuotients.Add(MeasureTypes.Megabit.ToDescription(), 9.2233720368548E+18);
            this.binaryQuotients.Add(MeasureTypes.Megabyte.ToDescription(), 1.1529215046068E+18);
            this.binaryQuotients.Add(MeasureTypes.Gigabit.ToDescription(), 9.007199254741E+15);
            this.binaryQuotients.Add(MeasureTypes.Gigabyte.ToDescription(), 1.1258999068426E+15);
            this.binaryQuotients.Add(MeasureTypes.Terabit.ToDescription(), 8796093022208);
            this.binaryQuotients.Add(MeasureTypes.Terabyte.ToDescription(), 1099511627776);
            this.binaryQuotients.Add(MeasureTypes.Petabit.ToDescription(), 8589934592);
            this.binaryQuotients.Add(MeasureTypes.Petabyte.ToDescription(), 1073741824);
            this.binaryQuotients.Add(MeasureTypes.Exabit.ToDescription(), 8388608);
            this.binaryQuotients.Add(MeasureTypes.Exabyte.ToDescription(), 1048576);
            this.binaryQuotients.Add(MeasureTypes.Zettabit.ToDescription(), 8192);
            this.binaryQuotients.Add(MeasureTypes.Zettabyte.ToDescription(), 1024);
            this.binaryQuotients.Add(MeasureTypes.Yottabit.ToDescription(), 8);
            this.binaryQuotients.Add(MeasureTypes.Yottabyte.ToDescription(), 1);
        }

        private void LoadDecimalQuotients()
        {
            this.decimalQuotients = new Dictionary<string, double>();

            this.decimalQuotients.Add(MeasureTypes.bit.ToDescription(), 8.0E+24);
            this.decimalQuotients.Add(MeasureTypes.Byte.ToDescription(), 1.0E+24);
            this.decimalQuotients.Add(MeasureTypes.Kilobit.ToDescription(), 8.0E+21);
            this.decimalQuotients.Add(MeasureTypes.Kilobyte.ToDescription(), 1.0E+21);
            this.decimalQuotients.Add(MeasureTypes.Megabit.ToDescription(), 8.0E+18);
            this.decimalQuotients.Add(MeasureTypes.Megabyte.ToDescription(), 1.0E+18);
            this.decimalQuotients.Add(MeasureTypes.Gigabit.ToDescription(), 8.0E+15);
            this.decimalQuotients.Add(MeasureTypes.Gigabyte.ToDescription(), 1.0E+15);
            this.decimalQuotients.Add(MeasureTypes.Terabit.ToDescription(), 8000000000000);
            this.decimalQuotients.Add(MeasureTypes.Terabyte.ToDescription(), 1000000000000);
            this.decimalQuotients.Add(MeasureTypes.Petabit.ToDescription(), 8000000000);
            this.decimalQuotients.Add(MeasureTypes.Petabyte.ToDescription(), 1000000000);
            this.decimalQuotients.Add(MeasureTypes.Exabit.ToDescription(), 8000000);
            this.decimalQuotients.Add(MeasureTypes.Exabyte.ToDescription(), 1000000);
            this.decimalQuotients.Add(MeasureTypes.Zettabit.ToDescription(), 8000);
            this.decimalQuotients.Add(MeasureTypes.Zettabyte.ToDescription(), 1000);
            this.decimalQuotients.Add(MeasureTypes.Yottabit.ToDescription(), 8);
            this.decimalQuotients.Add(MeasureTypes.Yottabyte.ToDescription(), 1);
        }
    }
}