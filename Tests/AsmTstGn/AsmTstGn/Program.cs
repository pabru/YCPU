﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ypsilon.Assembler;

namespace AsmTstGn
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter file;

            Directory.CreateDirectory("..\\..\\..\\..\\bld");

            using (file = new System.IO.StreamWriter("..\\..\\..\\..\\bld\\AsmTstGn-0.asm"))
            {
                file.WriteLine(generateALU());

                file.WriteLine(generateJMP());
                file.WriteLine(generateJMP_Far());
            }
            using (file = new System.IO.StreamWriter("..\\..\\..\\..\\bld\\AsmTstGn-1.asm"))
            {
                file.WriteLine(generateAL8());

                file.WriteLine(generateBRA());
                file.WriteLine(generateSHF());
                file.WriteLine(generateBTT());
                file.WriteLine(generateFLG());
                file.WriteLine(generateSTK());
                file.WriteLine(generateSFL());
                file.WriteLine(generateMMU());
                file.WriteLine(generateSET());
                file.WriteLine(generateIMM());
                file.WriteLine(generateIMM2());
                file.WriteLine(generateHWQ());
                file.WriteLine(generateMISC());
            }
        }

        static string generateALU()
        {
            // generate alu ops
            string[] ins = new string[] { 
                "cmp", "neg", "add", "sub",
                "adc", "sbc", "mul", "div",
                "mli", "dvi", "mod", "mdi",
                "and", "orr", "eor", "not",
                "lod", "sto" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate, AddressingMode.Absolute, 
                AddressingMode.ProcessorRegister,
                AddressingMode.Register, AddressingMode.Indirect,
                AddressingMode.IndirectOffset, AddressingMode.StackAccess,
                AddressingMode.IndirectPostInc, AddressingMode.IndirectPreDec,
                AddressingMode.IndirectIndexed };

            StringBuilder sb = new StringBuilder();
            generateInstructions2p(sb, ins, modes, "$FFEE");
            return sb.ToString();
        }

        static string generateAL8()
        {
            // generate alu ops
            string[] ins = new string[] { 
                "cmp.8", "neg.8", "add.8", "sub.8",
                "adc.8", "sbc.8", "mul.8", "div.8",
                "mli.8", "dvi.8", "mod.8", "mdi.8",
                "and.8", "orr.8", "eor.8", "not.8",
                "lod.8", "sto.8" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate, AddressingMode.Absolute, 
                // can't use .8 flag with processor registers.
                AddressingMode.Register, AddressingMode.Indirect,
                AddressingMode.IndirectOffset, AddressingMode.StackAccess,
                AddressingMode.IndirectPostInc, AddressingMode.IndirectPreDec,
                AddressingMode.IndirectIndexed };

            StringBuilder sb = new StringBuilder();
            generateInstructions2p(sb, ins, modes, "$00C8");
            return sb.ToString();
        }

        static string generateBRA()
        {
            string[] ins = new string[] { 
                "bcc", "buf", "bcs", "buh",
                "bne", "beq", "bpl", "bsf",
                "bmi", "bsh", "bvc", "bvs",
                "bug", "bsg", "baw" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate };

            StringBuilder sb = new StringBuilder();
            generateInstructions1p(sb, ins, modes, "$7F");
            return sb.ToString();
        }

        static string generateSHF()
        {
            string[] ins = new string[] { 
                "asl", "lsl", "rol", "rnl",
                "asr", "lsr", "ror", "rnr" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate, AddressingMode.Register };

            StringBuilder sb = new StringBuilder();
            generateInstructions2p(sb, ins, modes, "13");
            return sb.ToString();
        }

        static string generateBTT()
        {
            string[] ins = new string[] { 
                "btt", "btx", "btc", "bts" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate, AddressingMode.Register };

            StringBuilder sb = new StringBuilder();
            generateInstructions2p(sb, ins, modes, "11");
            return sb.ToString();
        }

        static string generateFLG()
        {
            string[] ins = new string[] { 
                "sef", "clf" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate };

            StringBuilder sb = new StringBuilder();
            // generateInstructions1p(sb, ins, modes, "r0, r1, r2, r3, r4, r5, r6, r7" );
            // generateInstructions1p(sb, ins, modes, "r0, r1, r2, r3, r4, r5, r6, r7");
            generateInstructions1p(sb, ins, modes, "n, z, c, v");
            return sb.ToString();
        }

        static string generateSTK()
        {
            string[] ins = new string[] { 
                "psh", "pop" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate };

            StringBuilder sb = new StringBuilder();
            generateInstructions1p(sb, ins, modes, "r0, r1, r2, r3, r4, r5, r6, r7" );
            generateInstructions1p(sb, ins, modes, "fl, pc, ps, usp, sp, ii, ia, p2");
            return sb.ToString();
        }

        static string generateSFL()
        {
            string[] ins = new string[] { 
                "sfl" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate };

            StringBuilder sb = new StringBuilder();
            generateInstructions1p(sb, ins, modes, "$21");
            return sb.ToString();
        }

        static string generateSET()
        {
            // generate alu ops
            string[] ins = new string[] { 
                "set" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate };

            StringBuilder sb = new StringBuilder();
            generateInstructions2p(sb, ins, modes, "$00");
            generateInstructions2p(sb, ins, modes, "$07");
            generateInstructions2p(sb, ins, modes, "$12");
            generateInstructions2p(sb, ins, modes, "$1F");
            generateInstructions2p(sb, ins, modes, "$0020");
            generateInstructions2p(sb, ins, modes, "$0100");
            generateInstructions2p(sb, ins, modes, "$4000");
            generateInstructions2p(sb, ins, modes, "$FFEF");
            return sb.ToString();
        }

        static string generateIMM()
        {
            // generate alu ops
            string[] ins = new string[] { 
                "inc", "dec" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate };

            StringBuilder sb = new StringBuilder();
            generateInstructions1p(sb, ins, modes, "r0");
            generateInstructions1p(sb, ins, modes, "r1");
            generateInstructions1p(sb, ins, modes, "r2");
            generateInstructions1p(sb, ins, modes, "r3");
            generateInstructions1p(sb, ins, modes, "r4");
            generateInstructions1p(sb, ins, modes, "r5");
            generateInstructions1p(sb, ins, modes, "r6");
            generateInstructions1p(sb, ins, modes, "r7");
            return sb.ToString();
        }

        static string generateIMM2()
        {
            string[] ins = new string[] { 
                "adi", "sbi" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate };

            StringBuilder sb = new StringBuilder();
            generateInstructions2p(sb, ins, modes, "$01");
            generateInstructions2p(sb, ins, modes, "$04");
            generateInstructions2p(sb, ins, modes, "$08");
            generateInstructions2p(sb, ins, modes, "$0F");
            generateInstructions2p(sb, ins, modes, "$10");
            generateInstructions2p(sb, ins, modes, "$12");
            generateInstructions2p(sb, ins, modes, "$18");
            generateInstructions2p(sb, ins, modes, "$20");
            return sb.ToString();
        }

        static string generateMMU()
        {
            // generate alu ops
            string[] ins = new string[] { 
                "mmr", "mmw" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Register };

            StringBuilder sb = new StringBuilder();
            generateInstructions2p(sb, ins, modes, "");

            ins = new string[] { 
                "mml", "mms" };
            modes = new AddressingMode[] {
                AddressingMode.Immediate };
            generateInstructions1p(sb, ins, modes, "r0");
            generateInstructions1p(sb, ins, modes, "r1");
            generateInstructions1p(sb, ins, modes, "r2");
            generateInstructions1p(sb, ins, modes, "r3");
            generateInstructions1p(sb, ins, modes, "r4");
            generateInstructions1p(sb, ins, modes, "r5");
            generateInstructions1p(sb, ins, modes, "r6");
            generateInstructions1p(sb, ins, modes, "r7");
            return sb.ToString();
        }

        static string generateJMP()
        {
            // generate alu ops
            string[] ins = new string[] { 
                "jmp", "jsr" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate, AddressingMode.Absolute, 
                AddressingMode.Register, AddressingMode.Indirect,
                AddressingMode.IndirectOffset, AddressingMode.StackAccess,
                AddressingMode.IndirectPostInc, AddressingMode.IndirectPreDec,
                AddressingMode.IndirectIndexed };

            StringBuilder sb = new StringBuilder();
            generateInstructions1p(sb, ins, modes, "$8000");
            return sb.ToString();
        }

        static string generateJMP_Far()
        {
            // generate alu ops
            string[] ins = new string[] { 
                "jmp.f", "jsr.f" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate };

            StringBuilder sb = new StringBuilder();
            generateInstructions1p(sb, ins, modes, "$8000, $1001");

            modes = new AddressingMode[] {
                AddressingMode.Absolute, 
                AddressingMode.Register, AddressingMode.Indirect,
                AddressingMode.IndirectOffset, AddressingMode.StackAccess,
                AddressingMode.IndirectPostInc, AddressingMode.IndirectPreDec,
                AddressingMode.IndirectIndexed };

            generateInstructions1p(sb, ins, modes, "$8000");
            return sb.ToString();
        }

        static string generateHWQ()
        {
            string[] ins = new string[] { 
                "hwq" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.Immediate };

            StringBuilder sb = new StringBuilder();
            generateInstructions1p(sb, ins, modes, "$00");
            generateInstructions1p(sb, ins, modes, "$01");
            generateInstructions1p(sb, ins, modes, "$02");
            generateInstructions1p(sb, ins, modes, "$03");
            return sb.ToString();
        }

        static string generateMISC()
        {
            string[] ins = new string[] { 
                "slp", "swi", "rti", "rts", "nop" };

            AddressingMode[] modes = new AddressingMode[] {
                AddressingMode.None };

            StringBuilder sb = new StringBuilder();
            generateInstructions1p(sb, ins, modes, "");
            return sb.ToString();
        }

        static void generateInstructions1p(StringBuilder sb, string[] instructions, AddressingMode[] modes, string immediate)
        {
            foreach (string instruction in instructions)
            {
                foreach (AddressingMode mode in modes)
                {
                    string addr;
                    switch (mode)
                    {
                        case AddressingMode.None:
                            sb.AppendLine(instruction);
                            break;
                        case AddressingMode.Immediate:
                            if (instruction == "sto")
                                continue;
                            addr = immediate;
                            sb.AppendLine(string.Format("{0} {1}", instruction, addr));
                            break;
                        case AddressingMode.Absolute:
                            addr = immediate;
                            sb.AppendLine(string.Format("{0} [{1}]", instruction, addr));
                            break;
                        case AddressingMode.Register:
                            if (instruction == "sto")
                                continue;
                            for (int r1 = 0; r1 < 8; r1++)
                                sb.AppendLine(string.Format("{0} r{1}", instruction, r1));
                            break;
                        case AddressingMode.Indirect:
                            for (int r1 = 0; r1 < 8; r1++)
                                sb.AppendLine(string.Format("{0} [r{1}]", instruction, r1));
                            break;
                        case AddressingMode.IndirectOffset:
                            for (int r1 = 0; r1 < 8; r1++)
                                sb.AppendLine(string.Format("{0} [r{1},{2}]", instruction, r1, immediate));
                            break;
                        case AddressingMode.StackAccess:
                            for (int s = 0; s < 8; s++)
                                sb.AppendLine(string.Format("{0} S[${1}]", instruction, s));
                            break;
                        case AddressingMode.IndirectPostInc:
                            for (int r1 = 0; r1 < 8; r1++)
                                sb.AppendLine(string.Format("{0} [r{1}+]", instruction, r1));
                            break;
                        case AddressingMode.IndirectPreDec:
                            for (int r1 = 0; r1 < 8; r1++)
                                sb.AppendLine(string.Format("{0} [-r{1}]", instruction, r1));
                            break;
                        case AddressingMode.IndirectIndexed:
                            for (int r1 = 0; r1 < 8; r1++)
                                for (int r2 = 0; r2 < 8; r2++)
                                    sb.AppendLine(string.Format("{0} [r{1},r{2}]", instruction, r1, r2));
                            break;
                        default:
                            throw new Exception();
                    }
                }
            }
        }

        static void generateInstructions2p(StringBuilder sb, string[] instructions, AddressingMode[] modes, string immediate)
        {
            foreach (string instruction in instructions)
            {
                for (int r = 0; r < 8; r++)
                {
                    foreach (AddressingMode mode in modes)
                    {
                        string addr;
                        switch (mode)
                        {
                            case AddressingMode.Immediate:
                                if (instruction == "sto" || instruction == "sto.8")
                                    continue;
                                addr = immediate;
                                sb.AppendLine(string.Format("{0} r{1}, {2}", instruction, r, addr));
                                break;
                            case AddressingMode.Absolute:
                                addr = immediate;
                                sb.AppendLine(string.Format("{0} r{1}, [{2}]", instruction, r, addr));
                                break;
                            case AddressingMode.ProcessorRegister:
                                string[] procRegs = new string[] { "fl", "pc", "ps", "p2", "ii", "ia", "sp", "usp" };
                                for (int i = 0; i < 8; i++)
                                    sb.AppendLine(string.Format("{0} r{1}, {2}", instruction, r, procRegs[i]));
                                break;
                            case AddressingMode.Register:
                                if (instruction == "sto" || instruction == "sto.8")
                                    continue;
                                for (int r1 = 0; r1 < 8; r1++)
                                    sb.AppendLine(string.Format("{0} r{1}, r{2}", instruction, r, r1));
                                break;
                            case AddressingMode.Indirect:
                                for (int r1 = 0; r1 < 8; r1++)
                                    sb.AppendLine(string.Format("{0} r{1}, [r{2}]", instruction, r, r1));
                                break;
                            case AddressingMode.IndirectOffset:
                                for (int r1 = 0; r1 < 8; r1++)
                                    sb.AppendLine(string.Format("{0} r{1}, [r{2},{3}]", instruction, r, r1, immediate));
                                break;
                            case AddressingMode.StackAccess:
                                for (int s = 0; s < 8; s++)
                                    sb.AppendLine(string.Format("{0} r{1}, S[${2}]", instruction, r, s));
                                break;
                            case AddressingMode.IndirectPostInc:
                                for (int r1 = 0; r1 < 8; r1++)
                                    sb.AppendLine(string.Format("{0} r{1}, [r{2}+]", instruction, r, r1));
                                break;
                            case AddressingMode.IndirectPreDec:
                                for (int r1 = 0; r1 < 8; r1++)
                                    sb.AppendLine(string.Format("{0} r{1}, [-r{2}]", instruction, r, r1));
                                break;
                            case AddressingMode.IndirectIndexed:
                                for (int r1 = 0; r1 < 8; r1++)
                                    for (int r2 = 0; r2 < 8; r2++)
                                        sb.AppendLine(string.Format("{0} r{1}, [r{2},r{3}]", instruction, r, r1, r2));
                                break;
                            default:
                                throw new Exception();
                        }
                    }
                }
            }
        }
    }
}
