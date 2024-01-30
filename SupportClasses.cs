using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime;
using s4pi.Package;
using s4pi.Interfaces;
using Ookii.Dialogs;

namespace TS4SliderConverter
{
    [Flags]
    public enum Age
    {
        None = 0,
        Baby = 1,
        Toddler = 2,
        BabyAndToddler = 3,
        Child = 4,
        ToddlerToChild = 6,
        BabyToChild = 7,
        Teen = 8,
        YoungAdult = 16,
        TeenAndYA = 24,
        Adult = 32,
        YAandAdult = 48,
        TeenToAdult = 56,
        ChildToAdult = 60,
        ToddlerToAdult = 62,
        BabyToAdult = 63,
        Elder = 64,
        AdultAndElder = 96,
        YAtoElder = 112,
        TeenToElder = 120,
        ChildToElder = 124,
        ToddlerToElder = 126,
        AllAges = 127
    }

    [Flags]
    public enum Gender
    {
        None = 0,
        Male = 1,
        Female = 2,
        Unisex = 3
    }

    [Flags]
    public enum AgeGender : uint
    {
        Baby = 0x00000001,
        Toddler = 0x00000002,
        Child = 0x00000004,
        Teen = 0x00000008,
        YoungAdult = 0x00000010,
        Adult = 0x00000020,
        Elder = 0x00000040,
        Male = 0x00001000,
        Female = 0x00002000
    }

    public enum Species : uint
    {
        Human = 1,
        Dog = 2,
        Cat = 3,
        LittleDog = 4
    }

    public enum SimRegion : uint
    {
        EYES = 0,
        NOSE,
        MOUTH,
        CHEEKS,
        CHIN,
        JAW,
        FOREHEAD,

        // Modifier-only face regions
        BROWS = 8,
        EARS,
        HEAD,

        // Other face regions
        FULLFACE = 12,

        // Modifier body regions
        CHEST = 14,
        UPPERCHEST,
        NECK,
        SHOULDERS,
        UPPERARM,
        LOWERARM,
        HANDS,
        WAIST,
        HIPS,
        BELLY,
        BUTT,
        THIGHS,
        LOWERLEG,
        FEET,

        // Other body regions
        BODY,
        UPPERBODY,
        LOWERBODY,
        TAIL,
        FUR,
        FORELEGS,
        HINDLEGS,

        //  ALL = LOWERBODY + 1,     // all

        CUSTOM_MaleParts = 50,
        CUSTOM_FemaleParts,
        CUSTOM_Breasts,
        CUSTOM_Chest,
        CUSTOM_UpperChest,
        CUSTOM_Back,
        CUSTOM_Neck,
        CUSTOM_Shoulders,
        CUSTOM_UpperArm,
        CUSTOM_LowerArm,
        CUSTOM_Hands,
        CUSTOM_Waist,
        CUSTOM_Hips,
        CUSTOM_Belly,
        CUSTOM_Butt,
        CUSTOM_Thighs,
        CUSTOM_LowerLeg,
        CUSTOM_Feet,
        CUSTOM_Misc1,
        CUSTOM_Misc2,
        CUSTOM_Misc3,
        CUSTOM_Misc4,
        CUSTOM_Misc5
    }

    public enum SimSubRegion
    {
        None = 0,
        EarsUp = 1,
        EarsDown = 2,
        TailLong = 3,
        TailRing = 4,
        TailScrew = 5,
        TailStub = 6
    }

    public class TGI
    {
        uint type;
        uint group;
        ulong instance;

        public uint Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public uint Group
        {
            get { return this.group; }
            set { this.group = value; }
        }

        public ulong Instance
        {
            get { return this.instance; }
            set { this.instance = value; }
        }

        public TGI()
        {
            type = 0U;
            group = 0U;
            instance = 0UL;
        }

        public TGI(uint typeID, uint groupID, ulong instanceID)
        {
            type = typeID;
            group = groupID;
            instance = instanceID;
        }

        public TGI(string tgi)
        {
            if (String.CompareOrdinal(tgi, " ") <= 0)
            {
                type = 0U;
                group = 0U;
                instance = 0LU;
                return;
            }
            string[] myTGI = tgi.Split('-', ':', '.', ' ', '_');
            for (int i = 0; i < myTGI.Length; i++)
            {
                if (String.CompareOrdinal(myTGI[i].Substring(0, 2), "0x") == 0)
                {
                    myTGI[i] = myTGI[i].Substring(2);
                }
            }
            try
            {
                type = UInt32.Parse(myTGI[0], System.Globalization.NumberStyles.HexNumber);
                group = UInt32.Parse(myTGI[1], System.Globalization.NumberStyles.HexNumber);
                instance = UInt64.Parse(myTGI[2], System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                throw new ApplicationException("Can't parse TGI string " + tgi);
            }
        }

        public TGI(TGI tgi)
        {
            this.type = tgi.Type;
            this.group = tgi.Group;
            this.instance = tgi.Instance;
        }

        public TGI(BinaryReader br)
        {
            this.type = br.ReadUInt32();
            this.group = br.ReadUInt32();
            this.instance = br.ReadUInt64();
        }

        public TGI(BinaryReader br, TGIsequence sequence)
        {
            if (sequence == TGIsequence.TGI)
            {
                this.type = br.ReadUInt32();
                this.group = br.ReadUInt32();
                this.instance = br.ReadUInt64();
            }
            if (sequence == TGIsequence.IGT)
            {
                this.instance = br.ReadUInt64();
                this.group = br.ReadUInt32();
                this.type = br.ReadUInt32();
            }
            if (sequence == TGIsequence.ITG)
            {
                this.instance = br.ReadUInt64();
                this.type = br.ReadUInt32();
                this.group = br.ReadUInt32();
            }
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(this.type);
            bw.Write(this.group);
            bw.Write(this.instance);
        }

        public void Write(BinaryWriter bw, TGIsequence sequence)
        {
            if (sequence == TGIsequence.TGI)
            {
                bw.Write(this.type);
                bw.Write(this.group);
                bw.Write(this.instance);
            }
            if (sequence == TGIsequence.IGT)
            {
                bw.Write(this.instance);
                bw.Write(this.group);
                bw.Write(this.type);
            }
            if (sequence == TGIsequence.ITG)
            {
                bw.Write(this.instance);
                bw.Write(this.type);
                bw.Write(this.group);
            }
        }

        public bool Equals(TGI tgi)
        {
            return (this.type == tgi.type & this.group == tgi.group & this.instance == tgi.instance);
        }

        public bool Equals(string tgi)
        {
            TGI tmp = new TGI(tgi);
            return (this.type == tmp.type & this.group == tmp.group & this.instance == tmp.instance);
        }

        public override bool Equals(object obj)
        {
            if (obj is TGI)
            {
                return this.Equals((TGI)obj);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.type.GetHashCode() + this.group.GetHashCode() + this.instance.GetHashCode();
        }

        public override string ToString()
        {
            return "0x" + this.type.ToString("X8") + "-" + "0x" + this.group.ToString("X8") + "-" + "0x" + this.instance.ToString("X16");
        }

        public enum TGIsequence
        {
            TGI, ITG, IGT
        }

    }
}
