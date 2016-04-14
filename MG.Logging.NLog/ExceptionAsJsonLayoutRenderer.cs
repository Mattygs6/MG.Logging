namespace MG.Logging.NLog
{
	using System.Text;

	using global::NLog;
	using global::NLog.Config;
	using global::NLog.LayoutRenderers;

	using Newtonsoft.Json;

	/// <summary>
	///     Exception information provided through
	///     a call to one of the Logger.*Exception() methods displayed with JsonConvert.SerializeObject.
	/// </summary>
	[LayoutRenderer("exceptionAsJson")]
	[ThreadAgnostic]
	public class ExceptionAsJsonLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		///     Renders the specified exception information and appends it to the specified
		///     <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			if (logEvent.Exception != null)
			{
				builder.Append(JsonConvert.SerializeObject(logEvent.Exception));
			}
		}
	}
}