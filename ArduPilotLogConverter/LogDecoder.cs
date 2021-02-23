using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduPilotLogConverter
{
    class LogUnit
    {
        public Type type;
        public string name;
        public static LogUnit create(Type type, string name)
        {
            LogUnit unit = new LogUnit();
            unit.type = type;
            unit.name = name;
            return unit;
        }
        public class FrightMode
        {
            readonly string[] modes = {
                    ""
                };
            public string ToString(int mode)
            {
                return base.ToString();
            }
        }
        public string convert(string value, float multi)
        {
            switch (this.type.ToString())
            {
                case "int":
                case "Int16":
                case "Int32":
                    return (int.Parse(value) * (int)multi).ToString();
                case "uint":
                case "UInt16":
                case "UInt32":
                    return (uint.Parse(value) * (uint)multi).ToString();
                case "float":
                    return (float.Parse(value) * multi).ToString();
                case "double":
                    return (double.Parse(value) * (double)multi).ToString();
                case "char":
                case "string":
                    return value;
            }
            return Convert.ChangeType(value, this.type).ToString();
        }
    }
    class LogFormat
    {
        public char format;
        public char name;
        public string convert(Dictionary<char, LogUnit> units, string value, float multi)
        {
            LogUnit unit = units[this.format];
            if (unit == null)
                return value;
            return unit == null ? value : unit.convert(value, multi);
        }
    }

    class LogDecoder
    {
        public Dictionary<char, LogUnit> Units = new Dictionary<char, LogUnit>();
        public Dictionary<char, float> Multis = new Dictionary<char, float>();
        public Dictionary<string, double> Params = new Dictionary<string, double>();
        public Dictionary<long, string[]> Values = new Dictionary<long, string[]>();

        public void init()
        {
            //Units.Clear();
            if (Units.Count <= 0)
            {
                generateUnit();
            }
            Multis.Clear();
            Params.Clear();
            Values.Clear();
        }
        private void generateUnit()
        {
            Units.Add('a', LogUnit.create(typeof(int), "int16_t[32]"));
            Units.Add('b', LogUnit.create(typeof(int), "int8_t"));
            Units.Add('B', LogUnit.create(typeof(uint), "uint8_t"));
            Units.Add('h', LogUnit.create(typeof(Int16), "int16_t"));
            Units.Add('H', LogUnit.create(typeof(UInt16), "uint16_t"));
            Units.Add('i', LogUnit.create(typeof(Int32), "int32_t"));
            Units.Add('I', LogUnit.create(typeof(UInt32), "uint32_t"));
            Units.Add('f', LogUnit.create(typeof(float), "float"));
            Units.Add('d', LogUnit.create(typeof(double), "double"));
            Units.Add('n', LogUnit.create(typeof(string), "char[4]"));
            Units.Add('N', LogUnit.create(typeof(string), "char[16]"));
            Units.Add('Z', LogUnit.create(typeof(string), "char[64]"));
            Units.Add('L', LogUnit.create(typeof(double), "	int32_t latitude/longitude (so -35.1332423 becomes -351332423)"));
            Units.Add('M', LogUnit.create(typeof(string), "char[64]"));
        }
        public bool load(StreamReader streamReader)
        {
            if (streamReader == null)
                return false;

            while (!streamReader.EndOfStream)
            {
                string oneLine = streamReader.ReadLine();
                string[] csv = oneLine.Split(',');
                switch (csv[0])
                {
                    case "FMT":
                        // Define format
                        break;
                    case "UNIT":
                        //Define Unit
                        break;
                    case "MULT":
                        //Define Multi
                        break;
                    case "EV":
                        //Define Event
                        break;
                    case "PARM":
                        //Define Option param
                        break;
                    default:
                        //Other (Value of someting parametor)
                        break;
                }

            }
            return true;
        }
        public bool writeFile (string filePath)
        {
            return false;
        }
    }
}
