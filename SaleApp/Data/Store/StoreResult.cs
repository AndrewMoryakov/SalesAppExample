using Microsoft.AspNetCore.Mvc;

namespace SaleAppExample.Data;

public class StoreResult
{
	public StoreResult(StatusCodeResult codeResult)
	{
		CodeResult = codeResult;
	}

	public ActionResult CodeResult { get; private set; }
}