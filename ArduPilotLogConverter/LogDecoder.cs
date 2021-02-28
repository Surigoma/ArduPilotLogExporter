using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduPilotLogConverter
{
    public struct ConvertOption
    {
        public bool Liner;
        public bool RCFloat;
    }
    public class LogType
    {
        public Type type;
        public string name;
        public int amp = 1;
        public static LogType create(Type type, string name, int amp = 1)
        {
            LogType unit = new LogType();
            unit.type = type;
            unit.name = name;
            unit.amp = amp;
            return unit;
        }
        public string convert(string value, float multi)
        {
            switch (this.type.Name)
            {
                case "int":
                case "Int16":
                case "Int32":
                    return ((int)(float.Parse(value) * (float)this.amp * (float)multi)).ToString();
                case "Int64":
                    return ((Int64)(float.Parse(value) * (float)this.amp * (float)multi)).ToString();
                case "uint":
                case "UInt16":
                case "UInt32":
                    return ((uint)(float.Parse(value) * (float)this.amp * (float)multi)).ToString();
                case "UInt64":
                    return ((UInt64)(float.Parse(value) * (float)this.amp * (float)multi)).ToString();
                case "float":
                    return (float.Parse(value) * (float)this.amp * multi).ToString();
                case "double":
                    return (double.Parse(value) * (double)this.amp * (double)multi).ToString();
                case "char":
                case "string":
                    return value;
            }
            return Convert.ChangeType(value, this.type).ToString();
        }
    }
    public class LogFormat
    {
        public int id;
        public List<LogFormatValue> values;
    }
    public class LogFormatValue
    {
        public char format;
        public string name;
        public char unit = '?';
        public char multi = '?';
        public string convert(Dictionary<char, LogType> types, Dictionary<char, float> multis, string value)
        {
            LogType type = types[this.format];
            float multi = multis.ContainsKey(this.multi) ? multis[this.multi] : 0.0f;
            multi = multi <= 0.0f ? 1.0f : multi;
            if (type == null)
                return value;
            return type == null ? value : type.convert(value, multi);
        }
    }

    public class LogDecoder
    {
        public Dictionary<char, LogType> Types = new Dictionary<char, LogType>();
        public Dictionary<char, string> Units = new Dictionary<char, string>();
        public Dictionary<char, float> Multis = new Dictionary<char, float>();
        public Dictionary<string, LogFormat> Formats = new Dictionary<string, LogFormat>();

        public Dictionary<string, double> Params = new Dictionary<string, double>();
        public List<string[]> Values = new List<string[]>();

        public void init()
        {
            //Units.Clear();
            if (Types.Count <= 0)
            {
                generateType();
            }
            Multis.Clear();
            Params.Clear();
            Values.Clear();
        }
        private void generateType()
        {
            Types.Add('a', LogType.create(typeof(int), "int16_t[32]"));
            Types.Add('b', LogType.create(typeof(int), "int8_t"));
            Types.Add('B', LogType.create(typeof(uint), "uint8_t"));
            Types.Add('h', LogType.create(typeof(Int16), "int16_t"));
            Types.Add('H', LogType.create(typeof(UInt16), "uint16_t"));
            Types.Add('i', LogType.create(typeof(Int32), "int32_t"));
            Types.Add('I', LogType.create(typeof(UInt32), "uint32_t"));
            Types.Add('f', LogType.create(typeof(float), "float"));
            Types.Add('d', LogType.create(typeof(double), "double"));
            Types.Add('n', LogType.create(typeof(string), "char[4]"));
            Types.Add('N', LogType.create(typeof(string), "char[16]"));
            Types.Add('Z', LogType.create(typeof(string), "char[64]"));
            Types.Add('L', LogType.create(typeof(double), "int32_t latitude/longitude (so -35.1332423 becomes -351332423)"));
            Types.Add('M', LogType.create(typeof(string), "Fright mode"));
            Types.Add('q', LogType.create(typeof(Int64), "int64_t"));
            Types.Add('Q', LogType.create(typeof(UInt64), "uint64_t"));
            Types.Add('c', LogType.create(typeof(float), "int16_t", 100));
            Types.Add('C', LogType.create(typeof(float), "uint16_t", 100));
            Types.Add('e', LogType.create(typeof(float), "int32_t", 100));
            Types.Add('E', LogType.create(typeof(float), "uint32_t", 100));
        }
        public bool load(StreamReader streamReader)
        {
            if (streamReader == null)
                return false;

            while (!streamReader.EndOfStream)
            {
                string oneLine = streamReader.ReadLine();
                string[] csv = oneLine.Split(',');
                List<string> remove_sp = new List<string>();
                foreach (string item in csv)
                {
                    remove_sp.Add(item.Trim());
                }
                switch (remove_sp[0])
                {
                    case "FMT":
                        // Define format
                        {
                            LogFormat logFormat = new LogFormat();
                            logFormat.id = int.Parse(remove_sp[1]);
                            logFormat.values = new List<LogFormatValue>();
                            for (int i = 0; i < remove_sp[4].Length; i++)
                            {
                                LogFormatValue logFormatValue = new LogFormatValue();
                                logFormatValue.name = remove_sp[5 + i];
                                logFormatValue.format = remove_sp[4][i];
                                logFormat.values.Add(logFormatValue);
                            }
                            Formats[remove_sp[3]] = logFormat;
                        }
                        break;
                    case "UNIT":
                        //Define Unit
                        {
                            char unit = (char)int.Parse(remove_sp[2]);
                            if (!Units.ContainsKey(unit))
                            {
                                Units.Add(unit, remove_sp[3]);
                            }
                            else
                            {
                                Units[unit] = remove_sp[3];
                            }
                        }
                        break;
                    case "FMTU":
                        foreach(KeyValuePair<string, LogFormat> keyValuePair in Formats)
                        {
                            if (keyValuePair.Value.id == int.Parse(remove_sp[2]))
                            {
                                LogFormat logFormat = keyValuePair.Value;
                                for (int i=0; i< remove_sp[3].Length;i++)
                                {
                                    logFormat.values[i].unit = remove_sp[3][i];
                                    logFormat.values[i].multi = remove_sp[4][i];
                                }
                                break;
                            }
                        }
                        break;
                    case "MULT":
                        //Define Multi
                        {
                            char multi = (char)int.Parse(remove_sp[2]);
                            if (!Multis.ContainsKey(multi))
                            {
                                Multis.Add(multi, float.Parse(remove_sp[3]));
                            }
                            else
                            {
                                Multis[multi] = float.Parse(remove_sp[3]);
                            }
                        }
                        break;
                    case "EV":
                        //Define Event
                        break;
                    case "PARM":
                        //Define Option param
                        if (!Params.ContainsKey(remove_sp[2]))
                        {
                            Params.Add(remove_sp[2], double.Parse(remove_sp[3]));
                        }
                        else
                        {
                            Params[remove_sp[2]] = double.Parse(remove_sp[3]);
                        }
                        break;
                    default:
                        //Other (Value of someting parametor)
                        Values.Add(remove_sp.ToArray());
                        break;
                }
            }
            return true;
        }
        public bool writeFile(string[] Categories, string[] Items, string filePath)
        {
            SortedDictionary<long, string[]> outputData = new SortedDictionary<long, string[]>();
            string[] CategoryFormats = new string[Items.Length];
            LogFormatValue[] ItemFormats = new LogFormatValue[Items.Length];
            StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8);

            for (int i = 0; i < Items.Length; i++)
            {
                string[] vs = Items[i].Split('.');
                CategoryFormats[i] = vs[0];
                if (Formats.ContainsKey(CategoryFormats[i]))
                {
                    LogFormat lf = Formats[CategoryFormats[i]];
                    foreach(LogFormatValue logFormatValue in lf.values)
                    {
                        if (logFormatValue.name == vs[1])
                        {
                            ItemFormats[i] = logFormatValue;
                            break;
                        }
                    }
                }
            }
            foreach(string[] values in Values)
            {
                int itemIndex = Array.IndexOf(Categories, values[0]);
                if (itemIndex < 0)
                {
                    continue;
                }
                string CategoryName = Categories[itemIndex];
                LogFormat logFormat = Formats[CategoryName];
                long logTime = long.Parse(values[1]);
                string[] data = null;
                if (outputData.ContainsKey(logTime))
                {
                    data = outputData[logTime];
                }
                else
                {
                    data = new string[Items.Length];
                    outputData[logTime] = data;
                }
                for (int i = 0; i < Items.Length; i++)
                {
                    for (int ii = 0; ii < logFormat.values.Count; ii++)
                    {
                        LogFormatValue logFormatValue = logFormat.values[ii];
                        if (Items[i] != CategoryName + "." + logFormatValue.name)
                        {
                            continue;
                        }
                        data[i] = logFormatValue.convert(Types, Multis, values[1 + ii]);
                    }
                }
            }
            string[] header = new string[Items.Length];
            for (int i = 0; i< Items.Length; i++)
            {
                string unit = "";
                if (Units.ContainsKey(ItemFormats[i].unit))
                {
                    unit = Units[ItemFormats[i].unit];
                }
                header[i] = CategoryFormats[i] + "." + ItemFormats[i].name + (unit == "" ? "" : " (" + unit + ")");
            }
            streamWriter.WriteLine("Time (us)," + String.Join(",", header));
            foreach (KeyValuePair<long, string[]> values in outputData.ToArray())
            {
                streamWriter.WriteLine(values.Key + "," + String.Join(",", values.Value));
            }
            streamWriter.Close();
            return true;
        }
    }
}
