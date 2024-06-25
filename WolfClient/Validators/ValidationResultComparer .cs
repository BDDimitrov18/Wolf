using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.Validators
{
    public class ValidationResultComparer : IEqualityComparer<ValidationResult>
    {
        public bool Equals(ValidationResult x, ValidationResult y)
        {
            return x.ErrorMessage == y.ErrorMessage && x.MemberNames.SequenceEqual(y.MemberNames);
        }

        public int GetHashCode(ValidationResult obj)
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + (obj.ErrorMessage?.GetHashCode() ?? 0);
                hash = hash * 23 + (obj.MemberNames != null ? obj.MemberNames.Aggregate(0, (acc, val) => acc + val.GetHashCode()) : 0);
                return hash;
            }
        }
    }
}
