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
  
  public class MozWindow  {

    private EmbedWidget moz;
    private Entry editbox;
    private ProgressBar pbar;
    private Statusbar sbar;
    private Window win;
    private VBox vbox;
    private HBox hbox;
    private HBox hbox2;
    
    private string tempMessage;
    private int loadPercent;
    private uint actualchrome;

    private static int win_count = 0;
    private static int initialized = 0;

    private bool toolBarOn;
    private bool statusBarOn;
    
    public static readonly string path;
    public static readonly string pname;

    public MozWindow (string p1, string p2)
    {
      path = p1;
      pname = p2;
      initialized = 1;
      CreateWindow((uint)ChromeFlags.Defaultchrome);
    }
    
    public MozWindow (uint chrome)
    {
      CreateWindow(chrome);
    }
    
    public EmbedWidget moz_widget{
      get {
	return moz;
      }
    }
    
    private void CreateWindow (uint chrome)
    {
      // Increment Window count
      win_count += 1;

      // Put actualchrome in
      actualchrome = chrome;

      // Init chrome
      toolBarOn = false;
      statusBarOn = false;

      if (chrome == (uint)ChromeFlags.Defaultchrome)
      	actualchrome = (uint)ChromeFlags.Allchrome;

      if ((actualchrome & (uint)ChromeFlags.Toolbaron) == (uint)ChromeFlags.Toolbaron) {
        toolBarOn = true;
      }

      if ((actualchrome & (uint)ChromeFlags.Statusbaron) == (uint)ChromeFlags.Statusbaron) {
        statusBarOn = true;
      }

      win = new Window ("Gecko Tester");
      win.DefaultSize = new Size (800, 600);
      win.DeleteEvent += new DeleteEventHandler (Window_Delete);
      
      vbox = new VBox (false, 0);
      win.Add (vbox);
      
      hbox = new HBox (false, 0);
      vbox.PackStart (hbox, false, false, 0);
      
      Toolbar toolbar = new Toolbar();
      toolbar.ToolbarStyle = ToolbarStyle.Both;
      toolbar.Orientation = Orientation.Horizontal;
      hbox.PackStart(toolbar, false, false, 0);
      
      toolbar.AppendItem("Go Back", "Go Back", "Go Back",
			 new Label("Go Back"),  new SignalFunc (back_clicked_cb));
      
      toolbar.AppendItem("Stop", "Stop", "Stop",
			 new Label("Stop"), new SignalFunc (stop_clicked_cb));
      
      toolbar.AppendItem("Forward", "Go Forward", "Go Forward",
			 new Label("Go Forward"), new SignalFunc (forward_clicked_cb));
      
      toolbar.AppendItem("Reload", "Reload", "Reload",
			 new Label("Reload"), new SignalFunc (reload_clicked_cb));
      
      editbox = new Entry();
      editbox.Activated += new EventHandler(entry_act);
      hbox.PackStart (editbox, true, true, 0);
      
      if (initialized < 1)
	throw new Exception();

      // Now, if we are initialized, we need to set the profile
      // and set initialized state to 2
      if (initialized != 2) {
	moz = new EmbedWidget(path, pname);
	initialized = 2;
      } else {
        Console.WriteLine("Calling EmbedWidget()");
	moz = new EmbedWidget();
	Console.WriteLine("Done calling EmbedWidget()");
      }
    
      vbox.PackStart (moz, true, true, 0);
      
      // Ok, we have a LOT of GtkMozEmbed signals...
      moz.Location += new EventHandler(moz_location_cb);
      moz.Title += new EventHandler(moz_title_cb);
      moz.NetStart += new EventHandler(moz_netstart_cb);
      moz.NetStop += new EventHandler(moz_netstop_cb);
      moz.DestroyBrowser += new EventHandler(moz_destroybrsr_cb);
      //moz.LinkMessage += new EventHandler(moz_linkmessage_cb);
      //moz.JsStatus += new EventHandler(moz_jsstatus_cb);
      
      // Now the ones with args!
      moz.NewWindow += new NewWindowHandler(moz_new_win_cb);
      //moz.Progress += new ProgressHandler(moz_progress_cb);
      //moz.ProgressAll += new ProgressAllHandler(moz_progressall_cb);
      //moz.NetState += new NetStateHandler(moz_netstate_cb);
      //moz.NetStateAll += new NetStateAllHandler(moz_netstateall_cb);
      moz.Visibility += new VisibilityHandler(moz_visibility_cb);
      //moz.OpenUri += new OpenUriHandler(moz_openuri_cb);
      //moz.SizeTo += new SizeToHandler(moz_sizeto_cb);
      
      hbox2 = new HBox (false, 0);
      vbox.PackStart (hbox2, false, false, 0);
      
      pbar = new ProgressBar();
      hbox2.PackStart (pbar, false, false, 0);
      
      Alignment salign = new Alignment (0, 0, 1, 1);
      // usize here
      sbar = new Statusbar();
      
      salign.Add (sbar);
      hbox2.PackStart(salign, true, true, 0);
      
      moz.LoadUrl("http://www.go-mono.com");

      set_moz_visibility(true);      
    }
    
    void update_status_bar_text()
    {
      sbar.Pop(1);
      if (tempMessage != null) {
	sbar.Push(1, tempMessage);
      } else {
	if (loadPercent != 0) {}
      }
    }

    void set_moz_visibility(bool vis)
    {
      if (!vis) {
      	win.Hide();
      	return;
      }

      if (toolBarOn)
      	hbox.ShowAll();
      else
        hbox.HideAll();

      if (statusBarOn)
        hbox2.ShowAll();
      else
        hbox2.HideAll();

      moz.Show();
      vbox.Show();
      win.Show();
    }
    
    void moz_new_win_cb (object obj, NewWindowArgs args)
    {
      MozWindow new_win  = new MozWindow(args.Chromemask);
      
      args.NewEmbed = new_win.moz_widget;
    }
    
    void moz_location_cb (object obj, EventArgs args)
    {
      string newLocation = null;
      int newPosition = 0;
      
      newLocation = moz.GeckoLocation;
      if (newLocation != null) {
	editbox.DeleteText(0, -1);
	editbox.Text = newLocation;
      }
    }
    
    void moz_title_cb (object obj, EventArgs args)
    {
      string newTitle = moz.GeckoTitle;

      win.Title = newTitle;
    }
    
    void moz_netstart_cb (object obj, EventArgs args)
    {
      update_status_bar_text();
      Console.Error.WriteLine("Starting to load...");
    }
    
    void moz_netstop_cb (object obj, EventArgs args)
    {
      Console.Error.WriteLine("Done");
    }

    void moz_visibility_cb (object obj, VisibilityArgs args)
    {
      set_moz_visibility(args.Visibility);
    }
    
    void moz_destroybrsr_cb (object obj, EventArgs args)
    {
      win.Destroy();
      win_count -= 1;
      
      if (win_count == 0)
	Application.Quit();
    }
    
    void entry_act (object obj, EventArgs args)
    {
      moz.LoadUrl(editbox.Text);
    }
    
    void back_clicked_cb ()
    {
      moz.GoBack();
    }
    
    void stop_clicked_cb ()
    {
      moz.StopLoad();
    }
    
    void forward_clicked_cb ()
    {
      moz.GoForward();
    }
    
    void reload_clicked_cb ()
    {
      moz.Reload(0);
    }
    
    void Window_Delete (object obj, DeleteEventArgs args)
    {
      win.Destroy();
      win_count -= 1;
      
      if (win_count == 0)
	Application.Quit();
      
      args.RetVal = true;
    }   
  }
}
