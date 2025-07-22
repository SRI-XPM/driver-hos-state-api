namespace driver_hos_state_api.Models
{
    /// <summary>
    /// Represents the full response for driver HOS state records.
    /// </summary>
    public class DriverHosStateResponse
    {
        public string DriverCompany { get; set; }
        public string DriverNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DriverHosRecord> Records { get; set; } = new();
    }
}
