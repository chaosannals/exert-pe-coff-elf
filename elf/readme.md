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
    unsigned char e_ident[EI_NIDENT];
    Elf32_Half e_type;
    Elf32_Half e_machine;
    Elf32_Word e_version;
    Elf32_Addr e_entry; // 程序入口地址
    Elf32_Off e_phoff; // 程序头表文件偏移
    Elf32_Off e_shoff; // 段头表文件偏移
    Elf32_Word e_flags;
    Elf32_Half e_ehsize; // ELF 头大小
    Elf32_Half e_phentsize; // 单个程序头大小
    Elf32_Half e_phnum; // 程序头数量
    Elf32_Half e_shentsize; // 单个段头大小
    Elf32_Half e_shnum; // 段头数量
    Elf32_Half e_shstrndx;
} Elf32_Ehdr;
```

### 程序头

```c++
typedef struct {
    Elf32_Word p_type;
    Elf32_Off p_offset;
    Elf32_Addr p_vaddr;
    Elf32_Addr p_paddr;
    Elf32_Wordp_filesz;
    Elf32_Word p_memsz;
    Elf32_Word p_flags;
    Elf32_Word p_align;
} Elf32_Phdr;
```
