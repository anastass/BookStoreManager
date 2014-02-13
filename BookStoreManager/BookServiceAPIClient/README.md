# Client for BookServiceAPI

## Styling

Default page (_Default.aspx_) uses layout defined by _Layout.Master_.
For styling master page Bootstrap 3 is used. There some changes compare to Boostrap 2 - 
for more information see [What's New in Bootstrap 3](http://bootply.com/bootstrap-3-migration-guide). 
To convert existsing CSS from Bootstrap 2 to Bootstrap 3 use [Bootstrap migration tool](http://upgrade-bootstrap.bootply.com/).

Additional information is available below:

- [Bootstrap 3](http://getbootstrap.com/css/)
- [Grid system](http://bootstrap.stage42.net/doc/grid)
- [Bootstrap theme](http://getbootstrap.com/examples/theme/)
- [The Bootstrap Playground](http://bootply.com/)
- [Twitter Bootstrap Tutorial – Handling Complex Designs](http://www.sitepoint.com/twitter-bootstrap-tutorial-handling-complex-designs/)
- [How To Use Twitter Bootstrap on an ASP.Net Website](http://geekswithblogs.net/JeremyMorgan/archive/2012/09/18/how-to-use-twitter-bootstrap-on-an-asp.net-website.aspx)
- [Walkthrough: Creating and Using ASP.NET Master Pages in Visual Web Developer](http://msdn.microsoft.com/en-us/library/ehszf8ax(v=vs.90).aspx)

## Links

- [HTTP access control (CORS)](https://developer.mozilla.org/en/docs/HTTP/Access_control_CORS)
- [Enabling Cross-Origin Requests in ASP.NET Web API](http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api)
- [Using CORS](http://www.html5rocks.com/en/tutorials/cors/)
- [ASP.NET Web API 2.0 Cross Origin Resource Sharing support](http://www.dotnetcurry.com/showarticle.aspx?ID=921)
- [Cross-Origin XMLHttpRequest](http://developer.chrome.com/extensions/xhr.html)
- [Custom Headers &lt;customHeaders&gt;](http://www.iis.net/configreference/system.webserver/httpprotocol/customheaders)
- [Cross Origin Resource Sharing using “Access-Control-Allow-Origin” in MVC 4](http://www.dotnettrace.net/2013/10/cross-origin-resource-sharing-using.html)
- [Using TypeConverters to Get AppSettings in .NET](http://stacktoheap.com/blog/2013/01/20/using-typeconverters-to-get-appsettings-in-net/)

## CORS - Examples

	[PHP]
	$http_origin = $_SERVER['HTTP_ORIGIN'];
	if ($http_origin == "http://www.domain1.com" || $http_origin == "http://www.domain2.com" || $http_origin == "http://www.domain3.info")
	{  
		header("Access-Control-Allow-Origin: $http_origin");
	}
