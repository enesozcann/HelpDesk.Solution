using System.Collections.Generic;

namespace HelpDesk.BusinessLayer
{
    public class HDBusinnesLResults<T> where T : class
    {
        public List<string> Errors { get; set; }
        public T Result { get; set; }

        public HDBusinnesLResults()
        {
            Errors = new List<string>();
        }
        //public void AddError(ErrorMessageCode code, string message)
        //{
        //    Errors.Add(new ErrorMessageObj() { Code = code, Message = message });
        //}
    }
}