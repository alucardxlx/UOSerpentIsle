using System;

namespace Server.Items
{ 
    public class SerpentTele : Teleporter
    {
        [CommandProperty(AccessLevel.GameMaster)]
        public static bool ToDarkPath { get { return ToDarkPath; } set { ToDarkPath = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public static Point3D ToWorldLoc { get { return ToWorldLoc; } set { ToWorldLoc = value; } }


        [Constructable]
        public SerpentTele()
            : base()
        {
        }

        public SerpentTele(Serial serial)
            : base(serial)
        {
        }

        public static SerpentJawbone GetTeleporterTicket(Mobile m)
        {
            for (int i = 0; i < m.Items.Count; i ++)
            {
                if (m.Items[i] is SerpentJawbone)
                    return (SerpentJawbone)m.Items[i];
            }
			
            if (m.Backpack != null)
                return m.Backpack.FindItemByType(typeof(SerpentJawbone), true) as SerpentJawbone;
				
            return null;
        }

        public override bool OnMoveOver(Mobile m)
        {
            SerpentJawbone ticket = GetTeleporterTicket(m);
			
            if (ticket != null && ToDarkPath)
            {
                m.SendMessage("Thy Jawbone reacts with the Serpent Gate.");
                m.SendSound(0x20F);
                m.MoveToWorld(new Point3D(2241, 1540, 5), Map.Ilshenar);
                return base.OnMoveOver(m);
            }
            else if(ticket != null && !ToDarkPath)
            {
                m.SendMessage("Thy Jawbone reacts with the Serpent Gate.");
                m.SendSound(0x20F);
                if(ToWorldLoc != Point3D.Zero)
                    m.MoveToWorld(ToWorldLoc, Map.Ilshenar);
                return base.OnMoveOver(m);
            }
            else
				m.SendMessage("Nothing happens as thou steppest across the Gate.");
				
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
