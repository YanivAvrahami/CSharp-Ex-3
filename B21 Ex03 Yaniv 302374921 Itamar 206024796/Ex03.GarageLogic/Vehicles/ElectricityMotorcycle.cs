using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricityMotorcycle : ElectricityVehicle
    {
        public eLicense License { get; private set; }
        public int EngineVolume { get; private set; }

        public ElectricityMotorcycle()
            : base(2, 30f, 1.8f)
        {
        }

        public override string GetVehicleInfo()
        {
            StringBuilder stringBuilder = new StringBuilder(base.GetVehicleInfo());

            stringBuilder.AppendLine($"License: {License}");
            stringBuilder.AppendLine($"Engine Volume: {EngineVolume}");

            return stringBuilder.ToString();
        }

        public override List<string> PropertiesNeededToFillForTheSpecificVehicle()
        {
            List<string> listOfProperties = base.PropertiesNeededToFillForTheSpecificVehicle();

            listOfProperties.Add("lisence");
            listOfProperties.Add("engine volume");

            return listOfProperties;
        }

        public override void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            base.InitializeProperites(i_PropertiesToCastAndFill);

            try
            {
                License = (eLicense)Enum.Parse(typeof(eLicense), i_PropertiesToCastAndFill[0]);
            }
            catch
            {
                throw new FormatException("There was a problem parsing a string to eColor enum.");
            }

            if (int.TryParse(i_PropertiesToCastAndFill[1], out int engineVolume))
            {
                EngineVolume = engineVolume;
            }
            else
            {
                throw new FormatException("Problem parsing the string to value...");
            }

            i_PropertiesToCastAndFill.RemoveRange(0, 2);
        }
    }
}
