namespace Jalasoft.Eva.Evaluations.Services.Impl.ScoreUtils
{
    using System.Collections.Generic;
    using org.mariuszgromada.math.mxparser;

    public abstract class AbstractListIterator<T> : FunctionExtension
    {
        public AbstractListIterator(IList<T> list, string funtionName)
        {
            this.Values = list;
            this.Index = 0;
            this.FunctionName = funtionName;
        }

        protected IList<T> Values { get; set; }

        protected int Index { get; set; }

        private string FunctionName { get; set; }

        public abstract double calculate();

        public FunctionExtension clone()
        {
            return this;
        }

        public string getParameterName(int parameterIndex)
        {
            return this.FunctionName;
        }

        public int getParametersNumber()
        {
            return 1;
        }

        public void setParameterValue(int parameterIndex, double parameterValue)
        {
            if (parameterIndex == 0)
            {
                this.Index = (int)parameterValue;
            }
        }
    }
}
