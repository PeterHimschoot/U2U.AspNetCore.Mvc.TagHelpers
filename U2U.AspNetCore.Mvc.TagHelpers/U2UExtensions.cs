using System;
using System.Collections.Generic;
using System.Text;
using U2U.AspNetCore.Mvc.TagHelpers;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class U2UExtensions
  {
    public static IServiceCollection AddMarkdown(this IServiceCollection services)
    => services.AddSingleton<IMarkdownProcessor, CommonMarkdownProcessor>();
  }
}
