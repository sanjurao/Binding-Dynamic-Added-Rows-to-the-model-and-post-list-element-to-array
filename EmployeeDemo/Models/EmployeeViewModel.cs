using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EmployeeDemo.Models
{
    public class EmployeeViewModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Phone> Phones { get { return _phones; } }

        private List<Phone> _phones = new List<Phone>();
    }

    public class Phone
    {
        public enum Types
        {
            Business,
            Cell,
            Fax,
            Home
        }

        [Required]
        public Types Type { get; set; }

        [Required]
        [Phone]
        public string Number { get; set; }

        public IEnumerable<SelectListItem> PhoneTypeSelectListItems
        {
            get
            {
                foreach(Types type in Enum.GetValues(typeof(Types)))
                {
                    SelectListItem selectListItem = new SelectListItem();
                    selectListItem.Text = type.ToString();
                    selectListItem.Value = type.ToString();
                    selectListItem.Selected = Type == type;

                    yield return selectListItem;
                }
            }
        }
    }

    public class CustomerViewModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public List<PhoneType> Phones { get; set; }
    }

    public class PhoneType
    {       
        public string Type { get; set; }
        
        public string Number { get; set; }        
    }
}