using System;
using System.Collections.Generic;
using System.Text;

namespace GRUDDemo.Services
{
	public class Result : IResult
	{
		public Guid ID { get; private set; }

		public Boolean Success { get; set; }

		public String Message { get; set; }

		public Exception Exception { get; set; }

		public List<IResult> InnerResults => new List<IResult>();

		public Result() : this(false) { }

		public Result(bool value)
		{
			ID = Guid.NewGuid();
			Success = value;
		}
	}
}
