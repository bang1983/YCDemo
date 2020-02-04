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
        public Guid ID { get; set; }

        /// <summary>
        /// 代碼
        /// </summary>
        [Required]
        [MaxLength(5)]
        public String Code { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 備註
        /// </summary> 
        [MaxLength(200)]
        public string Remark { get; set; }

        /// <summary>
        /// 建立人員姓名
        /// </summary>
        [MaxLength(8)]
        [Required]
        public string CreateUser { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now; 

    }
}
