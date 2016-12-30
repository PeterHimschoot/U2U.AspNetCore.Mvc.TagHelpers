using System;
using System.Collections.Generic;
using System.Text;

namespace U2U.AspNetCore.Mvc.TagHelpers
{
  public interface IMarkdownProcessor
  {
    string Convert(string markdown);
  }

  public class CommonMarkdownProcessor : IMarkdownProcessor
  {
    public string Convert(string markdown)
    => CommonMark.CommonMarkConverter.Convert(markdown);
  }
}
