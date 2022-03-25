# Executable and Linkable Format

## ELF 头

- Elf32_Addr 4
- Elf32_Half 2
- Elf32_Off 4
- Elf32_Sword 4
- Elf32_Word 4

```c++
#define EI_NIDENT 16
typedef struct{
    unsigned char e_ident[EI_NIDENT]; // 0x00
    Elf32_Half e_type; // 0x10
    Elf32_Half e_machine; // 0x12
    Elf32_Word e_version; // 0x14
    Elf32_Addr e_entry; // 0x18 程序入口地址
    Elf32_Off e_phoff; // 0x1C 程序头表文件偏移
    Elf32_Off e_shoff; // 0x20 段头表文件偏移
    Elf32_Word e_flags; // 0x24 
    Elf32_Half e_ehsize; // 0x28 ELF 头大小
    Elf32_Half e_phentsize; // 0x2A 单个程序头大小
    Elf32_Half e_phnum; // 0x2C 程序头数量
    Elf32_Half e_shentsize; // 0x2E 单个段头大小
    Elf32_Half e_shnum; // 0x30 段头数量
    Elf32_Half e_shstrndx; // 0x32 
} Elf32_Ehdr;
```

### 程序头

```c++
typedef struct {
    Elf32_Word p_type; // 类型
    Elf32_Off p_offset; // 文件中偏移
    Elf32_Addr p_vaddr; // 
    Elf32_Addr p_paddr; // 被加载到内存中的地址
    Elf32_Wordp_filesz; // 段在文件中字节数
    Elf32_Word p_memsz; // 段在内存中字节数
    Elf32_Word p_flags; // 段标志
    Elf32_Word p_align; // 从文件到内存的对齐策略
} Elf32_Phdr;
```
