using System;
using System.Collections.Generic;
using System.Text;

namespace GRUDDemo.Services
 {
	/// <summary>
	/// 結果
	/// </summary>
	public interface IResult
	{
		/// <summary>
		/// 識別碼
		/// </summary>
		Guid ID { get; }

		/// <summary>
		/// 成功/失敗
		/// </summary>
		Boolean Success { get; set; }

		/// <summary>
		/// 訊息
		/// </summary>
		String Message { get; set; }

		/// <summary>
		/// 例外錯誤
		/// </summary>
		Exception Exception { get; set; }

		/// <summary>
		/// 內部結果
		/// </summary>
		List<IResult> InnerResults { get; }
	}
}
