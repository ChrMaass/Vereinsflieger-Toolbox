using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vereinsflieger.Model
{
    public class Flight
    {
        /// <summary>
        /// Eindeutige Flugnummer
        /// </summary>
        [JsonProperty("flid")]
        public int Flid { get; set; }

        /// <summary>
        /// Datum der Erstellung
        /// </summary>
        [JsonProperty("createtime")]
        public DateTime Createtime { get; set; }

        /// <summary>
        /// Datum der letzten Änderung
        /// </summary>
        [JsonProperty("modifytime")]
        public DateTime Modifytime { get; set; }

        /// <summary>
        /// Eindeutige LFZ Nummer
        /// </summary>
        [JsonProperty("apid")]
        public int Apid { get; set; }

        /// <summary>
        /// LFZ_Kennzeichen
        /// </summary>
        [JsonProperty("callsign")]
        public string Callsign { get; set; }

        /// <summary>
        /// Eindeutige Benutzernummer des Piloten
        /// </summary>
        [JsonProperty("uidpilot")]
        public int Uidpilot { get; set; }

        /// <summary>
        /// Name des Piloten
        /// </summary>
        [JsonProperty("pilotname")]
        public string Pilotname { get; set; }

        /// <summary>
        /// Mitgliednummer des Piloten
        /// </summary>
        [JsonProperty("pilotmemberid")]
        public int? Pilotmemberid { get; set; }

        /// <summary>
        /// Eindeutige Benutzernummer des Begleiters / FI
        /// </summary>
        [JsonProperty("uidattendant")]
        public int Uidattendant { get; set; }

        /// <summary>
        /// Begleiter / FI
        /// </summary>
        [JsonProperty("attendantname")]
        public string Attendantname { get; set; }

        /// <summary>
        /// Mitgliedsnummer des Begleiters im Verein
        /// </summary>
        [JsonProperty("attendantmemberid")]
        public int? Attendantmemberid { get; set; }

        /// <summary>
        /// Eindeutige Benutzernummer des 2. Begleiters
        /// </summary>
        [JsonProperty("uidattendant2")]
        public int Uidattendant2 { get; set; }

        /// <summary>
        /// Name des 2. Begleiters
        /// </summary>
        [JsonProperty("attendantname2")]
        public string Attendantname2 { get; set; }

        /// <summary>
        /// Eindeutige Benutzernummer des 3. Begleiters
        /// </summary>
        [JsonProperty("uidattendant3")]
        public int Uidattendant3 { get; set; }

        /// <summary>
        /// Name des 3. Begleiters
        /// </summary>
        [JsonProperty("attendantname3")]
        public string Attendantname3 { get; set; }

        /// <summary>
        /// Eindeutige Benutzernummer des FI, welcher den Flugauftrag gegeben hat
        /// </summary>
        [JsonProperty("uidfi")]
        public int Uidfi { get; set; }

        /// <summary>
        /// Name des FI, welcher den Flugauftrag gegeben hat
        /// </summary>
        [JsonProperty("finame")]
        public string Finame { get; set; }

        /// <summary>
        /// Eindeutige Benutzernummer des zahlenden Mitglieds (bei chargetype = Anderes mitglied)
        /// </summary>
        [JsonProperty("iidcharge")]
        public int Uidcharge { get; set; }

        /// <summary>
        /// Flugdatum
        /// </summary>
        [JsonProperty("dateoffflight")]
        public DateTime Dateoffflight { get; set; }

        /// <summary>
        /// Abflugzeit
        /// </summary>
        [JsonProperty("departuretime")]
        public TimeSpan Departuretime { get; set; }

        /// <summary>
        /// Startort
        /// </summary>
        [JsonProperty("departurelocation")]
        public string Departurelocation { get; set; }

        /// <summary>
        /// Landezeit
        /// </summary>
        [JsonProperty("arrivaltime")]
        public TimeSpan Arrivaltime { get; set; }

        /// <summary>
        /// Landeort
        /// </summary>
        [JsonProperty("arrivallocation")]
        public string Arrivallocation { get; set; }

        /// <summary>
        /// Flugzeit (in Minuten)
        /// </summary>
        [JsonProperty("flighttime")]
        public int Flighttime { get; set; }

        /// <summary>
        /// Anzahl der Landungen
        /// </summary>
        [JsonProperty("landingcount")]
        public int Landingcount { get; set; }

        /// <summary>
        /// Startart
        /// </summary>
        [JsonProperty("starttype")]
        public Starttype Starttype { get; set; }

        /// <summary>
        /// Kommentar
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Flugmodus
        /// </summary>
        [JsonProperty("flightmode")]
        public Flightmode Flightmode { get; set; }

        /// <summary>
        /// ID der Flugart (Siehe Stammdaten Flugarten)
        /// </summary>
        [JsonProperty("ftid")]
        public int Ftid { get; set; }

        /// <summary>
        /// OffBlock Zeit
        /// </summary>
        [JsonProperty("offblock")]
        public DateTime Offblock { get; set; }

        /// <summary>
        /// OnBlock Zeit
        /// </summary>
        [JsonProperty("onblock")]
        public DateTime Onblock { get; set; }

        /// <summary>
        /// Blockzeit (in Minuten)
        /// </summary>
        [JsonProperty("blocktime")]
        public int Blocktime { get; set; }

        /// <summary>
        /// Eindeutige Flugnummer des dazugehörigen Schleppfluges
        /// </summary>
        [JsonProperty("flidtow")]
        public int Flidtow { get; set; }

        /// <summary>
        /// Abrechnungsmodus
        /// </summary>
        [JsonProperty("chargemode")]
        public Chargemode Chargemode { get; set; }

        /// <summary>
        /// ID der Winde
        /// </summary>
        [JsonProperty("wid")]
        public int Wid { get; set; }

        /// <summary>
        /// Luftfahrzeugart (Segelflugzeug, Reisemotorsegler, Ultraleicht ...)
        /// </summary>
        [JsonProperty("planetype")]
        public string Planetype { get; set; }

        /// <summary>
        /// Fluggebühren (nach der Abrechnung verfügbar
        /// </summary>
        [JsonProperty("invoiceinfo")]
        public Invoiceinfo[] Invoiceinfo { get; set; }

    }

    public class Invoiceinfo
    {
        /// <summary>
        /// Benutzernummer
        /// </summary>
        [JsonProperty("uid")]
        public int Uid { get; set; }

        /// <summary>
        /// ID der Buchungsnummer
        /// </summary>
        [JsonProperty("adid")]
        public int Adid { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Brutto Abrechnungsbetrag
        /// </summary>
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }

    public enum Starttype
    {
        Eigenstart = 1,
        F_Schlepp = 3,
        Winde = 5,
        Gummiseil = 7,
        Fahrzeug = 9
    }

    public enum Flightmode
    {
        Lokal = 1,
        Abflug = 2,
        Landung = 3,
        Fremd = 4
    }

    public enum Chargemode
    {
        Keine = 1,
        Pilot = 2,
        Begleiter = 3,
        Gastflug = 4,
        PilotUndBegleiter = 5,
        GastflugPilotZahlt = 6,
        AnderesMitglied = 7,
        UeberSegelflug = 8,
        Landegebühr = 9
    }
}
