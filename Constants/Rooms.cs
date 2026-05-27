using System.Reflection.PortableExecutable;

namespace LibreGeist.Constants
{
    /// <summary>
    /// Names of rooms in TetherGeist
    /// </summary>
    public static class Rooms
    {
        public const string Main_Menu = "c0TitleScreen";
        public const string Map = "c0Overworld";
        public const string Credits = "c0EndCredits";
        public static class Chapter1
        {
            public static class Introduction
            {
                public const string R1 = "c1p1r1";
                public const string R2 = "c1p1r2";
                public const string R3 = "c1p1r3";
                public const string R4 = "c1p1r4";

                public const string Lookout = "c1p1rLOOKOUT";
                public const string Pain = "c1p1rPAIN";
            }

            public static class TheVillage
            {
                public const string HubHome = "c1HubHome";
                public const string Hub1 = "c1Hub1";
                public const string Hub2 = "c1Hub2";
                public const string Hub3 = "c1Hub3";

                public const string HubHomeNight = "c1HubHomeNight";
                public const string Hub1Night = "c1Hub1Night";
                public const string Hub2Night = "c1Hub2Night";
                public const string Hub3Night = "c1Hub3Night";
            }

            public static class Departure
            {
                public const string R0 = "c1p3r0";
                public const string R1 = "c1p3r1";
                public const string R2 = "c1p3r2";
                public const string R3 = "c1p3r3";
                public const string R4 = "c1p3r4";
                public const string R5 = "c1p3r5";
                public const string R6 = "c1p3r6";
                public const string R7 = "c1p3r7";
                public const string R8 = "c1p3r8";
                public const string R9 = "c1p3r9";
            }
        }

        public static class Chapter2
        {
            public static class FungalForest
            {
                public const string Comic = "c2Comic";

                public const string R01 = "c2p1r01";
                public const string R02 = "c2p1r02";
                public const string R03 = "c2p1r03";
                public const string R04 = "c2p1r04";
                public const string R05 = "c2p1r05";
                public const string R06 = "c2p1r06";
                public const string R07 = "c2p1r07";
                public const string R08 = "c2p1r08";
                public const string R09 = "c2p1r09";
                public const string R10 = "c2p1r10";
                public const string R11 = "c2p1r11";

                public const string SpiritDoor = "c2p1r04_SpiritDoor";
                public const string SpiritDoorC = "c2p1rSpiritDoorC";

                public const string SpiritRoom = "c2p1r04_SpiritRoom";
            }

            public static class Shellwood
            {
                public const string Hub = "c2Hub";
            }

            public static class ForestDepths
            {
                public const string R01 = "c2p3r01";
                public const string R02 = "c2p3r02";
                public const string R03 = "c2p3r03";
                public const string R04 = "c2p3r04";
                public const string R05 = "c2p3r05";
                public const string R06 = "c2p3r06";
                public const string R07 = "c2p3r07";
                public const string R08 = "c2p3r08";
                public const string R09 = "c2p3r09";

                public const string Shrine = "c2p3r03_Shrine";
                public const string Frog = "c2p3r05_Frog";
                public const string FallenTree1 = "c2p3r07_FallenTree1";
                public const string FallenTree2 = "c2p3r08_FallenTree2";

                public const string SpiritRoom = "c2p3_SpiritRoom";
            }
        }

        public static class Chapter3
        {
            public static class EdenTown
            {
                public const string Comic = "c3Comic";
                public const string Hub = "c3Hub";
            }

            public static class EdenQuarry
            {
                public const string R01 = "c3p2r01";
                public const string R02 = "c3p2r02";
                public const string R03 = "c3p2r03";
                public const string R04 = "c3p2r04";
                public const string R05 = "c3p2r05";
                public const string R06 = "c3p2r06";
                public const string R07 = "c3p2r07";
                public const string R08 = "c3p2r08";
                public const string R09 = "c3p2r09";

                public const string YupaShrine = "c3p2r03_YupaShrine";

                public const string SpiritRoom = "c3p2_SpiritRoom";
            }

            public static class ForestOfEden
            {
                public const string R01 = "c3p3r01";
                public const string R02 = "c3p3r02";
                public const string R03 = "c3p3r03";
                public const string R04 = "c3p3r04";
                public const string R05 = "c3p3r05";
                public const string R06 = "c3p3r06";
                public const string R07 = "c3p3r07";
                public const string R08 = "c3p3r08";

                public const string FlowerRoom = "c3p3r03_FlowerRoom";

                public const string SpiritRoom = "c3p3_SpiritRoom";
            }
        }

        public static class Chapter4
        {
            public static class ForgottenCity
            {
                public const string Comic = "c4Comic";

                public const string Hub = "c4Hub";
                public const string HubHouse = "c4HubHouse";
            }

            public static class UpperRuins
            {
                public const string R01 = "c4p2r01";
                public const string R02 = "c4p2r02";
                public const string R03 = "c4p2r03";
                public const string R04 = "c4p2r04";
                public const string R05 = "c4p2r05";
                public const string R06 = "c4p2r06";
                public const string R07 = "c4p2r07";
                public const string R08 = "c4p2r08";
                public const string R09 = "c4p2r09";

                public const string OverlookMeeting = "c4p2r03_OverlookMeeting";
                public const string MuralMeeting = "c4p2r06_MuralMeeting";

                public const string SpiritRoom = "c4p2_SpiritRoom";
            }

            public static class FountOfSouls
            {
                public const string R01 = "c4p3r01";
                public const string R02 = "c4p3r02";
                public const string R03 = "c4p3r03";
                public const string R04 = "c4p3r04";
                public const string R05 = "c4p3r05";
                public const string R06 = "c4p3r06";
                public const string R07 = "c4p3r07";
                public const string R08 = "c4p3r08";

                public const string Summit = "c4p3r08_Summit";
                public const string PainAttackRoom = "c4p3r05_PainAttackRoom";

                public const string SpiritRoomA = "c4p3_SpiritRoomA";
                public const string SpiritRoomB = "c4p3_SpiritRoomB";
            }
        }

        public static class Chapter5
        {
            public static class TheChasm
            {
                public const string Comic = "c5Comic";
                public const string Hub = "c5Hub";
            }

            public static class LostLibraries
            {
                public const string R01 = "c5p2r01";
                public const string R02 = "c5p2r02";
                public const string R03 = "c5p2r03";
                public const string R04 = "c5p2r04";
                public const string R05 = "c5p2r05";
                public const string R06 = "c5p2r06";
                public const string R07 = "c5p2r07";
                public const string R08 = "c5p2r08";
                public const string R09 = "c5p2r09";
                public const string R10 = "c5p2r10";

                public const string FoyalLibraryFreakout = "c5p2r04_FoyalLibraryFreakout";

                public const string SpiritRoomA = "c5p2_SpiritRoomA";
                public const string SpiritRoomB = "c5p2_SpiritRoomB";
            }

            public static class TheChase
            {
                public const string R01 = "c5p3r01";
                public const string R02 = "c5p3r02";
                public const string R03 = "c5p3r03";
                public const string R04 = "c5p3r04";
                public const string R05 = "c5p3r05";
                public const string R06 = "c5p3r06";
                public const string R07 = "c5p3r07";
                public const string R08 = "c5p3r08";
                public const string R09 = "c5p3r09";
                public const string R10 = "c5p3r10";
                public const string R11 = "c5p3r11";
                public const string R12 = "c5p3r12";

                public const string FoyalTransformation = "c5p3r05_FoyalTransformation";

                public const string FoyalBossFightA = "c5p3r12_FoyalBossFightA";
                public const string FoyalBossFightB = "c5p3r12_FoyalBossFightB";

                public const string SpiritRoomA = "c5p3_SpiritRoomA";
                public const string SpiritRoomB = "c5p3_SpiritRoomB";
            }
        }

        public static class Chapter6
        {
            public static class VeiledChamber
            {
                public const string Comic = "c6Comic";

                public const string Hub = "c6p1r00_Hub";

                public const string R01 = "c6p1r01";
                public const string R02 = "c6p1r02";
                public const string R03 = "c6p1r03";
                public const string R04 = "c6p1r04";
                public const string R05 = "c6p1r05";
                public const string R06 = "c6p1r06";
                public const string R07 = "c6p1r07";
                public const string R08 = "c6p1r08";
                public const string R09 = "c6p1r09";
                public const string R10 = "c6p1r10";
                public const string R11 = "c6p1r11";

                public const string SpiritRoom = "c6p1_SpiritRoom";
            }

            public static class CorruptedHalls
            {
                public const string R01 = "c6p2r01";
                public const string R02 = "c6p2r02";
                public const string R03 = "c6p2r03";
                public const string R04 = "c6p2r04";
                public const string R05 = "c6p2r05";
                public const string R06 = "c6p2r06";
                public const string R07 = "c6p2r07";
                public const string R08 = "c6p2r08";
                public const string R09 = "c6p2r09";
                public const string R10 = "c6p2r10";

                public const string SpiritRoom = "c6p2_SpiritRoom";
            }
        }

        public static class Chapter7
        {
            public static class TheBinding
            {
                public const string R01A = "c7p1r01a";
                public const string R01B = "c7p1r01b";

                public const string R02A = "c7p1r02a";
                public const string R02B = "c7p1r02b";

                public const string R03A = "c7p1r03a";
                public const string R03B = "c7p1r03b";

                public const string R04A = "c7p1r04a";
                public const string R04B = "c7p1r04b";

                public const string R05A = "c7p1r05a";

                public const string MomCinematicART = "c7MomCinematic_ART";
                public const string MomCinematicPart2 = "c7MomCinematic_Part2";

                public const string GoopConfrontation = "c7GoopConfrontation";
                public const string GoopConfrontationPart2 = "c7GoopConfrontationPart2";

                public const string FoyalCinematic = "c7FoyalCinematic";

                public const string EldersCinematicPart1 = "c7EldersCinematicPart1";
                public const string EldersCinematicPart2 = "c7EldersCinematicPart2";

                public const string EndingA = "c7BindingEnding_A";
                public const string EndingB = "c7BindingEnding_B";
                public const string EndingC = "c7BindingEnding_C";
            }
        }
    }
}
