using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterTutorial.Configuration
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    class Configuration:System.Attribute
    {
        public string Name;
        public static Description;

        public Configuration(string name)
        {
            Name = name;
        }

    }
}
