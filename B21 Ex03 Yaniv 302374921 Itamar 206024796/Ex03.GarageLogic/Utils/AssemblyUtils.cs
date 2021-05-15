using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.GarageLogic
{
    class AssemblyUtils
    {
        public static Dictionary<string, Type> GetDictOfNamesAndTypesOfASubClass(Type i_SubClassOf, bool i_ContainAbastract)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Dictionary<string, Type> classNameTypes = new Dictionary<string, Type>();

            foreach (Type classType in assembly.GetTypes())
            {
                if (classType.IsSubclassOf(i_SubClassOf) && classType.IsAbstract == i_ContainAbastract)
                {
                    classNameTypes.Add(classType.Name, classType);
                }
            }

            return classNameTypes;
        }
    }
}
