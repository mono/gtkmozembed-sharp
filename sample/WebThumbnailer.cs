//
// Web thumbnailer sample application.
//
// Usage is: mono shot.exe url [-width N] [-height N] [output_file]
//
// Width, Height can optionally be specified, the right thing will happen.
//
// Author:
//   Miguel de Icaza.
//
using System;
using Gtk;
using Gecko;
using GLib;

class X {
	static WebControl wc;
	static string output = null;
	static string url = null;
	static int width = -1;
	static int height = -1;
	
	static void Main (string [] args)
	{
		for (int i = 0; i < args.Length; i++){
			switch (args [i]){
			case "-width":
				try {
					i++;
					width = Int32.Parse (args [i]);
				} catch {
					Console.WriteLine ("-width requires an int argument");
				}
				break;
			case "-height":
				try {
					i++;
					height = Int32.Parse (args [i]);
				} catch {
					Console.WriteLine ("-height requires an int argument");
				}
				break;
			case "-help":
			case "-h":
				Help ();
				break;
				
			default:
				if (url == null)
					url = args [i];
				else if (output == null)
					output = args [i];
				else
					Help ();
				break;
			}
		}
		if (url == null)
			Help ();
		if (output == null)
			output = "shot.png";

		Application.Init();
		Window w = new Window ("test");
		wc = new WebControl ();
		wc.LoadUrl (args [0]);
		wc.Show ();
		wc.LocChange += WaitABit;
		wc.SetSizeRequest (1024, 768);
		w.Add (wc);
		w.ShowAll ();
		//GLib.Timeout.Add(700, new TimeoutHandler(MakeShot));		
		Application.Run();
	}

	static void Help ()
	{
		Console.WriteLine ("Usage is: WebThumbnailer [-width N] [-height N] url [shot]");
		Environment.Exit (0);
	}
	
	static void WaitABit (object sender, EventArgs e)
	{
		GLib.Timeout.Add(1000, new TimeoutHandler(MakeShot));
	}
	
	static bool MakeShot ()
	{
		Console.WriteLine(wc.Location);
		Gdk.Window win = wc.GdkWindow;
		int iwidth = wc.Allocation.Width;
		int iheight = wc.Allocation.Height;
		Gdk.Pixbuf p = new Gdk.Pixbuf (Gdk.Colorspace.Rgb, false, 8, iwidth, iheight);
		Gdk.Pixbuf scaled;
	
		p.GetFromDrawable (win, win.Colormap, 0, 0, 0, 0, iwidth, iheight);
		if (width == -1){
			if (height == -1)
				scaled = p;
			else
				scaled = p.ScaleSimple (height * iwidth / iheight, height, Gdk.InterpType.Hyper);
		} else {
			if (height == -1)
				scaled = p.ScaleSimple (width, width * iheight / iwidth, Gdk.InterpType.Hyper);
			else
				scaled = p.ScaleSimple (width, height, Gdk.InterpType.Hyper);
		}
	
		scaled.Save (output, "png"); 
		Application.Quit ();
		return true;
	}
}
