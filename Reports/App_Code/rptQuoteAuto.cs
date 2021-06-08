îusing System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports
{
	/// <summary>
	/// Summary description for rptQuoteAuto.
	/// </summary>
	public class rptQuoteAuto : ActiveReport
	{
		public rptQuoteAuto()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeReport();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
			}
			base.Dispose( disposing );
		}

		#region Report Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeReport()
		{
		}
		#endregion
	}
}
