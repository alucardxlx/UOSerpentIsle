using System;

namespace Server.Items
{
    public class TeleporterTicket : Item
    {
		[Constructable]
		public TeleporterTicket() : base( 0x14F0 )
		{
			Name = "Ticket to Teleport";
			Hue = 0x492;
		}

        public TeleporterTicket(Serial serial)
            : base(serial)
        {
        }

        /*public override int LabelNumber
        {
            get
            {
                return 1020526;
            }
        }// bone machete*/

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}