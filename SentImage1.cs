namespace ChatServer
{
    class VideoServer
    {
        // The thread that will hold the connection listener
        private Thread thrListener;
        private Thread thrCapturing;
        // The TCP object that listens for connections
        private TcpListener tlsClient;
        // Will tell the while loop to keep monitoring for connections
        bool ServRunning = false;
        public static List<tcpclient> ClientList = new List<tcpclient>();

        private TcpClient tcpClient;

        public Image img;
        public Image img1;
        public event EventHandler sendPicture;
        public Form1 padre;

        public VideoServer(Image image, Form1 dad)
        {
            img = image;
            padre = dad;

        }

        public void StartListening()
        {
            // Create the TCP listener object using the IP of the server and the specified port
            tlsClient = new TcpListener(8002);


            // Start the TCP listener and listen for connections
            tlsClient.Start();

            // The while loop will check for true in this before checking for connections
            ServRunning = true;

            thrListener = new Thread(KeepListening);
            thrListener.Start();

        }

        private void KeepListening()
        {
            // While the server is running
            while (ServRunning == true)
            {
                // Accept a pending connection
                tcpClient = tlsClient.AcceptTcpClient();

                // Create a new instance of Connection
                ConnectionImage newConnection = new ConnectionImage(tcpClient);
            }
        }

        public void StartCapturing()
        {
            thrCapturing = new Thread(KeepCapturing);
            thrCapturing.Start();
        }

        public void KeepCapturing()
        {
            while (true)
            {

                Console.WriteLine("DEBUG: Server--> Entra nel While");
                ScreenCapture sc = new ScreenCapture(); // capture entire screen
                img = sc.CaptureScreen();
                img1 = (Image)img.Clone();
                padre.setImage(img1);
                //if (img != null) //If you choosed an image
                //{
                //videoServer.SendImage(img); //Send the image
                this.SendImage(img);
                //}

            }
        }

        public void StopCapturing()
        {
            thrCapturing.Abort();

            /* //codice per deallocare memoria
             IntPtr ptr = Marshal.AllocHGlobal(1024);
             GC.AddMemoryPressure(1024);
             if (ptr != IntPtr.Zero)
             {
                 Marshal.FreeHGlobal(ptr);
                 ptr = IntPtr.Zero;
                 GC.RemoveMemoryPressure(1024);
             }
             */
        }

        // Add the user to the List
        public static void AddUser(TcpClient tcpUser)
        {
            ClientList.Add(tcpUser);
        }

        // Remove the user from the hash tables
        public static void RemoveUser(TcpClient tcpUser)
        {

            ClientList.Remove(tcpUser);
        }

        private void CloseConnection(TcpClient tcpCon)
        {
            // Close the currently open objects
            tcpCon.Close();
        }

        public void SendImage(Image img)
        {
            for (int i = 0; i < ClientList.Count; i++)
            {
                TcpClient tempClient = (TcpClient)ClientList[i];
                if (tempClient.Connected) //If the client is connected
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(tempClient.GetStream(), img);
                    //Serialize the image to the tempClient NetworkStream
                }
                else
                {
                    ClientList.Remove(tempClient);
                    i--;
                }


            }
        }

    }

    class ConnectionImage
    {
        TcpClient tcpCon;
        // The thread that will send information to the client
        private Thread thrSender;

        // The constructor of the class takes in a TCP connection
        public ConnectionImage(TcpClient tcpClient)
        {
            tcpCon = tcpClient;
            // The thread that accepts the client and awaits messages
            thrSender = new Thread(AcceptClient);
            // The thread calls the AcceptClient() method
            thrSender.Start();
        }

        private void AcceptClient()
        {
            VideoServer.AddUser(tcpCon);
        }


    }
}
