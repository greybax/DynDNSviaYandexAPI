DynDNSviaYandexAPI
==================

<h2>What is it? </h2>
It's automatic tool for changed A-record your website, which delegeted on DNS Yandex. 

<h3> ver 2.0 </h3>
Planned make application as Windows Service.
coming soon...

<h3> ver 1.1 </h3>
<ul>
	<li>
	<b>New feature:</b> Supported multi-domain change A-record.
	It has 2 files.
	<ul>
		<li> domainInfo.csv - contains 3 part separated by comma: token,subdomain,domain </li>
		<li> YandexDynDNS.exe - file which executed from Windows Task Scheduler. </li>
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
		<li> YandexDynDNS.exe - file which executed from Windows Task Scheduler. </li>
	</ul>
	</li>
</ul>

<h3> System Requirements </h3>
<ul>
<li>OS Windows XP or high. Tested on Windows 7.</li>
<li>.NET 4.0</li>
</ul>
