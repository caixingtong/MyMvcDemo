namespace MyMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Goods
    {
        public int Id { get; set; }

        public int? Stock { get; set; }


        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Row { get; set; }

        [StringLength(100)]
        public string Col { get; set; }

        [StringLength(100)]
        public string Color { get; set; }

        [StringLength(100)]
        public string Areas { get; set; }

        [StringLength(200)]
        public string CityName { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        [StringLength(100)]
        public string Quality { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreatorId { get; set; }

        public int? LastModifierId { get; set; }

        public DateTime? LastModifyTime { get; set; }

        [StringLength(200)]
        public string Price { get; set; }

        [StringLength(200)]
        public string ChartMan { get; set; }

        [StringLength(200)]
        public string Tel { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }

        [StringLength(200)]
        public string Style { get; set; }

        [StringLength(200)]
        public string Grain { get; set; }

        [StringLength(200)]
        public string Money { get; set; }

        [StringLength(200)]
        public string ProvinceName { get; set; }

        [StringLength(50)]
        public string IsEnable { get; set; }
        

    }
}
