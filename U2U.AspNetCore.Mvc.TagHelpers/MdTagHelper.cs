using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace U2U.AspNetCore.Mvc.TagHelpers
{
  public class MdTagHelper : TagHelper
  {
    private IHostingEnvironment env;
    private ILogger<MdTagHelper> logger;
    private IMarkdownProcessor markdownProcessor;

    public MdTagHelper(IHostingEnvironment env, ILogger<MdTagHelper> logger, IMarkdownProcessor markdownProcessor)
    {
      this.env = env ?? throw new ArgumentNullException(paramName: nameof(env));
      this.logger = logger ?? throw new ArgumentNullException(paramName: nameof(logger));
      this.markdownProcessor = markdownProcessor ?? throw new ArgumentNullException(paramName: nameof(markdownProcessor));
    }

    [HtmlAttributeName(name: "path")]
    public string Path { get; set; }

    [HtmlAttributeName(name: "href")]
    public string HRef { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      string md = string.Empty;

      if (Path != null)
      {
        try
        {
          if (Path.StartsWith("~"))
          {
            Path = Path.Replace("~", env.WebRootPath);
          }
          //var fileProvider = env.WebRootFileProvider;
          using (var reader = File.OpenText(Path))
          {
            md = await reader.ReadToEndAsync();
          }
        }
        catch (Exception ex)
        {
          md = $"Problem reading file at {Path}";
          logger.LogError(eventId: 0, exception: ex, message: md);
        }
      } else if (HRef != null)
      {
        try
        {
          using (var hc = new HttpClient())
          {
            md = await hc.GetStringAsync(this.HRef);
          }
        }
        catch (Exception ex)
        {
          md = $"Problem reading url {HRef}";
          logger.LogError(eventId: 0, exception: ex, message: md);
        }
      } else if (Path == null && HRef == null)
      {
        var result = await output.GetChildContentAsync();
        // get markdown from inner text
        md = result.GetContent();
      }

      output.TagName = "div";

      if (md != string.Empty)
      {
        string mdAsHtml = this.markdownProcessor.Convert(md);
        output.Content.AppendHtml(mdAsHtml);
      }
    }
  }
}
