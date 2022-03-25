using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iced.Intel;

namespace ElfConsole
{
    public static class X86Dump
    {
        const int HEXBYTES_COLUMN_BYTE_LENGTH = 10;

        public static void Dump(this byte[] raw, ulong sip, int bitness = 32)
        {
            var bcr = new ByteArrayCodeReader(raw);
            var d = Decoder.Create(bitness, bcr);
            d.IP = sip;
            var eip = d.IP + (ulong)raw.Length;

            var instructions = new List<Instruction>();
            while (d.IP < eip)
            {
                instructions.Add(d.Decode());
            }

            var f = new NasmFormatter();
            f.Options.DigitSeparator = "`";
            f.Options.FirstOperandCharIndex = 10;
            var output = new StringOutput();
            foreach (var instr in instructions)
            {
                f.Format(instr, output);
                Console.Write(instr.IP.ToString("X16"));
                Console.Write(" ");
                int il = instr.Length;
                int bbi = (int)(instr.IP - sip);
                for (int i = 0; i < il; ++i)
                {
                    Console.Write(raw[bbi + i].ToString("X2"));
                }
                int missingbs = HEXBYTES_COLUMN_BYTE_LENGTH - il;
                for (int i = 0; i < missingbs; ++i)
                {
                    Console.Write("  ");
                }
                Console.Write("  ");
                Console.WriteLine(output.ToStringAndReset());
            }
        }
    }
}
