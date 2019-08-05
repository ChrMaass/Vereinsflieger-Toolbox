using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vereinsflieger.Model;

namespace Vereinsflieger.Api
{
    public class FlightsController
    {
        public static async Task<List<Flight>> GetFlights(Connection connection, 
                                                         DateTime? startdate = null, 
                                                         DateTime? enddate = null, 
                                                         string departurelocation = null,
                                                         Chargemode? chargemode = null,
                                                         int? wid = null)
        {
            if (!connection.Loggedin)
                throw new UnauthorizedAccessException("Bitte vorher einloggen");

            HttpResponseMessage response;
            var fluege = new List<Flight>();

            if (!startdate.HasValue) startdate = DateTime.Today;
            if (!enddate.HasValue) enddate = DateTime.Today;


            var startDateNew = startdate < enddate ? startdate.Value.Date : enddate.Value.Date;
            var endDateNew = startdate > enddate ? startdate.Value.Date : enddate.Value.Date;
            if (endDateNew > DateTime.Now.Date) endDateNew = DateTime.Now.Date;
            var workdate = startDateNew;

            while (workdate <= endDateNew)
            {
                var parameters = connection.GetDefaultParameter();
                parameters.Add("dateparam", workdate.ToString("yyyy-MM-dd"));

                using (var client = connection.GetNewClient())
                    response = await client.PostAsync(Vereinsflieger.Api.Connection.restBaseUrl + "flight/list/date", new FormUrlEncodedContent(parameters));

                var content = await response.Content.ReadAsStringAsync();
                //using var sr = new StreamReader("test.json");
                //var content = sr.ReadToEnd();
                var flights = JsonConvert.DeserializeObject<Dictionary<string, Flight>>(content, Converter.Settings).Select(entry => entry.Value);

                // Hier sind die ganzen Filter
                if (departurelocation != null)
                    flights = flights.Where(f => f.Departurelocation.Contains(departurelocation));
                if (chargemode != null)
                    flights = flights.Where(f => f.Chargemode == chargemode);
                if (wid.HasValue)
                    flights = flights.Where(f => f.Wid == wid);

                fluege.AddRange(flights);

                workdate = workdate.AddDays(1);
                response.Dispose();

            }

            return fluege;
        }

        public static async Task EditFlightAsync(Connection connection, int flid, Dictionary<string, string> parameter)
        {
            using var client = connection.GetNewClient();
            var param = connection.GetDefaultParameter();
            foreach (var p in parameter)
                param.Add(p.Key, p.Value);

            var response = await client.PostAsync(Vereinsflieger.Api.Connection.restBaseUrl + "flight/edit/" + flid, 
                                                  new FormUrlEncodedContent(param));

            if (!response.IsSuccessStatusCode)
                throw new Exception("Fehler beim Update des Fluges.\n\rFehler: " + response.ToString());
        }

    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            Error = (se, ev) =>
            {
                if (ev.ErrorContext.Path != "httpstatuscode" && !ev.ErrorContext.Error.Message.Contains("0000-00-00"))
                    Debug.WriteLine($"Fehler beim serialisieren. Fehler: {ev.ErrorContext.Error.Message}");
                else
                    ev.ErrorContext.Handled = true;
            }
        };
    }


}
