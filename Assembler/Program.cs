internal class Program
{
    private static void Main(string[] args)
    {
        string f2r = @"Prog.asm";
        string[] lines = File.ReadAllLines(f2r);
        List<string> l_list = new List<string>(lines);
        l_list = format_lines(l_list);

        foreach (string line in l_list)
        {
            Console.WriteLine(line);
        }

        Dictionary<string, int> special_cases = new Dictionary<string, int>
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


    static string remove_comments(string l)
    {
        if (l.Contains("//"))
        {
            var ind = l.IndexOf("//");
            if (ind >= 0)
            {
                l = l.Remove(ind);
            }
        }
        return l;
    }
}