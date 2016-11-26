using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ClairvoyantAPI.Models
{
    public class Person
    {

        [Key]
        public string ID { get; set; }
        public string Name
        {
            get;

            set;
        }

        /// <summary>
        /// 1为男性，0为女性
        /// </summary>
        public Boolean Gender
        {
            get;

            set;
        }

        /// <summary>
        /// 国籍
        /// </summary>
        public string Country
        {
            get;

            set;
        }

        /// <summary>
        /// 省份，地级市，县级市
        /// </summary>
        public string Region
        {
            get;
            set;
        }

        public int Age
        {
            get; set;
        }
        
        public byte[] img { get; set;}
    }
}