/* 
	LetterGump.cs - Version 3.0
	Script generated by Gump Creator 2.01
	
	Mail System - Version 1.0

	Newly Modified On 15/11/2016 
	
	By Veldian 
	Dragon's Legacy Uo Shard 
*/

using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;

namespace Server.Gumps
{
    public class LetterGump : Gump
    {
        private Mobile m_Owner;
		private Mobile m_From;
        private string m_Letter;
        public Item m_Master;
        public PlayerLetter playlet;

        public Mobile Owner 
		{
			get { return m_Owner; } 
			set { m_Owner = value; }	
		}

        public LetterGump(Mobile owner, string text, Mobile from, Item master)
            : base(25, 25)
        {
            m_Master = master;
            playlet = m_Master as PlayerLetter;
            m_From = from;
            m_Letter = text;
            owner.CloseGump(typeof(LetterGump));

            int gumpX = 0; int gumpY = 0; bool initialState = false;

            m_Owner = owner;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = true;

            AddPage(1);
			
			gumpX = 0; gumpY = 0;
            AddImage(gumpX, gumpY, 0x820);

			gumpX = 35; gumpY = 5;
            AddLabel(gumpX, gumpY, 0xFAE, "From");

			gumpX = 95; gumpY = 5;
            AddLabel(gumpX, gumpY, 0x111, m_From.Name);

            gumpX = 17; gumpY = 37;
            AddImage(gumpX, gumpY, 0x821);

            gumpX = 17; gumpY = 107;
            AddImage(gumpX, gumpY, 0x822);

            gumpX = 17; gumpY = 177;
            AddImage(gumpX, gumpY, 0x822);

			gumpX = 18; gumpY = 247;
            AddImage(gumpX, gumpY, 0x823);

            gumpX = 245; gumpY = 253;
            AddButton(gumpX, gumpY, 0xFAE, 0xFB0, 1, GumpButtonType.Reply, 0);

            gumpX = 210; gumpY = 255;
            AddLabel(gumpX, gumpY, 0, "Reply");

            gumpX = 30; gumpY = 37;
            AddHtml(gumpX, gumpY, 234, 200, m_Letter, false, true);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 1:
                    if (playlet != null)
                    {
                        if (playlet.m_Replied == false)
                        {
                            from.SendGump(new WriteLetterGump(m_Owner, m_From));
                            from.CloseGump(typeof(LetterGump));
                            playlet.m_Replied = true;
                            playlet.Name = playlet.Name;
                        }
                        else
                            from.SendMessage("You have already replied to that message!");
                    }
                    break;
            }
        }
    }
}
