using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PleaseShareYourCode.PSYC
{
	public partial class AutoCloseMessageBox : Form
	{
		private Timer mFadeTimer;
		private Timer mCloseTimer;
		private const double OPACITY_INCREMENT = 0.05;
		private int mFadeOutTime;

		public AutoCloseMessageBox(string message, int displayTime, int fadeInTime, int fadeOutTime)
		{
			InitializeComponent();

			label1.Text = message;

			mCloseTimer = new Timer();
			mCloseTimer.Interval = displayTime;
			mCloseTimer.Tick += new EventHandler(CloseTimer_Tick);

			mFadeTimer = new Timer();
			mFadeTimer.Interval = fadeInTime;
			mFadeTimer.Tick += new EventHandler(FadeInTimer_Tick);

			mFadeOutTime = fadeOutTime;
		}

		private void AutoCloseMessageBox_Shown(object sender, EventArgs e)
		{
			mCloseTimer.Start();
			mFadeTimer.Start();
		}

		private void CloseTimer_Tick(object sender, EventArgs e)
		{
			mCloseTimer.Stop();
			mFadeTimer.Stop();

			// Start fading out
			mFadeTimer = new Timer();
			mFadeTimer.Interval = mFadeOutTime;
			mFadeTimer.Tick += new EventHandler(FadeOutTimer_Tick);
			mFadeTimer.Start();
		}

		private void FadeInTimer_Tick(object sender, EventArgs e)
		{
			if (Opacity < 1)
			{
				Opacity += OPACITY_INCREMENT;
			}
			else
			{
				mFadeTimer.Stop();
			}
		}

		private void FadeOutTimer_Tick(object sender, EventArgs e)
		{
			if (Opacity > 0)
			{
				Opacity -= OPACITY_INCREMENT;
			}
			else
			{
				mFadeTimer.Stop();
				Close();
			}
		}
	}
}
