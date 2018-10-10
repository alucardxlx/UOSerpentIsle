using System;

namespace Server.Items
{ 
    public class ShipTicketTele : Teleporter
    { 
        [Constructable]
        public ShipTicketTele()
            : base()
        {
        }

        public ShipTicketTele(Serial serial)
            : base(serial)
        {
        }

        public static ShipTicket GetTeleporterTicket(Mobile m)
        {
            for (int i = 0; i < m.Items.Count; i ++)
            {
                if (m.Items[i] is ShipTicket)
                    return (ShipTicket)m.Items[i];
            }
			
            if (m.Backpack != null)
                return m.Backpack.FindItemByType(typeof(ShipTicket), true) as ShipTicket;
				
            return null;
        }

        public override bool OnMoveOver(Mobile m)
        {
            ShipTicket ticket = GetTeleporterTicket(m);
			
            if (ticket != null)
            {
                ticket.Delete();
                m.SendMessage("Thy ticket is taken as thou boardest the ship.");

                return base.OnMoveOver(m);
            }
            else
				m.SendMessage("Thou will needest a ticket to board this ship.");
				
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
