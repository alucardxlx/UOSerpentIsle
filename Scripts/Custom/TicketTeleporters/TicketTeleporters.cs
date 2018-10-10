using System;

namespace Server.Items
{ 
    public class TicketTele : Teleporter
    { 
        [Constructable]
        public TicketTele()
            : base()
        {
        }

        public TicketTele(Serial serial)
            : base(serial)
        {
        }

        public static TeleporterTicket GetTeleporterTicket(Mobile m)
        {
            for (int i = 0; i < m.Items.Count; i ++)
            {
                if (m.Items[i] is TeleporterTicket)
                    return (TeleporterTicket)m.Items[i];
            }
			
            if (m.Backpack != null)
                return m.Backpack.FindItemByType(typeof(TeleporterTicket), true) as TeleporterTicket;
				
            return null;
        }

        public override bool OnMoveOver(Mobile m)
        {
            TeleporterTicket ticket = GetTeleporterTicket(m);
			
            if (ticket != null)
            {
                if (Utility.RandomDouble() < 0.75 || ticket.Insured || ticket.LootType == LootType.Blessed)
                {
					m.SendMessage("Your ticket is valid.");
                }
                else
                {
                    ticket.Delete();
					m.SendMessage("Your ticket disappears as you step onto the teleporter.");
                }
				
                return base.OnMoveOver(m);
            }
            else
				m.SendMessage("Nothing happens as you step onto the teleporter.");
				
            return true;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
			
            int version = reader.ReadInt();
        }
    }
}