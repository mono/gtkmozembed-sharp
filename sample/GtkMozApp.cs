// GtkMozEmbed test app
//
// Author: Mark Crichton <crichton@gimp.org>
//
// (c) 2002-2003 Mark Crichton

namespace GtkSamples {

	using Gtk;
	using GtkSharp;
	using GtkMozEmbed;
	using GtkMozEmbedSharp;
	using System;
	using System.Drawing;

	public class MozApp  {

		public static int Main (string[] args)
		{
			Application.Init ();

			MozWindow main_win = new MozWindow("/tmp/mono-test", "MonoSharpTest");

			Application.Run ();
			return 0;
		}
	}
}
