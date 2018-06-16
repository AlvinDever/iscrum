using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iScrum.Model
{
    public class ToDo
    {
        int _ID;
        string _Name;

        public int ID
        {
            get { return _ID; }
            set { this._ID = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { this._Name = value; }
        }
    }
}
