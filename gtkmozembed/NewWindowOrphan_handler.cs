// This file was generated by the Gtk# Code generator.
// Any changes made will be lost if regenerated.

namespace Gecko {

	using System;

	public delegate void NewWindowOrphanHandler(object o, NewWindowArgs args);

	public class NewWindowOrphanArgs : GLib.SignalArgs {
		public WebControl NewEmbed{
			set {
				Args[0] = (WebControl) value;
			}
		}

		public uint Chromemask{
			get {
				return (uint) Args[1];
			}
		}

	}
}
