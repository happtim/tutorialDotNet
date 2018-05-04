using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SocketTool
{
    public partial class Form1 : Form {

        private Socket socket = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void tsbStart_Click(object sender, EventArgs e) {

            if (cboType.Text.Contains("Client")) {
                IPAddress ipAddress = IPAddress.Parse(cboIp.Text);
                IPEndPoint ipe = new IPEndPoint(ipAddress, int.Parse(txtPort.Text));

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try {
                    socket.Connect(ipe);

                    new Thread(new ThreadStart(delegate() {
                        while (true) {

                            try {
                                var bytes = new byte[1024];
                                int i = socket.Receive(bytes);
                                txtReceive.Text += "Receive:" + Encoding.ASCII.GetString(bytes, 0, i) + "\r\n";
                                txtConsole.AppendText(string.Format("Receive {0} Bytes\r\n", i));
                            } catch (SocketException se) {
                                txtConsole.AppendText(string.Format("SocketException : {0}\r\n", se.ToString()));
                            }

                        }
                    })).Start();
                  

                } catch (ArgumentNullException ae) {
                    txtConsole.AppendText(string.Format("ArgumentNullException : {0}\r\n", ae.ToString()));
                } catch (SocketException se) {
                    txtConsole.AppendText ( string.Format("SocketException : {0}\r\n", se.ToString()));
                } catch (Exception ex) {
                    txtConsole.AppendText ( string.Format("Unexpected exception : {0}\r\n", ex.ToString()));
                }

            } else if (cboType.Text.Contains("Server")) {

                try {
                    IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, int.Parse(txtPort.Text));
                    Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    listener.Bind(localEndPoint);
                    listener.Listen(100);

                    txtConsole.AppendText ("Waiting for a connection...\r\n");

                    new Thread(new ThreadStart(delegate (){

                        try {
                            while (true) {

                                socket = listener.Accept();

                                new Thread(new ThreadStart(delegate () {

                                    try {
                                        while (true) {
                                            var bytes = new byte[1024];
                                            int i = socket.Receive(bytes);

                                            txtReceive.Text += "Receive:" + Encoding.ASCII.GetString(bytes, 0, i) + "\r\n";
                                            txtConsole.AppendText(string.Format("Receive {0} Bytes\r\n", i));
                                        }

                                    } catch (SocketException se) {
                                        txtConsole.AppendText(string.Format("SocketException : {0}\r\n", se.ToString()));
                                    } catch (Exception ex) {
                                        txtConsole.AppendText(string.Format("Unexpected exception : {0}\r\n", ex.ToString()));
                                    } finally {
                                        socket.Close();
                                        socket.Dispose();
                                    }

                                })).Start();

                            }
                        }catch(SocketException se) {
                            txtConsole.AppendText(string.Format("SocketException : {0}\r\n", se.ToString()));
                        } catch (Exception ex) {
                            txtConsole.AppendText(string.Format("Unexpected exception : {0}\r\n", ex.ToString()));
                        }

                    })).Start();

                  

                } catch(SocketException se) {
                    txtConsole.AppendText(  string.Format("SocketException : {0}\r\n", se.ToString()));
                } catch (Exception ex)
                {
                    txtConsole.AppendText(string.Format("Unexpected exception : {0}\r\n", ex.ToString()));
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try {
                if(socket!= null && socket.Connected) {
                    int i = socket.Send( Encoding.ASCII.GetBytes( txtSend.Text ));
                    txtConsole.AppendText( string.Format("Send {0} Bytes \r\n", i));
                } else {
                    txtConsole.AppendText ( string.Format("Socket DisConnected."));
                }


            }catch(SocketException se) {
                txtConsole.AppendText(  string.Format("SocketException : {0}\r\n", se.ToString()));
            }
            catch (Exception ex)
            {
                txtConsole.AppendText (string.Format("Unexpected exception : {0}\r\n", ex.ToString()));
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            foreach(var ipAddress in ipHostInfo.AddressList) {
                cboIp.Items.Add(ipAddress.ToString());
            }
            cboIp.SelectedIndex = 0;
        }
    }
}
