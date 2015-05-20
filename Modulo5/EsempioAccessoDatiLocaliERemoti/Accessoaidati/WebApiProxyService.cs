using System;
using System.Threading.Tasks;
using ClassLibrary1;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace Accessoaidati
{
	public class WebApiProxyService
	{
		public WebApiProxyService ()
		{
		}


		private HttpClient createHttpClient()
		{

			var client = new HttpClient();
			client.Timeout = TimeSpan.FromSeconds(40);
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue ("application/json"));

			string fullUrl = "http://10.1.1.217/WebApplication2/api/";

			client.BaseAddress = new Uri(fullUrl);

			return client;
		}

		public async Task<List<TodoItemDto>> GetItemsAsync()
		{
			// var requestDTO = createRequestObject<RequestDTO> ();
			// string requestParamsAsString = JsonConvert.SerializeObject(requestDTO);

			var httpClient = createHttpClient ();
			// var httpContent = createHttpPostRequestContent (requestParamsAsString);

			HttpResponseMessage response = await httpClient.GetAsync ("Values"); // , httpContent); 

			response.EnsureSuccessStatusCode (); // http://www.jayway.com/2012/03/13/httpclient-makes-get-and-post-very-simple/

			string content = await response.Content.ReadAsStringAsync ();

			List<TodoItemDto> resp = JsonConvert.DeserializeObject<List<TodoItemDto>>(content);

			return resp; // Task<TResult> returns an object of type TResult
		}
	}
}

