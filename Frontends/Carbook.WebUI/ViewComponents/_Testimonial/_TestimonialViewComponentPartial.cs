﻿using Carbook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents._Testimonial
{
    public class _TestimonialViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7189/api/Testimonials ");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
