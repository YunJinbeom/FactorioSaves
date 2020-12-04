using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;
using MySql.Data.MySqlClient;

namespace FactorioSave
{
    public partial class MainForm : Form
    {
        Point mousePoint;

        string saveFolderPath;
        string appdataPath;

        string selectedSaveFilePath;
        string selectedSaveFileName;
        //List<string> saves = new List<string>();

        List<SaveFile> saves = new List<SaveFile>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Thumbnail.SizeMode = PictureBoxSizeMode.CenterImage;
            //this.saveList.DisplayMember = nameof(SaveFile.name);

            appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            saveFolderPath = appdataPath + "\\factorio\\saves";

            // 세이브 파일들의 이름을 가져옴
            GetFiles();
            //SQLConnect();
            mainLogin();
            //PrintList();
        }

        private void GetFiles()
        {
            string[] files = Directory.GetFiles(saveFolderPath);

            StringBuilder builder = new StringBuilder();

            foreach (string file in files)
            {
                string saveName = Path.GetFileNameWithoutExtension(file);
                builder.Append(saveName + "\n");

                using (ZipArchive zip = ZipFile.OpenRead(file))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        if (entry.Name == "preview.jpg")
                        {
                            Stream s = entry.Open();
                            Image image = System.Drawing.Image.FromStream(s);
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();

                                string base64String = Convert.ToBase64String(imageBytes);
                                saves.Add(new SaveFile() { path = file, name = saveName, image = base64String });

                                var item = new SaveFile() { path = file, name = saveName, image = base64String };
                                saveList.Items.Add(item);

                            }
                        }
                    }
                }
            }
        }

        private void saveList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveFile saveFile = saveList.SelectedItem as SaveFile;
            string name = saveFile.name;
            string path = saveFile.path;
            string image = saveFile.image;

            selectedSaveFilePath = saveFile.path;
            selectedSaveFileName = saveFile.name;

            byte[] bytes = Convert.FromBase64String(image);
            Image thumbnail = byteArrayToImage(bytes);

            Thumbnail.Image = thumbnail;
            saveName_label.Text = name;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public void PrintList()
        {
            StringBuilder builder = new StringBuilder();
            //int index = saves.Count();
            foreach (var item in saves)
            {
                builder.Append(item.name + " " + item.path + "\n");
            }
            MessageBox.Show(builder.ToString(), "", MessageBoxButtons.OK);
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                     this.Top - (mousePoint.Y - e.Y));
            }
        }

        /*public void UploadFtpFile(string filePath)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(
                new Uri("ftp://ighook.cafe24.com/" + Path.GetFileName(filePath)));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("ighook", "wlsqja4292!");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = true;

            //Load the file
            FileStream stream = File.OpenRead(filePath);
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            //Upload file
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();

            request = null;
            MessageBox.Show("Uploaded Successfully");
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            FtpUpload(selectedSaveFilePath);
        }

        public static void FtpUpload(string localFilePath)
        {
            string fileName = Path.GetFileName(localFilePath);
            string ftpPath = $@"ftp://192.168.0.34/factorio/{fileName}";

            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential("ighook", "dwq4292!");
                client.UploadFile(ftpPath, WebRequestMethods.Ftp.UploadFile, localFilePath);
            }
        }

        public static void FtpDownload(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            string inputFilePath = $@"data/{fileName}";
            string ftpPath = $@"ftp://ftp://192.168.0.34/factorio/";

            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential("ighook", "dwq4292!");
                byte[] fileData = client.DownloadData(ftpPath);

                using (FileStream file = File.Create(inputFilePath))
                {
                    file.Write(fileData, 0, fileData.Length);
                }
            }
        }

        public void SQLConnect()
        {
            string connStr = "server = ighook.cafe24.com; database = ighook; uid = ighook; pwd = wlsqja4292!; charset = utf8";

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                //DB 연결 여부 확인 (Ping을 쏜 후 정상적으로 연결 되었다면 True 아니라면 False)
                Boolean temp = conn.Ping();

                //연결이 성공하였을 경우 DB연결 성공 실패하였을 경우 DB 연결 실패
                /*if (temp == true)
                {
                    MessageBox.Show("DB연결 성공", "DB 연결", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("DB 연결 실패", "DB 연결", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/

                MySqlCommand insertCommand = new MySqlCommand();
                insertCommand.Connection = conn;
                insertCommand.CommandText = "INSERT INTO user VALUES('dd', 'dd', 'dd', 'dd')";

                //insertCommand.Parameters.Add("@name", MySqlDbType.VarChar, 10);
                //insertCommand.Parameters.Add("@sub", MySqlDbType.VarChar, 20);

                //insertCommand.Parameters[0].Value = "정강원";
                //insertCommand.Parameters[1].Value = "무직";

                insertCommand.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static CookieContainer cookie = new CookieContainer();

        //페이지 로그인 하면서 쿠키를 받아롬
        public HttpWebResponse mainLogin()
        {
            //REQUEST 설정
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://factorio.com/login");
            req.Method = "Post";
            req.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.106 Safari/535.2";
            string s = "username_or_email=ighook&password=dwq4292"; //input테그 목록을 참조해서 바꿈
            req.CookieContainer = cookie; //삽질한 부분 - 쿠키 컨테이너는 static 으로 공유되어야함
            req.ContentLength = s.Length;
            req.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            //req.ContentType = "text/plain";
            //req.ContentType = "application/xml, text/xml, */*; q=0.01";
            req.KeepAlive = true;

            //POST값 전송
            TextWriter w = (TextWriter)new System.IO.StreamWriter(req.GetRequestStream());
            w.Write(s);
            w.Close();

            //사이트 긁어오기
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            TextReader r = (TextReader)new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            return resp;
        }
    }
}
