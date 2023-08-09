using Microsoft.AspNetCore.Mvc;

namespace Clipdrop.Controllers
{

	[ApiController]
	[Route("")]
	public class ClipboardController : ControllerBase
	{

		private readonly ILogger<ClipboardController> _logger;

		public ClipboardController(ILogger<ClipboardController> logger)
		{
			_logger = logger;
		}

		[HttpGet("")]
		public string Get()
		{
			if (!System.IO.File.Exists("clipboard.txt"))
			{
				return string.Empty;
			}

			return System.IO.File.ReadAllText("clipboard.txt");
		}

		[HttpPost("")]
		public async Task<IActionResult> Post()
		{
			using (var reader = new StreamReader(HttpContext.Request.Body))
			{
				var data = await reader.ReadToEndAsync();
				Console.WriteLine(data);

				System.IO.File.WriteAllText("clipboard.txt", data);

				return StatusCode(StatusCodes.Status200OK, $"{data.Length} bytes uploaded to ClipDrop!" + Environment.NewLine);
			}
		}
	}
}