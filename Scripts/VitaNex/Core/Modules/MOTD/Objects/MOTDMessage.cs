﻿#region Header
//   Vorspire    _,-'/-'/  MOTDMessage.cs
//   .      __,-; ,'( '/
//    \.    `-.__`-._`:_,-._       _ , . ``
//     `:-._,------' ` _,`--` -: `_ , ` ,' :
//        `---..__,,--'  (C) 2018  ` -'. -'
//        #  Vita-Nex [http://core.vita-nex.com]  #
//  {o)xxx|===============-   #   -===============|xxx(o}
//        #        The MIT License (MIT)          #
#endregion

#region References
using System;
using System.Drawing;
using System.Text;

using Server;

using VitaNex.Text;
#endregion

namespace VitaNex.Modules.MOTD
{
	[PropertyObject]
	public sealed class MOTDMessage : IEquatable<MOTDMessage>, IComparable<MOTDMessage>
	{
		public string UniqueID { get; private set; }

		[CommandProperty(MOTD.Access)]
		public TimeStamp Date { get; set; }

		[CommandProperty(MOTD.Access)]
		public string Title { get; set; }

		[CommandProperty(MOTD.Access)]
		public string Content { get; set; }

		[CommandProperty(MOTD.Access)]
		public string Author { get; set; }

		[CommandProperty(MOTD.Access)]
		public bool Published { get; set; }

		public MOTDMessage(
			string uid,
			TimeStamp date,
			string title,
			string content,
			string author = "*Anon*",
			bool published = false)
		{
			UniqueID = uid;
			Date = date;
			Title = title;
			Content = content;
			Author = author;
			Published = published;
		}

		public int CompareTo(MOTDMessage m)
		{
			return m == null ? -1 : Date > m.Date ? -1 : Date < m.Date ? 1 : 0;
		}

		public void Delete()
		{
			Date = TimeStamp.UtcNow;
			Title = String.Empty;
			Content = String.Empty;
			Published = false;

			MOTD.Messages.Remove(UniqueID);
		}

		public override string ToString()
		{
			return String.Format("{0}: {1} ({2})", Date.Value.ToSimpleString(), Title, Author);
		}

		public string ToHtmlString(
			bool includeDate = true,
			bool includeTitle = true,
			bool includeAuthor = true,
			bool includeContent = true,
			bool usePrefix = true,
			bool parseCode = true,
			Color? headerColor = null,
			Color? contentColor = null)
		{
			var output = new StringBuilder();
			var hasHeader = false;

			output.Append("<BODY>");

			if (includeDate)
			{
				output.AppendFormat("<BIG><B>{0}{1}</B></BIG><BR>", usePrefix ? "Date: " : String.Empty, Date.Value.ToString("g"));
				hasHeader = true;
			}

			if (includeAuthor)
			{
				output.AppendFormat("<BIG><B>{0}{1}</B></BIG><BR>", usePrefix ? "Author: " : String.Empty, Author);
				hasHeader = true;
			}

			if (includeTitle)
			{
				output.AppendFormat("<BIG><B>{0}{1}</B></BIG><BR>", usePrefix ? "Title: " : String.Empty, Title);
				hasHeader = true;
			}

			if (hasHeader && headerColor != null)
			{
				output.Insert(6, String.Format("<BASEFONT COLOR=#{0:X6}>", headerColor.Value.ToRgb()));
			}

			if (includeContent)
			{
				var content = hasHeader ? "<BR>" + Content : Content;

				if (parseCode)
				{
					content = content.ParseBBCode(contentColor);
				}

				if (contentColor != null)
				{
					output.AppendFormat("<BASEFONT COLOR=#{0:X6}>{1}", contentColor.Value.ToRgb(), content);
				}
				else
				{
					output.Append(content);
				}
			}

			output.Append("</BASEFONT>");
			output.Append("</BODY>");

			return output.ToString();
		}

		public override int GetHashCode()
		{
			return UniqueID != null ? UniqueID.GetHashCode() : 0;
		}

		public override bool Equals(object obj)
		{
			return obj is MOTDMessage && Equals((MOTDMessage)obj);
		}

		public bool Equals(MOTDMessage other)
		{
			return !ReferenceEquals(null, other) && UniqueID == other.UniqueID;
		}

		public void Serialize(GenericWriter writer)
		{
			var version = writer.SetVersion(0);

			switch (version)
			{
				case 0:
				{
					writer.Write(UniqueID);
					writer.Write(Date.Stamp);
					writer.Write(Title);
					writer.Write(Content);
					writer.Write(Author);
					writer.Write(Published);
				}
					break;
			}
		}

		public void Deserialize(GenericReader reader)
		{
			var version = reader.GetVersion();

			switch (version)
			{
				case 0:
				{
					UniqueID = reader.ReadString();
					Date = reader.ReadDouble();
					Title = reader.ReadString();
					Content = reader.ReadString();
					Author = reader.ReadString();
					Published = reader.ReadBool();
				}
					break;
			}
		}

		public static bool operator ==(MOTDMessage l, MOTDMessage r)
		{
			return ReferenceEquals(l, null) ? ReferenceEquals(r, null) : l.Equals(r);
		}

		public static bool operator !=(MOTDMessage l, MOTDMessage r)
		{
			return ReferenceEquals(l, null) ? !ReferenceEquals(r, null) : !l.Equals(r);
		}
	}
}