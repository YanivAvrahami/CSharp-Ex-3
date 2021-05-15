using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class RegularTruck : PetrolVehicle
    {
        public bool HasHazardous { get; set; }
        public float MaxCarry { get; set; }

        public RegularTruck()
            : base(16, 26f, eFuelType.Soler, 120f)
        {
        }

        public override List<string> PropertiesNeededToFillForTheSpecificVehicle()
        {
            throw new System.NotImplementedException();
        }

        public override void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            throw new System.NotImplementedException();
        }
    }
}
