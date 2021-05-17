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
            StringBuilder infoStrBuilder = new StringBuilder(base.GetVehicleInfo());

            infoStrBuilder.AppendLine($"License: {License}");
            infoStrBuilder.AppendLine($"Engine Volume: {EngineVolume}");

            return infoStrBuilder.ToString();
        }

        public override List<string> PropertiesToInitialize()
        {
            List<string> listOfProperties = base.PropertiesToInitialize();

            listOfProperties.Add("lisence");
            listOfProperties.Add("engine volume");

            return listOfProperties;
        }

        public override void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            base.InitializeProperites(i_PropertiesToCastAndFill);

            initLicense(i_PropertiesToCastAndFill[0]);
            initEngineVolume(i_PropertiesToCastAndFill[1]);

            i_PropertiesToCastAndFill.RemoveRange(0, 2);
        }

        private void initLicense(string i_LicenseStr)
        {
            try
            {
                License = (eLicense)Enum.Parse(typeof(eLicense), i_LicenseStr);
            }
            catch
            {
                throw new FormatException("There was a problem parsing a string to eLicense enum.");
            }
        }

        private void initEngineVolume(string i_EngineVolumeStr)
        {
            if (int.TryParse(i_EngineVolumeStr, out int engineVolume))
            {
                EngineVolume = engineVolume;
            }
            else
            {
                throw new FormatException("Problem parsing the string to value...");
            }
        }
    }
}
