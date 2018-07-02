using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


namespace HelloWorld.Rest.Common.Logging
{
    public class ErrorList : IEnumerable<KeyValuePair<string, List<string>>>
    {
        private Dictionary<string, List<string>> _Errors = new Dictionary<string, List<string>>();

        System.Collections.IEnumerator IEnumerable.GetEnumerator()
        {
            return _Errors.GetEnumerator();
        }

        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<string>>> GetEnumerator()
        {
            return this.GetErrorsEnumerator();
        }

        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<string>>> GetErrorsEnumerator()
        {
            return _Errors.GetEnumerator();
        }

        public void AddError(string Key, IEnumerable<string> ModelErrors)
        {
            if (!_Errors.ContainsKey(Key))
            {
                _Errors.Add(Key, new List<string>(ModelErrors));
            }
            else
            {
                _Errors[Key].AddRange(ModelErrors);
            }
        }
    }
}
