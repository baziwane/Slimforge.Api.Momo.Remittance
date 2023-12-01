// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalOAuth
{
    internal class ExternalAuthorizationResponse
    {
        [JsonProperty(propertyName: "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(propertyName: "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(propertyName: "expires_in")]
        public int ExpiresIn { get; set; }
    }
}

/*
 "access_token": "eyJ0eXAiOiJKV1QiLCJhbGciOiJSMjU2In0.eyJjbGllbnRJZCI6IjQ5YmQ2OGQwLWU4NmYtMTFlOC05ZjMyLWYyODAxZjFiOWZkMSIsImV4cGlyZXMiOiIyMDIzLTExLTI4VDAyOjMzOjIyLjE5MiIsInNlc3Npb25JZCI6IjFlODYzNGM1LWI0OTgtNDY2Ni04ZTZhLTc5OGJiMWQ2ZjFjNCJ9.N9dXyDyIYhqZjLMzXTGuyWS1oFMSiLzAtrY_74V2ugcgwYZFimUlsVfA8rcw6zxVBFSu5Q3OTtk5Ij0xCXBHwgsPf2lv770aPjkylFqxOFBA7ZP8XRhNaYql7dw_rM3-JRhMQrJ6mey0Ne8wbgfRoMW-alYJV44FiIqR_wxm_gYzfYi706h2fZ2x6CDzvrrT1vmU4HHPt4Xao9pE_IIye2HyclEpbHclH9iTy9G22oX-_0TZVNAxMrBpsZQNNPhUrOLeOv-KQ6h_ks8bNW-nPmjdRTwy_EQS5YhfjqwecjAVkqmSdkl3iy8_Axz_KxdsniOGV5GAns8h0xY9BXgwXg",
    "token_type": "access_token",
    "expires_in": 3600

*/

