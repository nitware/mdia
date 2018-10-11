using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdia.Model.Model
{
    public class Role : Setup
    {
        //private bool _hasUser;
        //private string _name;

        
        public bool HasUser { get; set; }
        public List<Right> Rights { get; set; }
        public UserRight UserRight { get; set; }


        //public override string Name
        //{
        //    get { return _name; }
        //    set
        //    {
        //        _name = value;
        //        base.OnPropertyChanged("Name");
        //    }
        //}

        //public bool HasUser
        //{
        //    get { return _hasUser; }
        //    set
        //    {
        //        _hasUser = value;
        //        base.OnPropertyChanged("HasUser");
        //    }
        //}




    }
}
