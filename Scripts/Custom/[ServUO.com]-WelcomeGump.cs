using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class WelcomeGump : Gump
	{
		public WelcomeGump()
			: base( 0, 0 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(128, 205, 532, 384, 9250);
			this.AddImage(243, -24, 1418);
			this.AddBackground(144, 220, 501, 353, 9350);
			this.AddBackground(166, 295, 457, 264, 2620);
			this.AddAlphaRegion(172, 302, 444, 249);
			this.AddImage(76, 174, 10440);
			this.AddImage(627, 174, 10441);
			this.AddImageTiled(280, 242, 226, 31, 87);
			this.AddHtml( 172, 302, 444, 249, @"Neshobas Announcement Of The Day!

Recent Updates:

++++++++++++++++
Oct, 21, 2017
++++++++++++++++
 add your content here
++++++++++++++++
Oct, 20, 2017
+++++++++++++++
 add your content here
++++++++++++++++
Oct, 2 , 2017
++++++++++++++++
add your content here
++++++++++++++++
July,18, 2017
++++++++++++++++
add your content in this section
March, 16 , 2017
++++++++++++++++
same thing in this section
++++++++++++++++
Jan,28, 2017
++++++++++++++++
same thing here also 
++++++++++++++++
Dec, 13 2016
++++++++++++++++ 
Some of the rules at forums have been updated  Please stop and read them
 
++++++++++++++++
March 12, 2018
++++++++++++++++

also add content here if needed


-------------------------------------------------------------------------------------------

Please check Webstones Located Throughout The World for an idea on how things work around here(Direct yourself to the Web Stone).", (bool)false, (bool)true); // this can be edited also
			this.AddImage(268, 228, 83);
			this.AddImageTiled(283, 226, 222, 20, 84);
			this.AddLabel(318, 236, 1577, @"Neshobas Gorean World!"); /// change this it is the welcome gump header
			this.AddImage(305, 259, 96);
			this.AddImage(484, 250, 97);
			this.AddImage(296, 250, 95);
			this.AddImage(505, 228, 85);
			this.AddImageTiled(266, 244, 14, 31, 86);
			this.AddImageTiled(506, 243, 14, 26, 88);
			this.AddImage(268, 267, 89);
			this.AddImage(505, 267, 91);
			this.AddImageTiled(284, 269, 222, 12, 90);

		}
		

	}
}