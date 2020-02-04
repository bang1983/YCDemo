using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRUDDemo.Models
{
    /// <summary>
    /// 每日記錄
    /// </summary>
    public class DemoCode
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Display(Name = "ID")]
        public Guid ID { get; set; }

        /// <summary>
        /// 代碼
        /// </summary>
        [Required]
        [MaxLength(5)]
        [Display(Name = "代碼")]
        public String Code { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        [Required]
        [MaxLength(20)]
        [Display(Name = "名稱")]
        public string Name { get; set; }

        /// <summary>
        /// 備註
        /// </summary> 
        [MaxLength(200)]
        [Display(Name = "備註")]
        public string Remark { get; set; }

        /// <summary>
        /// 建立人員姓名
        /// </summary> 
        [NotMapped]
        [Display(Name = "建立人員姓名")]
        public Users CreateUser { get; set; }

        /// <summary>
        /// 建立人員姓名
        /// </summary>
        [MaxLength(8)]
        [Required]
        [Column("CreateUser")] 
        public string CreateUserID
        {
            get => CreateUser.ToString();
            set
            {
                Users tryParseValue;
                if (!Enum.TryParse<Users>(value, out tryParseValue))
                    throw new ArgumentException($"Invalid User: {value}");
                CreateUser = tryParseValue;
            }
        }

        /// <summary>
        /// 建立日期
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "建立日期")]
        public DateTime CreateDate { get; set; } = DateTime.Today;

    }

    /// <summary>
    /// 狀態旗標
    /// </summary>
    public enum Users
    {
        /// <summary>
        /// Ada
        /// </summary>
        Ada,
        /// <summary>
        /// Bang
        /// </summary>
        Bang,
        /// <summary>
        /// Claire
        /// </summary>
        Claire
    }
}
