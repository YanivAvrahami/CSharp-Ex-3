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

            initHazardousFromStr(i_PropertiesToCastAndFill[0]);
            initMaxCarryFromStr(i_PropertiesToCastAndFill[1]);

            i_PropertiesToCastAndFill.RemoveRange(0, 2);
        }

        private void initHazardousFromStr(string i_HasHazStr)
        {
            if (bool.TryParse(i_HasHazStr, out bool hasHazardous))
            {
                HasHazardous = hasHazardous;
            }
            else
            {
                throw new FormatException("Problem parsing the string to value...");
            }
        }

        private void initMaxCarryFromStr(string i_MaxCarryStr)
        {
            if (float.TryParse(i_MaxCarryStr, out float maxCarry))
            {
                MaxCarry = maxCarry;
            }
            else
            {
                throw new FormatException("Problem parsing the string to value...");
            }
        }
    }
}
