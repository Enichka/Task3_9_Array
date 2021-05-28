using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace Task1_9_Array
{
    public class TicketOffice
    {
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        ArrayList Ticks = new ArrayList();
        ArrayList Sort_Tick = new ArrayList();

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        public TicketOffice(string loc)
        {
            var f = new StreamReader(loc);
            while (!f.EndOfStream)
            {
                string l = f.ReadLine();
                string[] ob = l.Split(';');
                Ticks.Add(new Ticket(int.Parse(ob[0]), ob[1], DateTime.Parse(ob[2]), ob[3], int.Parse(ob[4]), int.Parse(ob[5]), int.Parse(ob[6]), bool.Parse(ob[7])));
            }
            f.Close();
        }     



        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

       

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        public string Info_Avail_Tick()
        {
            string info = "";
            foreach (Ticket tick in Ticks)
            {
                if (tick.Booking)
                    info += tick.Orcode + ". Мероприятие: " + tick.Event + "; дата проведения: " + tick.Date + "; " + tick.Price + "рублей; расположение: " + tick.Location + "; ряд: " + tick.Row + "; место: " + tick.Seat +"; Это место свободно" + Environment.NewLine;                
            }
            return info;
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>


        public void Group_Event(string Ev)
        {
            Sort_Tick.Clear();
            var Ev_Gr =
                from Ticket tick in Ticks
                where tick.Event == Ev
                select tick;

            foreach (Ticket tick in Ev_Gr)
            {
                if (tick.Booking)
                    Sort_Tick.Add(tick);
            }
        }

        public ArrayList New_Tick(int b)
        {
            Ticks.Clear();
            Sort_Tick.Clear();            
            var Ev_Gr =
                from Ticket tick in Ticks
                where tick.Orcode != b
                select tick;

            foreach (Ticket tick in Ev_Gr)
            {
                if (tick.Booking)
                {
                    Sort_Tick.Add(tick);
                    Ticks.Add(tick);
                }
                    
            }
            return Ticks;
        }


        public void Ava()
        {
            Sort_Tick.Clear();           

            foreach (Ticket tick in Ticks)
            {
                if (tick.Booking)
                    Sort_Tick.Add(tick);
            }
        }

        public void Cle()
        {
            Sort_Tick.Clear();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>


        public void Group_Location_1(string Loc)
        {
            Sort_Tick.Clear();
            var Loc_Gr =
                from Ticket tick in Ticks
                where tick.Location == Loc
                select tick;

            foreach (Ticket tick in Loc_Gr)
            {
                if (tick.Booking)
                    Sort_Tick.Add(tick);
            }
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>


        public void Group_Location_2(string Loc1, string Loc2)
        {
            Sort_Tick.Clear();
            var Locs_Gr =
                from Ticket tick in Ticks
                where tick.Location == Loc1 || tick.Location == Loc2
                select tick;

            foreach (Ticket tick in Locs_Gr)
            {
                if (tick.Booking)
                    Sort_Tick.Add(tick);
            }
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        public void Group_Date(DateTime Date1, DateTime Date2)
        {
            Sort_Tick.Clear();
            var Dat_Gr =
                from Ticket tick in Ticks
                where tick.Date >= Date1 && tick.Date <= Date2
                select tick;

            foreach (Ticket tick in Dat_Gr)
            {
                if (tick.Booking)
                    Sort_Tick.Add(tick);
            }
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        public void Group_Price(int Pr1, int Pr2)
        {
            Sort_Tick.Clear();
            var Pr_Gr =
                from Ticket tick in Ticks
                where tick.Price >= Pr1 && tick.Price <= Pr2
                select tick;

            foreach (Ticket tick in Pr_Gr)
            {
                if (tick.Booking)
                    Sort_Tick.Add(tick);
            }
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        public void Group_All_1(string Ev, string Loc, DateTime Date1, DateTime Date2, int Pr1, int Pr2)
        {
            Sort_Tick.Clear();
            var All_Gr =
                from Ticket tick in Ticks
                where tick.Event == Ev && tick.Location == Loc && tick.Date >= Date1 && tick.Date <= Date2 && tick.Price >= Pr1 && tick.Price <= Pr2
                select tick;

            foreach (Ticket tick in All_Gr)
            {
                if (tick.Booking)
                    Sort_Tick.Add(tick);
            }
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        public void Group_All_2(string Ev, string Loc1, string Loc2, DateTime Date1, DateTime Date2, int Pr1, int Pr2)
        {
            Sort_Tick.Clear();
            var All_Gr =
                from Ticket tick in Ticks
                where tick.Event == Ev && (tick.Location == Loc1 || tick.Location == Loc2) && tick.Date >= Date1 && tick.Date <= Date2 && tick.Price >= Pr1 && tick.Price <= Pr2
                select tick;

            foreach (Ticket tick in All_Gr)
            {
                if (tick.Booking)
                    Sort_Tick.Add(tick);
            }
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        public void Group_All_without_Loc(string Ev, DateTime Date1, DateTime Date2, int Pr1, int Pr2)
        {
            Sort_Tick.Clear();
            var All_Gr =
                from Ticket tick in Ticks
                where tick.Event == Ev  && tick.Date >= Date1 && tick.Date <= Date2 && tick.Price >= Pr1 && tick.Price <= Pr2
                select tick;

            foreach (Ticket tick in All_Gr)
            {
                if (tick.Booking)
                    Sort_Tick.Add(tick);
            }
        }

        public ArrayList Get_Ava()
        {
            Sort_Tick.Clear();

            foreach (Ticket tick in Ticks)
            {
                if (tick.Booking)
                    Sort_Tick.Add(tick);
            }
            return Sort_Tick;
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        public ArrayList Get_Sort()
        {
            return Sort_Tick;
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        public ArrayList Get_Tick()
        {
            return Ticks;
        }
    }
}
        





