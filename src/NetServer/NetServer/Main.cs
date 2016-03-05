using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.IO;
using NetServer.TcpServer.Protocols;

namespace NetServer
{
    public partial class Main : Form
    {

        private static int PORT = 8116;
        private static int MAX_BACK = 5;
        private static int PACK_LENGTH = 1024;

        private Socket socket;
        private IPEndPoint serverIPEL;
        private Thread th;
        private Socket uc;
        private ArrayList alSock;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
			NetServer.TcpServer.Protocols.DataHead head = new TcpServer.Protocols.DataHead(200, TcpServer.Protocols.ProtocolType.C2SMessage, "aabbccdd");
			byte[] data = head.GetHeadByte();
			NetServer.TcpServer.Protocols.DataHead head2 = new TcpServer.Protocols.DataHead(data);
			MessageBox.Show(head2.HeadType + "  " + head2.DataLength + "  " + head2.Tag );

            //int[][] results;
            //results.GetLength(
        }

        private void Server()
        {
			/*
            serverIPEL = new IPEndPoint(IPAddress.Any, PORT);
            socket = new Socket(serverIPEL.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind((EndPoint)serverIPEL);
            socket.Listen(MAX_BACK);
            alSock = new ArrayList();

            while (true)
            {
                try
                {
                    uc = socket.Accept();
                    alSock.Add(uc);

                    byte[] data = new byte[PACK_LENGTH];
                    int rect = uc.Receive(data);

                }
                catch (Exception ex)
                {

                }
            }
			 */
        }
		/*
        public void Listen()
        {     //设置端口
            //setPort = int.Parse(serverport.Text.Trim());
            //初始化SOCKET实例
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //初始化终结点实例
            serverIPEL = new IPEndPoint(IPAddress.Any, PORT);
            try
            {
                //绑定
                socket.Bind(serverIPEL);
                //监听
                socket.Listen(MAX_BACK);
                //用于设置按钮状态
                //m_Listening = true;
                //开始接受连接，异步。
                socket.BeginAccept(new AsyncCallback(OnConnectRequest), socket);
            }
            catch (Exception ex)
            {
                lst_Error.Items.Add(ex);
            }

        }
		*/
        public void OnConnectRequest(IAsyncResult ar)
        {
            //初始化一个SOCKET，用于其它客户端的连接
            Socket server = (Socket)ar.AsyncState;
            Socket client = server.EndAccept(ar);

            //将要发送给连接上来的客户端的提示字符串
            string strDateLine = "getscr";
            Byte[] byteDateLine = System.Text.Encoding.ASCII.GetBytes(strDateLine);
            //将提示信息发送给客户端
            client.Send(byteDateLine, byteDateLine.Length, 0);
            //等待新的客户端连接
            server.BeginAccept(new AsyncCallback(OnConnectRequest), server);
            while (true)
            {
                int recv = client.Receive(byteDateLine);
                string stringdata = Encoding.ASCII.GetString(byteDateLine, 0, recv);
                if (stringdata == "bit")
                {
                    byte[] by = new byte[1024 * 256];
                    recv = client.Receive(by);

                    Image MyImage = Image.FromStream(new MemoryStream(by));
                    //pic_Box.Image = MyImage;
                    //pic_.Image = MyImage;//显示图片
                    //Bitmap bitmap = BytesToBitmap(byteDateLine);
                    //pic_Box.Image = bitmap;
                }
                /*
                string stringdata = Encoding.ASCII.GetString(byteDateLine, 0, recv);
                DateTimeOffset now = DateTimeOffset.Now;
                //获取客户端的IP和端口
                string ip = client.RemoteEndPoint.ToString();
                if (stringdata == "STOP")
                {
                    //当客户端终止连接时
                    showinfo.AppendText(ip + "已从服务器断开");
                    break;
                }
                //显示客户端发送过来的信息
                showinfo.AppendText(ip + "    " + now.ToString("G") + "     " + stringdata + "\r\n");
                 * */
            }

        }

        public static Bitmap BytesToBitmap(byte[] Bytes)
        {
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream(Bytes);
                return new Bitmap((Image)new Bitmap(stream));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            finally
            {
                stream.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Listen();
        }

		private void button2_Click(object sender, EventArgs e) {
			/*
			FileListProtocol flp = new FileListProtocol(@"F:\迅雷下载");
			byte[] data = flp.Data;
			FileListProtocol flp2 = new FileListProtocol(data);
			List<string[]> files = (List<string[]>) flp2.FormatReceiveProtocol();
			files.ForEach(a => {
				for (int i = 0; i < a.Length; i++) {
					richTextBox1.Text += a[i] + '\n';
				}
			});
			 * */
			DeviceProtocol dp = new DeviceProtocol();
			byte[] data = dp.Data;
			DeviceProtocol dp2 = new DeviceProtocol(data);
			List<string> devi = (List<string>)dp2.FormatReceiveProtocol();
			devi.ForEach(a => richTextBox1.Text += a + '\n');


		}
    }
}
