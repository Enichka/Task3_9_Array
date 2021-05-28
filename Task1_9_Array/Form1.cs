using System;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Linq;



namespace Task1_9_Array
{
    public partial class Form1 : Form
    {
        static TicketOffice Ticks_need= new TicketOffice("Events.txt");
        public Form1()
        {
            InitializeComponent();
            string[] events = { "Филармония", "Выступление танцевально-спортивного клуба \"Pulse\"", "Цирк Гии Эрадзе", "Кукольный театр \"Невесомость вдвоём\"", "Шоу на льду с Авербухом" };
            listBox2.Items.AddRange(events);
        }

        TicketOffice Ticks = Ticks_need;



        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>



        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        private void All_Tick(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox1.Text = Info_Tick();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        private void Avail_Tick(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;   
            textBox1.Text = Ticks.Info_Avail_Tick();            
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        private string Show_Sort_Tick()
        {
            string info = "";
            foreach (Ticket tick in Ticks.Get_Sort())
            {
                info += tick.Orcode + ". Мероприятие: " + tick.Event + "; дата проведения: " + tick.Date + "; " + tick.Price + "рублей; расположение: " + tick.Location + "; ряд: " + tick.Row + "; место: " + tick.Seat + "; Это место свободно" + Environment.NewLine;
            }
            return info;
        }

        public string Info_Tick_Buy(int co)
        {
            string info = "";
            foreach (Ticket tick in Ticks.Get_Tick())
            {
                if (tick.Orcode == co)
                    info += "Мероприятие: " + tick.Event + "; дата проведения: " + tick.Date + "; " + tick.Price + "рублей; расположение: " + tick.Location + "; ряд: " + tick.Row + "; место: " + tick.Seat;
            }
            return info;
        }


        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        public void Chek_Loc(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    if (checkBox3.Checked)
                        Ticks.Ava();
                    else
                    {
                        Ticks.Group_Location_2("Партер", "Бельэтаж");
                    }
                }
                else
                {
                    if (checkBox3.Checked)
                    {
                        Ticks.Group_Location_2("Партер", "Балкон");                        
                    }
                    else
                    {
                        Ticks.Group_Location_1("Партер");
                    }
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    if (checkBox3.Checked)
                    {
                        Ticks.Group_Location_2("Бельэтаж", "Балкон");
                    }
                    else
                    {
                        Ticks.Group_Location_1("Бельэтаж");
                    }
                }
                else
                {
                    if (checkBox3.Checked)
                    {
                        Ticks.Group_Location_1("Балкон");
                    }
                    else
                    {
                        Ticks.Cle();
                    }
                    
                }
            }
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>


        public string Info_Tick()
        {
            string info = "";
            foreach (Ticket tick in Ticks.Get_Tick())
            {
                info += tick.Orcode + ". Мероприятие: " + tick.Event + "; дата проведения: " + tick.Date + "; " + tick.Price + "рублей; расположение: " + tick.Location + "; ряд: " + tick.Row + "; место: " + tick.Seat;
                if (tick.Booking)
                    info += "; Это место свободно" + Environment.NewLine;
                else
                    info += "; Это место занято" + Environment.NewLine;
            }
            return info;
        }

        public void All_Chek(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    if (checkBox3.Checked)
                        Ticks.Group_All_without_Loc(listBox2.Text.ToString(), dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                    else
                    {
                        Ticks.Group_All_2(listBox2.Text.ToString(), "Партер", "Бельэтаж", dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));                        
                    }
                }
                else
                {
                    if (checkBox3.Checked)
                    {
                        Ticks.Group_All_2(listBox2.Text.ToString(), "Партер", "Балкон", dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));                  
                    }
                    else
                    {
                        Ticks.Group_All_1(listBox2.Text.ToString(), "Партер", dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                    }
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    if (checkBox3.Checked)
                    {
                        Ticks.Group_All_2(listBox2.Text.ToString(), "Бельэтаж", "Балкон", dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                    }
                    else
                    {
                        Ticks.Group_All_1(listBox2.Text.ToString(), "Бельэтаж", dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                    }
                }
                else
                {
                    if (checkBox3.Checked)
                    {
                        Ticks.Group_All_1(listBox2.Text.ToString(), "Балкон", dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                    }
                    else
                    {
                        Ticks.Cle();
                    }                    
                }
            }
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>


        private void button1_Click(object sender, EventArgs e)
        {
            All_Tick(sender, e);
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        private void button2_Click(object sender, EventArgs e)
        {
            Avail_Tick(sender, e);
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void button7_Click(object sender, EventArgs e)
        {
            Ticks.Group_Event(listBox2.SelectedItem.ToString());    
            textBox1.Text = Show_Sort_Tick();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void button3_Click(object sender, EventArgs e)
        {            
            Ticks.Group_Date(dateTimePicker1.Value, dateTimePicker2.Value);
            textBox1.Text = Show_Sort_Tick();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        private void button4_Click(object sender, EventArgs e)
        {
            Ticks.Group_Price(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
            textBox1.Text = Show_Sort_Tick();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        private void button5_Click(object sender, EventArgs e)
        {
            Chek_Loc(sender, e);
            textBox1.Text = Show_Sort_Tick();
        }
                   

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        private void button6_Click(object sender, EventArgs e)
        {
            All_Chek(sender, e);
            textBox1.Text = Show_Sort_Tick();
        }

        
        
        private void button8_Click(object sender, EventArgs e)
        {
            int b = Convert.ToInt32(textBox2.Text);            

            Form2 newForm = new Form2();
            newForm.label2.Text = Info_Tick_Buy(b);
            Ticks_need.New_Tick(b);
            newForm.Show();
            this.Refresh();
        }


        
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}
