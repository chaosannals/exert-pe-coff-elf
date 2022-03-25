using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using Iced.Intel;
using ElfConsole;

var here = Environment.CurrentDirectory;

Console.WriteLine(here);

Console.WriteLine("boot --------------------------");

var bootp = Path.Combine(here, "boot.bin");
if (File.Exists(bootp))
{
    var c = File.ReadAllBytes(bootp);
    c?.Dump(0x7c00, 16);
}

Console.WriteLine("init --------------------------");

var initp = Path.Combine(here, "init.bin");
if (File.Exists(initp))
{
    var c = File.ReadAllBytes(initp);
    c?.Dump(0x7c00, 16);
}


Console.WriteLine("elf --------------------------");

foreach (string p in Directory.GetFiles(here, "*.elf"))
{
    Console.WriteLine(p);

    var elf = ELFReader.Load(p);
    foreach (var h in elf.GetSections<ProgBitsSection<uint>>().Where(x => x.LoadAddress != 0))
    {
        Console.WriteLine($"{h.Flags} => {h}");

        var c = h.GetContents();
        c?.Dump(h.LoadAddress, 32);
    }
}