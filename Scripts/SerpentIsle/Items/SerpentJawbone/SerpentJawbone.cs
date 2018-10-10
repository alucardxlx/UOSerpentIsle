using System;

namespace Server.Items
{
    public class SerpentJawbone : Item
    {
		[Constructable]
		public SerpentJawbone() : base(0x0F05)
		{
			Name = "Serpent's Jawbone";
		}

        public SerpentJawbone(Serial serial)
            : base(serial)
        {
        }


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
