using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using AForge.Controls;
using AForge.Video.DirectShow;


namespace NetServer.TcpServer.Protocols {
	class CameraProtocol : Protocol {
		private static VideoSourcePlayer _videoSourcePlayer = null;
		private static FilterInfoCollection _videoDevices = null;
		private static FilterInfo _device = null;
		private static VideoCaptureDevice _videoSource = null;
		private static bool _IsStart = false;
		public static bool HasDevice { set; get; }

		public delegate void SetCameraOnEventHandler(bool on);

		public static SetCameraOnEventHandler SetCamerOnState = SetCameraOn;


		static CameraProtocol() {

			_videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

			if (_videoDevices.Count == 0) {
				HasDevice = false;
				return;
			}
			else {
				HasDevice = true;
			}

			_device = _videoDevices[0];

			_videoSource = new VideoCaptureDevice(_device.MonikerString);

			_videoSourcePlayer = new VideoSourcePlayer();
			_videoSourcePlayer.Name = "videoSourcePlayer";
			_videoSourcePlayer.Text = "videoSourcePlayer";

			_videoSourcePlayer.VideoSource = _videoSource;

		}



		public static void SetCameraOn(bool on) {
			if (_videoSourcePlayer.InvokeRequired) {
				_videoSourcePlayer.Invoke(new SetCameraOnEventHandler(SetCameraOn), on);
			}
			else {
				if (_videoSourcePlayer != null) {
					if (on && !_IsStart) {
						_IsStart = true;
						_videoSourcePlayer.Start();
					}

					if (!on && _IsStart) {
						_IsStart = false;
						_videoSourcePlayer.SignalToStop();
						_videoSourcePlayer.WaitForStop();
					}
				}
			}
		}

		private byte[] _data;

		public override byte[] Data {
			get { return _data; }
			set { _data = value; }
		}

		public CameraProtocol() {
		}

		public CameraProtocol(byte[] data) {
			this._data = data;
		}

		public CameraProtocol(bool nowCamera) {
			if (nowCamera) {
				this._data = GetCameraByte();
			}
		}

		public override object FormatReceiveProtocol() {
			MemoryStream ms = new MemoryStream(_data, 0, _data.Length);
			Image image = Image.FromStream(ms);
			return image;
		}

		public static byte[] GetCameraByte() {
			if (_videoSourcePlayer != null) {
				if (_videoSourcePlayer.GetCurrentVideoFrame() != null) {
					Bitmap bitmap = (Bitmap)_videoSourcePlayer.GetCurrentVideoFrame().Clone();
					MemoryStream ms = new MemoryStream();
					bitmap.Save(ms, ImageFormat.Jpeg);
					byte[] data = ms.GetBuffer();
					ms.Flush();
					return data;
				}
				else {
					return null;
				}
			}
			else {
				return null;
			}
		}
	}
}
