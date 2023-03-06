# ManyFormats

### ManyFormats provides functionality to format text using predefined or custom formats.

I maintain a project which has documentation in Markdown formatting as well as BBCode formatting. I got fed up with updating two otherwise equal files all the time, so I figured out a way to keep the text in one place.

To achieve this I created this project, ManyFormats, and use [T4 Text Templates](https://learn.microsoft.com/en-us/visualstudio/modeling/code-generation-and-t4-text-templates) to keep all the text centralised.

### Let me quickly show you how it works

Given the following example file `document-template.txt`:

```
<#= mf.Heading("This is a header") #>

<#= mf.Link("Open an issue!", "https://github.com/SpikeHimself/ManyFormats/issues") #>
```

I can maintain my documentation using the following T4 setup, for Markdown:

```
<#@ output extension=".md" #>
<# var mf = new Markdown(); #>
<#@ include file="document-template.txt" once="true" #>

```

And like so, for BBCode:

```
<#@ output extension=".bbcode" #>
<# var mf = new Bbcode(); #>
<#@ include file="document-template.txt" once="true" #>
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
