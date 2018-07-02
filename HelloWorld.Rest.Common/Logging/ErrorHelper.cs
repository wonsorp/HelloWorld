using System;
using System.Collections.Generic;
using System.Text;
using HelloWorld.Rest.Common.Repository;

namespace HelloWorld.Rest.Common.Logging
{
    public static partial class ErrorHelper
    {
        public static void CheckNotNull(ErrorList ValidationErrors, string FieldNm, string Value)
        {
            if (Value == null)
            {
                ValidationErrors.AddError(FieldNm, new List<string>() { "Cannot Be Blank" });
            }
        }

        public static void CheckRepositoryType(ErrorList ValidationErrors, string FieldNm, int Value)
        {
            if (!Enum.IsDefined(typeof(RepositoryType), Value))
            {
                ValidationErrors.AddError(FieldNm, new List<string>() { "Invalid repository type" });
            }
        }

}
}
