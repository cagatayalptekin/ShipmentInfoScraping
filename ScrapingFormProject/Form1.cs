using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ScrapingFormProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         //   InitializeListView();
           // this.Resize += Form1_Resize;
        }
        //private void Form1_Resize(object sender, EventArgs e)
        //{
        //    int listViewX = (this.ClientSize.Width - listView1.Width) / 2;
        //    listView1.Location = new Point(listViewX, listView1.Location.Y);
        //}
        static void ScrollToBottom(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
        //private void InitializeListView()
        //{
        //    // Set the view to show details.
        //    listView1.View = View.Details;
        //    listView1.Height = 800;
        //    listView1.Width = 1800;
        //    listView1.Columns.Add(" ", 250);
        //    listView1.Columns.Add(" ", 250);
        //    listView1.Columns.Add(" ", 250);
        //    listView1.Columns.Add(" ", 250);
        //    listView1.Columns.Add(" ", 250);
        //    listView1.Columns.Add(" ", 250);
        //    listView1.Columns.Add(" ", 250);
        //    listView1.Columns.Add(" ", 250);
        //    listView1.Columns.Add(" ", 250);
        //    listView1.Columns.Add(" ", 250);

        //    // Add columns.
        //    int listViewX = (this.ClientSize.Width - listView1.Width) / 2;
        //    listView1.Location = new Point(listViewX, listView1.Location.Y);

        //    // Scroll to the bottom of the ListView



        //}
        private void Form1_Load(object sender, EventArgs e)
        {
             
         string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Shipment;Integrated Security=True;";
         SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            ListViewItem listViewItem1 = new ListViewItem();


            ChromeOptions options = new ChromeOptions();
            //   options.AddArgument("--incognito");

            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddAdditionalChromeOption("useAutomationExtension", false);


            options.AddArguments("--no-sandbox");






            var driver = new ChromeDriver(options);
            var driver2 = new ChromeDriver(options);
            var driver3 = new ChromeDriver(options);

            driver.Url = "https://mydhl.express.dhl/us/en/auth/logout.html";
            driver2.Url = "https://www.fedex.com/secure-login/#/login-credentials";
            driver3.Url = "https://www.ups.com/lasso/login?loc=tr_TR&returnto=https%3A%2F%2Fwww.ups.com%2Ftr%2Ftr%2FHome.page";

            //    Thread.Sleep(6000);

            //driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
            //driver2.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(100));
            driver2.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(100));
            driver3.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(100));


            //DHL
            var username = driver.FindElement(By.Name("username"));
            var password = driver.FindElement(By.Name("password"));
            username.Clear();
            username.SendKeys("airexpress@airexpresscargo.net");
            password.Clear();
            password.SendKeys("6515152Ca.");



            Thread.Sleep(4000);
            //FEDEX
            var usernameFedex = driver2.FindElement(By.Id("userId"));
            var passwordFedex = driver2.FindElement(By.Id("password"));
            usernameFedex.Clear();
            passwordFedex.Clear();
            passwordFedex.SendKeys("123456Ab");


            usernameFedex.SendKeys("airexpresscargo");







            //UPS

            var usernameUPS = driver3.FindElement(By.Id("email"));
            usernameUPS.Clear();
            usernameUPS.SendKeys("airexpresscargo");
            Thread.Sleep(1500);
            var continue_btn = driver3.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div/div/div/main/div/div/div/form/div[3]/div/button"));
            continue_btn.Click();

            Thread.Sleep(5000);
            var passwordUPS = driver3.FindElement(By.Id("pwd"));
            passwordUPS.Clear();
            passwordUPS.SendKeys("Airex6515152.");
            var login_btn = driver3.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div/div/div/main/div/div/div/form/div[3]/div/button"));
            login_btn.Click();
            Thread.Sleep(1500);

            //"RETRY




            //DHL
            var btn = driver.FindElement(By.XPath("/html/body/div[8]/div[2]/div[2]/div[3]/div/button[1]"));
            btn.Click();
            Thread.Sleep(1000);
            var submitbtn = driver.FindElement(By.XPath("/html/body/header/div[1]/div[3]/div/table/tbody/tr/td[2]/table[1]/tbody/tr/td[2]/div/div/div[2]/form/button"));

            submitbtn.Click();
            Thread.Sleep(5000);



            //FEDEX                                  
            var btn2 = driver2.FindElement(By.XPath("/html/body/wlgn-root/div/ciam-head-foot/main/div/div/div/div/wlgn-login-credentials/div/form/div[7]/ciam-spinner-button/button"));
            btn2.Click();
            Task.Delay(15000);
            try
            {
                var retry = driver2.FindElement(By.XPath("/html/body/wlgn-root/div/ciam-head-foot/fdx-common-core/main/div/div/div/div/wlgn-error/wlgn-retry/div/div/ciam-spinner-button/button"));
                retry.Click();
                Thread.Sleep(10000);

            }
            catch (Exception)
            {




                try
                {
                    var english_selection = driver2.FindElement(By.XPath("/html/body/dialog/div/div/div/div/div/div/div[2]/ul/li[1]/a"));
                    english_selection.Click();

                }
                catch (Exception exc)
                {
                    var btn_login = driver2.FindElement(By.XPath("/html/body/wlgn-root/div/ciam-head-foot/main/div/div/div/div/wlgn-login-credentials/div/form/div[7]/ciam-spinner-button/button"));
                    btn_login.Click();
                    Thread.Sleep(30000);
                    var english_selection = driver2.FindElement(By.XPath("/html/body/dialog/div/div/div/div/div/div/div[2]/ul/li[1]/a"));
                    english_selection.Click();
                }

                Thread.Sleep(5000);
                driver2.Manage().Window.Maximize();

                var tracking_btn = driver2.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div/div/div/header/nav/div/div[1]/div/div[2]/div/div/a"));
                tracking_btn.Click();
                Thread.Sleep(1000);

                var ship_tracking = driver2.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div/div/div/header/nav/div/div[1]/div/div[2]/div/div/div/div/div[2]/div/a"));
                ship_tracking.Click();
                Thread.Sleep(15000);
                try
                {
                    var label_filter = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/div/div[2]/app-dashboard/div/app-dashboard-tile[3]"));
                    label_filter.Click();
                    Thread.Sleep(5000);
                }
                catch (ElementNotInteractableException ex)
                {
                    var label_filter = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/div/div[2]/app-dashboard/div/app-dashboard-tile[3]"));
                    label_filter.Click();
                    Thread.Sleep(5000);
                }






                var edit_columns = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[1]/nav/ul/li[2]/button[2]"));
                edit_columns.Click();
                Thread.Sleep(2500);
                var uncheck_delivered_date = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[2]/div[2]/app-edit-columns/div/div[1]/div[2]/div/div/div[5]/span"));
                uncheck_delivered_date.Click();
                Thread.Sleep(1000);
                var uncheck_direction = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[2]/div[2]/app-edit-columns/div/div[1]/div[2]/div/div/div[11]/span"));
                uncheck_direction.Click();
                Thread.Sleep(3000);


                var uncheck_reference = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[2]/div[2]/app-edit-columns/div/div[1]/div[2]/div/div/div[35]/span"));
                uncheck_reference.Click();
                Thread.Sleep(3000);
                var uncheck_scheduled_delivery_time = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[2]/div[2]/app-edit-columns/div/div[1]/div[2]/div/div/div[42]/span"));
                uncheck_scheduled_delivery_time.Click();
                Thread.Sleep(2000);
                var delivery_time_before = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[2]/div[2]/app-edit-columns/div/div[1]/div[2]/div/div/div[43]/span"));
                delivery_time_before.Click();
                Thread.Sleep(1000);



                var uncheck_status = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[2]/div[2]/app-edit-columns/div/div[1]/div[2]/div/div/div[51]/span"));
                uncheck_status.Click();
                Thread.Sleep(2000);





                //var shipper_info = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[2]/div[2]/app-edit-columns/div/div[1]/div[1]/a[2]"));
                //shipper_info.Click();
                //Thread.Sleep(1500);


                //var shipper_city = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[2]/div[2]/app-edit-columns/div/div[1]/div[2]/div/div/div[4]/span/label/input"));
                //shipper_city.Click();
                //Thread.Sleep(1500);




                var recipient_info = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[2]/div[2]/app-edit-columns/div/div[1]/div[1]/a[3]/div"));
                recipient_info.Click();
                Thread.Sleep(1500);


                var recipient_city = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[2]/div[2]/app-edit-columns/div/div[1]/div[2]/div/div/div[5]/span/label/input")); ;
                recipient_city.Click();
                Thread.Sleep(1500);




                var apply = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-action-bar/div[1]/div[2]/div[2]/app-edit-columns/div/div[2]/button"));
                apply.Submit();
                Thread.Sleep(3000);

                var ful_screen = driver2.FindElement(By.XPath("/html/body/app-root/fdx-common-core/div[3]/app-tracking-root/div[2]/div[2]/div/div/app-list-view-grid/div[1]/a"));
                ful_screen.Click();
                Thread.Sleep(1500);









                var data = driver2.FindElements(By.CssSelector("[role='row']"));


                string text = "";
                foreach (var item in data)
                {
                    text += item.Text + "\n";
                }

                //  var array = text.Split("\n");
                var array = text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                //***************************END OF FEDEX***********************
                int l = 0;
                ListViewItem listViewItemforFedex = new ListViewItem();
                ListView listViewforFedex = new ListView();
                listView1.Items.Add("Fedex Bilgiler");
                listViewItem1 = new ListViewItem();
                listViewItem1.SubItems.Add("TakipNumarasi");
                listViewItem1.SubItems.Add("GondericiAd");
                listViewItem1.SubItems.Add("GondericiFirma");
                listViewItem1.SubItems.Add("AliciAd");
                listViewItem1.SubItems.Add("AliciFirma");
                listViewItem1.SubItems.Add("AliciSehir");
                listViewItem1.SubItems.Add("AlinisTarihi");
                listView1.Items.Add(listViewItem1);
                while (l < array.Length - 12)
                {


                    if (array[l].Equals("More Options\r"))
                    {
                        var time = DateTime.Now.ToString();
                        listViewItem1 = new ListViewItem();
                        var TakipNumarasi = array[l + 1];
                        var GondericiAd = array[l + 3];
                        var GondericiFirma = array[l + 5];
                        var AliciAd = array[l + 7];
                        var AliciFirma = array[l + 9];
                        var AliciSehir = array[l + 11];
                        var AlinisTarihi = time;
                        var firma = "Fedex";
                        listViewItem1.SubItems.Add(TakipNumarasi);
                        listViewItem1.SubItems.Add(GondericiAd);
                        listViewItem1.SubItems.Add(GondericiFirma);
                        listViewItem1.SubItems.Add(AliciAd);
                        listViewItem1.SubItems.Add(AliciFirma);
                        listViewItem1.SubItems.Add(AliciSehir);
                        listViewItem1.SubItems.Add(AlinisTarihi);
                        
                       
                        listView1.Items.Add(listViewItem1);


                        string queryforFedex = "INSERT INTO Shipment ([TakipNumarasi], [GondericiAd], [GondericiFirma], [AliciAd], [AliciFirma], [AliciSehir], [BilgiCekimTarihi], [KargoFirmasi]) " +
                                       "VALUES (@TakipNumarasi, @GondericiAd, @GondericiFirma, @AliciAd, @AliciFirma, @AliciSehir, @AlinisTarihi, @firma);";
                        
                        SqlCommand commandforFedex = new SqlCommand(queryforFedex, connection);
                        commandforFedex.Parameters.AddWithValue("@TakipNumarasi", TakipNumarasi);
                        commandforFedex.Parameters.AddWithValue("@GondericiAd", GondericiAd);
                        commandforFedex.Parameters.AddWithValue("@GondericiFirma", GondericiFirma);
                        commandforFedex.Parameters.AddWithValue("@AliciAd", AliciAd);
                        commandforFedex.Parameters.AddWithValue("@AliciFirma", AliciFirma);
                        commandforFedex.Parameters.AddWithValue("@AliciSehir", AliciSehir);
                        commandforFedex.Parameters.AddWithValue("@AlinisTarihi", AlinisTarihi);
                        commandforFedex.Parameters.AddWithValue("@firma", firma);
                        commandforFedex.ExecuteNonQuery();







                    }
                    l++;
                }

                //var retry = driver2.FindElement(By.XPath("/html/body/wlgn-root/div/ciam-head-foot/fdx-common-core/main/div/div/div/div/wlgn-error/wlgn-retry/div/div/ciam-spinner-button/button"));
                //if(retry!=null)
                //{
                //    retry.Click();
                //    Thread.Sleep(5000);
                //}




                //****************************START OF UPS*******************************

                var toggle_btn = driver3.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div/div/div/header/div/div[4]/button"));
                toggle_btn.Click();
                Thread.Sleep(1500);
                var nakliye_btn = driver3.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div/div/div/header/div/div[5]/nav[1]/ul/li[1]/a"));
                nakliye_btn.Click();
                Thread.Sleep(1500);


                var gonderi_gecmisi = driver3.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div/div/div/header/div/div[5]/nav[1]/ul/li[1]/div/div[1]/ul/li[5]/a"));
                gonderi_gecmisi.Click();
                Thread.Sleep(13000);
                driver3.Manage().Window.Maximize();


                var get_fifty_result = driver3.FindElement(By.XPath("/html/body/div[5]/div[3]/div/div/div/div/div/main/div[7]/app-root/div[2]/div/div/div[1]/div/div[3]/app-history-results-per-page/div/shared-results-per-page/shared-field/div/div/select"));
                get_fifty_result.Click();
                Thread.Sleep(3000);
                var select_fifty = driver3.FindElement(By.XPath("/html/body/div[5]/div[3]/div/div/div/div/div/main/div[7]/app-root/div[2]/div/div/div[1]/div/div[3]/app-history-results-per-page/div/shared-results-per-page/shared-field/div/div/select/option[3]"));
                select_fifty.Click();
                Thread.Sleep(3000);


                //var close_popdown = driver3.FindElement(By.XPath("/html/body/div[6]/div/button"));
                //close_popdown.Click();
                //Thread.Sleep(1000);

                //var gorunum = driver3.FindElement(By.XPath("/html/body/div[5]/div[3]/div/div/div/div/div/main/div[7]/app-root/div[2]/div/div/div[3]/div/fieldset/div/div/div[2]"));
                //gorunum.Click();
                //Thread.Sleep(3000);


                var td = driver3.FindElements(By.TagName("td"));
                string td_data = "";
                foreach (var item in td)
                {
                    td_data += item.Text + "\n";
                }
                //  var arrayforUPS = td_data.Split("\n");
                var arrayforUPS = td_data.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                int j = 0;



                listView1.Items.Add("UPS Bilgiler");
                listViewItem1 = new ListViewItem();
                listViewItem1.SubItems.Add("GonderiTarihi");
                listViewItem1.SubItems.Add("AliciFirma");
                listViewItem1.SubItems.Add("AliciUlke");
                listViewItem1.SubItems.Add("TakipNo");
                listViewItem1.SubItems.Add("AlinisTarihi");
                listView1.Items.Add(listViewItem1);

                int nottwice = 1;
                while (j <= arrayforUPS.Length - 1)
                {
                    if (j == arrayforUPS.Length - 1 && nottwice == 1)
                    {
                        try
                        {
                            var page2 = driver3.FindElement(By.XPath("/html/body/div[5]/div[3]/div/div/div/div/div/main/div[7]/app-root/div[2]/div/div/div[4]/history-pagination/shared-pagination-bar/nav/ul/li[4]/button"));
                            page2.Click();
                            Thread.Sleep(6000);
                        }
                        catch (Exception exc)
                        {
                            ScrollToBottom(driver3);
                            Thread.Sleep(2000);
                            var page2 = driver3.FindElement(By.XPath("/html/body/div[5]/div[3]/div/div/div/div/div/main/div[7]/app-root/div[2]/div/div/div[4]/history-pagination/shared-pagination-bar/nav/ul/li[4]/button"));
                            page2.Click();
                            Thread.Sleep(6000);
                        }

                        var tdforpage2 = driver3.FindElements(By.TagName("td"));
                        string td_dataforpage2 = "";
                        foreach (var item in tdforpage2)
                        {
                            td_dataforpage2 += item.Text + "\n";
                        }
                        //  arrayforUPS = td_dataforpage2.Split("\n");
                         arrayforUPS = td_dataforpage2.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                        j = 0;
                        nottwice = 0;
                    }
                    listViewItem1 = new ListViewItem();

                    if (arrayforUPS[j].Equals("Eylem Menüsü"))
                    {
                        //    ListViewItem listViewItem=new ListViewItem();
                        var GonderiTarihi = arrayforUPS[j + 1];
                        var AliciFirma = arrayforUPS[j + 2];
                        var AliciUlke = arrayforUPS[j + 3];
                        var TakipNo = arrayforUPS[j + 4];
                        var AlinisTarihi = DateTime.Now.ToString("dd.MM.yyyy");
                        var firma = "UPS";
                        listViewItem1.SubItems.Add(GonderiTarihi);
                        listViewItem1.SubItems.Add(AliciFirma);
                        listViewItem1.SubItems.Add(AliciUlke);
                        listViewItem1.SubItems.Add(TakipNo);
                        listViewItem1.SubItems.Add(DateTime.Now.ToString("dd.MM.yyyy"));



                        string queryforUPS = "INSERT INTO Shipment ([GonderiTarihi], [AliciFirma], [AliciUlke], [TakipNumarasi], [BilgiCekimTarihi], [KargoFirmasi]) " +
                                      "VALUES (@GonderiTarihi, @AliciFirma, @AliciUlke, @TakipNo, @AlinisTarihi, @firma)";

                        SqlCommand commandforUPS = new SqlCommand(queryforUPS, connection);
                        commandforUPS.Parameters.AddWithValue("@GonderiTarihi", GonderiTarihi);
                        commandforUPS.Parameters.AddWithValue("@AliciFirma", AliciFirma);
                        commandforUPS.Parameters.AddWithValue("@AliciUlke", AliciUlke);
                        commandforUPS.Parameters.AddWithValue("@TakipNo", TakipNo);
                        commandforUPS.Parameters.AddWithValue("@AlinisTarihi", AlinisTarihi);
                        commandforUPS.Parameters.AddWithValue("@firma", firma);
                        commandforUPS.ExecuteNonQuery();

                        listView1.Items.Add(listViewItem1);


                    }
                    j++;
                }
                //*********************************END OF UPS***************************
                listViewItem1 = new ListViewItem();
                listView1.Items.Add("DHL Bilgiler");
                listViewItem1 = new ListViewItem();
                ListViewItem listViewItemforDHlColumn = new ListViewItem();
                listViewItem1.SubItems.Add("TakipNumarasi");
                listViewItem1.SubItems.Add("GonderiTarihi");
                listViewItem1.SubItems.Add("GondericiFirma");
                listViewItem1.SubItems.Add("GondericiAd");
                listViewItem1.SubItems.Add("GondericiAdres");
                listViewItem1.SubItems.Add("BilgiCekimTarihi");
                listViewItem1.SubItems.Add("AliciFirma");
                listViewItem1.SubItems.Add("AliciIsim");
                listViewItem1.SubItems.Add("AliciUlke");

                listView1.Items.Add(listViewItem1);



                int num = 0;
                int i = 0;

                try
                {
                    var tum_gonderiler = driver.FindElement(By.XPath("/html/body/header/div[1]/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr/td[4]/a"));
                    var tr_en_control = tum_gonderiler.GetAttribute("text");
                    if (tr_en_control.Contains("Gönderileri Yönet"))
                    {
                        var english = driver.FindElement(By.XPath("/html/body/header/div[1]/nav/div/div[3]/a[1]"));
                        english.Click();
                        Thread.Sleep(1500);
                        var evet = driver.FindElement(By.XPath("/html/body/div[10]/div/div/div/div/div/div/div/div[2]/button[1]"));
                        evet.Click();
                        Thread.Sleep(10000);
                    }


                    tum_gonderiler.Click();
                }
                catch (StaleElementReferenceException ex)
                {
                    var tum_gonderiler = driver.FindElement(By.XPath("/html/body/header/div[1]/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr/td[4]/a"));
                    var tr_en_control = tum_gonderiler.GetAttribute("text");
                    if (tr_en_control.Contains("Gönderileri Yönet"))
                    {
                        var english = driver.FindElement(By.XPath("/html/body/header/div[1]/nav/div/div[3]/a[1]"));
                        english.Click();
                        Thread.Sleep(1500);
                        var evet = driver.FindElement(By.XPath("/html/body/div[10]/div/div/div/div/div/div/div/div[2]/button[1]"));
                        evet.Click();
                        Thread.Sleep(10000);
                    }


                    tum_gonderiler.Click();
                }
                catch (NoSuchElementException ex)
                {
                    btn = driver.FindElement(By.XPath("/html/body/div[8]/div[2]/div[2]/div[3]/div/button[1]"));
                    btn.Click();
                    Thread.Sleep(1000);
                    submitbtn = driver.FindElement(By.XPath("/html/body/header/div[1]/div[3]/div/table/tbody/tr/td[2]/table[1]/tbody/tr/td[2]/div/div/div[2]/form/button"));

                    submitbtn.Click();
                    Thread.Sleep(3000);
                }

                Thread.Sleep(3000);
                var tum_gonderiler_goruntule = driver.FindElement(By.XPath("/html/body/header/div[1]/div[3]/div/table/tbody/tr/td[1]/table/tbody/tr/td[4]/div/div/div[1]/ul/li[1]/a"));
                tum_gonderiler_goruntule.Click();
                Thread.Sleep(5000);


                var hundred_result = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/section/div[3]/div[10]/div[1]/div/div[4]/div/div/div[2]/div[1]/div[2]/select"));
                hundred_result.Click();
                Thread.Sleep(2000);
                var hundred_result_click = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/section/div[3]/div[10]/div[1]/div/div[4]/div/div/div[2]/div[1]/div[2]/select/option[4]"));
                hundred_result_click.Click();
                Thread.Sleep(12000);


                var matches = driver.FindElements(By.TagName("tr"));
                string text_data = "";
                foreach (var item in matches)
                {
                    text_data += item.Text;
                }

                //  array = text_data.Split("\n");
                array = text_data.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                array = array.Skip(9).ToArray();
                int k = 0;


                bool control = true;
                listViewItem1 = new ListViewItem();
                var gondericifirma = "";
                var gondericiname = "";
                var gondericiulke = "";
                var alinistarihi = "";
                var alicifirma = "";
               var aliciname = "";
               var aliciulke = "";
                var numara = "";
                var KargoFirmasi = "DHL";

                while (k < array.Length - 1)
                {

                    ListViewItem listViewItemforDhlData = new ListViewItem();
                    ListView listViewforDhlData = new ListView();
                    control = true;
                    var cmp = "";
                    cmp = array[k].Substring(0, array[k].Length - 1);
                    bool res = int.TryParse(array[k].FirstOrDefault().ToString(), out _);
                    if (!res)
                    {


                        if (array[k + 1].Equals("(Temporary ID)\r"))
                        {
                            while (!res && k < array.Length - 1)
                            {
                                k++;

                                res = int.TryParse(array[k].FirstOrDefault().ToString(), out _);

                            }



                            control = true;


                        }

                    }
                    if (control == true)
                    {
                        if (cmp.Equals("Ship From"))
                        {

                             gondericifirma = array[k + 1];
                             gondericiname = array[k + 2];
                             gondericiulke = array[k + 3];
                             alinistarihi = DateTime.Now.ToString();
                            listViewItem1.SubItems.Add(gondericifirma);
                            listViewItem1.SubItems.Add(gondericiname);
                            listViewItem1.SubItems.Add(gondericiulke);
                            listViewItem1.SubItems.Add(alinistarihi);

                        }
                        else if (cmp.Equals("Ship To"))
                        {
                             alicifirma = array[k + 1];
                             aliciname = array[k + 2];
                             aliciulke = array[k + 3];
                            listViewItem1.SubItems.Add(alicifirma);
                            listViewItem1.SubItems.Add(aliciname);
                            listViewItem1.SubItems.Add(aliciulke);








                            
                            if(alicifirma.Length>=50)
                            {
                                 int indexfirma = alicifirma.IndexOf("Shipment");
                                if (indexfirma != -1)
                                {
                                    alicifirma = alicifirma.Substring(0, indexfirma);
                                    // Console.WriteLine(truncatedString);
                                }
                                
                            }
                            int index = aliciulke.IndexOf("Shipment");
                            if (index != -1)
                            {
                                 aliciulke = aliciulke.Substring(0, index);
                               // Console.WriteLine(truncatedString);
                            }


                            string queryforDhl = "INSERT INTO Shipment ([TakipNumarasi], [GondericiAd], [GondericiFirma],[GondericiUlke], [AliciAd], [AliciFirma], [AliciUlke], [BilgiCekimTarihi], [KargoFirmasi]) " +
                                      "VALUES (@numara, @gondericiname, @gondericifirma, @gondericiulke, @aliciname, @alicifirma, @aliciulke,@alinistarihi, @KargoFirmasi)";

                            SqlCommand commandforDhl = new SqlCommand(queryforDhl, connection);
                            commandforDhl.Parameters.AddWithValue("@numara", numara);
                            commandforDhl.Parameters.AddWithValue("@gondericiname", gondericiname);
                            commandforDhl.Parameters.AddWithValue("@gondericifirma", gondericifirma);
                            commandforDhl.Parameters.AddWithValue("@gondericiulke", gondericiulke);
                            commandforDhl.Parameters.AddWithValue("@aliciname", aliciname);
                            commandforDhl.Parameters.AddWithValue("@alicifirma", alicifirma);
                            commandforDhl.Parameters.AddWithValue("@aliciulke", aliciulke);
                            commandforDhl.Parameters.AddWithValue("@alinistarihi", alinistarihi);
                            commandforDhl.Parameters.AddWithValue("@KargoFirmasi", KargoFirmasi);
                            commandforDhl.ExecuteNonQuery();



                          //  listView1.Items.Add(listViewItem1);




                        }
                        else if (cmp.Contains("Shipment Date"))
                        {
                            int shipmentIndex = cmp.IndexOf("Shipment Date") + "Shipment Date".Length;

                            // Extract the substring containing the date
                            string dateSubstring = cmp.Substring(shipmentIndex);
                            listViewItem1.SubItems.Add(dateSubstring);


                        }
                        else if (res == true)
                        {
                            listViewItem1 = new ListViewItem();
                             numara = array[k];
                            listViewItem1.SubItems.Add(numara);
                        }
                        k++;
                        if (k < array.Length - 1 && array[k].Contains("Help and Support\r"))
                        {
                            break;
                        }
                    }
                   
                  

                }





            }

            connection.Close();
            using(SqlConnection connectionforAll = new SqlConnection(connectionString))
            {
                connectionforAll.Open();
                string query = "SELECT * FROM Shipment";
                SqlCommand command = new SqlCommand(query, connectionforAll);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                connectionforAll.Close();
            }
            

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}




























