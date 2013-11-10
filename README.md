DynDNSviaYandexAPI
==================

<h2>What is it? </h2>
It's automatic tool for changed A-record your website, which delegeted on DNS Yandex. 

<h2>Donate </h2>
If you liked this application and you are looking for a way to support future development (or just say thank you), 
you always can do it with PayPal donate button below

<form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
<input type="hidden" name="cmd" value="_s-xclick">
<input type="hidden" name="hosted_button_id" value="DXA9J72YMS47Y">
<input type="image" src="https://www.paypalobjects.com/ru_RU/RU/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal — более безопасный и легкий способ оплаты через Интернет!">
<img alt="" border="0" src="https://www.paypalobjects.com/ru_RU/i/scr/pixel.gif" width="1" height="1">
</form>


<h3> ver 2.0.1 </h3>
<ul>
	<li>
	<b>New feature:</b>
	<ul>
		<li> Program start automatically after execute </li>
		<li> Add second url for definition ip addres (http://israspa.ru/getip/getip.php) </li>
	</ul>
	</li>
</ul>

<h3> ver 2.0 </h3>
<ul>
	<li>
	<b>New feature:</b>
	<ul>
		<li> Add GUI for application </li>
		<li> Import/Export csv files </li>
		<li> Indicates about new updates of application </li>
		<li> Refresh rate setting </li>
		<li> Hide in tray windows </li>
		<li> Storage data in SQLite database file </li>
	</ul>
	It has 5 files.
	<ul>
		<li> DbDomainInfo.db - SQLite database file </li>
		<li> DdnsViaYandexApiGUI.exe - main executed file. </li>
		<li> DdnsViaYandexApiGUI.exe.config - config file between DdnsViaYandexApi.exe and DbDomainInfo.db. </li>
		<li> \x64\SQLite.Interop.dll - SQLite library for x64. </li>
		<li> \x86\SQLite.Interop.dll - SQLite library for x86. </li>
	</ul>
	</li>
</ul>

<h3> ver 1.2 </h3>
<ul>
	<li>
	<b>New feature:</b> Add log4net. Logging success results, errors, exceptions and etc.
	It has 4 files.
	<ul>
		<li> domainInfo.csv - contains 3 part separated by comma: token,subdomain,domain </li>
		<li> DdnsViaYandexApi.exe - file which executed from Windows Task Scheduler. </li>
		<li> DdnsViaYandexApi.exe.config - config file between DdnsViaYandexApi.exe and log4net.dll. </li>
		<li> log4net.dll - log4net library version 1.2.11. </li>
	</ul>
	</li>
</ul>

<h3> ver 1.1 </h3>
<ul>
	<li>
	<b>New feature:</b> Supported multi-domain change A-record.
	It has 2 files.
	<ul>
		<li> domainInfo.csv - contains 3 part separated by comma: token,subdomain,domain </li>
		<li> DdnsViaYandexApi.exe - file which executed from Windows Task Scheduler. </li>
	</ul>
	</li>
</ul>

<h3> ver 1.0 </h3>
<ul>
	<li>
	It has 3 files.
	<ul>
		<li> domain.txt - Name of your website </li>
		<li> token.txt - token you get for this website when you delegeted it on Yandex DNS. How you can get it - (http://api.yandex.ru/pdd/doc/api-pdd/reference/api-dns_get_token.xml#api-dns_get_token). </li>
		<li> DdnsViaYandexApi.exe - file which executed from Windows Task Scheduler. </li>
	</ul>
	</li>
</ul>

<h3> System Requirements </h3>
<ul>
<li>OS Windows XP or high. Tested on Windows 7.</li>
<li>.NET 4.0</li>
</ul>
