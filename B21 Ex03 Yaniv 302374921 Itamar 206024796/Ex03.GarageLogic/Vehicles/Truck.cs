using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Truck : PetrolVehicle
    {
        public bool HasHazardous { get; set; }
        public float MaxCarry { get; set; }

        public Truck() : base()
        {

        }

        public Truck(string i_ModelName, float i_CurrentEnergy)
            : base(i_ModelName, i_CurrentEnergy)
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
