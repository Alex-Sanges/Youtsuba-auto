using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Text.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Newtonsoft.Json;
//Json:
//id
//name
//telefon

namespace Yotsuba_auto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string text = ""; // костыль для того чтобы не придумывать с объектом
        private void button1_Click(object sender, EventArgs e)
        {
            Connect_JSONs();
        }
        public class Order
        {
            public string id;
            public string name;
            public string telefon;
        }
        public class Autos
        {
            public string title;
            public int price;
            public bool sale;
            public string [] img;
            public string category;
        }
        public class BY_autos
        {
            public string title;
            public int price;
            public bool sale;
            public int year;
            public int ad;
            public string[] img;
            public string category;
        }
        public class Otz 
        {
            public string Name;
            public string Text;
            public string Date;
            public string[] img;
        }
        public class Orders
        {
            public string Name;
            public string Auto;
            public string Text;
            public string Date;
            public string[] img;
        }
        /*public class Goods {
            public class[] goods = new BY_autos;
        }*/
        public string[] files = new string[0];
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            //Connect.Visible = false;
            try {
                using (StreamReader sr = File.OpenText(@"C:\Users\Public\Documents\Youtsuba-auto"))
                {
                    string s = "";
                    int g = 0;
                    while ((s = sr.ReadLine()) != null)
                    {
                        Array.Resize(ref files, files.Length + 1);
                        //MessageBox.Show((s));
                        files[g] = /*@""+*/s;
                        g += 1;
                    }
                }
            }
            catch {
                MessageBox.Show("Возможно, файл настройки повреждён или не существует, настройте программу указав пути файлов, для этого нажмите кнопку \"Пути\"", "Внимание");
                Connect_JSONs();
            }
        }
        public void Connect_JSONs() //подключение файлов
        {
            StreamWriter fs = new StreamWriter(@"C:\Users\Public\Documents\Youtsuba-auto", true);//путь для файла конфига
            {
                while (DialogResult.Yes == MessageBox.Show("Вам нужно подключить файл JSON?", "Внимание!", MessageBoxButtons.YesNo)) //пока пользователь не откажется, будет выполняться условие
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.Yes) { MessageBox.Show(openFileDialog1.FileName); } //немного мусора    
                    fs.WriteLine(openFileDialog1.FileName);// запись пути файла в строку текстовика
                }
                fs.Close();//закрытие подключения
            }
            fs.Close();
        }
        public void Dat_Put_vedra_order()
        {
            text = File.ReadAllText(files[0]);
            var Order2 = JsonConvert.DeserializeObject<List<Order>>(text);
            for (int i = 0; i < Order2.Count; i++) { textBox1.Text += Order2[i].id + Order2[i].name + Order2[i].telefon + Environment.NewLine; }
            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = Order2.Count;
            for (int j = 0; j < Order2.Count; j++)
            {
                dataGridView1.Columns[0].Name = "id";
                dataGridView1.Columns[1].Name = "name";
                dataGridView1.Columns[2].Name = "telefon";
                dataGridView1.Rows[j].Cells[0].Value = Order2[j].id;
                dataGridView1.Rows[j].Cells[1].Value = Order2[j].name;
                dataGridView1.Rows[j].Cells[2].Value = Order2[j].telefon;
                /*for (int i = 0; i < Order2.Count; i++) { dataGridView1.Rows[j].Cells[i].Value = Order2[i].id; dataGridView1.Rows[j].Cells[i].Value = Order2[i].name; dataGridView1.Rows[j].Cells[i].Value = Order2[i].telefon; }*/
            }
        }
        public void Dat_Put_vedra_catalog()
        {
            text = File.ReadAllText(files[1]);
            text=text.Substring(text.IndexOf("["));
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1) 
            {
                text += Convert.ToString(arr[i]);
            }
            text = text.Substring(text.IndexOf("]"));
            arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text += Convert.ToString(arr[i]);
            }
            textBox1.Text = text;
            //goods=new 
             var Order2 = JsonConvert.DeserializeObject<List<BY_autos>>(text);
             for (int i = 0; i < Order2.Count; i++) { textBox1.Text+= Order2[i].title + Order2[i].price + Order2[i].sale + Order2[i].year + Order2[i].ad + Order2[i].img + Environment.NewLine; }
             dataGridView1.ColumnCount = 7;
             dataGridView1.RowCount = Order2.Count;
             for (int j = 0; j < Order2.Count; j++)
             {
                dataGridView1.Columns[0].Name = "title";
                dataGridView1.Columns[1].Name = "price";
                dataGridView1.Columns[2].Name = "sale";
                dataGridView1.Columns[3].Name = "year";
                dataGridView1.Columns[4].Name = "ad";
                dataGridView1.Columns[5].Name = "img";
                dataGridView1.Columns[6].Name = "category";
                dataGridView1.Rows[j].Cells[0].Value = Order2[j].title;
                dataGridView1.Rows[j].Cells[1].Value = Order2[j].price;
                dataGridView1.Rows[j].Cells[2].Value = Order2[j].sale;
                dataGridView1.Rows[j].Cells[3].Value = Order2[j].year;
                dataGridView1.Rows[j].Cells[4].Value = Order2[j].ad;
                dataGridView1.Rows[j].Cells[5].Value = "";
                for (int i = 0; i < Order2[j].img.Length; i++)
                    dataGridView1.Rows[j].Cells[5].Value += Order2[j].img[i]+" ";
                dataGridView1.Rows[j].Cells[6].Value = Order2[j].category;
            }
        }
        public void Dat_Put_catalog_order()
        {
            text = File.ReadAllText(files[2]);
            var Order2 = JsonConvert.DeserializeObject<List<Order>>(text);
            for (int i = 0; i < Order2.Count; i++) { textBox1.Text += Order2[i].id + Order2[i].name + Order2[i].telefon + Environment.NewLine; }
            dataGridView1.ColumnCount = 3;
            if (Order2.Count == 0) { dataGridView1.RowCount = 1; }else
            dataGridView1.RowCount = Order2.Count;
            for (int j = 0; j < Order2.Count; j++)
            {
                dataGridView1.Columns[0].Name = "id";
                dataGridView1.Columns[1].Name = "name";
                dataGridView1.Columns[2].Name = "telefon";
                dataGridView1.Rows[j].Cells[0].Value = Order2[j].id;
                dataGridView1.Rows[j].Cells[1].Value = Order2[j].name;
                dataGridView1.Rows[j].Cells[2].Value = Order2[j].telefon;
                /*for (int i = 0; i < Order2.Count; i++) { dataGridView1.Rows[j].Cells[i].Value = Order2[i].id; dataGridView1.Rows[j].Cells[i].Value = Order2[i].name; dataGridView1.Rows[j].Cells[i].Value = Order2[i].telefon; }*/
            }
        }
        public void Dat_Put_catalog_catalog()
        {
            text = File.ReadAllText(files[3]);
            text = text.Substring(text.IndexOf("["));
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text += Convert.ToString(arr[i]);
            }
            text = text.Substring(text.IndexOf("]"));
            arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text += Convert.ToString(arr[i]);
            }
            textBox1.Text = text;
            //goods=new 
            var Order2 = JsonConvert.DeserializeObject<List<Autos>>(text);
            //for (int i = 0; i < Order2.Count; i++) { textBox1.Text += Order2[i].title + Order2[i].price + Order2[i].sale + Order2[i].year + Order2[i].ad + Order2[i].img + Environment.NewLine; }
            dataGridView1.ColumnCount = 5;
            dataGridView1.RowCount = Order2.Count;
            for (int j = 0; j < Order2.Count; j++)
            {
                dataGridView1.Columns[0].Name = "title";
                dataGridView1.Columns[1].Name = "price";
                dataGridView1.Columns[2].Name = "sale";
                dataGridView1.Columns[3].Name = "img";
                dataGridView1.Columns[4].Name = "category";
                dataGridView1.Rows[j].Cells[0].Value = Order2[j].title;
                dataGridView1.Rows[j].Cells[1].Value = Order2[j].price;
                dataGridView1.Rows[j].Cells[2].Value = Order2[j].sale;
                dataGridView1.Rows[j].Cells[4].Value = "";
                for (int i = 0; i < Order2[j].img.Length; i++)
                    dataGridView1.Rows[j].Cells[3].Value += Order2[j].img[i] + " ";
                dataGridView1.Rows[j].Cells[4].Value = Order2[j].category;
            }
        }
        public void Dat_Put_otz() 
        {
            //
            text = File.ReadAllText(files[4]);
            text = text.Substring(text.IndexOf("["));
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text += Convert.ToString(arr[i]);
            }
            text = text.Substring(text.IndexOf("]"));
            arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text += Convert.ToString(arr[i]);
            }
            textBox1.Text = text;
            var Order2 = JsonConvert.DeserializeObject<List<Otz>>(text);
            //for (int i = 0; i < Order2.Count; i++) { textBox1.Text += Order2[i].title + Order2[i].price + Order2[i].sale + Order2[i].year + Order2[i].ad + Order2[i].img + Environment.NewLine; }
            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = Order2.Count;
            for (int j = 0; j < Order2.Count; j++)
            {
                dataGridView1.Columns[0].Name = "Name";
                dataGridView1.Columns[1].Name = "Text";
                dataGridView1.Columns[2].Name = "Date";
                dataGridView1.Columns[3].Name = "img";
                dataGridView1.Rows[j].Cells[0].Value = Order2[j].Name;
                dataGridView1.Rows[j].Cells[1].Value = Order2[j].Text;
                dataGridView1.Rows[j].Cells[2].Value = Order2[j].Date;
                dataGridView1.Rows[j].Cells[3].Value = "";
                for (int i = 0; i < Order2[j].img.Length; i++)
                    dataGridView1.Rows[j].Cells[3].Value += Order2[j].img[i] + " ";
            }
        }
        public void Dat_Put_Orders() 
        {
            //
            text = File.ReadAllText(files[5]);
            text = text.Substring(text.IndexOf("["));
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text += Convert.ToString(arr[i]);
            }
            text = text.Substring(text.IndexOf("]"));
            arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text += Convert.ToString(arr[i]);
            }
            textBox1.Text = text;
            //goods=new 
            var Order2 = JsonConvert.DeserializeObject<List<Orders>>(text);
            dataGridView1.ColumnCount = 7;
            dataGridView1.RowCount = Order2.Count;
            for (int j = 0; j < Order2.Count; j++)
            {
                dataGridView1.Columns[0].Name = "Trek";
                dataGridView1.Columns[1].Name = "Auto";
                dataGridView1.Columns[2].Name = "Text";
                dataGridView1.Columns[3].Name = "Date";
                dataGridView1.Columns[4].Name = "img";
                dataGridView1.Rows[j].Cells[0].Value = Order2[j].Name;
                dataGridView1.Rows[j].Cells[1].Value = Order2[j].Auto;
                dataGridView1.Rows[j].Cells[2].Value = Order2[j].Text;
                dataGridView1.Rows[j].Cells[3].Value = Order2[j].Date;
                dataGridView1.Rows[j].Cells[4].Value = "";
                for (int i = 0; i < Order2[j].img.Length; i++)
                    dataGridView1.Rows[j].Cells[4].Value += Order2[j].img[i] + " ";
            }
        }
        public void Save0()
        {
            var Order3 = new List<Order>();
            int coun = dataGridView1.RowCount - 1;
            if ((string)dataGridView1.Rows[coun].Cells[0].Value == "")
            {
                coun -= coun;
            }
            for (int j = 0; j <= coun; j += 1)
            {
                Order3.Add(new Order
                {
                    id = Convert.ToString(dataGridView1.Rows[j].Cells[0].Value),
                    name = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value),
                    telefon = Convert.ToString(dataGridView1.Rows[j].Cells[2].Value)
                });
            }
            File.WriteAllText(files[0], JsonConvert.SerializeObject(Order3));
            MessageBox.Show("Cохранение прошло успешно", "Успех");
        }
        public void Save1()
        {
            var Order3 = new List<BY_autos>();
            int coun = dataGridView1.RowCount - 1;
            if ((string)dataGridView1.Rows[coun].Cells[0].Value == "")
            {
                coun -= coun;
            }
            for (int j = 0; j <= coun; j += 1)
            {
                Order3.Add(new BY_autos
                {
                    title = Convert.ToString(dataGridView1.Rows[j].Cells[0].Value),
                    price = Convert.ToInt32(dataGridView1.Rows[j].Cells[1].Value),
                    sale = Convert.ToBoolean(dataGridView1.Rows[j].Cells[2].Value),
                    year= Convert.ToInt32(dataGridView1.Rows[j].Cells[3].Value),
                    ad= Convert.ToInt32(dataGridView1.Rows[j].Cells[4].Value),
                    //for (int i = 0; i < Order3[j].img.Length; i++)
                    img = Convert.ToString(dataGridView1.Rows[j].Cells[5].Value).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries),
                    category= Convert.ToString(dataGridView1.Rows[j].Cells[6].Value)});
            }
            //
            text = File.ReadAllText(files[1]);
            string text0 = text.Substring(0,text.IndexOf("["));
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text += Convert.ToString(arr[i]);
            }
            string text1 = text.Substring(0,text.IndexOf("]"));
            arr = text1.ToCharArray();
            Array.Reverse(arr);
            text1 = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text1 += Convert.ToString(arr[i]);
            }
            //textBox1.Text = text;
            //
            File.WriteAllText(files[1], text0+JsonConvert.SerializeObject(Order3)+text1);
            MessageBox.Show("Cохранение прошло успешно", "Успех");
        }
        public void Save2()
        {
            var Order3 = new List<Order>();
            int coun = dataGridView1.RowCount - 1;
            if ((string)dataGridView1.Rows[coun].Cells[0].Value == "")
            {
                coun -= coun;
            }
            for (int j = 0; j <= coun; j += 1)
            {
                Order3.Add(new Order
                {
                    id = Convert.ToString(dataGridView1.Rows[j].Cells[0].Value),
                    name = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value),
                    telefon = Convert.ToString(dataGridView1.Rows[j].Cells[2].Value)
                });
            }

            File.WriteAllText(files[2], JsonConvert.SerializeObject(Order3));
            MessageBox.Show("Cохранение прошло успешно", "Успех");
        }
        public void Save3()
        {
            var Order3 = new List<Autos>();
            int coun = dataGridView1.RowCount - 1;
            if ((string)dataGridView1.Rows[coun].Cells[0].Value == "")
            {
                coun -= coun;
            }
            for (int j = 0; j <= coun; j += 1)
            {
                Order3.Add(new Autos
                {
                    title = (string)dataGridView1.Rows[j].Cells[0].Value,
                    price = Convert.ToInt32(dataGridView1.Rows[j].Cells[1].Value),
                    sale = Convert.ToBoolean(dataGridView1.Rows[j].Cells[2].Value),
                    //for (int i = 0; i < Order3[j].img.Length; i++)
                    img = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries),
                    category = Convert.ToString(dataGridView1.Rows[j].Cells[4].Value)
                });
            }
            //
            text = File.ReadAllText(files[3]);
            string text0 = text.Substring(0, text.IndexOf("["));
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text += Convert.ToString(arr[i]);
            }
            string text1 = text.Substring(0, text.IndexOf("]"));
            arr = text1.ToCharArray();
            Array.Reverse(arr);
            text1 = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text1 += Convert.ToString(arr[i]);
            }
            //textBox1.Text = text;
            //
            File.WriteAllText(files[3], text0 + JsonConvert.SerializeObject(Order3) + text1);
            MessageBox.Show("Cохранение прошло успешно", "Успех");
        }
        public void Save4()
        {
            var Order3 = new List<Otz>();
            int coun = dataGridView1.RowCount - 1;
            if ((string)dataGridView1.Rows[coun].Cells[0].Value == "")
            {
                coun -= coun;
            }
            for (int j = 0; j <= coun; j += 1)
            {
                Order3.Add(new Otz
                {
                    Name = Convert.ToString(dataGridView1.Rows[j].Cells[0].Value),
                    Text = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value),
                    Date = Convert.ToString(dataGridView1.Rows[j].Cells[2].Value),
                    //for (int i = 0; i < Order3[j].img.Length; i++)
                    img = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                });
            }
            //
            text = File.ReadAllText(files[4]);
            string text0 = text.Substring(0, text.IndexOf("["));
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text += Convert.ToString(arr[i]);
            }
            string text1 = text.Substring(0, text.IndexOf("]"));
            arr = text1.ToCharArray();
            Array.Reverse(arr);
            text1 = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text1 += Convert.ToString(arr[i]);
            }
            File.WriteAllText(files[4], text0 + JsonConvert.SerializeObject(Order3) + text1);
            MessageBox.Show("Cохранение прошло успешно", "Успех");
        }
        public void Save5()
        {
            var Order3 = new List<Orders>();
            int coun = dataGridView1.RowCount - 1;
            if ((string)dataGridView1.Rows[coun].Cells[0].Value == "")
            {
                coun -= coun;
            }
            for (int j = 0; j <= coun; j += 1)
            {
                string[] im={ Convert.ToString(dataGridView1.Rows[j].Cells[4].Value) };
                Order3.Add(new Orders
                {
                    Name = Convert.ToString(dataGridView1.Rows[j].Cells[0].Value),
                    Auto = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value),
                    Text = Convert.ToString(dataGridView1.Rows[j].Cells[2].Value),
                    Date = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value),
                    img = im
                });
            }
            //
            text = File.ReadAllText(files[5]);
            string text0 = text.Substring(0, text.IndexOf("["));
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            text = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text += Convert.ToString(arr[i]);
            }
            string text1 = text.Substring(0, text.IndexOf("]"));
            arr = text1.ToCharArray();
            Array.Reverse(arr);
            text1 = "";
            for (int i = 0; i < arr.Length; i += 1)
            {
                text1 += Convert.ToString(arr[i]);
            }
            //
            File.WriteAllText(files[5], text0 + JsonConvert.SerializeObject(Order3) + text1);
            MessageBox.Show("Cохранение прошло успешно", "Успех");
        }
        private void save_but_Click(object sender, EventArgs e)
        {
            switch (numericUpDown1.Value)
            {
                case 0: Save0(); break;
                case 1: Save1(); break;
                case 2: Save2(); break;
                case 3: Save3(); break;
                case 4: Save4(); break;
                case 5: Save5(); break;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = files.Length-1;
            textBox1.Text = "";
            switch (numericUpDown1.Value) {
                case 0: Dat_Put_vedra_order(); break;
                case 1: Dat_Put_vedra_catalog(); break;
                case 2: Dat_Put_catalog_order(); break;
                case 3: Dat_Put_catalog_catalog();break;
                case 4: Dat_Put_otz();break;
                case 5: Dat_Put_Orders();break;
            }
        }
    }
}
