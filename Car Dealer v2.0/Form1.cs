using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Dealer_v2._0
{
    public partial class Form1 : Form
    {
        List<Car> Cars;
        public Form1()
        {
            InitializeComponent();
            Cars = new List<Car>();

            Cars.Add(new Car() { Id = 1, Make = "Volvo", Model = "V70", Color = "White", Km = 1292, Price = 3465, Year = 1998 });
            Cars.Add(new Car() { Id = 31, Make = "Skoda", Model = "Fabia", Color = "Red", Km = 1292, Price = 76556, Year = 2001 });
            Cars.Add(new Car() { Id = 14, Make = "Volvo", Model = "XC90", Color = "Blue", Km = 432, Price = 32001, Year = 2003 });
            Cars.Add(new Car() { Id = 4, Make = "Volvo", Model = "V70", Color = "Red", Km = 1223492, Price = 24512, Year = 1998 });
            Cars.Add(new Car() { Id = 23, Make = "BMW", Model = "735", Color = "Black", Km = 435, Price = 234512, Year = 1999 });
            Cars.Add(new Car() { Id = 234, Make = "Audi", Model = "Q3", Color = "Blue", Km = 345, Price = 334552, Year = 2010 });
            Cars.Add(new Car() { Id = 451, Make = "Volvo", Model = "V40", Color = "Grey", Km = 235235, Price = 535512, Year = 2008 });
            Cars.Add(new Car() { Id = 651, Make = "Volvo", Model = "XC90", Color = "White", Km = 345345, Price = 34510, Year = 2011 });
            Cars.Add(new Car() { Id = 91, Make = "Volvo", Model = "V70", Color = "Red", Km = 345, Price = 4512, Year = 1997 });
            Cars.Add(new Car() { Id = 8001, Make = "Audi", Model = "A3", Color = "White", Km = 123492, Price = 87500, Year = 2001 });
            Cars.Add(new Car() { Id = 631, Make = "Audi", Model = "A8", Color = "Blue", Km = 55342, Price = 55400, Year = 2010 });
            Cars.Add(new Car() { Id = 51, Make = "Volvo", Model = "V40", Color = "Red", Km = 1692, Price = 3465, Year = 1999 });
            Cars.Add(new Car() { Id = 781, Make = "Skoda", Model = "Fabia", Color = "Blue", Km = 1792, Price = 56556, Year = 2000 });
            Cars.Add(new Car() { Id = 144, Make = "Volvo", Model = "XC90", Color = "Blue", Km = 4382, Price = 25001, Year = 2004 });
            Cars.Add(new Car() { Id = 48, Make = "Volvo", Model = "V70", Color = "Red", Km = 12292, Price = 26512, Year = 1997 });
            Cars.Add(new Car() { Id = 912, Make = "BMW", Model = "735", Color = "Black", Km = 4395, Price = 134512, Year = 1960 });
            Cars.Add(new Car() { Id = 2344, Make = "Audi", Model = "Q3", Color = "Grey", Km = 3425, Price = 434552, Year = 2011 });
            Cars.Add(new Car() { Id = 4501, Make = "Volvo", Model = "V40", Color = "Grey", Km = 215235, Price = 435512, Year = 2007 });
            Cars.Add(new Car() { Id = 6051, Make = "Volvo", Model = "XC90", Color = "White", Km = 47345, Price = 134510, Year = 2012 });
            Cars.Add(new Car() { Id = 991, Make = "Volvo", Model = "V70", Color = "Red", Km = 3475, Price = 14512, Year = 1998 });
            Cars.Add(new Car() { Id = 801, Make = "Audi", Model = "A7", Color = "White", Km = 492, Price = 187500, Year = 2002 });
            Cars.Add(new Car() { Id = 6031, Make = "Audi", Model = "A6", Color = "Blue", Km = 553, Price = 55400, Year = 2011 });

            int i = Cars.Select(x => x.Color).Distinct().Count(); 
            var CarColors = Cars.Select(x => x.Color).Distinct();

            //MessageBox.Show(CarColors.GetType().ToString());

            foreach (var item in CarColors)
            {
                listBox3.Items.Add(item);
            }
            label1.Text = $"We offer {i} these colors:";

            foreach (Car anka in Cars.OrderBy(x => x.Make)) //anka can be any variable name
            {
                listBox1.Items.Add(anka); //listBox1.Items.Add($"{anka.Make} {anka.Model}"); from Car class
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //event when we press an item in listbox1
        {
            
            
            listBox2.Items.Clear(); //removes all items in listbox2
            ListBox myListofCars = sender as ListBox;

            //MessageBox.Show(myListofCars.SelectedItem.GetType().ToString());

            Car mySelectedCar = myListofCars.SelectedItem as Car;

            listBox2.Items.Add($"Make: {mySelectedCar.Make}");  //we make it on multiple rows to make it jump down,
            listBox2.Items.Add($"Color: {mySelectedCar.Color} "); //could also have put everything on the same row,
            listBox2.Items.Add($"Price: {mySelectedCar.Price}Kr");//with listBox2.Items.Add($"Make: {} {} {} {}");
            listBox2.Items.Add($"ID: {mySelectedCar.Id}");
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) //event when we press an item in listbox3
        {
            listBox4.Items.Clear(); //removes all items in listbox4
            

            string SelectedColor = (sender as ListBox).SelectedItem as String;
            
            var i = Cars.FindAll(x => x.Color == SelectedColor);
            foreach (var item in i)
            {
                listBox4.Items.Add($"{item}");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) //Edit button works after puttin in a correct ID, give error if there's none
        {
            string SelectedIdTemp = textBoxId.Text;

            int SelectedId = int.Parse(SelectedIdTemp);

            var SelectedCarEdit = Cars.Find(x => x.Id == SelectedId);

            textBoxPrice.Text = SelectedCarEdit.Price.ToString();
            textBoxKm.Text = SelectedCarEdit.Km.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            var Price = Cars.Find(x => x.Id == int.Parse(textBoxId.Text)).Price = int.Parse(textBoxPrice.Text);

            var Km = Cars.Find(x => x.Id == int.Parse(textBoxId.Text)).Km = int.Parse(textBoxKm.Text);

            listBox2.Items.Add($"New Price: {Price}");
            listBox2.Items.Add($"New Km: {Km}");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Cars.RemoveAt(SelectedCar());
            listBox1.Items.Clear();
            foreach (Car anka in Cars.OrderBy(x => x.Make)) //anka can be any variable name
            {
                listBox1.Items.Add(anka);
            }
            
        }
        public int SelectedCar() //Used to declare what car the user wants removed. public int idnummer() sortbyid + 1, return
        {
            return Cars.FindIndex(x => x.Id == int.Parse(textBoxId.Text));
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            Cars.Add(new Car()
            {
                Id = int.Parse(textBox1.Text),
                Make = textBox2.Text,
                Model = textBox3.Text,
                Color = textBox4.Text,
                Km = int.Parse(textBox5.Text),
                Price = int.Parse(textBox6.Text),
                Year = int.Parse(textBox7.Text)
            });
            listBox1.Items.Clear();

            foreach (Car c in Cars.OrderBy(x => x.Make))
            {
                listBox1.Items.Add(c);
            }
        }
       
    }
}
