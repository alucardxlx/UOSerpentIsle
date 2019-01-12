using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Mobiles
{
    class Filbercio : TalkingBaseCreature
    {
        [Constructable]
        public Filbercio() : base(AIType.AI_Mage, FightMode.None, 5, 1, 0.1, 0.2)
        {
            Name = "Filbercio";
            Female = false;
            InitBody();
        }

        public Filbercio(Serial serial) : base(serial)
        {
        }

        public void InitBody()
        {
            Body = 0x190;
            Hue = 0x83EA;
            SpeechHue = Utility.RandomDyedHue();

            InitOutfit();
        }

        public void InitOutfit()
        {
            Item hair = new Item(8252)
            {
                Hue = 1133,
                Layer = Layer.Hair,
                Movable = false
            };
            AddItem(hair);

            Items.Bonnet bonnet = new Items.Bonnet()
            {
                Hue = 3
            };
            AddItem(bonnet);

            Server.Items.FancyShirt fancyShirt = new Items.FancyShirt()
            {
                Hue = 718
            };
            AddItem(fancyShirt);

            Server.Items.GildedDress gildedDress = new Items.GildedDress()
            {
                Hue = 718
            };
            AddItem(gildedDress);

            Server.Items.Shoes shoes = new Items.Shoes()
            {
                Hue = 718
            };
            AddItem(shoes);

            PackGold(50, 200);
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
