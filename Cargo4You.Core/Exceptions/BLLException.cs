using Cargo4You.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cargo4You.Core.Exceptions
{
	public class BLLException : ExceptionBase
	{

		/// <summary>
		/// Prevents a default instance of the <see cref="BLLException"/> class from being created.
		/// </summary>
		private BLLException() : base("") { }

		/// <summary>
		/// Initializes a new instance of the BLLException with an exception code (enum)
		/// </summary>
		/// <param name="code">The code.</param>
		public BLLException(ExceptionCodes.BLLExceptions code)
			: base(EnumsHelper.GetDescription(code))
		{
			Code = code.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the BLLException with an exception code (enum) and a message
		/// </summary>
		/// <param name="code">The code.</param>
		public BLLException(ExceptionCodes.BLLExceptions code, string message)
			: base(message)
		{
			Code = code.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the BLLException with an exception code (enum), a message and an exception
		/// </summary>
		/// <param name="code"></param>
		/// <param name="message"></param>
		/// <param name="ex"></param>
		public BLLException(ExceptionCodes.BLLExceptions code, string message, Exception ex)
			: base(message, ex)
		{
			Code = code.ToString();
		}


		///// <summary>
		///// Initializes a new instance of the <see cref="BLLException"/> class with multiple error codes
		///// </summary>
		///// <param name="code">The code.</param>
		///// <param name="errorCodes">The error codes.</param>
		///public BLLException(ExceptionCodes.BLLExceptions code, List<string> errorCodes)
		///    : base("")
		///{
		///    Code = code.ToString();
		///    ErrorCodes = errorCodes;
		///}
	}
}
