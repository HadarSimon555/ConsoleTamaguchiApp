﻿using ConsoleTamaguchiApp.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace ConsoleTamaguchiApp.WebServices
{
    public class TamaguchiWebAPI
    {
        private HttpClient client;
        private string baseUri;

        public TamaguchiWebAPI(string baseUri)
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            //Create client with the handler!
            this.client = new HttpClient(handler, true);
            this.baseUri = baseUri;
        }

        #region GetPlayerActiveAnimalAsync
        public async Task<AnimalDTO> GetPlayerActiveAnimalAsync()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetAnimals");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<AnimalDTO> fList = JsonSerializer.Deserialize<List<AnimalDTO>>(content, options);
                    AnimalDTO aDTO = fList.Where(a => a.OverallStatusId != 4).FirstOrDefault();
                    return aDTO;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region LoginAsync
        public async Task<PlayerDTO> LoginAsync(PlayerDTO pd)
        {
            try
            {
                string playerJson = JsonSerializer.Serialize(pd);
                StringContent content = new StringContent(playerJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = JsonSerializer.Serialize(response);
                    PlayerDTO p = JsonSerializer.Deserialize<PlayerDTO>(responseJson);
                    return p;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region ChangePasswordAsync
        public async Task<bool> ChangePasswordAsync(string newPswd)
        {
            string json = JsonSerializer.Serialize(newPswd);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/ChangePassword", content);
            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string res = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<bool>(res, options);
            }
            return false;
        }
        #endregion

        #region GetPlayerAnimalsAsync
        public async Task<List<AnimalDTO>> GetPlayerAnimalsAsync()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetAnimals");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<AnimalDTO> fList = JsonSerializer.Deserialize<List<AnimalDTO>>(content, options);
                    return fList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region CreateAnimalAsync
        public async Task<AnimalDTO> CreateAnimalAsync(string animalName)
        {
            try
            {
                string json = JsonSerializer.Serialize(animalName);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/CreateAnimal", content);
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string responseJson = JsonSerializer.Serialize(response);
                    AnimalDTO a = JsonSerializer.Deserialize<AnimalDTO>(responseJson);
                    return a;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region GetActionTypeAsync
        public async Task<ActionTypeDTO> GetActionTypeAsync(string actionTypeName)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetActionType?actionTypeName={actionTypeName}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    ActionTypeDTO actionType = JsonSerializer.Deserialize<ActionTypeDTO>(content, options);
                    return actionType;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region GetActionsListAsync
        public async Task<List<ActionDTO>> GetActionsListAsync(ActionTypeDTO type)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetActionsList?actionTypeDTO={type}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<ActionDTO> aList = JsonSerializer.Deserialize<List<ActionDTO>>(content, options);
                    return aList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region GetAction
        public async Task<List<ActionDTO>> GetAction(int id)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetActionsList?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<ActionDTO> aList = JsonSerializer.Deserialize<List<ActionDTO>>(content, options);
                    return aList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

    }
}
