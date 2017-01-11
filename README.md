# U2U.AspNetCore.Mvc.TagHelpers

This package contains a number of taghelpers.

## Markdown <md> taghelper

This taghelper will replace itself with **markdown** converted to html. 

You can learn more about this handy syntax here: <https://daringfireball.net/projects/markdown/>

You can choose between

* Path to a markdown file on disk
* Url to markdown contents
* Embedded markdown

To convert a local markdown file to html:

```
<md path="~/md/demo.md">
</md>
```

To convert some markdown content from the internet use:

```
<md href="https://applephi.blob.core.windows.net/demo/README.md">
</md>
```

And of course you can simply embed markdown:

```
<md class="row">
  ## This is a test

  This is a test

  ```
  With some code
  ```
</md>
```

# Sources

I you're interested in how this packages works, it is available on github at
<https://github.com/PeterHimschoot/U2U.AspNetCore.Mvc.TagHelpers>

Any bugs, remarks, etc... can always be sent to <peter@u2u.be>