using System;
using System.Net.Http.Headers;
using FastPay.Payments.Application.Common.Interfaces;
using FastPay.Payments.Application.Dto;

namespace FastPay.Payments.Infrastructure.Persistence
{
	public class ProfileContactRepository: IProfileContactRepository
	{
        private readonly HttpClient _httpClient;

		public ProfileContactRepository(HttpClient httpClient)
		{
            _httpClient=httpClient;
		}

        public async Task<ProfileContactDto> GetProfileContactById(int contactId)
        {

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ProfileContactDto result = new ProfileContactDto();
            HttpResponseMessage response = await _httpClient.GetAsync($"api/contacts/{contactId}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<ProfileContactDto>();
            }


            return result;

        }
    }
}

