using System;

namespace BibliographyMaker
{
	public partial class dialog : Gtk.Dialog
	{
		public dialog ()
		{
			this.Build ();

		}
		protected void buttonEvent (object sender, EventArgs e)
		{
			this.Destroy();
		}

	}
}

