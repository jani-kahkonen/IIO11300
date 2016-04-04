using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava10
{
    [Serializable]
    public class Book
    {
        #region PROPERTIES
        private string fName;
        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }

        private string lName;
        public string LName
        {
            get { return lName; }
            set { lName = value; }
        }

        private string group;
        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        private string price;
        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        #region CONSTUCTORS
        public Book(string fName, string lName, string group, string price, string id)
        {
            this.fName = fName;
            this.lName = lName;
            this.group = group;
            this.price = price;
            this.id = id;
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return fName + " " + lName + ", " + group;
        }
        #endregion
    }

    class BLPlayer
    {
        private static string cs = Tehtava10.Properties.Settings.Default.Kirjakauppa;

        public static List<Book> GetBooks(Boolean useDB)
        {
            try
            {
                List<Book> temp = new List<Book>();

                DataTable dt = DBPlayer.GetBooks(cs);

                foreach (DataRow dr in dt.Rows)
                {
                    Book book = new Book( dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());

                    temp.Add(book);
                }

                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateBook(Book book)
        {
            try
            {
                int lkm = DBPlayer.UpdateBook(cs, book.FName, book.LName, book.Price, book.Group, book.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
