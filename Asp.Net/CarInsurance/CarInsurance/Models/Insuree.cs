using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInsurance.Models
{
    public class Insuree
    {
        public required int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string EmailAddress { get; set; }

        [Column(TypeName = "date")]
        public required DateTime DateOfBirth { get; set; }

        public required int CarYear { get; set; }

        public required string CarMake { get; set; }

        public required string CarModel { get; set; }

        public required bool DUI { get; set; } // 是否有酒驾记录，布尔：true有 / false无

        public required int SpeedingTickets { get; set; } // 超速罚单数量

        public required string CoverageType { get; set; } // 保险类型，例如Full / Liability

        public required decimal Quote { get; set; } // 报价金额，小数类型
    }
}
