using System.ComponentModel.DataAnnotations;

namespace CarRental.WebApi.Models
{
    public class RentalModel
    {
        /// <summary>
        /// Placa del vehículo
        /// </summary>
        /// <example>PLC-226</example>
        [Required]
        public string? CarId { get; set; }
        /// <summary>
        /// Modelo del vehículo
        /// </summary>
        /// <example> Chevrolet Spark</example>
        [Required]
        public string? Model { get; set; }
        /// <summary>
        /// Sucursal origen del vehículo
        /// </summary>
        /// <example>Bucaramanga - Santander</example>
        [Required]
        public string? PickUpMarket { get; set; }
        /// <summary>
        /// Sucursal donde será retornado el vehículo
        /// </summary>
        /// <example>Cúcuta - Norte de Santander</example>
        [Required]
        public string? ReturnMarket { get; set; }
        /// <summary>
        /// Dirección de recogida del vehículo
        /// </summary>
        /// <example>Carrera 27 #35-04 Edificio de testing</example>
        [Required]
        public string? PickUpAddress { get; set; }
        /// <summary>
        /// Dirección de retorno del vehículo
        /// </summary>
        /// <example>Carrera 5 #05-01 Edificio de cúcuta</example>
        [Required]
        public string? ReturnAddress { get; set; }
        /// <summary>
        /// Tarifa a pagar si la sucursal de entrega difiere de la inicial, retornada por la consulta de vehículos
        /// </summary>
        /// <example>10</example>
        [Required]
        public int ReturnTax { get; set; }
    }
}
