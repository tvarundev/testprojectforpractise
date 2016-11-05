using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Application.Common
{
    internal static class ServiceMethods
    {
        /// <summary>
        /// Restfull Get Request
        /// </summary>
        /// <typeparam name="TSourceEntity"></typeparam>
        /// <param name="serviceInputObect"></param>
        /// <returns></returns>
        public static TSourceEntity GenerateGatRequest<TSourceEntity>(ServiceInputObject serviceInputObect) where TSourceEntity : class
        {

            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(serviceInputObect.baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync(serviceInputObect.finalUrlStringForGet).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TSourceEntity>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    throw new ServiceExceptions(response.ReasonPhrase);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static TSourceEntity GeneratePostRequest<TSourceEntity>(TSourceEntity sourceEntity, ServiceInputObject serviceInputObect) where TSourceEntity : class
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(serviceInputObect.baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.PostAsJsonAsync(serviceInputObect.finalUrlStringForPost, sourceEntity).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TSourceEntity>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    throw new ServiceExceptions(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static TDestinationEntity GeneratePostRequestWithDifferentDestinationEntity<TSourceEntity, TDestinationEntity>(TSourceEntity sourceEntity, ServiceInputObject serviceInputObect)
            where TSourceEntity : class
            where TDestinationEntity : class
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(serviceInputObect.baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.PostAsJsonAsync(serviceInputObect.finalUrlStringForPost, sourceEntity).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TDestinationEntity>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    throw new ServiceExceptions(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static int GeneratePostRequestWithIntDestinationEntity<TSourceEntity>(TSourceEntity sourceEntity, ServiceInputObject serviceInputObect)
            where TSourceEntity : class
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(serviceInputObect.baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.PostAsJsonAsync(serviceInputObect.finalUrlStringForPost, sourceEntity).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    throw new ServiceExceptions(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static TDestinationEntity GeneratePostRequestWithIntSourceEntity<TDestinationEntity>(int sourceEntity, ServiceInputObject serviceInputObect) where TDestinationEntity : class
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(serviceInputObect.baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.PostAsJsonAsync(serviceInputObect.finalUrlStringForPost, sourceEntity).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TDestinationEntity>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    throw new ServiceExceptions(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public static TSourceEntity GeneratePutRequest<TSourceEntity>(TSourceEntity sourceEntity, ServiceInputObject serviceInputObect) where TSourceEntity : class
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(serviceInputObect.baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.PutAsJsonAsync(serviceInputObect.finalUrlStringForPut, sourceEntity).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TSourceEntity>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    throw new ServiceExceptions(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static int GeneratePutRequestIntDestinationEntity<TSourceEntity>(TSourceEntity sourceEntity, ServiceInputObject serviceInputObect) where TSourceEntity : class
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(serviceInputObect.baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.PutAsJsonAsync(serviceInputObect.finalUrlStringForPut, sourceEntity).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    throw new ServiceExceptions(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static int GenerateDeleteRequest(int idToDelete, ServiceInputObject serviceInputObect)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(serviceInputObect.baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.DeleteAsync(serviceInputObect.finalUrlStringForDelete).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    throw new ServiceExceptions(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}