using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetServer {
	public partial class MidFormScreen : Form {
		public MidFormScreen() {
			InitializeComponent();
		}

		private void MidFormScreen_Load(object sender, EventArgs e) {

		}

		private void tsb_Scale_Click(object sender, EventArgs e) {
			if (pic_Screen.SizeMode == PictureBoxSizeMode.Normal) {
				pic_Screen.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			else {
				pic_Screen.SizeMode = PictureBoxSizeMode.Normal;
			}
		}

		private void pic_Screen_Click(object sender, EventArgs e) {

		}
	}
}
