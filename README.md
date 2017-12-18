# WebBrowser

I wanted to use the webBrowser control in WinForms to make a fully fledged web browser. Obviously I didn't make the webBrowser element, just the UI surrounding it. The intent is for it to be customisable, with options to change the program icon and title. There will probably be more options in the future, so stay tuned for those. If you are interested in the code, there are tons of comments so you can understand how it works.


## What everything is and what it does

### The main window

![Diagram of the main window](https://raw.githubusercontent.com/floathandthing/WebBrowser/master/MainUI.png?raw=true "Main UI diagram")

#### Reload
Sends the refresh command to the page, reloading it.

#### URL bar
This displays the URL of the page you are currently on, whilst also allowing you to enter your own URL to directly go to that page. Hitting return on your keyboard will load the URL in the bar. Pressing the go button does the same thing.

#### Go button
Pressing this loads the page in the URL bar. Pretty fundamental.

#### Back and Forward buttons
Pressing these tells the webBrowser to go either backwards or forwards along visited pages respectively. This is useful if you want to go back to a previous page and vice versa.

#### Home Button
When pressed, it loads the address specified in the Homepage option in Settings. See Settings for how to configure this page.

#### Status Indicator
This is a small label containing a short string, like "Idle", "Loading" or something like that. Its purpose is to tell you when the web browser is doing something.

#### EXIT
This button opens the Settings menu, which we are just about to talk about.

### Settings
![Settings dialog](https://raw.githubusercontent.com/floathandthing/WebBrowser/master/Settings.png?raw=true "Settings dialog")

#### Homepage
This textbox contains the page that is first loaded when the browser opens. Leave blank to disable this feature.

#### Remember last page visited
If checked, the browser keeps track of the last page you visited was, and the next time you open the browser it opens that page.

#### Use HTTPS
By default, the browser attempts to use HTTPS automatically. You can specify to use http in the URL bar, but this makes HTTPS the default option. I recommend that this box remains checked to ensure privacy, but if you want, it can be disabled.

#### Choose custom icon
If you have an image that you want to set to the program icon, you can select it here. The image has to be in the .ico format, but there are countless online conversion tools to convert ordinary images into this format. Note that if you delete the icon image, the browser will not be able to load it at startup, and will revert to the standard icon.

