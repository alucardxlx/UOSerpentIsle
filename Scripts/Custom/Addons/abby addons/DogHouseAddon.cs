// Automatically generated by the
// AddonGenerator script by Arya
// Generator edited 10.Mar.07 by Papler
using System;
using Server;
using Server.Items;
namespace Server.Items
{
	public class DogHouseAddon : BaseAddon {
		public override BaseAddonDeed Deed{get{return new DogHouseAddonDeed();}}
		[ Constructable ]
		public DogHouseAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 5634 );
			AddComponent( ac, 2, 0, 0 );

			ac = new AddonComponent( 1472 );
			AddComponent( ac, 1, 3, 10 );

			ac = new AddonComponent( 3244 );
			AddComponent( ac, 1, 2, 0 );

			ac = new AddonComponent( 1472 );
			AddComponent( ac, 1, 2, 13 );

			ac = new AddonComponent( 6930 );
			AddComponent( ac, 1, 1, 0 );

			ac = new AddonComponent( 1473 );
			AddComponent( ac, 1, 1, 13 );

			ac = new AddonComponent( 3707 );
			AddComponent( ac, 1, 0, 0 );

			ac = new AddonComponent( 3254 );
			AddComponent( ac, 0, 3, 0 );

			ac = new AddonComponent( 1472 );
			AddComponent( ac, 0, 3, 10 );

			ac = new AddonComponent( 1472 );
			AddComponent( ac, 0, 2, 13 );

			ac = new AddonComponent( 16 );
			AddComponent( ac, 0, 2, 0 );

			ac = new AddonComponent( 7067 );
			AddComponent( ac, 0, 1, 0 );

			ac = new AddonComponent( 1473 );
			AddComponent( ac, 0, 1, 13 );

			ac = new AddonComponent( 3254 );
			AddComponent( ac, 0, 0, 0 );

			ac = new AddonComponent( 18 );
			AddComponent( ac, 0, 0, 0 );

			ac = new AddonComponent( 3245 );
			AddComponent( ac, -1, 3, 0 );

			ac = new AddonComponent( 1472 );
			AddComponent( ac, -1, 3, 10 );

			ac = new AddonComponent( 1472 );
			AddComponent( ac, -1, 2, 13 );

			ac = new AddonComponent( 18 );
			AddComponent( ac, -1, 2, 0 );

			ac = new AddonComponent( 1473 );
			AddComponent( ac, -1, 1, 13 );

			ac = new AddonComponent( 18 );
			AddComponent( ac, -1, 0, 0 );

			ac = new AddonComponent( 3348 );
			AddComponent( ac, -2, 3, 0 );

			ac = new AddonComponent( 17 );
			AddComponent( ac, -2, 2, 0 );

			ac = new AddonComponent( 17 );
			AddComponent( ac, -2, 1, 0 );

			ac = new AddonComponent( 3287 );
			AddComponent( ac, -2, -2, 0 );

			ac = new AddonComponent( 3286 );
			AddComponent( ac, -2, -2, 0 );


		}
		public DogHouseAddon( Serial serial ) : base( serial ){}
		public override void Serialize( GenericWriter writer ){base.Serialize( writer );writer.Write( 0 );}
		public override void Deserialize( GenericReader reader ){base.Deserialize( reader );reader.ReadInt();}
	}

	public class DogHouseAddonDeed : BaseAddonDeed {
		public override BaseAddon Addon{get{return new DogHouseAddon();}}
		[Constructable]
		public DogHouseAddonDeed(){Name = "DogHouse";}
		public DogHouseAddonDeed( Serial serial ) : base( serial ){}
		public override void Serialize( GenericWriter writer ){	base.Serialize( writer );writer.Write( 0 );}
		public override void	Deserialize( GenericReader reader )	{base.Deserialize( reader );reader.ReadInt();}
	}
}