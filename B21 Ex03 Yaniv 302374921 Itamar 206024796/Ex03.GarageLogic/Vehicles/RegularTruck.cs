using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class RegularTruck : PetrolVehicle
    {
        public bool HasHazardous { get; private set; }
        public float MaxCarry { get; private set; }

        public RegularTruck()
            : base(16, 26f, eFuelType.Soler, 120f)
        {
        }

        public override string GetVehicleInfo()
        {
            StringBuilder infoStrBuilder = new StringBuilder(base.GetVehicleInfo());

            infoStrBuilder.AppendLine($"Has hazardous cargo: {HasHazardous}");
            infoStrBuilder.AppendLine($"Maximum carry: {MaxCarry}");

            return infoStrBuilder.ToString();
        }

        public override List<string> PropertiesToInitialize()
        {
            List<string> listOfProperties = base.PropertiesToInitialize();

            listOfProperties.Add("has hazardous cargo");
            listOfProperties.Add("max carry");

            return listOfProperties;
        }

        public override void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            base.InitializeProperites(i_PropertiesToCastAndFill);

            if (bool.TryParse(i_PropertiesToCastAndFill[0], out bool hasHazardous))
            {
                HasHazardous = hasHazardous;
            }
            else
            {
                throw new FormatException("Problem parsing the string to value...");
            }

            if (float.TryParse(i_PropertiesToCastAndFill[1], out float maxCarry))
            {
                MaxCarry = maxCarry;
            }
            else
            {
                throw new FormatException("Problem parsing the string to value...");
            }

            i_PropertiesToCastAndFill.RemoveRange(0, 2);
        }
    }
}
