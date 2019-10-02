using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace AutoConfig
{
    public partial class Form1 : Form
    {
        private string serverName;
        private XmlDocument appConfig;
        private XmlDocument webConfig;
        public Form1()
        {
            InitializeComponent();
            GetServerName();
            tb2.ForeColor = Color.Green;
            this.tb2.Text = "Old connection string \r\n ";
            XmlParse(ref appConfig, Define.appConfigPath, "Model Config");
            XmlParse(ref webConfig, Define.webConfigPath, "Web Congig");
        }


        private void XmlParse(ref XmlDocument doc, string path, string fileName)
        {
            try
            {
                doc = new XmlDocument();
                doc.Load(path);
                XmlNode connectionNode = doc.SelectSingleNode("/configuration/connectionStrings/add");
                tb2.Text += fileName + "\r\n" + connectionNode.Attributes["connectionString"].InnerText + "\r\n \r\n";
            }
            catch (Exception e)
            {
                tb2.Text = "Sorry something went wrong";
            }

        }

        private void XmlWriter()
        {
            XmlNode appConnectionNode = appConfig.SelectSingleNode("/configuration/connectionStrings/add");
            XmlNode webConnectionNode = webConfig.SelectSingleNode("/configuration/connectionStrings/add");
            string oldAppConnection = appConnectionNode.Attributes["connectionString"].InnerText;
            string[] oldAppServerName = oldAppConnection.Split('=', ';');

            string oldWebConnection = webConnectionNode.Attributes["connectionString"].InnerText;
            string[] oldWebServerName = oldWebConnection.Split('=', ';');
            if (!string.IsNullOrEmpty(serverName))
            {
                this.tb2.Clear();
                this.tb2.Text = "New Conection \t\n";
                try
                {

                    //app config
                    string newAppConection = oldAppConnection.Replace(oldAppServerName[1], serverName);
                    appConnectionNode.Attributes["connectionString"].InnerText = newAppConection;
                    appConfig.Save(Define.appConfigPath);
                    //web config
                    string newWebConection = oldWebConnection.Replace(oldWebServerName[1], serverName);
                    webConnectionNode.Attributes["connectionString"].InnerText = newWebConection;
                    webConfig.Save(Define.webConfigPath);

                    tb2.ForeColor = Color.RoyalBlue;

                    tb2.Text = " New App config \r\n "+newAppConection+" \r\n "+"New Web config \r\n "+newWebConection;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Sorry something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MessageBox.Show("[DONE] click [YES TO ALL] if visual ask you", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }


        }

        private void GetServerName()
        {
            string myServer = Environment.MachineName;
            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            for (int i = 0; i < servers.Rows.Count; i++)
            {
                if (myServer == servers.Rows[i]["ServerName"].ToString())
                {

                    this.serverName = servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"];
                    tb1.Text = this.serverName;
                }
                else
                {
                    this.serverName = servers.Rows[i]["ServerName"].ToString();
                    tb1.Text = this.serverName;
                }
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            XmlWriter();

        }

    }
}
