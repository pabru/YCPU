﻿using System;

namespace Ypsilon.Hardware.Processor
{
    partial class YCPU
    {
        public enum BitWidth
        {
            Int8 = 0,
            Int16 = 1,
            Int32 = 2
        }

        public delegate void YCPUOpcode(ushort opcode);
        public delegate string YCPUDisassembler(string name, ushort opcode, ushort nextword, ushort address, out bool uses_next_word);

        public struct YCPUInstruction
        {
            public string Name;
            public YCPUOpcode Opcode;
            public YCPUDisassembler Disassembler;
            public int Cycles;
            public bool IsNOP;

            public YCPUInstruction(string name, YCPUOpcode opcode, int cycles, bool isNOP = false)
            {
                Name = name;
                Opcode = opcode;
                Disassembler = null;
                Cycles = cycles;
                IsNOP = isNOP;
            }

            public bool UsesNextWord(ushort opcode)
            {
                bool value;
                string s = Disassembler(string.Empty, opcode, 0x0000, 0x0000, out value);
                return value;
            }
        }

        public YCPUInstruction[] Opcodes = new YCPUInstruction[0x100];

        #region OpCode Initialization
        private void InitializeOpcodes()
        {
            Opcodes[0x00] = new YCPUInstruction("LOD", LOD, 0);
            Opcodes[0x01] = new YCPUInstruction("LOD", LOD, 0);
            Opcodes[0x02] = new YCPUInstruction("LOD", LOD, 0);
            Opcodes[0x03] = new YCPUInstruction("LOD", LOD, 0);
            Opcodes[0x04] = new YCPUInstruction("LOD", LOD, 0);
            Opcodes[0x05] = new YCPUInstruction("LOD", LOD, 0);
            Opcodes[0x06] = new YCPUInstruction("LOD", LOD, 0);
            Opcodes[0x07] = new YCPUInstruction("LOD", LOD, 0);

            Opcodes[0x08] = new YCPUInstruction("STO", STO, 0);
            Opcodes[0x09] = new YCPUInstruction("STO", STO, 0);
            Opcodes[0x0A] = new YCPUInstruction("STO", STO, 0);
            Opcodes[0x0B] = new YCPUInstruction("STO", STO, 0);
            Opcodes[0x0C] = new YCPUInstruction("STO", STO, 0);
            Opcodes[0x0D] = new YCPUInstruction("STO", STO, 0);
            Opcodes[0x0E] = new YCPUInstruction("STO", STO, 0);
            Opcodes[0x0F] = new YCPUInstruction("STO", STO, 0);

            Opcodes[0x10] = new YCPUInstruction("ADD", ADD, 0);
            Opcodes[0x11] = new YCPUInstruction("ADD", ADD, 0);
            Opcodes[0x12] = new YCPUInstruction("ADD", ADD, 0);
            Opcodes[0x13] = new YCPUInstruction("ADD", ADD, 0);
            Opcodes[0x14] = new YCPUInstruction("ADD", ADD, 0);
            Opcodes[0x15] = new YCPUInstruction("ADD", ADD, 0);
            Opcodes[0x16] = new YCPUInstruction("ADD", ADD, 0);
            Opcodes[0x17] = new YCPUInstruction("ADD", ADD, 0);

            Opcodes[0x18] = new YCPUInstruction("SUB", SUB, 0);
            Opcodes[0x19] = new YCPUInstruction("SUB", SUB, 0);
            Opcodes[0x1A] = new YCPUInstruction("SUB", SUB, 0);
            Opcodes[0x1B] = new YCPUInstruction("SUB", SUB, 0);
            Opcodes[0x1C] = new YCPUInstruction("SUB", SUB, 0);
            Opcodes[0x1D] = new YCPUInstruction("SUB", SUB, 0);
            Opcodes[0x1E] = new YCPUInstruction("SUB", SUB, 0);
            Opcodes[0x1F] = new YCPUInstruction("SUB", SUB, 0);

            Opcodes[0x20] = new YCPUInstruction("ADC", ADC, 0);
            Opcodes[0x21] = new YCPUInstruction("ADC", ADC, 0);
            Opcodes[0x22] = new YCPUInstruction("ADC", ADC, 0);
            Opcodes[0x23] = new YCPUInstruction("ADC", ADC, 0);
            Opcodes[0x24] = new YCPUInstruction("ADC", ADC, 0);
            Opcodes[0x25] = new YCPUInstruction("ADC", ADC, 0);
            Opcodes[0x26] = new YCPUInstruction("ADC", ADC, 0);
            Opcodes[0x27] = new YCPUInstruction("ADC", ADC, 0);

            Opcodes[0x28] = new YCPUInstruction("SBC", SBC, 0);
            Opcodes[0x29] = new YCPUInstruction("SBC", SBC, 0);
            Opcodes[0x2A] = new YCPUInstruction("SBC", SBC, 0);
            Opcodes[0x2B] = new YCPUInstruction("SBC", SBC, 0);
            Opcodes[0x2C] = new YCPUInstruction("SBC", SBC, 0);
            Opcodes[0x2D] = new YCPUInstruction("SBC", SBC, 0);
            Opcodes[0x2E] = new YCPUInstruction("SBC", SBC, 0);
            Opcodes[0x2F] = new YCPUInstruction("SBC", SBC, 0);

            Opcodes[0x30] = new YCPUInstruction("MUL", MUL, 0);
            Opcodes[0x31] = new YCPUInstruction("MUL", MUL, 0);
            Opcodes[0x32] = new YCPUInstruction("MUL", MUL, 0);
            Opcodes[0x33] = new YCPUInstruction("MUL", MUL, 0);
            Opcodes[0x34] = new YCPUInstruction("MUL", MUL, 0);
            Opcodes[0x35] = new YCPUInstruction("MUL", MUL, 0);
            Opcodes[0x36] = new YCPUInstruction("MUL", MUL, 0);
            Opcodes[0x37] = new YCPUInstruction("MUL", MUL, 0);

            Opcodes[0x38] = new YCPUInstruction("DIV", DIV, 31);
            Opcodes[0x39] = new YCPUInstruction("DIV", DIV, 31);
            Opcodes[0x3A] = new YCPUInstruction("DIV", DIV, 31);
            Opcodes[0x3B] = new YCPUInstruction("DIV", DIV, 31);
            Opcodes[0x3C] = new YCPUInstruction("DIV", DIV, 31);
            Opcodes[0x3D] = new YCPUInstruction("DIV", DIV, 31);
            Opcodes[0x3E] = new YCPUInstruction("DIV", DIV, 31);
            Opcodes[0x3F] = new YCPUInstruction("DIV", DIV, 31);

            Opcodes[0x40] = new YCPUInstruction("MLI", MLI, 0);
            Opcodes[0x41] = new YCPUInstruction("MLI", MLI, 0);
            Opcodes[0x42] = new YCPUInstruction("MLI", MLI, 0);
            Opcodes[0x43] = new YCPUInstruction("MLI", MLI, 0);
            Opcodes[0x44] = new YCPUInstruction("MLI", MLI, 0);
            Opcodes[0x45] = new YCPUInstruction("MLI", MLI, 0);
            Opcodes[0x46] = new YCPUInstruction("MLI", MLI, 0);
            Opcodes[0x47] = new YCPUInstruction("MLI", MLI, 0);

            Opcodes[0x48] = new YCPUInstruction("DVI", DVI, 31);
            Opcodes[0x49] = new YCPUInstruction("DVI", DVI, 31);
            Opcodes[0x4A] = new YCPUInstruction("DVI", DVI, 31);
            Opcodes[0x4B] = new YCPUInstruction("DVI", DVI, 31);
            Opcodes[0x4C] = new YCPUInstruction("DVI", DVI, 31);
            Opcodes[0x4D] = new YCPUInstruction("DVI", DVI, 31);
            Opcodes[0x4E] = new YCPUInstruction("DVI", DVI, 31);
            Opcodes[0x4F] = new YCPUInstruction("DVI", DVI, 31);

            Opcodes[0x50] = new YCPUInstruction("MOD", MOD, 31);
            Opcodes[0x51] = new YCPUInstruction("MOD", MOD, 31);
            Opcodes[0x52] = new YCPUInstruction("MOD", MOD, 31);
            Opcodes[0x53] = new YCPUInstruction("MOD", MOD, 31);
            Opcodes[0x54] = new YCPUInstruction("MOD", MOD, 31);
            Opcodes[0x55] = new YCPUInstruction("MOD", MOD, 31);
            Opcodes[0x56] = new YCPUInstruction("MOD", MOD, 31);
            Opcodes[0x57] = new YCPUInstruction("MOD", MOD, 31);

            Opcodes[0x58] = new YCPUInstruction("MDI", MDI, 31);
            Opcodes[0x59] = new YCPUInstruction("MDI", MDI, 31);
            Opcodes[0x5A] = new YCPUInstruction("MDI", MDI, 31);
            Opcodes[0x5B] = new YCPUInstruction("MDI", MDI, 31);
            Opcodes[0x5C] = new YCPUInstruction("MDI", MDI, 31);
            Opcodes[0x5D] = new YCPUInstruction("MDI", MDI, 31);
            Opcodes[0x5E] = new YCPUInstruction("MDI", MDI, 31);
            Opcodes[0x5F] = new YCPUInstruction("MDI", MDI, 31);

            Opcodes[0x60] = new YCPUInstruction("AND", AND, 0);
            Opcodes[0x61] = new YCPUInstruction("AND", AND, 0);
            Opcodes[0x62] = new YCPUInstruction("AND", AND, 0);
            Opcodes[0x63] = new YCPUInstruction("AND", AND, 0);
            Opcodes[0x64] = new YCPUInstruction("AND", AND, 0);
            Opcodes[0x65] = new YCPUInstruction("AND", AND, 0);
            Opcodes[0x66] = new YCPUInstruction("AND", AND, 0);
            Opcodes[0x67] = new YCPUInstruction("AND", AND, 0);

            Opcodes[0x68] = new YCPUInstruction("ORR", ORR, 0);
            Opcodes[0x69] = new YCPUInstruction("ORR", ORR, 0);
            Opcodes[0x6A] = new YCPUInstruction("ORR", ORR, 0);
            Opcodes[0x6B] = new YCPUInstruction("ORR", ORR, 0);
            Opcodes[0x6C] = new YCPUInstruction("ORR", ORR, 0);
            Opcodes[0x6D] = new YCPUInstruction("ORR", ORR, 0);
            Opcodes[0x6E] = new YCPUInstruction("ORR", ORR, 0);
            Opcodes[0x6F] = new YCPUInstruction("ORR", ORR, 0);

            Opcodes[0x70] = new YCPUInstruction("EOR", EOR, 0);
            Opcodes[0x71] = new YCPUInstruction("EOR", EOR, 0);
            Opcodes[0x72] = new YCPUInstruction("EOR", EOR, 0);
            Opcodes[0x73] = new YCPUInstruction("EOR", EOR, 0);
            Opcodes[0x74] = new YCPUInstruction("EOR", EOR, 0);
            Opcodes[0x75] = new YCPUInstruction("EOR", EOR, 0);
            Opcodes[0x76] = new YCPUInstruction("EOR", EOR, 0);
            Opcodes[0x77] = new YCPUInstruction("EOR", EOR, 0);

            Opcodes[0x78] = new YCPUInstruction("NOT", NOT, 0);
            Opcodes[0x79] = new YCPUInstruction("NOT", NOT, 0);
            Opcodes[0x7A] = new YCPUInstruction("NOT", NOT, 0);
            Opcodes[0x7B] = new YCPUInstruction("NOT", NOT, 0);
            Opcodes[0x7C] = new YCPUInstruction("NOT", NOT, 0);
            Opcodes[0x7D] = new YCPUInstruction("NOT", NOT, 0);
            Opcodes[0x7E] = new YCPUInstruction("NOT", NOT, 0);
            Opcodes[0x7F] = new YCPUInstruction("NOT", NOT, 0);

            Opcodes[0x80] = new YCPUInstruction("CMP", CMP, 0);
            Opcodes[0x81] = new YCPUInstruction("CMP", CMP, 0);
            Opcodes[0x82] = new YCPUInstruction("CMP", CMP, 0);
            Opcodes[0x83] = new YCPUInstruction("CMP", CMP, 0);
            Opcodes[0x84] = new YCPUInstruction("CMP", CMP, 0);
            Opcodes[0x85] = new YCPUInstruction("CMP", CMP, 0);
            Opcodes[0x86] = new YCPUInstruction("CMP", CMP, 0);
            Opcodes[0x87] = new YCPUInstruction("CMP", CMP, 0);

            Opcodes[0x88] = new YCPUInstruction("NEG", NEG, 0);
            Opcodes[0x89] = new YCPUInstruction("NEG", NEG, 0);
            Opcodes[0x8A] = new YCPUInstruction("NEG", NEG, 0);
            Opcodes[0x8B] = new YCPUInstruction("NEG", NEG, 0);
            Opcodes[0x8C] = new YCPUInstruction("NEG", NEG, 0);
            Opcodes[0x8D] = new YCPUInstruction("NEG", NEG, 0);
            Opcodes[0x8E] = new YCPUInstruction("NEG", NEG, 0);
            Opcodes[0x8F] = new YCPUInstruction("NEG", NEG, 0);

            Opcodes[0x90] = new YCPUInstruction("BCC", BCC, 0);
            Opcodes[0x91] = new YCPUInstruction("BCS", BCS, 0);
            Opcodes[0x92] = new YCPUInstruction("BNE", BNE, 0);
            Opcodes[0x93] = new YCPUInstruction("BEQ", BEQ, 0);
            Opcodes[0x94] = new YCPUInstruction("BPL", BPL, 0);
            Opcodes[0x95] = new YCPUInstruction("BMI", BMI, 0);
            Opcodes[0x96] = new YCPUInstruction("BVC", BVC, 0);
            Opcodes[0x97] = new YCPUInstruction("BVS", BVS, 0);

            Opcodes[0x98] = new YCPUInstruction("BUG", BUG, 0);
            Opcodes[0x99] = new YCPUInstruction("BSG", BSG, 0);
            // 0x9A - 0x9E are Undefined operations in the branch opcode space.
            Opcodes[0x9F] = new YCPUInstruction("BAW", BAW, 0);

            Opcodes[0xA0] = new YCPUInstruction("ASL", ASL, 0);
            Opcodes[0xA1] = new YCPUInstruction("LSL", ASL, 0); // ASL == LSL, per spec.
            Opcodes[0xA2] = new YCPUInstruction("ROL", ROL, 0);
            Opcodes[0xA3] = new YCPUInstruction("RNL", RNL, 0);
            Opcodes[0xA4] = new YCPUInstruction("ASR", ASR, 3);
            Opcodes[0xA5] = new YCPUInstruction("LSR", LSR, 3);
            Opcodes[0xA6] = new YCPUInstruction("ROR", ROR, 0);
            Opcodes[0xA7] = new YCPUInstruction("RNR", RNR, 0);
            Opcodes[0xA8] = new YCPUInstruction("BIT", BIT, 1);
            Opcodes[0xA9] = new YCPUInstruction("BTX", BTX, 1);
            Opcodes[0xAA] = new YCPUInstruction("BTC", BTC, 1);
            Opcodes[0xAB] = new YCPUInstruction("BTS", BTS, 1);
            Opcodes[0xAC] = new YCPUInstruction("SWO", SWO, 0);
            Opcodes[0xAD] = new YCPUInstruction("FPU", FPU, 9);
            Opcodes[0xAE] = new YCPUInstruction("SEF", SEF, 0);
            Opcodes[0xAF] = new YCPUInstruction("CLF", CLF, 0);

            Opcodes[0xB0] = new YCPUInstruction("PSH", PSH, 0);
            Opcodes[0xB1] = new YCPUInstruction("PSH", PSH, 0);
            Opcodes[0xB2] = new YCPUInstruction("POP", POP, 0);
            Opcodes[0xB3] = new YCPUInstruction("POP", POP, 0);
            // B4 : SFL
            // B5 : ---
            Opcodes[0xB6] = new YCPUInstruction("SET", SET, 0);
            Opcodes[0xB7] = new YCPUInstruction("SET", SET, 0);

            Opcodes[0xB8] = new YCPUInstruction("ADI", ADI, 0);
            Opcodes[0xB9] = new YCPUInstruction("SBI", SBI, 0);
            Opcodes[0xBA] = new YCPUInstruction("TSR", TSR, 0);
            Opcodes[0xBB] = new YCPUInstruction("TRS", TRS, 0);
            Opcodes[0xBC] = new YCPUInstruction("MMR", MMR, 0);
            Opcodes[0xBD] = new YCPUInstruction("MMW", MMW, 0);
            Opcodes[0xBE] = new YCPUInstruction("MML", MML, 15);
            Opcodes[0xBF] = new YCPUInstruction("MMS", MMS, 15);

            Opcodes[0xC0] = new YCPUInstruction("JMP", JMP, 0);
            Opcodes[0xC1] = new YCPUInstruction("JSR", JSR, 1);
            Opcodes[0xC2] = new YCPUInstruction("JUM", JUM, 1);
            Opcodes[0xC3] = new YCPUInstruction("JCX", JCX, 47);
            Opcodes[0xC4] = new YCPUInstruction("HWQ", HWQ, 0);
            Opcodes[0xC5] = new YCPUInstruction("SLP", SLP, 0);
            Opcodes[0xC6] = new YCPUInstruction("SWI", SWI, 0);
            Opcodes[0xC7] = new YCPUInstruction("RTI", RTI, 11);
            
            // C8 - CF are undefined.

            // D0 - FF are undefined. (48 opcodes)

            for (int i = 0; i < 0x100; i += 1)
                if (Opcodes[i].Opcode == null)
                    Opcodes[i] = new YCPUInstruction("NOP", NOP, 1, true);
        }
        #endregion

        #region NOP
        private void NOP(ushort operand)
        {
            // InterruptReset();
            // raise an error
        }
        #endregion

        #region ALU Instructions
        private void ADC(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            int u_result = R[(int)destination] + value + Carry;
            int s_result = (short)R[(int)destination] + (short)value + Carry;
            R[(int)destination] = (ushort)(u_result & 0x0000FFFF);
            FL_N = ((u_result & 0x8000) != 0);
            FL_Z = (u_result == 0x0000);
            FL_C = ((u_result & 0xFFFF0000) != 0);
            FL_V = (s_result < -0x8000) | (s_result > 0x7FFF);
        }

        private void ADD(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            int u_result = R[(int)destination] + value;
            int s_result = (short)R[(int)destination] + (short)value;
            R[(int)destination] = (ushort)(u_result & 0x0000FFFF);
            FL_N = ((u_result & 0x8000) != 0);
            FL_Z = (u_result == 0x0000);
            FL_C = ((u_result & 0xFFFF0000) != 0);
            FL_V = (s_result < -0x8000) | (s_result > 0x7FFF);
        }

        private void AND(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            int result = R[(int)destination] & value;
            R[(int)destination] = (ushort)(result & 0x0000FFFF);
            FL_N = ((result & 0x8000) != 0);
            FL_Z = (result == 0x0000);
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }

        private void CMP(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            int register = R[(int)destination];
            FL_N = ((short)register >= (short)value);
            FL_Z = (register == value);
            FL_C = (register >= value);
            // V [Overflow] Not effected.
        }

        private void DIV(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);
            if (value == 0)
            {
                Interrupt_DivideByZero();
                return;
            }

            int result = R[(int)destination] / value;
            R[(int)destination] = (ushort)(result & 0x0000FFFF);
            FL_N = false;
            FL_Z = (value == 0x0000);
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }

        private void DVI(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);
            if (value == 0)
            {
                Interrupt_DivideByZero();
                return;
            }

            if ((R[(int)destination] == 0x8000) && (value == 0xFFFF))
            {
                // R is unchanged.
                FL_N = true;
                FL_Z = false;
                // C [Carry] Not effected.
                FL_V = true;
            }
            else
            {
                int result = (short)R[(int)destination] / (short)value;
                R[(int)RegGPIndex.R0] = (ushort)(result >> 16);
                R[(int)destination] = (ushort)(result & 0x0000FFFF);
                FL_N = ((result & 0x8000) != 0);
                FL_Z = (result == 0x0000);
                // C [Carry] Not effected.
                FL_V = false;
            }
        }

        private void EOR(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            int result = R[(int)destination] ^ value;
            FL_N = ((value & 0x8000) != 0);
            FL_Z = (value == 0x0000);
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }

        private void LOD(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            R[(int)destination] = value;
            FL_N = ((value & 0x8000) != 0);
            FL_Z = (value == 0x0000);
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }

        private void MDI(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);
            if (value == 0)
            {
                Interrupt_DivideByZero();
                return;
            }

            int s_result = (short)R[(int)destination] % (short)value;
            ushort r = (ushort)(s_result & 0x0000FFFF);
            R[(int)destination] = r;
            FL_N = ((r & 0x8000) != 0);
            FL_Z = (r == 0x0000);
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }

        private void MLI(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            R[(int)destination] = 0xFFFE;
            value = 0x8000;

            int result = (short)R[(int)destination] * (short)value;
            R[(int)RegGPIndex.R0] = (ushort)(result >> 16);
            FL_C = (R[(int)RegGPIndex.R0] != 0);
            R[(int)destination] = (ushort)(result & 0x0000FFFF);
            FL_N = ((result & 0x80000000) != 0);
            FL_Z = (result == 0);
            // V [Overflow] Not effected.
        }

        private void MOD(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);
            if (value == 0)
            {
                Interrupt_DivideByZero();
                return;
            }

            int result = R[(int)destination] % value;
            R[(int)destination] = (ushort)(result & 0x0000FFFF);
            FL_N = ((result & 0x8000) != 0);
            FL_Z = (result == 0x0000);
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }

        private void MUL(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            int result = R[(int)destination] * value;
            R[(int)RegGPIndex.R0] = (ushort)(result >> 16);
            FL_C = (R[(int)RegGPIndex.R0] != 0);
            R[(int)destination] = (ushort)(result & 0x0000FFFF);
            FL_N = false; // Always cleared.
            FL_Z = (result == 0);
            // V [Overflow] Not effected.
        }

        private void NEG(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            if (value == 0x8000)
            {
                // negated value of -32768 doesn't fit in 16-bits.
                R[(int)destination] = 0x8000;
                FL_N = true;
                FL_Z = false;
                // C [Carry] Not effected.
                FL_V = true;
            }
            else
            {
                int result = (0 - value);
                R[(int)destination] = (ushort)(result & 0x0000FFFF);
                FL_N = ((result & 0x8000) != 0);
                FL_Z = (result == 0x0000);
                // C [Carry] Not effected.
                FL_V = false;
            }
        }

        private void NOT(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            int result = ~value;
            R[(int)destination] = (ushort)(result & 0x0000FFFF);
            FL_N = ((result & 0x8000) != 0);
            FL_Z = (result == 0x0000);
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }

        private void ORR(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            int result = R[(int)destination] | value;
            R[(int)destination] = (ushort)(result & 0x0000FFFF);
            FL_N = ((result & 0x8000) != 0);
            FL_Z = (result == 0x0000);
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }

        private void SBC(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            int u_result = R[(int)destination] - value - (1 - Carry);
            int s_result = (short)R[(int)destination] - (short)value - (1 - Carry);
            R[(int)destination] = (ushort)(u_result & 0x0000FFFF);
            FL_N = ((u_result & 0x8000) != 0);
            FL_Z = (u_result == 0x0000);
            FL_C = ((u_result & 0xFFFF0000) != 0);
            FL_V = (s_result < -0x8000) | (s_result > 0x7FFF);
        }

        private void STO(ushort operand)
        {
            ushort dest_address;
            RegGPIndex source;
            BitPatternSTO(operand, out dest_address, out source);
            if (source == RegGPIndex.Error)
                return;
            else
            {
                if ((operand & 0x1000) != 0) // eight bit mode
                    WriteMemInt8(dest_address, (byte)R[(int)source]);
                else
                    WriteMemInt16(dest_address, R[(int)source]);
            }
            // N [Negative] Not effected.
            // Z [Zero] Not effected.
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }

        private void SUB(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternALU(operand, out value, out destination);

            int u_result = R[(int)destination] - value;
            int s_result = (short)R[(int)destination] - (short)value;
            R[(int)destination] = (ushort)(u_result & 0x0000FFFF);
            FL_N = ((u_result & 0x8000) != 0);
            FL_Z = (u_result == 0x0000);
            FL_C = ((u_result & 0xFFFF0000) != 0);
            FL_V = (s_result < -0x8000) | (s_result > 0x7FFF);
        }
        #endregion

        #region INC Instructions
        private void ADI(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternINC(operand, out value, out destination);

            int u_result = R[(int)destination] + value;
            int s_result = (short)R[(int)destination] + value;
            R[(int)destination] = (ushort)(u_result & 0x0000FFFF);
            FL_N = ((u_result & 0x8000) != 0);
            FL_Z = (u_result == 0x0000);
            FL_C = ((u_result & 0xFFFF0000) != 0);
            FL_V = (s_result < -0x8000) | (s_result > 0x7FFF);
        }

        private void SBI(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternINC(operand, out value, out destination);

            int u_result = R[(int)destination] - value;
            int s_result = (short)R[(int)destination] - value;
            R[(int)destination] = (ushort)(u_result & 0x0000FFFF);
            FL_N = ((u_result & 0x8000) != 0);
            FL_Z = (u_result == 0x0000);
            FL_C = ((u_result & 0xFFFF0000) != 0);
            FL_V = (s_result < -0x8000) | (s_result > 0x7FFF);
        }
        #endregion

        #region Bit Testing Instructions
        private void BIT(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternBIT(operand, out value, out destination);
            ushort bit = (ushort)Math.Pow(2, value);
            if ((R[(int)destination] & bit) != 0)
            {
                FL_Z = false;
            }
            else
            {
                FL_Z = true;
            }
        }

        private void BTX(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternBIT(operand, out value, out destination);
            ushort bit = (ushort)Math.Pow(2, value);
            if ((R[(int)destination] & bit) != 0)
            {
                FL_Z = false;
                FL_C = true;
            }
            else
            {
                FL_Z = true;
                FL_C = false;
            }
            R[(int)destination] ^= bit;
        }

        private void BTC(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternBIT(operand, out value, out destination);
            ushort bit = (ushort)Math.Pow(2, value);
            if ((R[(int)destination] & bit) != 0)
            {
                FL_Z = false;
                FL_C = true;
            }
            else
            {
                FL_Z = true;
                FL_C = false;
            }
            R[(int)destination] &= (ushort)~bit;
        }

        private void BTS(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternBIT(operand, out value, out destination);
            ushort bit = (ushort)Math.Pow(2, value);
            if ((R[(int)destination] & bit) != 0)
            {
                FL_Z = false;
                FL_C = false;
            }
            else
            {
                FL_Z = true;
                FL_C = true;
            }
            R[(int)destination] |= bit;
        }
        #endregion

        #region Branch Instructions
        private void BCC(ushort operand)
        {
            if (!FL_C)
            {
                ushort value;
                RegGPIndex destination;
                BitPatternBRA(operand, out value, out destination);
                PC = (ushort)(PC + (sbyte)value - 2);
            }
        }

        private void BCS(ushort operand)
        {
            if (FL_C)
            {
                ushort value;
                RegGPIndex destination;
                BitPatternBRA(operand, out value, out destination);
                PC = (ushort)(PC + (sbyte)value - 2);
            }
        }

        private void BNE(ushort operand)
        {
            if (!FL_Z)
            {
                ushort value;
                RegGPIndex destination;
                BitPatternBRA(operand, out value, out destination);
                PC = (ushort)(PC + (sbyte)value - 2);
            }
        }

        private void BEQ(ushort operand)
        {
            if (FL_Z)
            {
                ushort value;
                RegGPIndex destination;
                BitPatternBRA(operand, out value, out destination);
                PC = (ushort)(PC + (sbyte)value - 2);
            }
        }

        private void BPL(ushort operand)
        {
            if (!FL_N)
            {
                ushort value;
                RegGPIndex destination;
                BitPatternBRA(operand, out value, out destination);
                PC = (ushort)(PC + (sbyte)value - 2);
            }
        }

        private void BMI(ushort operand)
        {
            if (FL_N)
            {
                ushort value;
                RegGPIndex destination;
                BitPatternBRA(operand, out value, out destination);
                PC = (ushort)(PC + (sbyte)value - 2);
            }
        }

        private void BVC(ushort operand)
        {
            if (!FL_V)
            {
                ushort value;
                RegGPIndex destination;
                BitPatternBRA(operand, out value, out destination);
                PC = (ushort)(PC + (sbyte)value - 2);
            }
        }

        private void BVS(ushort operand)
        {
            if (FL_V)
            {
                ushort value;
                RegGPIndex destination;
                BitPatternBRA(operand, out value, out destination);
                PC = (ushort)(PC + (sbyte)value - 2);
            }
        }

        private void BUG(ushort operand)
        {
            if (!FL_Z && FL_C)
            {
                ushort value;
                RegGPIndex destination;
                BitPatternBRA(operand, out value, out destination);
                PC = (ushort)(PC + (sbyte)value - 2);
            }
        }

        private void BSG(ushort operand)
        {
            if (!FL_Z && FL_N)
            {
                ushort value;
                RegGPIndex destination;
                BitPatternBRA(operand, out value, out destination);
                PC = (ushort)(PC + (sbyte)value - 2);
            }
        }

        private void BAW(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternBRA(operand, out value, out destination);
            PC = (ushort)(PC + (sbyte)value - 2);
        }
        #endregion

        #region FLG Instructions
        private void SEF(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternFLG(operand, out value, out destination);

            if ((operand & 0x8000) != 0)
                FL_N = true;
            if ((operand & 0x4000) != 0)
                FL_Z = true;
            if ((operand & 0x2000) != 0)
                FL_C = true;
            if ((operand & 0x1000) != 0)
                FL_V = true;
        }
        private void CLF(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternFLG(operand, out value, out destination);

            if ((operand & 0x8000) != 0)
                FL_N = false;
            if ((operand & 0x4000) != 0)
                FL_Z = false;
            if ((operand & 0x2000) != 0)
                FL_C = false;
            if ((operand & 0x1000) != 0)
                FL_V = false;
        }
        #endregion

        #region FPU Instructions
        private void FPU(ushort operand)
        {
            ushort value;
            RegGPIndex destination, source;
            BitPatternFPU(operand, out value, out destination);
            source = (RegGPIndex)value;
            int operation = (operand & 0x0300) >> 8;
            float[] operands = FPU_GetOperands(destination, source);
            float result;
            switch (operation)
            {
                case 0x00:
                    result = operands[0] + operands[1];
                    break;
                case 0x01:
                    result = operands[0] - operands[1];
                    break;
                case 0x02:
                    result = operands[0] * operands[1];
                    break;
                case 0x03:
                    if (operands[1] == 0.0f)
                    {
                        Interrupt_FPUError();
                        return;
                    }
                    result = operands[0] / operands[1];
                    break;
                default:
                    return;
            }
            ushort[] result_words = FPU_GetWordsFromFloat(result);
            StackPush(result_words[0]);
            StackPush(result_words[1]);

            FL_N = result < 0;
            FL_Z = (result == 0);
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }
        private float[] FPU_GetOperands(RegGPIndex dest, RegGPIndex src)
        {
            ushort addr_dest = R[(int)dest];
            ushort addr_src = R[(int)src];
            ushort[] m = new ushort[4];
            // get the address of the first operand.
            m[0] = ReadMemInt16(addr_dest);
            addr_dest += 2;
            m[1] = ReadMemInt16(addr_dest);

            // get the address of the second operand.
            m[2] = ReadMemInt16(addr_src);
            addr_src += 2;
            m[3] = ReadMemInt16(addr_src);

            // copy the data into local memory as floats so the host processor can work on them.
            float[] f = new float[2];
            Buffer.BlockCopy(m, 0, f, 0, 8);
            return f;
        }
        private ushort[] FPU_GetWordsFromFloat(float value)
        {
            ushort[] result = new ushort[2];
            float[] value_f = new float[1] { value };
            Buffer.BlockCopy(value_f, 0, result, 0, 4);
            return result;
        }
        #endregion

        #region HWQ & SLP
        private void HWQ(ushort operand)
        {
            if (!PS_S)
            {
                Interrupt_UnPrivOpcode();
                return;
            }

            ushort query_type;
            RegGPIndex unused;
            BitPatternHWQ(operand, out query_type, out unused);

            switch (query_type)
            {
                case 0x00:
                    R[(int)RegGPIndex.R0] = m_Bus.DevicesConnected;
                    break;
                case 0x01:
                    ushort[] device_info = m_Bus.QueryDevice(R[(int)RegGPIndex.R0]);
                    R[(int)RegGPIndex.R0] = device_info[0];
                    R[(int)RegGPIndex.R1] = device_info[1];
                    R[(int)RegGPIndex.R2] = device_info[2];
                    R[(int)RegGPIndex.R3] = device_info[3];
                    break;
                case 0x02:
                    R[0] = m_Bus.SendDeviceMessage(R[(int)RegGPIndex.R0],
                        R[(int)RegGPIndex.R1],
                        R[(int)RegGPIndex.R2]);
                    break;
                case 0x03:
                    m_RTC.SetTickRate(R[(int)RegGPIndex.R0], m_Cycles);
                    break;
                case 0x04:
                    ushort[] rtc_data = m_RTC.GetData();
                    R[(int)RegGPIndex.R0] = rtc_data[0];
                    R[(int)RegGPIndex.R1] = rtc_data[1];
                    R[(int)RegGPIndex.R2] = rtc_data[2];
                    R[(int)RegGPIndex.R3] = rtc_data[3];
                    break;
                default:
                    // fail silently.
                    break;
            }
        }

        private void SLP(ushort operand)
        {
            if (!PS_S)
            {
                Interrupt_UnPrivOpcode();
                return;
            }

            // pause processor
        }
        #endregion

        #region JMP Instructions
        private void JMP(ushort operand)
        {
            ushort value;
            RegGPIndex unused;
            BitPatternJMP(operand, out value, out unused);
            PC = value;
        }

        private void JSR(ushort operand)
        {
            ushort value;
            RegGPIndex unused;
            BitPatternJMP(operand, out value, out unused);
            StackPush(PC);
            PC = value;
        }

        private void JUM(ushort operand)
        {
            if (!PS_S)
            {
                Interrupt_UnPrivOpcode();
                return;
            }

            ushort value;
            RegGPIndex unused;
            BitPatternJMP(operand, out value, out unused);
            PS_S = false;
            PC = value;
        }

        private void JCX(ushort operand)
        {
            if (!PS_S)
            {
                Interrupt_UnPrivOpcode();
                return;
            }

            // bit pattern not used for this instruction.
            ushort mmu_ptr = StackPop();
            
            R[(int)RegGPIndex.R7] = StackPop();
            R[(int)RegGPIndex.R6] = StackPop();
            R[(int)RegGPIndex.R5] = StackPop();
            R[(int)RegGPIndex.R4] = StackPop();
            R[(int)RegGPIndex.R3] = StackPop();
            R[(int)RegGPIndex.R2] = StackPop();
            R[(int)RegGPIndex.R1] = StackPop();
            R[(int)RegGPIndex.R0] = StackPop();
            FL = StackPop();
            PC = StackPop();
            ushort iPS = StackPop();
            MMU_StoreCacheDataFromMemory(mmu_ptr);
            PS = iPS;
        }
        #endregion

        #region MMU Instructions
        private void MML(ushort operand)
        {
            if (!PS_S)
            {
                Interrupt_UnPrivOpcode();
                return;
            }

            ushort address;
            RegGPIndex unused;
            BitPatternJMP(operand, out address, out unused);
            MMU_LoadMemoryWithCacheData(address);
        }

        private void MMW(ushort operand)
        {
            if (!PS_S)
            {
                Interrupt_UnPrivOpcode();
                return;
            }

            ushort mmuIndex;
            RegGPIndex regIndex, regValue;
            BitPatternMMU(operand, out mmuIndex, out regValue);
            regIndex = (RegGPIndex)mmuIndex;
            MMU_Write(R[(int)regIndex], R[(int)regValue]);
        }

        private void MMS(ushort operand)
        {
            if (!PS_S)
            {
                Interrupt_UnPrivOpcode();
                return;
            }

            ushort address;
            RegGPIndex unused;
            BitPatternJMP(operand, out address, out unused);
            MMU_StoreCacheDataFromMemory(address);
        }

        private void MMR(ushort operand)
        {
            if (!PS_S)
            {
                Interrupt_UnPrivOpcode();
                return;
            }

            ushort mmuIndex;
            RegGPIndex regIndex, regValue;
            BitPatternMMU(operand, out mmuIndex, out regValue);
            regIndex = (RegGPIndex)mmuIndex;
            R[(int)regValue] = MMU_Read(R[(int)regIndex]);
        }
        #endregion

        #region SET Instructions
        private void SET(ushort operand)
        {
            RegGPIndex regDestination;
            ushort value;
            BitPatternSET(operand, out value, out regDestination);
            R[(int)regDestination] = value;
        }
        #endregion

        #region SHF Instructions
        private void ASL(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternSHF(operand, out value, out destination);

            int register = (short)R[(int)destination] << value;
            R[(int)destination] = (ushort)(register & 0x0000FFFF);

            FL_N = ((R[(int)destination] & 0x8000) != 0);
            FL_Z = (register == 0x0000);
            FL_C = ((register & 0xFFFF0000) != 0);
            // V [Overflow]    Not effected.
        }

        private void ASR(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternSHF(operand, out value, out destination);

            int register = (short)R[(int)destination] >> value;
            int mask = (int)Math.Pow(2, value) - 1;
            FL_C = ((mask & register) != 0);

            R[(int)destination] = (ushort)(register & 0x0000FFFF);
            FL_N = ((R[(int)destination] & 0x8000) != 0);
            FL_Z = (register == 0x0000);
            // V [Overflow]    Not effected.
        }

        private void LSR(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternSHF(operand, out value, out destination);

            R[(int)destination] = 0x8000;
            value = 1;

            uint register = (uint)R[(int)destination] >> value;
            uint mask = (uint)Math.Pow(2, value) - 1;
            FL_C = ((mask & register) != 0);

            R[(int)destination] = (ushort)(register & 0x0000FFFF);
            FL_N = ((R[(int)destination] & 0x8000) != 0);
            FL_Z = (register == 0x0000);
            // V [Overflow]    Not effected.
        }

        private void RNL(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternSHF(operand, out value, out destination);

            if (value != 0)
            {
                uint register = (uint)R[(int)destination] << value;
                uint lo_bits = (uint)(register & 0xFFFF0000) >> 16;
                R[(int)destination] = (ushort)((register & 0x0000FFFF) | lo_bits);
                // C [Carry]       Not effected.
                // V [Overflow]    Not effected.
            }
            FL_N = ((R[(int)destination] & 0x8000) != 0);
            FL_Z = (R[(int)destination] == 0x0000);
        }

        private void RNR(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternSHF(operand, out value, out destination);

            if (value != 0)
            {
                uint register = (uint)((ushort)R[(int)destination] >> value);
                uint lo_mask = (uint)0x0000FFFF >> (16 - value);
                uint lo_bits = (uint)(R[(int)destination] & lo_mask) << (16 - value);
                R[(int)destination] = (ushort)((register & 0x0000FFFF) | lo_bits);
                // C [Carry]       Not effected.
                // V [Overflow]    Not effected.
            }
            FL_N = ((R[(int)destination] & 0x8000) != 0);
            FL_Z = (R[(int)destination] == 0x0000);
        }

        private void ROL(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternSHF(operand, out value, out destination);

            if (value != 0)
            {
                uint out_carry = (uint)R[(int)destination] & (ushort)Math.Pow(2, (16 - value));
                uint in_carry = (FL_C ? (uint)(Math.Pow(2, value - 1)) : 0);
                uint register = (uint)((ushort)R[(int)destination] << value);
                uint hi_mask = 0xFFFF0000 ^ (uint)Math.Pow(2, 15 + value);

                R[(int)destination] = (ushort)((uint)(register & 0x0000FFFF) | (uint)((register & hi_mask) >> 16) | (uint)in_carry);
                FL_C = (out_carry != 0);

                // V [Overflow]    Not effected.
            }
            FL_N = ((R[(int)destination] & 0x8000) != 0);
            FL_Z = (R[(int)destination] == 0x0000);
        }

        private void ROR(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternSHF(operand, out value, out destination);

            if (value != 0)
            {
                R[(int)destination] = 0x000F;
                value = 1;
                FL_C = false;

                uint out_carry = (uint)R[(int)destination] & (ushort)Math.Pow(2, value - 1);
                uint in_carry = (FL_C ? (uint)(Math.Pow(2, 16 - value)) : 0);
                uint register = (uint)((ushort)R[(int)destination] >> value);
                uint lo_mask = (uint)0x0000FFFF >> (17 - value);
                uint lo_bits = (uint)(R[(int)destination] & lo_mask) << (17 - value);

                R[(int)destination] = (ushort)((uint)(register & 0x0000FFFF) | lo_bits | (uint)in_carry);
                FL_C = (out_carry != 0);
                // V [Overflow]    Not effected.
            }
            FL_N = ((R[(int)destination] & 0x8000) != 0);
            FL_Z = (R[(int)destination] == 0x0000);
        }
        #endregion

        #region SWI / RTI
        private void SWI(ushort operand)
        {
            Interrupt_SWI();
        }

        private void RTI(ushort operand)
        {
            if (!PS_S)
            {
                Interrupt_UnPrivOpcode();
                return;
            }

            ReturnFromInterrupt();
        }
        #endregion

        #region Stack Instructions
        private void PSH(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternPSH(operand, out value, out destination);
            if ((value & 0x0001) == 0)
            {
                if ((value & 0x0100) != 0)
                    StackPush(R[(int)RegGPIndex.R0]);
                if ((value & 0x0200) != 0)
                    StackPush(R[(int)RegGPIndex.R1]);
                if ((value & 0x0400) != 0)
                    StackPush(R[(int)RegGPIndex.R2]);
                if ((value & 0x0800) != 0)
                    StackPush(R[(int)RegGPIndex.R3]);
                if ((value & 0x1000) != 0)
                    StackPush(R[(int)RegGPIndex.R4]);
                if ((value & 0x2000) != 0)
                    StackPush(R[(int)RegGPIndex.R5]);
                if ((value & 0x4000) != 0)
                    StackPush(R[(int)RegGPIndex.R6]);
                if ((value & 0x8000) != 0)
                    StackPush(R[(int)RegGPIndex.R7]);
            }
            else
            {
                if ((value & 0x0100) != 0)
                    StackPush(SP);
                if ((value & 0x0200) != 0)
                    StackPush(USP);
                if ((value & 0x0400) != 0)
                    StackPush(PS);
                if ((value & 0x0800) != 0)
                    StackPush(PC);
                if ((value & 0x1000) != 0)
                    StackPush(FL);
            }
        }
        private void POP(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternPSH(operand, out value, out destination);
            if ((value & 0x0001) == 0)
            {
                if ((value & 0x8000) != 0)
                    R[(int)RegGPIndex.R7] = StackPop();
                if ((value & 0x4000) != 0)
                    R[(int)RegGPIndex.R6] = StackPop();
                if ((value & 0x2000) != 0)
                    R[(int)RegGPIndex.R5] = StackPop();
                if ((value & 0x1000) != 0)
                    R[(int)RegGPIndex.R4] = StackPop();
                if ((value & 0x0800) != 0)
                    R[(int)RegGPIndex.R3] = StackPop();
                if ((value & 0x0400) != 0)
                    R[(int)RegGPIndex.R2] = StackPop();
                if ((value & 0x0200) != 0)
                    R[(int)RegGPIndex.R1] = StackPop();
                if ((value & 0x0100) != 0)
                    R[(int)RegGPIndex.R0] = StackPop();
            }
            else
            {

                if ((value & 0x1000) != 0)
                    FL = StackPop();
                if ((value & 0x0800) != 0)
                    PC = StackPop();
                if ((value & 0x0400) != 0)
                    PS = StackPop();
                if ((value & 0x0200) != 0)
                    USP = StackPop();
                if ((value & 0x0100) != 0)
                    SP = StackPop();
            }
        }
        #endregion
        
        #region SWO Instructions
        private void SWO(ushort operand)
        {
            ushort value;
            RegGPIndex destination;
            BitPatternSWO(operand, out value, out destination);

            R[(int)destination] = value;
            FL_N = ((value & 0x8000) != 0);
            FL_Z = (value == 0x0000);
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }
        #endregion

        #region TSR Instructions
        private void TRS(ushort operand)
        {
            if (!PS_S)
            {
                Interrupt_UnPrivOpcode();
                return;
            }

            ushort index;
            RegGPIndex source;
            BitPatternTSR(operand, out index, out source);

            switch (index)
            {
                case 0x00:
                    PC = R[(int)source];
                    break;
                case 0x01:
                    SP = R[(int)source];
                    break;
                case 0x02:
                    IA = R[(int)source];
                    break;
                case 0x03:
                    II = R[(int)source];
                    break;
                case 0x04:
                    PS = R[(int)source];
                    break;
                case 0x05:
                    P2 = R[(int)source];
                    break;
                case 0x06:
                    USP = R[(int)source];
                    break;
                case 0x07:
                    SSP = R[(int)source];
                    break;
                default:
                    return;
            }
            // N [Negative] Not effected.
            // Z [Zero] Not effected.
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }
        private void TSR(ushort operand)
        {
            if (!PS_S)
            {
                Interrupt_UnPrivOpcode();
                return;
            }

            ushort index, value;
            RegGPIndex destination;
            BitPatternTSR(operand, out index, out destination);

            switch (index)
            {
                case 0x00:
                    value = PC;
                    break;
                case 0x01:
                    value = SP;
                    break;
                case 0x02:
                    value = IA;
                    break;
                case 0x03:
                    value = II;
                    break;
                case 0x04:
                    value = PS;
                    break;
                case 0x05:
                    value = P2;
                    break;
                case 0x06:
                    value = USP;
                    break;
                case 0x07:
                    value = SSP;
                    break;
                default:
                    return;
            }
            R[(int)destination] = value;
            FL_N = ((value & 0x8000) != 0);
            FL_Z = (value == 0x0000);
            // C [Carry] Not effected.
            // V [Overflow] Not effected.
        }
        #endregion
    }
}
