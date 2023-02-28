# ManyFormats

I maintain a project which has documentation in Markdown formatting as well as BBCode formatting. I got fed up with updating two otherwise equal files all the time, so I figured out a way to keep the text in one place.

To achieve this I created this project, ManyFormats, and use [T4 Text Templates](https://learn.microsoft.com/en-us/visualstudio/modeling/code-generation-and-t4-text-templates) to keep all the text centralised.

### Let me quickly show you how it works

Given the following example file `document-template.txt`:

```
<#= Fmt.Heading("This is a header") #>

<#= Fmt.Link("Open an issue!", "https://github.com/SpikeHimself/ManyFormats/issues") #>
```

I can maintain my documentation like so, for Markdown:

```
<#@ template debug="false" hostspecific="false" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ assembly name="$(SolutionDir)\libraries\ManyFormats.dll" #>
<#@ import namespace="ManyFormats" #>
<#@ import namespace="ManyFormats.Formats" #>
<#@ output extension=".md" #>
<# var Fmt = new Markdown(); #>
<#@ include file="document-template.txt" once="true" #>

```

And a similar file with only the changes below, for BBCode:

```
<#@ output extension=".bbcode" #>
<# var Fmt = new BBCode(); #>

```

And the outputs would be, respectively:

#### output.md
```
# This is a header

[Open an issue!](https://github.com/SpikeHimself/ManyFormats/issues)
```

#### output.bbcode
```
[size=6]This is a header[/size]

[url=https://github.com/SpikeHimself/ManyFormats/issues]Open an issue![/url]
```

### Wow!

Documentation to follow... :)
