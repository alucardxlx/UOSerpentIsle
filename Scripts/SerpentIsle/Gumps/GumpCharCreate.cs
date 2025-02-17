
//////////////////////////////////////////////////////////////////////
// Automatically generated by Bradley's GumpStudio and roadmaster's 
// exporter.dll,  Special thanks goes to Daegon whose work the exporter
// was based off of, and Shadow wolf for his Template Idea.
//////////////////////////////////////////////////////////////////////
//#define RunUo2_0

using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Regions;
using Felladrin.Commands;
using VitaNex.Items;
using VitaNex.SuperGumps.UI;
using Server.Mobiles;

namespace Server.Gumps
{
    public class GumpCharCreate : Gump
    {
        static Mobile caller;
        static int Page = 0;

        public static void Initialize()
        {
            CommandSystem.Register("CharCreate", AccessLevel.Player, new CommandEventHandler(_OnCommand));
        }

        [Usage("[CharCreate")]
        [Description("Calls the Character Creation gump. Must be at the SPEL.")]
        public static void _OnCommand(CommandEventArgs e)
        {
            caller = e.Mobile;

            if (caller.HasGump(typeof(GumpCharCreate)))
            {
                caller.CloseGump(typeof(GumpCharCreate));
            }

            if(caller.Region.IsPartOf("the Serpent Pillar Expedition Launch"))
                caller.SendGump(new GumpCharCreate(caller, 0));
        }

        public GumpCharCreate(Mobile from, int page = 0) : base( 150, 150)
        {
            caller = from;
            Page = page;

            this.Closable=false;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);
			AddBackground(0, 0, 320, 240, 9200);
			AddLabel(48, 17, 54, @"Create New Character");
			AddButton(23, 64, 4005, 4007, (int)Buttons.Name, GumpButtonType.Reply, 0);
			AddLabel(65, 63, 0, @"Name");
			AddButton(154, 64, 4005, 4007, (int)Buttons.Body, GumpButtonType.Reply, 0);
			AddButton(23, 108, 4005, 4007, (int)Buttons.Hair, GumpButtonType.Reply, 0);
			
			AddButton(154, 108, 4005, 4007, (int)Buttons.HColor, GumpButtonType.Reply, 0);
			
			AddLabel(198, 63, 0, @"Body");
			AddLabel(65, 108, 0, @"Hair");

            if (caller != null)
            {
                if (caller.Female == false)
                {
                    AddButton(23, 151, 4005, 4007, (int)Buttons.Beard, GumpButtonType.Reply, 0);
                    AddLabel(65, 150, 0, @"Beard");
                    AddLabel(198, 150, 0, @"B. Color");
                    AddButton(154, 151, 4005, 4007, (int)Buttons.BColor, GumpButtonType.Reply, 0);
                }
            }          			        

            AddLabel(198, 108, 0, @"H. Color");
            AddButton(128, 199, 247, 248, (int)Buttons.Submit, GumpButtonType.Reply, 0);
			AddBackground(427, 0, 250, 300, 9300);
			AddLabel(522, 12, 6, @"Guide");
			AddHtml( 447, 47, 209, 232, @"Welcome to Ultima Online Part 2: Serpent Isle! 

Please use this prompt to design your character. You can return to this prompt using the Character Create scroll in your backpack, or by entering the ""[charcreate"" command in chat. This scroll will be removed when you embark for the Serpent Isle.

Please also find in your backpack a Stat and Skill Study Guide, both of which can be used to design your starting class. If these books are not used, they will be removed when you embark for the Serpent Isle.

Finally, you have some starting gold, food, and a waterskin that can be refilled when in range of a trough or other source. Be certain you have completely prepared before you embark for the Serpent Isle.", (bool)true, (bool)true);

            if(Page == 1)
            {
                PageTwo();
            }
        }

        public void PageTwo()
        {
            AddPage(1);
            AddBackground(0, 30, 400, 228, 9200);
            AddLabel(142, 46, 54, @"Modify    Body:");
            AddBackground(427, 0, 250, 300, 9300);
            AddLabel(522, 12, 6, @"Guide");
            AddHtml(447, 47, 209, 232, @"Select thine sex and body color here.

This choice has no effect on skills, stats, or quests.", (bool)true, (bool)true);
            AddButton(246, 98, 1809, 1810, (int)Buttons.buttonMale, GumpButtonType.Reply, 0);
            AddButton(61, 98, 1806, 1807, (int)Buttons.buttonFemale, GumpButtonType.Reply, 0);
            AddButton(124, 158, 4005, 4007, (int)Buttons.BodyColor, GumpButtonType.Reply, 0);
            AddLabel(168, 157, 0, @"Body Color");
            AddButton(168, 215, 241, 243, (int)Buttons.Cancel, GumpButtonType.Reply, 0);
        }

        public enum Buttons
		{
			Name,
			Sex,
            Body,
			Hair,
			Beard,
			HColor,
			BColor,
			Submit,
			buttonMale,
			buttonFemale,
            BodyColor,
			Cancel
		}


        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            switch(info.ButtonID)
            {
                case (int)Buttons.Name:
				{
                    from.SendGump(new NameChangeDeedGump(from.Backpack));
					break;
				}
                case (int)Buttons.Body:
                {
                    if(from.HasGump(typeof(GumpCharCreate)))
                        from.CloseGump(typeof(GumpCharCreate));

                    from.SendGump(new GumpCharCreate(from, 1));
                    break;
                }
                case (int)Buttons.Hair:
				{
                    from.SendGump(new ChangeHairStyle.ChangeHairstyleGump(from, 0, false, ChangeHairStyle.ChangeHairstyleEntry.HairEntries));
					break;
				}
				case (int)Buttons.Beard:
				{
                    from.SendGump(new ChangeHairStyle.ChangeHairstyleGump(from, 0, true, ChangeHairStyle.ChangeHairstyleEntry.BeardEntries));
                    break;
				}
				case (int)Buttons.HColor:
				{
                    from.SendGump(new ChangeHairStyle.ChangeHairHueGump(from, 0, true, false, ChangeHairStyle.ChangeHairHueEntry.RegularEntries));
                    break;
				}
				case (int)Buttons.BColor:
				{
                    from.SendGump(new ChangeHairStyle.ChangeHairHueGump(from, 0, false, true, ChangeHairStyle.ChangeHairHueEntry.RegularEntries));
                    break;

				}
                case (int)Buttons.buttonMale:
                {
                    from.Body = from.Race.MaleBody;
                    from.HairItemID = 0;
                    from.HairHue = 0;
                    from.FacialHairItemID = 0;
                    from.FacialHairHue = 0;
                    from.Female = false;
                    break;
                }
                case (int)Buttons.buttonFemale:
                {
                    from.Body = from.Race.FemaleBody;
                    from.HairItemID = 0;
                    from.HairHue = 0;
                    from.FacialHairItemID = 0;
                    from.FacialHairHue = 0;
                    from.Female = true;
                    break;
                }
                case (int)Buttons.BodyColor:
                    {
                        BaseGump.SendGump(new InternalGump((PlayerMobile)from));
                        break;
                    }
                case (int)Buttons.Cancel:
                {
                    if (from.HasGump(typeof(GumpCharCreate)))
                        from.CloseGump(typeof(GumpCharCreate));

                    from.SendGump(new GumpCharCreate(from, 0));
                    break;
                }
                case (int)Buttons.Submit:
				{
                    from.CloseGump(typeof(GumpCharCreate));
					break;
				}

            }
        }

        private class InternalGump : BaseGump
        {
            public override int GetTypeID()
            {
                return 0xF3EA1;
            }

            public int SelectedHue { get; set; }

            public InternalGump(PlayerMobile pm)
                : base(pm, 50, 50)
            {

            }

            public override void AddGumpLayout()
            {
                AddBackground(0, 0, 460, 300, 2620);

                int[] list = GetHueList();

                int rows = User.Race == Race.Human ? 8 : 6;
                int start = User.Race == Race.Human ? 40 : 80;
                bool elf = User.Race == Race.Elf;

                int x = start;
                int y = start;
                int displayHue;

                for (int i = 0; i < list.Length; i++)
                {
                    if (i > 0 && i % rows == 0)
                    {
                        x = start;
                        y += 22;
                    }

                    displayHue = elf ? list[i] - 1 : list[i];

                    AddImage(x, y, 210, displayHue);
                    AddButton(x, y, 212, 212, i + 100, GumpButtonType.Reply, 0);

                    x += 21;
                }

                displayHue = SelectedHue != 0 ? SelectedHue : User.Hue ^ 0x8000;

                if (elf)
                    displayHue--;

                AddImage(240, 0, GetPaperdollImage(), displayHue);

                AddButton(250, 260, 239, 238, 1, GumpButtonType.Reply, 0);
                AddButton(50, 260, 242, 241, 0, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(RelayInfo info)
            {
                int button = info.ButtonID;

                if (button >= 100)
                {
                    button -= 100;

                    int[] list = GetHueList();

                    if (button >= 0 && button < list.Length)
                    {
                        SelectedHue = list[button];
                        Refresh(true, false);
                    }
                }
                else if (button == 1)
                {
                    if (SelectedHue != 0)
                    {
                        User.Hue = User.Race.ClipSkinHue(SelectedHue & 0x3FFF) | 0x8000;
                    }
                }
            }

            private int GetPaperdollImage()
            {
                if (User.Race == Race.Human)
                {
                    return User.Female ? 13 : 12;
                }

                if (User.Race == Race.Elf)
                {
                    return User.Female ? 15 : 14;
                }

                if (User.Race == Race.Gargoyle)
                {
                    return User.Female ? 665 : 666;
                }

                return 0;
            }

            private int[] GetHueList()
            {
                if (User.Race == Race.Human)
                {
                    return HumanSkinHues;
                }

                if (User.Race == Race.Elf)
                {
                    return ElfSkinHues;
                }

                if (User.Race == Race.Gargoyle)
                {
                    return GargoyleSkinHues;
                }

                return new int[0];
            }

            private static int[] _HumanSkinHues;
            private static int[] _ElfSkinHues;
            private static int[] _GargoyleSkinHues;

            public static int[] HumanSkinHues
            {
                get
                {
                    if (_HumanSkinHues == null)
                    {
                        _HumanSkinHues = new int[57];

                        for (int i = 0; i < _HumanSkinHues.Length; i++)
                        {
                            _HumanSkinHues[i] = i + 1001;
                        }
                    }

                    return _HumanSkinHues;
                }
            }

            public static int[] ElfSkinHues
            {
                get
                {
                    if (_ElfSkinHues == null)
                    {
                        _ElfSkinHues = new int[]
                        {
                            0x4DE, 0x76C, 0x835, 0x430, 0x24D, 0x24E, 0x24F, 0x0BF,
                            0x4A7, 0x361, 0x375, 0x367, 0x3E8, 0x3DE, 0x353, 0x903,
                            0x76D, 0x384, 0x579, 0x3E9, 0x374, 0x389, 0x385, 0x376,
                            0x53F, 0x381, 0x382, 0x383, 0x76B, 0x3E5, 0x51D, 0x3E6
                        };
                    }

                    return _ElfSkinHues;
                }
            }

            public static int[] GargoyleSkinHues
            {
                get
                {
                    if (_GargoyleSkinHues == null)
                    {
                        _GargoyleSkinHues = new int[25];

                        for (int i = 0; i < _GargoyleSkinHues.Length; i++)
                        {
                            _GargoyleSkinHues[i] = i + 1754;
                        }
                    }

                    return _GargoyleSkinHues;
                }
            }
        }
    }
}
