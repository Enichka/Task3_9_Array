using System.IO;
using System;
using System.Collections;



namespace Task1_9_Array
{
    public class Ticket
    {

        

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        public Ticket(int Orcode, string Event, DateTime Date, string Location, int Row, int Seat, int Price, bool Booking)
        {
            this.Orcode = Orcode;
            this.Event = Event;
            this.Date = Date;
            this.Location = Location;
            this.Row = Row;
            this.Seat = Seat;
            this.Price = Price;            
            this.Booking = Booking;
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

        public Ticket() { }
        public int Orcode { set; get; }
        public string Event { set; get; }
        public DateTime Date { set; get; }
        public string Location { set; get; }
        public int Row { set; get; }
        public int Seat { set; get; }
        public int Price { set; get; }        
        public bool Booking { set; get; }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
       
    }
}


