# McMotd.Net.Razor


McMotd.Net.Razor can use RazorComponent  
## how to use?
### setup
import McMotdParser.Razor
```csharp
@using McMotdParser.Razor
```

simple using
```html
<McMotdComponent RawMotdString="Minecraft Server!"/>
```
or
```html
@(await Html.RenderComponentAsync<McMotdComponent>(RenderMode.ServerPrerendered, new { RawMotdString = "Minecraft Server!"} ))
```
---
**razor components does not yet support multiple spacing.**  
