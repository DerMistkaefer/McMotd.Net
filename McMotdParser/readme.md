# McMotd.Net

McMotd.Net is Minecraft Motd Parser  
McMotd.Net can convert motd string to html

---
## how to use?
basic using
```csharp
string RawMotd = "Hello Minecraft!!";
string HtmlMotd = new MotdParser().ToHtml(RawMotd); 
```
HtmlMotd will output like
```html
<div class="mcmotd-container">
    <span style="color:#808080;">Hello&nbsp;Minecraft!!</span>
</div>
```
McMotd.Net can also resolve json and §(SectionSign)  
using Json
```csharp
string RawMotd = "{\"extra\":[{\"color\":\"#55FF55\",\"text\":\"HyPixel Network \"},{\"color\":\"#FF5555\",\"text\":\"[1.8-1.20]rn\"},{\"bold\":true,\"color\":\"#55FFFF\",\"text\":\"Test\"}],\"text\":\"\"}";
string HtmlMotd = new MotdParser().ToHtml(RawMotd); 
```
output : 
```html
<div class="mcmotd-container">
    <span style="color:#55FF55;">Hypixel&nbsp;Network&nbsp;</span>
    <span style="color:#FF5555;">[1.8-1.20]</span>
    <span style="color:#55FFFF; font-weight : bolder;"><br/>Test</span>
</div>
```


using §(SectionSign)
```csharp
string RawMotd = "§aHypixel Network §c[1.8-1.20]\r\n§b§lTest";
string HtmlMotd = new MotdParser().ToHtml(RawMotd); 
```
output :  
```html
<div class="mcmotd-container">
    <span style="color:#55FF55;">Hypixel&nbsp;Network&nbsp;</span>
    <span style="color:#FF5555;">[1.8-1.20]</span>
    <span style="color:#55FFFF; font-weight : bolder;">
        <br/>Test
    </span>
</div>
```

