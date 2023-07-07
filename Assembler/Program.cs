using System.IO;

internal class Program
{
    static Dictionary<string, int> special_cases = new Dictionary<string, int>
        {
            {"SP", 0},
            {"LCL", 1},
            {"ARG", 2},
            {"THIS", 3},
            {"THAT", 4},
            {"SCREEN", 16384},
            {"KBD", 24576},
            {"R0", 0},
            {"R1", 1},
            {"R2", 2},
            {"R3", 3},
            {"R4", 4},
            {"R5", 5},
            {"R6", 6},
            {"R7", 7},
            {"R8", 8},
            {"R9", 9},
            {"R10", 10},
            {"R11", 11},
            {"R12", 12},
            {"R13", 13},
            {"R14", 14},
            {"R15", 15}
        };

    static Dictionary<string, int> used_keywords = new Dictionary<string, int>();

    static Dictionary<string, int>

    static int n = 16;
    private static void Main(string[] args)
    {
        string f2r = @"Prog.asm";
        List<string> lines = File.ReadLines(f2r).ToList();
        lines = format_lines(lines);
        string binary_line;
        string temp;
        foreach (string line in lines)
        {
            if (line.StartsWith("@"))
            {
                //remove @ symbol
                temp = line.Replace("@", "");
                binary_line = a_instruction(temp);
                Console.WriteLine(binary_line);
            }
            else if (line.StartsWith("("))
            {
                if(!line.EndsWith(")"))
                {
                    Console.WriteLine("Cannot Parse Line.");
                    return;//error out
                }
                else
                {
                    temp = line.Replace("(", "");
                    temp = line.Replace(")", "");
                    binary_line = a_instruction(temp);
                    Console.WriteLine(binary_line);
                }
            }
            else
            {

                Console.WriteLine(line);
            }
        }
    }

    static List<string> format_lines(List<string> lines)
    {
        List<string> result = new List<string>();

        foreach (var line in lines)
        {
            //remove all commented lines and comments inline
            string formatted_line = remove_comments(line);
            //remove all whitespace from in front and behind
            formatted_line = formatted_line.Trim();
            //remove all whitespace between
            formatted_line = formatted_line.Replace(" ", "");
            if (!string.IsNullOrEmpty(formatted_line))
            {
                result.Add(formatted_line);
            }
        }
        return result;
    }


    static string remove_comments(string s)
    {
        if (s.Contains("//"))
        {
            var ind = s.IndexOf("//");
            if (ind >= 0)
            {
                s = s.Remove(ind);
            }
        }
        return s;
    }

    static string a_instruction(string s)
    {
        string result;
        //if the string is a special case
        if (special_cases.ContainsKey(s))
        {
            result = convert_to_binary(special_cases[s]);
        }
        else if (used_keywords.ContainsKey(s))
        {
            result = convert_to_binary(used_keywords[s]);
        }
        else if (int.TryParse(s, out int number))
        {
            result = convert_to_binary(number);
        }
        else //this is not in the previous cases but is a word, not a number
        {
            result = convert_to_binary(n);
            used_keywords.Add(s, n);
            n += 1;
        }

        return result;
    }

    static string convert_to_binary(int value)
    {
        string s = "0";
        string temp = Convert.ToString(value, 2);
        temp = temp.PadLeft(15, '0');
        s += temp;

        return s;
    }

    static string c_instruction(string s)
    {
        string result = "";

        

        return result;
    }
}