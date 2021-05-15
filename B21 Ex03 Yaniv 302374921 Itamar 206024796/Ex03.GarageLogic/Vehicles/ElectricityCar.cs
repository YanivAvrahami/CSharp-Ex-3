using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricityCar : ElectricityVehicle
    {
        public eColor Color { get; private set; }
        public int Doors { get; private set; }

        public ElectricityCar()
            : base(4, 32f, 3.2f)
        {
        }

        public override string GetVehicleInfo()
        {
            StringBuilder infoStrBuilder = new StringBuilder(base.GetVehicleInfo());

            infoStrBuilder.AppendLine($"Color: {Color}");
            infoStrBuilder.AppendLine($"Number of doors: {Doors}");

            return infoStrBuilder.ToString();
        }

        public override List<string> PropertiesNeededToFillForTheSpecificVehicle()
        {
            List<string> listOfProperties = base.PropertiesNeededToFillForTheSpecificVehicle();

            listOfProperties.Add("color");
            listOfProperties.Add("doors");

            return listOfProperties;
        }

        public override void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            base.InitializeProperites(i_PropertiesToCastAndFill);

            try
            {
                Color = (eColor)Enum.Parse(typeof(eColor), i_PropertiesToCastAndFill[0]);
            }
            catch
            {
                throw new FormatException("There was a problem parsing a string to eColor enum.");
            }

            if (int.TryParse(i_PropertiesToCastAndFill[1], out int doorNumber))
            {
                Doors = doorNumber;
            }
            else
            {
                throw new FormatException("Problem parsing the string to value...");
            }

            i_PropertiesToCastAndFill.RemoveRange(0, 2);
        }
    }
}
