using System;
using System.ComponentModel.DataAnnotations;

namespace MESProject.Models
{
    public class WorkOrder
    {
        [Key]
        public int WorkOrderId { get; set; }

        [Required(ErrorMessage = "產品代碼為必填欄位")]
        [StringLength(50, ErrorMessage = "產品代碼不能超過50個字元")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "數量為必填欄位")]
        [Range(1, 99999, ErrorMessage = "數量必須介於1到99999之間")]
        public int Quantity { get; set; }

        // 擴展的欄位
        [Display(Name = "計劃開始時間")]
        public DateTime? PlannedStartTime { get; set; }

        [Display(Name = "實際開始時間")]
        public DateTime? ActualStartTime { get; set; }

        [Display(Name = "完成時間")]
        public DateTime? CompletionTime { get; set; }

        [StringLength(50, ErrorMessage = "生產線不能超過50個字元")]
        [Display(Name = "生產線")]
        public string? ProductionLine { get; set; }

        [Display(Name = "備註")]
        public string? Notes { get; set; }

        // 現有欄位
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}