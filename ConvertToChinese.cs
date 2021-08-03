using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rmb
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertToChinese("-900000000000078000.08"));

        }

        static string ConvertToChinese(string x)
        {

            string[] sArray = x.Split('.');
            string zs = double.Parse(sArray[0]).ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#");
            string xs = ".0B0A";
            if (sArray.Length == 2)
            {
                if (double.Parse(sArray[1]) > 0)
                {
                    xs = double.Parse("0." + sArray[1]).ToString(".#B#A");
                }

            }
            string s = zs + xs;
            string d = Regex.Replace(s, @"((?'a'-)[\D]*)|((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${a}${b}${z}");
            string st = Regex.Replace(d, ".",
                options => "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟萬億兆京垓秭穰"[options.Value[0] - 45].ToString());
            return Regex.Replace(st, "[\u5143]$", "元整");
        }
    }

}
