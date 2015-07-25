using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HoverSharp.Models;
using Newtonsoft.Json;

namespace HoverSharp
{
    public class Hover
    {
        private readonly HttpClient _httpClient;
        private CookieContainer _cookies = new CookieContainer();

        public Hover(string username, string password)
        {
            _httpClient = new HttpClient();
            new HttpClient(new HttpClientHandler { AllowAutoRedirect = true, UseCookies = true, CookieContainer = new CookieContainer() });

            _httpClient.BaseAddress = new Uri("https://www.hover.com/api/");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username",username),
                new KeyValuePair<string, string>("password",password),
            });

            var response = _httpClient.PostAsync("login", content).Result;
        }


        public async Task<List<Domain>> GetDomains()
        {
            var response =await _httpClient.GetAsync("domains");
            return JsonConvert.DeserializeObject<DomainResponse>(await response.Content.ReadAsStringAsync()).domains;
        }

        public async Task<List<Entry>> GetDomainDns(Domain domain)
        {
            var response = await _httpClient.GetAsync(string.Format("domains/{0}/dns", domain.id));
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<DnsResponse>(content);
            var domainData = data.domains.First(x => x.id == domain.id);
            return domainData.entries;
        }

        public async Task UpdateSubDomain(string baseDomain, string subDomain, string ip)
        {
            var working = await GetDomain(baseDomain); 
            var dnsEntries = await GetDomainDns(working);
            var target = dnsEntries.First(x => x.name == subDomain);

            var url = string.Format("dns/{0}", target.id);

            var content = new FormUrlEncodedContent(new []
            {
                new KeyValuePair<string, string>("content",ip) 
            });

            await _httpClient.PutAsync(url, content);
        }

        public async Task AddSubDomain(string baseDomain, string subDomain, string type, string value)
        {
            var working = await GetDomain(baseDomain);
            var url = string.Format("domains/{0}/dns", working.id);
            var content = new FormUrlEncodedContent(new []
            {
                new KeyValuePair<string, string>("name",subDomain), 
                new KeyValuePair<string, string>("type",type), 
                new KeyValuePair<string, string>("content",value) 
            });
            await _httpClient.PostAsync(url, content);

        }

        private async Task<Domain> GetDomain(string baseDomain)
        {
            var domains = await GetDomains();
            var working = domains.FirstOrDefault(x => x.domain_name.ToLower() == baseDomain);
            return working;
        }
    }


}
