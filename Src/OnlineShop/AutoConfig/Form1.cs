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
using System.Threading.Tasks;
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

            DataTable table = SqlDataSourceEnumerator.Instance.GetDataSources();

            foreach (DataRow server in table.Rows)
            {
                string servername = server[table.Columns["ServerName"]].ToString();

                // you can get that using the instanceName property 
                string instancename = server[table.Columns["InstanceName"]].ToString();

                //and version property tells you the version of sql server i.e 2000, 2005, 2008 r2 etc
                string sqlversion = server[table.Columns["Version"]].ToString();

                //to form the servername you can combine the server and instancenames as
                string sqlserverfullname = String.Format(@"{0}\{1}", servername, instancename);

              
                this.serverName = sqlserverfullname;
                tb1.Text = this.serverName;
            }

        }
        private void btn1_Click(object sender, EventArgs e)
        {
         
            if (tb1.Text=="")
            {
                label1.Text = "Cant get server name please enter your server name below";
                label1.ForeColor = Color.Red;
                tb1.Clear();
                tb1.ReadOnly = false;
                tb1.Focus();
                return;
            }
            else
            {
                XmlWriter();
            }    
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            if (!tb1.ReadOnly)
            {
                this.serverName = tb1.Text;
            }
          
        }
    }
}
